# -*- coding: cp936 -*-
from selenium import webdriver
from selenium.webdriver import ActionChains
import writelog
import sys
import mysql_conect
import sql_class
import comparison
import  time
import Event_T
import _mssql
import uuid
import find_element

reload(sys)
sys.setdefaultencoding('cp936')
sysname=raw_input("被测系统名称:")

#步骤组
def steps(steps_name):
    steps=sql_class._steps_(steps_name,sysname)
    steps_page_count=steps.steps_count()
    for step_id in range(steps_page_count):
        steps_element_name,steps_page_class,steps_page_value,find_way=sql_class._steps_(steps_name,sysname).steps_value(step_id)
        #步骤组的具体元素的值，只有一行
        steps_col_value=sql_class._steps_(steps_name,sysname).step_col_value(step_id)
        #步骤组中调用 步骤组
        if steps_page_class=='步骤组':
            steps_page_count2=sql_class._steps_(steps_col_value,sysname).steps_count()
            for step_id2 in range(steps_page_count2):
                steps_element_name,steps_page_class,steps_page_value,find_way=sql_class._steps_(steps_col_value,sysname).steps_value(step_id2)
                #步骤组的具体元素的值，只有一行
                steps_col_value2=sql_class._steps_(steps_col_value,sysname).step_col_value(step_id2)
                Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,steps_page_class,steps_page_value,steps_col_value2,"",steps_col_value,steps_element_name).use_event()
        else:
            Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,steps_page_class,steps_page_value,steps_col_value,"",steps_name,steps_element_name).use_event()

##total_config表的数据
total_config_id,total_config_url,total_config_waittime,total_browser=sql_class._total_config_(sysname).total_value()
##config表的记录数
config_count=sql_class._config_(sysname).config_count()
for i in range (config_count):
    if total_browser=="Chrome":
        driver=webdriver.Chrome()
    elif total_browser=="FireFox":
        driver=webdriver.Firefox()
    else:
        driver=webdriver.Ie()
    driver.implicitly_wait(total_config_waittime)
    driver.get(total_config_url)
    log=writelog.WrLog()
    logerr=writelog.LOG("执行用例的模块:main.py")
    function_name=sql_class._config_(sysname).config_value(i)
    #取出执行测试用例数
    test_count=sql_class._test_case_(sysname,function_name).test_count()
    for j in range(test_count):
        test_id_value,test_id,result=sql_class._test_case_(sysname,function_name).test_value()
        log.wrlog("执行用例名称为："+test_id+"的用例")
        #driver.refresh()
        try:
            ##测试步骤的数量
            step_count=sql_class._test_page_(sysname,function_name).test_page_count()
            #判断是否测试用例是否运行，或者是否是退出按钮
            for k in range(step_count):
                ##元素的值：
                element_name,page_class,find_way,page_value=sql_class._test_page_(sysname,function_name).test_page_value(k)
                #result 等于NoRun 代表没有跑
                if str(result)=="NoRun"  or bool(element_name.find("退出")+1)==True or bool(element_name.find("exit")+1)==True:
                #取出执行用例的列：
                    test_col_value=sql_class._test_case_(sysname,function_name).test_col_value(k,test_id_value)
                    if (str(test_col_value)!=''and str(test_col_value)!='None') or page_class=="刷新":
                        try:
                            if page_class=="步骤组" :
                                steps(test_col_value)
                            elif page_class=="刷新":
                                driver.refresh()
                            elif page_class=="等待时间":
                                time.sleep(int(test_col_value))
                            elif page_class=="检查点" :
                                #多个检查点：
                                and_or=""
                                if bool (test_col_value.lower().find("and")+1)==True and  bool (test_col_value.lower().find("or")+1)==False:
                                    test_check_value=test_col_value.strip().lower().split('and')
                                    test_check_count=test_col_value.lower().count('and')
                                    and_or='and'
                                elif bool(test_col_value.lower().find("and")+1)==False and  bool (test_col_value.lower().find("or")+1)==True:
                                    test_check_value=test_col_value.strip().lower().split('or')
                                    test_check_count=test_col_value.lower().count('or')
                                    and_or='or'
                                else:
                                    test_check_count=0
                                    and_or=""
                                for test_check_index in range(test_check_count+1):
                                    if and_or=='and' or and_or=='or':
                                        t_c_value=test_check_value[test_check_index].strip()
                                    else:
                                        t_c_value=test_col_value.strip()
                                    try:
                                        check=sql_class._check_(t_c_value,sysname)
                                        check_count=check.check_count()
                                        for check_index in range(check_count):
                                            check_element_name,check_page_class,check_page_value,find_way=check.check_value(check_index)
                                            #检查点的具体元素的值，只有一行
                                            check_col_value=check.check_col_value(check_index)
                                            #检查点中引用步骤组
                                            if check_page_class=='步骤组':
                                                steps(check_col_value)
                                            else:
                                                Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,check_page_class,check_page_value,check_col_value,and_or,"","").use_event()
                                    except:
                                        logerr.error()
                            else:
                                Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,page_class,page_value,test_col_value,"","","").use_event()
                        except:
                            str_Message="在主函数：被测系统："+sysname+", 功能点："+function_name+", 用例："+test_id+"，步骤名："+element_name+"值："+test_col_value+"  出错"
                            log.wrlog(str_Message)
                            logerr.error()
        except:
            logerr.error()
        comments,run_result=sql_class._test_case_(sysname,function_name).test_run_value(j)
        if comments !='None' and comments!="":
            if run_result !='None' and run_result !="":
                test_result=run_result+"  提示："+comments
            else:
                test_result=comments
            sql_class._test_case_(sysname,function_name).update_result_comment(test_id,test_result)
        ##运行的结果
        comparison.comparison(test_id,function_name.strip(),sysname).result()
    driver.close()
raw_input("程序已经执行完毕，请按回车键退出")
driver.quit()
