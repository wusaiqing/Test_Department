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
    ##��ȡǰ��10���ַ����ж�
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
            print "�ҵ���"
            print "i��ֵ1111��",i
            break

    t=sure_text(Line_value)

    #��������ָ����λ��
    #if bool(Line_value.find("input")+1)==True or bool(Line_value.find("<a")+1)==True :
    if t==True:
        Line_value=linecache.getline(r"tips.txt",i).decode('gbk').encode('utf-8')
        print "���ֵ�λ�ã���",i,"��"
        print "�ҵ���ֵ��",Line_value

    else:
    #�����ң�
        if up_of_down=="down":
            #<td>�����
            print "i��ֵ:",i
            for j in range(i,count+1):
                if t==False:
                #if bool(Line_value.find("input")+1)!=True or bool(Line_value.find("<a")+1)!=True :
                    Line_value=linecache.getline(r"tips.txt",j).decode('gbk').encode('utf-8')
                    t=sure_text(Line_value)
                else:
                    break
            print "�����ң����ֵ�λ�ã���",j-1,"��"
            print "�����ң��ҵ���ֵ��",Line_value

        #�����ң�
        elif up_of_down=="up":
            #<td>�����
            print "i��ֵ:",i
            for j in range(i,0,-1):
                if t==False:
                    Line_value=linecache.getline(r"tips.txt",j).decode('gbk','ignore').encode('utf-8')
                    t=sure_text(Line_value)
                else :
                    break
            print "�����ң����ֵ�λ�ã���",j+1,"��"
            print "�����ң��ҵ���ֵ��",Line_value
    return  Line_value
file_object.close()


def find_way_tips(message):
    message_begin_text=message[:10]
    if """bool(message_begin_text.find("<a")+1)==True or
    bool(message_begin_text.find("<strong>")+1)==True""":
        #�� > Ϊ�ָ�����,�ҵ����ǣ������ı�
        ##������Ҫ�Ż���
        message_value2=message.split(">")
        message_count2=message.count(">")
        me_value2=message_value2[1].split("<")
        me_count2=message_value2[1].count("<")
        print "�������Ԫ�ط�ʽ:find_element_by_link_text  "+"ҳ������ֵ��"+me_value2[0]

    elif """bool(message_begin_text.find("<input")+1)==True or
            bool(message_begin_text.find("<span")+1)==True or
            bool(message_begin_text.find("<img")+1)==True """:
                     #�Կո�Ϊ�ָ�����
                    message_value=message.split(" ")
                    message_count=message.count(" ")
                    for i in range(message_count+1):
                        me_value=message_value[i].split("\"")
                        me_count=message_value[i].count("\"")
                        for j in range(me_count+1):
                            #print "j,me_value[j]��ֵ��",j,me_value[j]
                            if bool(me_value[j].find("id=")+1)==True:
                                print "�������Ԫ�ط�ʽ:find_element_by_id "+"ҳ������ֵ��"+me_value[j+1]
                                break
    elif bool(message_begin_text.find("<select")+1)==True:
        message_value3=message.split(" ")
        message_count3=message.count(" ")
        for i in range(message_count3+1):
            me_value3=message_value3[i].split("\"")
            me_count3=message_value3[i].count("\"")
            for j in range(me_count3+1):
                if bool(me_value3[j].find("class=")+1)==True:
                    print "�������Ԫ�ط�ʽ:find_elements_by_class_name "+"ҳ������ֵ��"+me_value3[j+1]
                    break
    else:
        print "find_way_tips ��Ҫ�Ż�����Щ�Ƿ�<a,<"

        #<strong>��������ͳ��</strong>





if __name__=='__main__':
    ##����Ҫ�ҵ�ֵ
    message_value="kdsjhdjdh"


    ##�����ǳ����Լ�����
    print "�����ҵ�λ�ã�==============================="
    t=RowReturn(message_value,"down")
    find_way_tips(t)
    print "\n"
    print "�����ҵ�λ�ã�==============================="
    t=RowReturn(message_value,"up")
    find_way_tips(t)

