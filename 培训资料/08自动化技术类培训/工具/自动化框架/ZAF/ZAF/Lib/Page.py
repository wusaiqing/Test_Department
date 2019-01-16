#encoding: utf-8
from ZAF import ZAF

class Page(object):
    def __init__(self):
        self.zaf = ZAF()

    def open_browser(self, url, browser, remote_url=False):
        u'''
        根据执行url打开浏览器\r\n
        :url: 打开的url\r\n
        :browser: 打开的浏览器类型，可选chrome、ff、ie\r\n
        :remote_url: 指定远程的执行url， 默认为本地执行
        '''
        self.zaf.open_browser(url, browser, remote_url)
        self.zaf.maximize_browser_window()

    def close_browser(self):
        u'''
        关闭浏览器
        '''
        self.zaf.close_browser()

    def wait(self, s):
        u'''
        延时等待时间\r\n
        s: 单位秒
        '''
        self.zaf.wait(s)

    def capture_page_screenshot(self):
        u'''
        屏幕截屏
        '''
        self.zaf.capture_page_screenshot()

    def go_to(self, url):
        u'''
        URL跳转\r\n
        '''
        self.zaf.go_to(url)

    def input_box_verification(self, locator_method, locator_label, value, err_locator, verify_value):
        locator = locator_method%locator_label
        try:
            self.zaf.selenium.input_text(locator, value)
        except Exception, e:
            print e
            return "Fail"
        if verify_value != '':
            try:
                self.zaf.selenium.check_element_contain(err_locator, verify_value)
                return "Pass"
            except Exception, e:
                print e
                return "Fail"
        else:
            try:
                self.zaf.selenium.check_page_not_contain_element(err_locator)
                return "Pass"
            except Exception, e:
                print e
                return "Fail"
