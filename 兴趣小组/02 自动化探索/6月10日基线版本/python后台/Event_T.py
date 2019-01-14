# -*- coding: cp936 -*-
from selenium.webdriver import ActionChains
import sys
import mysql_conect
import time
import writelog
import find_way_function


reload(sys)
sys.setdefaultencoding('cp936')
log=writelog.WrLog()
class _Event_():
    def __init__(self,driver,sysname,function_name,find_way,test_id,element_name,page_class,page_value,col_value,and_or,steps_check_name,steps_check_col_value):
        self.driver=driver
        self.sysname=sysname
        self.function_name=function_name
        self.find_way=find_way
        self.page_value=page_value
        self.test_id=test_id
        self.element_name=element_name
        self.page_class=page_class
        self.col_value=col_value
        self.and_or=and_or
        self.steps_check_name=steps_check_name
        self.steps_check_col_value=steps_check_col_value
    def use_event(self):
        t=_Event_(driver=self.driver,sysname=self.sysname,function_name=self.function_name,find_way=self.find_way,test_id=self.test_id,element_name=self.element_name,page_class=self.page_class,page_value=self.page_value,col_value=self.col_value,and_or=self.and_or,steps_check_name=self.steps_check_name,steps_check_col_value=self.steps_check_col_value)
        if self.page_class=="输入框":
            t.text_input()
        elif self.page_class=="按钮":
            t.click()
        elif self.page_class=="单选框"or self.page_class=="复选框":
            t.click()
        #elif self.page_class=="复选框":
            #t.checkbox()
        elif self.page_class=="下拉框":
            t.selectbox()
        elif self.page_class=="双击":
            t.double_click()
        elif self.page_class=="刷新":
            self.driver.refresh()
        elif self.page_class=='等待时间':
            time.sleep(int(self.col_value))
        elif self.page_class=='iframe':
            t.iframe()
        elif self.page_class=='文本框':
            Run_Result=find_way_function.find_element(self.driver,self.sysname,self.test_id,self.element_name,self.function_name,self.steps_check_name,self.steps_check_col_value).find_element_way(self.find_way,self.page_value,"检查点")
            sql_run_result_y="select run_result from test_case   where test_id='"+self.test_id+"' and (sysname like '%"+self.sysname+"%' or sysname='all_system')"
            run_result_y=mysql_conect.sql_value(sql_run_result_y)
            run_result_y_value=run_result_y.sql_query("run_result")
            if str(run_result_y_value[0][0])!="" and str(run_result_y_value[0][0])!='None' and self.and_or=='and':
                Run_Result=str(run_result_y_value[0][0])+" and "+str(Run_Result)
            elif str(run_result_y_value[0][0])!="" and str(run_result_y_value[0][0])!='None' and self.and_or=='or':
                Run_Result=str(run_result_y_value[0][0])+" or "+str(Run_Result)
            sql_run_result="update test_case set run_result='"+str(Run_Result)+"' where test_id='"+self.test_id+"' and ( sysname like '%"+self.sysname+"%'or sysname='all_system')"
            run_result=mysql_conect.sql_value(sql_run_result)
            run_result.sql_update()

    def click(self):
        if str(self.col_value).lower()=="click":
            find_way_function.find_element(self.driver,self.sysname,self.test_id,self.element_name,self.function_name,self.steps_check_name,self.steps_check_col_value).find_element_way(self.find_way,self.page_value,self.col_value)
            try:
                time.sleep(1)
                Ie_trips=self.driver.switch_to_alert()
                sql_y="select comments  from test_case where test_id='"+self.test_id+"' and (sysname like '%"+self.sysname+"%'or sysname='all_system')"
                sql_y_v=mysql_conect.sql_value(sql_y)
                sql_y_value=sql_y_v.sql_query("comments")
                if (str(sql_y_value[0][0])!="" and str(sql_y_value[0][0])!="None"):
                    sql="update test_case set comments='"+sql_y_value[0][0]+"；"+Ie_trips.text.strip()+"' where test_id='"+self.test_id+"' and (sysname like '%"+self.sysname+"%' or sysname='all_system')"
                else:
                    sql="update test_case set comments='"+Ie_trips.text.strip()+"' where test_id='"+self.test_id+"' and (sysname like '%"+self.sysname+"%' or sysname='all_system')"
                sql_update=mysql_conect.sql_value(sql)
                sql_update.sql_update()
                Ie_trips.accept()
            except:
                pass
        elif  str(self.col_value).lower()=="link":
            currenthandle = self.driver.current_window_handle
            find_way_function.find_element(self.driver,self.sysname,self.test_id,self.element_name,self.function_name,self.steps_check_name,self.steps_check_col_value).find_element_way(self.find_way,self.page_value,self.col_value)
            for handle in self.driver.window_handles:
                if currenthandle!=handle:
                    self.driver.switch_to_window(handle)
                else:
                    self.driver.switch_to_window(currenthandle)
        elif str(self.col_value).lower()=="return":
            JJ="setTimeout(function(){"+self.page_value+"},100)"
            self.driver.execute_script(JJ)
            time.sleep(1)
            self.driver.switch_to_window(self.driver.window_handles[-1])
        else:
            message_str="被测系统名称："+self.sysname+", 功能点名称："+self.function_name+", 元素名称："+self.element_name+" 是按钮，值不能为:"+self.col_value+",按钮只能填写：click、link、return"
            print message_str
            log.wrlog(message_str)

    def double_click(self):
        self.col_value=self.col_value
        if  str(self.col_value)!="":
            self.col_value2="double_click";
            aa=find_way_function.find_element(self.driver,self.sysname,self.test_id,self.element_name,self.function_name,self.steps_check_name,self.steps_check_col_value).find_element_way(self.find_way,self.page_value,self.col_value2);
            action_chains = ActionChains(self.driver)
            action_chains.double_click(aa)
            action_chains.perform()
            if str(self.col_value).lower()=="link":
                currenthandle = self.driver.current_window_handle
                for handle in self.driver.window_handles:
                    if currenthandle!=handle:
                        self.driver.switch_to_window(handle)
                    else:
                        self.driver.switch_to_window(currenthandle)

    def text_input(self):
        if self.col_value!="None":
            find_way_function.find_element(self.driver,self.sysname,self.test_id,self.element_name,self.function_name,self.steps_check_name,self.steps_check_col_value).find_element_way(self.find_way,self.page_value,self.col_value)

    #def checkbox(self):
     #   find_way_function.find_element(self.driver,self.sysname,self.test_id,self.element_name,self.function_name,self.steps_check_name,self.steps_check_col_value).find_element_way(self.find_way,self.col_value,"checkbox")

    def selectbox(self):
        self.col_value=self.col_value+'#selectbox'
        find_way_function.find_element(self.driver,self.sysname,self.test_id,self.element_name,self.function_name,self.steps_check_name,self.steps_check_col_value).find_element_way(self.find_way,self.page_value,self.col_value)

    def iframe(self):
        if self.col_value!="None":
            self.driver.switch_to_default_content()
            col_value_v=self.col_value.split("->")
            me_count=self.col_value.count("->")
            for i in range(me_count+1):
                self.driver.switch_to_frame(col_value_v[i].strip())
