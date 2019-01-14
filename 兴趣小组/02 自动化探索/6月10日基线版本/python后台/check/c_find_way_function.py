# -*- coding: cp936 -*-
import sys
import c_mysql_conect
reload(sys)
sys.setdefaultencoding('cp936')

class find_element:
    def __init__(self,driver,sysname):
        self.driver=driver
        self.sysname=sysname
        sql_count="select  count(0)  from iframe where sysname in (select sysname  from total_config) and sysname='"+self.sysname+"'"
        iframe_c=c_mysql_conect.sql_value(sql_count)
        self.iframe_count=iframe_c.sql_query_count()

        sql="select  *  from iframe where sysname in (select sysname  from total_config)  and sysname='"+self.sysname+"'"
        iframe=c_mysql_conect.sql_value(sql)
        self.iframe_value=iframe.sql_query("iframe_name")

    def find_element_way(self,page_id,way,message,page_class):
        if page_class!="iframe":
            index=True
            index2=True
            for iframe_id in range (0,self.iframe_count+3):
                if index==True :
                    message_id=message[-4:]
                    find_result=""
                    if bool (message_id.find("[")+1)==True and bool(message_id.find("]"))==True and way!="by_xpath":
                        find_result=find_element(driver=self.driver,sysname=self.sysname).elements(way,message,message_id)
                    else:
                        find_result=find_element(driver=self.driver,sysname=self.sysname).element(way,message)
                    sql_update="update page_properties set check_find='"+find_result+"' where id ='"+page_id+"'"
                    check_result_comment=c_mysql_conect.sql_value(sql_update)
                    check_result_comment.sql_update()
                    if find_result=='found':
                        break
                    else:
                        #得到iframe的名称：
                        self.driver.switch_to_default_content()
                        if index2==False:
                            iframe_value2=str(self.iframe_value[iframe_id-1][0])
                            if iframe_value2!='0':
                                message_v=iframe_value2.split("->")
                                me_count=iframe_value2.count("->")
                                for i in range(me_count+1):
                                    self.driver.switch_to_frame(message_v[i].strip())
                        index2=False
                        index=True

    def element(self,way,message):
        if way=="by_xpath":
            try:
                aa=self.driver.find_element_by_xpath(message)
                find_result='found'
            except:
                find_result='not_found'

        elif way=="by_link_text":
            try:
                aa=self.driver.find_element_by_link_text(message)
                find_result='found'
            except:
                find_result='not_found'

        elif way=="by_id":
            try:
                aa=self.driver.find_element_by_id(message)
                find_result='found'
            except:
                find_result='not_found'

        elif way=="by_class_name":
            try:
                aa=self.driver.find_element_by_class_name(message)
                find_result='found'
            except:
                find_result='not_found'
        elif way=="by_name":
            try:
                aa=self.driver.find_element_by_name(message)
                find_result='found'
            except:
                find_result='not_found'
        return find_result

    def elements(self,way,message,message_id):
        #把abc[1]和abc[10]区分开来
        if message_id[0]=="[":
            message=message[:-4]
            message_id=message_id[1:-1]
        else:
            message=message[:-3]
            message_id=message_id[2:-1]
        message_id=int(message_id)
        if way=="by_xpath":
            try:
                aa=self.driver.find_elements_by_xpath(message)[message_id]
                find_result='found'
            except:
                find_result='not_found'

        elif way=="by_link_text":
            try:
                aa=self.driver.find_elements_by_link_text(message)[message_id]
                find_result='found'
            except:
                find_result='not_found'

        elif way=="by_id":
            try:
                aa=self.driver.find_elements_by_id(message)[message_id]
                find_result='found'
            except:
                find_result='not_found'

        elif way=="by_class_name":
            try:
                aa=self.driver.find_elements_by_class_name(message)[message_id]
                find_result='found'
            except:
                find_result='not_found'
        elif way=="by_name":
            try:
                aa=self.driver.find_elements_by_name(message)[message_id]
                find_result='found'
            except:
                find_result='not_found'

        return find_result