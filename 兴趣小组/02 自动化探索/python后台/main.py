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
sysname=raw_input("����ϵͳ����:")

#������
def steps(steps_name):
    steps=sql_class._steps_(steps_name,sysname)
    steps_page_count=steps.steps_count()
    for step_id in range(steps_page_count):
        steps_element_name,steps_page_class,steps_page_value,find_way=sql_class._steps_(steps_name,sysname).steps_value(step_id)
        #������ľ���Ԫ�ص�ֵ��ֻ��һ��
        steps_col_value=sql_class._steps_(steps_name,sysname).step_col_value(step_id)
        #�������е��� ������
        if steps_page_class=='������':
            steps_page_count2=sql_class._steps_(steps_col_value,sysname).steps_count()
            for step_id2 in range(steps_page_count2):
                steps_element_name,steps_page_class,steps_page_value,find_way=sql_class._steps_(steps_col_value,sysname).steps_value(step_id2)
                #������ľ���Ԫ�ص�ֵ��ֻ��һ��
                steps_col_value2=sql_class._steps_(steps_col_value,sysname).step_col_value(step_id2)
                Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,steps_page_class,steps_page_value,steps_col_value2,"",steps_col_value,steps_element_name).use_event()
        else:
            Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,steps_page_class,steps_page_value,steps_col_value,"",steps_name,steps_element_name).use_event()

##total_config�������
total_config_id,total_config_url,total_config_waittime,total_browser=sql_class._total_config_(sysname).total_value()
##config��ļ�¼��
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
    logerr=writelog.LOG("ִ��������ģ��:main.py")
    function_name=sql_class._config_(sysname).config_value(i)
    #ȡ��ִ�в���������
    test_count=sql_class._test_case_(sysname,function_name).test_count()
    for j in range(test_count):
        test_id_value,test_id,result=sql_class._test_case_(sysname,function_name).test_value()
        log.wrlog("ִ����������Ϊ��"+test_id+"������")
        #driver.refresh()
        try:
            ##���Բ��������
            step_count=sql_class._test_page_(sysname,function_name).test_page_count()
            #�ж��Ƿ���������Ƿ����У������Ƿ����˳���ť
            for k in range(step_count):
                ##Ԫ�ص�ֵ��
                element_name,page_class,find_way,page_value=sql_class._test_page_(sysname,function_name).test_page_value(k)
                #result ����NoRun ����û����
                if str(result)=="NoRun"  or bool(element_name.find("�˳�")+1)==True or bool(element_name.find("exit")+1)==True:
                #ȡ��ִ���������У�
                    test_col_value=sql_class._test_case_(sysname,function_name).test_col_value(k,test_id_value)
                    if (str(test_col_value)!=''and str(test_col_value)!='None') or page_class=="ˢ��":
                        try:
                            if page_class=="������" :
                                steps(test_col_value)
                            elif page_class=="ˢ��":
                                driver.refresh()
                            elif page_class=="�ȴ�ʱ��":
                                time.sleep(int(test_col_value))
                            elif page_class=="����" :
                                #������㣺
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
                                            #����ľ���Ԫ�ص�ֵ��ֻ��һ��
                                            check_col_value=check.check_col_value(check_index)
                                            #���������ò�����
                                            if check_page_class=='������':
                                                steps(check_col_value)
                                            else:
                                                Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,check_page_class,check_page_value,check_col_value,and_or,"","").use_event()
                                    except:
                                        logerr.error()
                            else:
                                Event_T._Event_(driver,sysname,function_name.strip(),find_way,test_id,element_name,page_class,page_value,test_col_value,"","","").use_event()
                        except:
                            str_Message="��������������ϵͳ��"+sysname+", ���ܵ㣺"+function_name+", ������"+test_id+"����������"+element_name+"ֵ��"+test_col_value+"  ����"
                            log.wrlog(str_Message)
                            logerr.error()
        except:
            logerr.error()
        comments,run_result=sql_class._test_case_(sysname,function_name).test_run_value(j)
        if comments !='None' and comments!="":
            if run_result !='None' and run_result !="":
                test_result=run_result+"  ��ʾ��"+comments
            else:
                test_result=comments
            sql_class._test_case_(sysname,function_name).update_result_comment(test_id,test_result)
        ##���еĽ��
        comparison.comparison(test_id,function_name.strip(),sysname).result()
    driver.close()
raw_input("�����Ѿ�ִ����ϣ��밴�س����˳�")
driver.quit()
