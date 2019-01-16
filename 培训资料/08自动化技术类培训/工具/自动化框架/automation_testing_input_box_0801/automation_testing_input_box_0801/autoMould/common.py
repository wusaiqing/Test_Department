#coding:utf-8
import sys, os, re, time, datetime
import HTMLParser
from ZAF import ZAF

class Common():
    def __init__(self):
        self.zaf = ZAF()
        self.excel_mould_path = self.get_path() + "/auto_test_mould_3.xls"
        self.report_file = self.get_path() + "/report/input_box_report"+datetime.datetime.now().strftime('%Y%m%d%H%M%S')+'.xls'

    def get_path(self):
        pwd = sys.path[0]
        package_path = os.path.abspath(os.path.join(pwd, os.pardir))
        return package_path

    def login(self, login_url ,username, password):
        my = MyParser()
        html = self.zaf.send_request(login_url,{}, '', '')
        my.feed(html)
        print my.username_id, my.password_id
        self.zaf.open_browser(login_url, 'ie')
        self.username_locator = "id=%s"%my.username_id
        self.password_locator = "id=%s"%my.password_id
        self.zaf.input_text(self.username_locator, username)
        self.zaf.input_text(self.password_locator, password)
        time.sleep(2)
        self.zaf.send("{Enter}")
        #self.selenium.go_to("http://www.baidu.com")

    def goto_login_page(self, login_url):
        self.zaf.open_browser(login_url, "ie")

    def goto_testing_page(self, login_url, username, password, url, module):
        if module != u'登录':
            self.login(login_url, username, password)
            time.sleep(3)
            self.zaf.go_to(url)

        else:
            self.goto_login_page(login_url)

    def input_box_verification(self, locator_method, locator_label, value, err_locator, verify_value):
        locator = locator_method%locator_label
        try:
            self.zaf.input_text(locator, value)
        except Exception, e:
            print e
            return "Fail"
        if verify_value != '':
            try:
                self.zaf.check_element_contain(err_locator, verify_value)
                return "Pass"
            except Exception, e:
                print e
                return "Fail"
        else:
            try:
                self.zaf.check_page_not_contain_element(err_locator)
                return "Pass"
            except Exception, e:
                print e
                return "Fail"

class MyParser(HTMLParser.HTMLParser):
    def __init__(self):
        HTMLParser.HTMLParser.__init__(self)
        self.username_id = ''
        self.password_id = ''

    def convert_value(self, data):
        data_lower = data.lower()
        data_result = re.sub('_', '', data_lower)
        return data_result

    def handle_starttag(self, tag, attrs):
        username_may_list = ['username', 'loginname']
        password_may_list = ['password']
        #这里重新定义了处理开始标签的函数
        if tag == 'input':
        #判断标签<input>的属性
            for key,value in attrs:
                if key == 'id':
                    value1 = self.convert_value(value)
                    for i in username_may_list:
                            if i in value1:
                                self.username_id = value
                    for j in password_may_list:
                        if j in value1:
                            self.password_id = value
        return  self.username_id, self.password_id
