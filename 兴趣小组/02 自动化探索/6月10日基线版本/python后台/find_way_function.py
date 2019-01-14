# -*- coding: cp936 -*-
import writelog
import sys
import mysql_conect
import time
from find_elements import elements
from  find_element import element
reload(sys)
sys.setdefaultencoding('cp936')
log=writelog.WrLog()
logerr=writelog.LOG("执行用例的模块:find_way.py")

class find_element():
    def __init__(self,driver,sysname,test_id,element_name,function_name,steps_check_name,steps_check_col_value):
        self.driver=driver
        self.sysname=sysname
        self.test_id=test_id
        self.element_name=element_name
        self.function_name=function_name
        sql_count="select  count(0)  from iframe where sysname in (select sysname  from total_config) and sysname='"+self.sysname+"'"
        iframe_c=mysql_conect.sql_value(sql_count)
        self.iframe_count=iframe_c.sql_query_count()
        sql="select  *  from iframe where sysname in (select sysname  from total_config)  and sysname='"+self.sysname+"'"
        iframe=mysql_conect.sql_value(sql)
        self.iframe_value=iframe.sql_query("iframe_name")
        self.steps_check_name=steps_check_name
        self.steps_check_col_value=steps_check_col_value

    def find_element_way(self,way,message,value):
        index=True
        index2=True
        for iframe_id in range (0,self.iframe_count+3):
            self.driver.implicitly_wait(2)
            if index==True :
                try:
                    message_id=message[-4:]
                    if bool (message_id.find("[")+1)==True and bool(message_id.find("]"))==True and way!="by_xpath":
                        a=elements(self.driver).find_elements(way,message,value,message_id)
                        return a
                    else:
                        a=element(self.driver).find(way,message,value)
                        return a
                    index=False
                except:
                    #得到iframe的名称：
                    self.driver.switch_to_default_content()
                    if index2==False:
                        iframe_value2=str(self.iframe_value[iframe_id-1][0])
                        if iframe_value2!='0':
                            message_v=iframe_value2.split("->")
                            me_count=iframe_value2.count("->")
                            for i in range(me_count+1):
                                self.driver.switch_to_frame(message_v[i].strip())
                        if self.element_name!="步骤组":
                            str_Message="被测系统："+self.sysname+", 功能点："+self.function_name+", 用例："+self.test_id+"，步骤名："+self.element_name+" 值："+value+" 正在try iframe:"+iframe_value2
                        else:
                            str_Message="被测系统："+self.sysname+", 功能点："+self.function_name+", 用例："+self.test_id+"，步骤组名："+self.steps_check_name+" ,步骤组中步骤："+self.steps_check_col_value+" 值："+value+" 正在try iframe:"+iframe_value2
                        print str_Message
                        log.wrlog(str_Message)
                        if iframe_id==self.iframe_count+2:
                            if self.element_name!="步骤组":
                                str_Message2="被测系统："+self.sysname+", 功能点："+self.function_name+", 用例："+self.test_id +" 出错了"+"！ 步骤名："+self.element_name+"，值："+value
                            else:
                                str_Message2="被测系统："+self.sysname+", 功能点："+self.function_name+", 用例："+self.test_id +" 出错了"+"！ 步骤组名："+self.steps_check_name +" ,步骤组中步骤："+self.steps_check_col_value+"，值："+value
                            log.wrlog(str_Message2)
                            logerr.error()
                    index2=False
                    index=True
        sql_time="select waittime from total_config where sysname='"+self.sysname+"'"
        wait_t=mysql_conect.sql_value(sql_time)
        wait_time=wait_t.sql_query("waittime")
        self.driver.implicitly_wait(wait_time[0][0])
