# -*- coding: utf-8 -*-
from selenium import webdriver
from selenium.selenium import  selenium
import sys
import  time
import socket

reload(sys)
sys.setdefaultencoding('utf-8')

driver=webdriver.Chrome()#启动谷歌浏览器
driver.get("http://192.168.102.213:8088/mi")

driver.implicitly_wait(10)
driver.find_element_by_id("txtAccount").send_keys("csy")
driver.find_element_by_id("txtPassword").send_keys("Csy123")
driver.find_element_by_id("ibtnLogin").click()
driver.find_element_by_link_text("● 已发布的竞赛").click()
driver.switch_to_default_content()
driver.switch_to_frame("ContentFrame")
currenthandle = driver.current_window_handle
driver.find_element_by_xpath("//a[@title='进入竞赛']").click()

driver.switch_to_default_content()

print "curr_handle=",currenthandle
for handle in driver.window_handles:
    print "handle=",handle
    if currenthandle!=handle:
        driver.switch_to_window(handle)

driver.find_element_by_id("TraderByMatch1_txt_LoginName").send_keys("aaa")
'''
str="	VE竞赛管理系统-管理端".decode('utf-8')
print str
driver.switch_to_window()
driver.find_element_by_id("ctl00_MainContentPlaceHolder_NoticeManage1_txtNoticeTitle").send_keys("aaadw")
'''