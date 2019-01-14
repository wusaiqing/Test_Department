# -*- coding: cp936 -*-
from selenium import webdriver
import c_mysql_conect
import c_find_way_function
import sys

reload(sys)
sys.setdefaultencoding('cp936')
sysname=raw_input("被测系统名称:")

##total_config表的数据
sql_total="select * from total_config where sysname like '%"+sysname.strip()+"%'"
total_config=c_mysql_conect.sql_value(sql_total)
mysql_total_config=total_config.sql_query("url","browser")
url=mysql_total_config[0][0]
total_browser=mysql_total_config[0][1]

if total_browser=="Chrome":
    driver=webdriver.Chrome()
elif total_browser=="FireFox":
    driver=webdriver.Firefox()
else:
    driver=webdriver.Ie()
driver.get(url)
for j in range(100):
    sql_page_c="select count(0) from page_properties where check_find='y' or check_find='not_found'"
    page_c=c_mysql_conect.sql_value(sql_page_c)
    page_count=page_c.sql_query_count()
    check_yes_or_no=raw_input("输入：Y/y:检测；其他(或回车)：不检测退出程序：")
    if check_yes_or_no.lower()=='y':
        for i in range (page_count):
            sql_page="select * from page_properties where check_find='y' or check_find='not_found'"
            sql_page_v=c_mysql_conect.sql_value(sql_page)
            page_v=sql_page_v.sql_query("id","find_way","page_value","page_class")
            page_id=str(page_v[i][0])
            find_way=page_v[i][1]
            page_value=page_v[i][2]
            page_class=page_v[i][3]
            c_find_way_function.find_element(driver,sysname).find_element_way(page_id,find_way,page_value,page_class)
    else:
        break
driver.quit()
