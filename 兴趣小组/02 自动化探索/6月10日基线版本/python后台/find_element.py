# -*- coding: cp936 -*-
from selenium import webdriver
import sys
import time
reload(sys)
sys.setdefaultencoding('cp936')

class element:
    def __init__(self,driver):
        self.driver=driver
    def find(self,way,message,value):
        if way=="by_xpath":
            if value=="检查点":
                check_value=self.driver.find_element_by_xpath(message).text
                return check_value
            #按钮、选择框，链接
            elif value=="click" or value=="link" or value=="checkbox":
                self.driver.find_element_by_xpath(message).click()
            #双击事件
            elif value=="double_click":
                dbclick=self.driver.find_element_by_xpath(message)
                return dbclick
            elif bool (value.find("#selectbox")+1)==True:
                select=self.driver.find_element_by_xpath(message)
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
                self.driver.find_element_by_xpath(message).clear()
                time.sleep(0.5)
                self.driver.find_element_by_xpath(message).send_keys(value)
        elif way=="by_link_text":
            self.driver.find_element_by_link_text(message).click()
        elif way=="by_id":
            #检查点:
            if value=="检查点":
                check_value=self.driver.find_element_by_id(message).text
                return check_value
            #按钮 #复选框
            elif value=="click" or value=="link" or value=="checkbox":
                self.driver.find_element_by_id(message).click()
            #双击事件
            elif value=="double_click":
                dbclick=self.driver.find_element_by_id(message)
                return dbclick
            #下拉框
            elif bool (value.find("#selectbox")+1)==True:
                select=self.driver.find_element_by_id(message)
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
                self.driver.find_element_by_id(message).clear()
                time.sleep(0.5)
                self.driver.find_element_by_id(message).send_keys(value)
        elif way=="by_class_name":
            if value=="检查点":
                check_value=self.driver.find_element_by_class_name(message).text
                return check_value
            elif value=="click" or value=="link" or value=="checkbox":
                self.driver.find_element_by_class_name(message).click()
            #双击事件
            elif value=="double_click":
                dbclick=self.driver.find_element_by_class_name(message)
                return dbclick
            elif bool (value.find("#selectbox")+1)==True:
                select=self.driver.find_element_by_class_name(message)
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
                self.driver.find_element_by_class_name(message).clear()
                time.sleep(0.5)
                self.driver.find_element_by_class_name(message).send_keys(value)
        elif way=="by_name":
            if value=="检查点":
                check_value=self.driver.find_element_by_name(message).text
                return check_value
            elif value=="click" or value=="link" or value=="checkbox":
                self.driver.find_element_by_name(message).click()
            #双击事件
            elif value=="double_click":
                dbclick=self.driver.find_element_by_name(message)
                return dbclick
            elif bool (value.find("#selectbox")+1)==True:
                select=self.driver.find_element_by_name(message)
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
                self.driver.find_element_by_name(message).clear()
                time.sleep(0.5)
                self.driver.find_element_by_name(message).send_keys(value)
