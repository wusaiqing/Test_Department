# -*- coding: cp936 -*-
import sys
import fileinput
from glob import glob
import linecache

reload(sys)
sys.setdefaultencoding('cp936')
file_object=open("tips.txt","r")
count=len(file_object.readlines())

def sure_text(Line_value):
    text_value="<span <input <a <select <img <strong>"
    text_value_spilt=text_value.split(" ")
    text_value_count=text_value.count(" ")
    ##读取前面10个字符来判断
    a=False
    Line_value=Line_value[:10]
    for i in range(text_value_count+1):
        if bool(Line_value.find(text_value_spilt[i])+1)==True:
            a=True
            break
    return a




def RowReturn(message,up_of_down):
    for i in range(count):

        Line_value=linecache.getline(r"tips.txt",i).decode('gbk').encode('utf-8')
        if bool(Line_value.find(message)+1)==True:
            print "找到了"
            print "i的值1111：",i
            break

    t=sure_text(Line_value)

    #以下是找指定的位置
    #if bool(Line_value.find("input")+1)==True or bool(Line_value.find("<a")+1)==True :
    if t==True:
        Line_value=linecache.getline(r"tips.txt",i).decode('gbk').encode('utf-8')
        print "出现的位置：第",i,"行"
        print "找到的值：",Line_value

    else:
    #往下找：
        if up_of_down=="down":
            #<td>的情况
            print "i的值:",i
            for j in range(i,count+1):
                if t==False:
                #if bool(Line_value.find("input")+1)!=True or bool(Line_value.find("<a")+1)!=True :
                    Line_value=linecache.getline(r"tips.txt",j).decode('gbk').encode('utf-8')
                    t=sure_text(Line_value)
                else:
                    break
            print "往下找，出现的位置：第",j-1,"行"
            print "往下找，找到的值：",Line_value

        #往上找：
        elif up_of_down=="up":
            #<td>的情况
            print "i的值:",i
            for j in range(i,0,-1):
                if t==False:
                    Line_value=linecache.getline(r"tips.txt",j).decode('gbk','ignore').encode('utf-8')
                    t=sure_text(Line_value)
                else :
                    break
            print "往上找，出现的位置：第",j+1,"行"
            print "往上找，找到的值：",Line_value
    return  Line_value
file_object.close()


def find_way_tips(message):
    message_begin_text=message[:10]
    if """bool(message_begin_text.find("<a")+1)==True or
    bool(message_begin_text.find("<strong>")+1)==True""":
        #以 > 为分隔符号,找到的是：链接文本
        ##这里需要优化的
        message_value2=message.split(">")
        message_count2=message.count(">")
        me_value2=message_value2[1].split("<")
        me_count2=message_value2[1].count("<")
        print "建议查找元素方式:find_element_by_link_text  "+"页面属性值："+me_value2[0]

    elif """bool(message_begin_text.find("<input")+1)==True or
            bool(message_begin_text.find("<span")+1)==True or
            bool(message_begin_text.find("<img")+1)==True """:
                     #以空格为分隔符号
                    message_value=message.split(" ")
                    message_count=message.count(" ")
                    for i in range(message_count+1):
                        me_value=message_value[i].split("\"")
                        me_count=message_value[i].count("\"")
                        for j in range(me_count+1):
                            #print "j,me_value[j]的值：",j,me_value[j]
                            if bool(me_value[j].find("id=")+1)==True:
                                print "建议查找元素方式:find_element_by_id "+"页面属性值："+me_value[j+1]
                                break
    elif bool(message_begin_text.find("<select")+1)==True:
        message_value3=message.split(" ")
        message_count3=message.count(" ")
        for i in range(message_count3+1):
            me_value3=message_value3[i].split("\"")
            me_count3=message_value3[i].count("\"")
            for j in range(me_count3+1):
                if bool(me_value3[j].find("class=")+1)==True:
                    print "建议查找元素方式:find_elements_by_class_name "+"页面属性值："+me_value3[j+1]
                    break
    else:
        print "find_way_tips 需要优化，有些是非<a,<"

        #<strong>在线人数统计</strong>





if __name__=='__main__':
    ##输入要找的值
    message_value="kdsjhdjdh"


    ##以下是程序自己运行
    print "往下找的位置：==============================="
    t=RowReturn(message_value,"down")
    find_way_tips(t)
    print "\n"
    print "往上找的位置：==============================="
    t=RowReturn(message_value,"up")
    find_way_tips(t)

