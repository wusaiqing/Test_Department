# -*- coding: cp936 -*-
from selenium import webdriver
import sys
import time

reload(sys)
sys.setdefaultencoding('cp936')

class elements():
    def __init__(self,driver):
        self.driver=driver
    def find_elements(self,way,message,value,message_id):
        #把abc[1]和abc[10]区分开来
        if message_id[0]=="[":
            message=message[:-4]
            message_id=message_id[1:-1]
        else:
            message=message[:-3]
            message_id=message_id[2:-1]
        message_id=int(message_id)
        if way=="by_id":
            if value=="检查点":
                check_value=self.driver.find_elements_by_id(message)[message_id].text
                return check_value
            #按钮 #复选框
            elif value=="click" or value=="link" or value=="checkbox":
                self.driver.find_elements_by_id(message)[message_id].click()
            #双击事件
            elif value=="double_click":
                dbclick=self.driver.find_elements_by_id(message)[message_id]
                return dbclick
            #下拉框
            elif bool (value.find("#selectbox")+1)==True:
                select=self.driver.find_elements_by_id(message)[message_id]
                value2=value.strip().split("#selectbox")
                if bool(value2[0].find("/")+1)==True:
                    select.click()
                    self.driver.find_element_by_xpath(value2[0]).click()
                elif bool(value2[0].find("^")+1)==True:
                    val=value2[0]
                    value3=val.lstrip("^")
                    select.click()
                    self.driver.find_element_by_link_text(value3).click()
                else:
                    select.find_element_by_xpath("//option[@value='"+value2[0]+"']").click()
            #输入框
            elif  value!="click" and value!="checkbox" and value !="":
                self.driver.find_elements_by_id(message)[message_id].clear()
                time.sleep(0.5)
                self.driver.find_elements_by_id(message)[message_id].send_keys(value)
        elif way=="by_link_text":
            self.driver.find_elements_by_link_text(message)[message_id].click()
        elif way=="by_class_name":
            if value=="检查点":
                check_value=self.driver.find_elements_by_class_name(message)[message_id].text
                return check_value
            elif value=="click" or value=="link" or value=="checkbox":
                self.driver.find_elements_by_class_name(message)[message_id].click()
            #双击事件
            elif value=="double_click":
                dbclick=self.driver.find_elements_by_class_name(message)[message_id]
                return dbclick
            #下拉框
            elif bool (value.find("#selectbox")+1)==True:
                select=self.driver.find_elements_by_class_name(message)[message_id]
                value2=value.strip().split("#selectbox")
                if bool(value2[0].find("/")+1)==True:
                    select.click()
                    self.driver.find_element_by_xpath(value2[0]).click()
                elif bool(value2[0].find("^")+1)==True:
                    val=value2[0]
                    value3=val.lstrip("^")
                    select.click()
                    self.driver.find_element_by_link_text(value3).click()
                else:
                    select.find_element_by_xpath("//option[@value='"+value2[0]+"']").click()
            #输入框
            elif  value!="click" and value!="checkbox" and value !="":
                self.driver.find_elements_by_class_name(message)[message_id].clear()
                time.sleep(0.5)
                self.driver.find_elements_by_class_name(message)[message_id].send_keys(value)
        elif way=="by_name":
            if value=="检查点":
                check_value=self.driver.find_elements_by_name(message)[message_id].text
                return check_value
            elif value=="click" or value=="link" or value=="checkbox":
                self.driver.find_elements_by_name(message)[message_id].click()
            #双击事件
            elif value=="double_click":
                dbclick=self.driver.find_elements_by_name(message)[message_id]
                return dbclick
            elif bool (value.find("#selectbox")+1)==True:
                select=self.driver.find_elements_by_name(message)[message_id]
                value2=value.strip().split("#selectbox")
                if bool(value2[0].find("/")+1)==True:
                    select.click()
                    self.driver.find_element_by_xpath(value2[0]).click()
                elif bool(value2[0].find("^")+1)==True:
                    val=value2[0]
                    value3=val.lstrip("^")
                    select.click()
                    self.driver.find_element_by_link_text(value3).click()
                else:
                    select.find_element_by_xpath("//option[@value='"+value2[0]+"']").click()
            #输入框
            elif  value!="click" and value!="checkbox" and value !="":
                self.driver.find_elements_by_name(message)[message_id].clear()
                time.sleep(0.5)
                self.driver.find_elements_by_name(message)[message_id].send_keys(value)
