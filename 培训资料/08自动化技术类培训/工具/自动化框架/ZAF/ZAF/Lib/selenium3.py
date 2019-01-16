#encoding: utf-8
from Selenium2Library import Selenium2Library
import time

class Selenium3():
    def __init__(self,
                 timeout=5.0,
                 implicit_wait=0.0,
                 run_on_failure='Capture Page Screenshot',
                 screenshot_root_directory=None, speed=1):
        self.selenium = Selenium2Library(timeout, implicit_wait, run_on_failure, screenshot_root_directory)
        self.speed = speed

    def open_browser(self, url, browser='firefox', alias=None,remote_url=False,
                desired_capabilities=None, ff_profile_dir=None):
        self.selenium.open_browser(url, browser, alias,remote_url,desired_capabilities,ff_profile_dir)
        self.maximize_browser_window()

    def check_page_load_completed(self):
        page_state = self.execute_javascript("return document.readyState")
        for i in range(0,10):
            if page_state != 'complete':
                self.set_selenium_implicit_wait(1)

    def close_browser(self):
        #self.capture_page_screenshot()
        self.selenium.close_browser()

    def close_all_browsers(self):
        self.selenium.close_all_browsers()

    def switch_browser(self, index_or_alias):
        self.selenium.switch_browser(index_or_alias)

    def go_to(self, url):
        self.selenium.go_to(url)

    def get_cookies(self):
        self.selenium.get_cookies()

    def add_cookies(self):
        self.selenium.add_cookie()

    def input_text(self, locator, text):
        #time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        self.selenium.input_text(locator, text)

    def input_password(self, locator, text):
        self.selenium.input_password(locator, text)

    def click_element(self, locator):
        time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        self.selenium.click_element(locator)

    def double_click_element(self, locator):
        time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        self.selenium.double_click_element(locator)

    def select_from_list_by_index(self, locator, *indexes):
        self.selenium.select_from_list_by_index(locator, *indexes)

    def select_from_list_by_label(self, locator, *indexes):
        self.selenium.select_from_list_by_label(locator, *indexes)

    def select_from_list_by_value(self, locator, *indexes):
        self.selenium.select_from_list_by_value(locator, *indexes)

    def select_checkbox(self, locator):
        self.select_checkbox(locator)

    def select_radio_button(self, group_name, value):
        self.selenium.select_radio_button(group_name, value)

    def maximize_browser_window(self):
        self.selenium.maximize_browser_window()

    def choose_file(self, locator, file_path):
        self.selenium.choose_file(locator, file_path)

    def set_element_attr(self, locator, attr, value):
        locator = locator.replace('jquery=', '')
        self.execute_javascript('document.querySelector("%s").%s="%s"' % (locator, attr, value))

    def set_css_value(self, locator, attr, value):
        locator = locator.replace('jquery=', '')
        self.execute_javascript('document.querySelector("%s").style.%s="%s"' % (locator, attr, value))

    def wait_for(self, locator, timeout=5):
        self.selenium.wait_until_page_contains_element(locator, timeout)

    def select_frame(self, myLocator):
        self.selenium.select_frame(locator=myLocator)

    def unselect_frame(self):
        self.selenium.unselect_frame()

    def refreash(self):
        self.selenium.reload_page()

    def get_text(self, locator):
        time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        print locator
        return self.selenium.get_text(locator)

    def get_value(self, locator):
        time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        return self.selenium.get_value(locator)

    def get_selected_list_label(self, locator):
        return self.selenium.get_selected_list_label(locator)

    def get_selected_list_value(self, locator):
        return self.selenium.get_selected_list_value(locator)

    def get_list_items(self, locator):
        return self.selenium.get_list_items(locator)

    def get_source(self):
        return self.selenium.get_source()

    def execute_javascript(self, code):
        print code
        return self.selenium.execute_javascript(code)

    def get_window_titles(self):
        return self.selenium.get_window_titles()

    def get_element_attr(self, locator, attribute):
        time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        return self.selenium.get_element_attribute('%s@%s' % (locator,attribute))

    def get_css_value(self, locator, attribute):
        #self.wait_until_page_contains_element(locator)
        #time.sleep(1)
        #locator = locator.replace('jquery=', '')
        js = 'return document.querySelector("%s").style.%s' % (locator, attribute)
        return self.execute_javascript(js)

    def get_web_elements(self, locator):
        time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        return self.selenium.get_webelements(locator)

    def get_table_rows(self, table_locator):
        locator = '%s tbody tr' % table_locator
        return self.selenium.get_webelements(locator)

    def get_url(self):
        return self.selenium.get_location()

    ###检查点方法
    def check_element_text(self, locator, expected, msg=''):
        print self.selenium.get_text(locator)
        self.selenium.element_text_should_be(locator, expected, msg)

    def check_element_contain(self, locator, expected, message=''):
        #self.wait_until_page_contains_element(locator)
        #time.sleep(1)
        self.selenium.get_text(locator)
        self.selenium.element_should_contain(locator, expected, message)

    def check_page_contain_text(self, text, loglevel='INFO'):
        self.selenium.page_should_contain(text, loglevel)

    def check_page_not_contain_text(self, text, loglevel='INFO'):
        self.selenium.page_should_not_contain(text, loglevel)

    def check_page_contain_element(self, locator, message='', loglevel='INFO'):
        time.sleep(0.5)
        self.wait_until_page_contains_element(locator)
        time.sleep(1)
        self.selenium.page_should_contain_element(locator, message, loglevel)

    def check_page_not_contain_element(self, locator, message='', loglevel='INFO'):
        time.sleep(0.5)
        self.wait_until_page_does_not_contain_element(locator)
        time.sleep(1)
        self.selenium.page_should_not_contain_element(locator, message, loglevel)

    def check_radiobox(self, group, value=''):
        if value:
            self.selenium.radio_button_should_be_set_to(group, value)
        else:
            self.selenium.radio_button_should_not_be_selected(group)

    def check_table_header(self, tablelocator, txt):
        u'''表格标题某个字段包含指定内容
        :param tablelocator: 表格定位
        :param txt: 指定内容
        '''
        self.selenium.table_header_should_contain(tablelocator, txt)

    def capture_page_screenshot(self, fn=None):
        u'''
        屏幕界面，RF调用
        :param fn: 图片名称
        :return:
        '''
        if not fn:
            fn =  'capture_%s.jpg' % int(time.time())
        self.selenium.capture_page_screenshot(fn)

    def select_window(self, locater=None):
        return self.selenium.select_window(locater)

    def list_windows(self):
        return self.selenium.list_windows()

    def get_title(self):
        return self.selenium.get_title()

    def set_browser_implicit_wait(self, waitSeconds):
        self.selenium.set_browser_implicit_wait(seconds=waitSeconds)

    def set_selenium_implicit_wait(self, waitSeconds):
        self.selenium.set_selenium_implicit_wait(seconds=waitSeconds)

    def alert_should_be_present(self, getText=''):
        self.selenium.alert_should_be_present(text=getText)

    def choose_cancel_on_next_confirmation(self):
        self.selenium.choose_cancel_on_next_confirmation()

    def choose_ok_on_next_confirmation(self):
        self.selenium.choose_ok_on_next_confirmation()

    def dismiss_alert(self, isAccept=True):
        return self.selenium.dismiss_alert(accept=isAccept)

    def dismiss_alert_cancel(self, isAccept=False):
        return self.selenium.dismiss_alert(accept=isAccept)

    def get_alert_message(self, isDismiss=True):
        return self.selenium.get_alert_message(dismiss=isDismiss)

    def close_window(self):
        self.selenium.close_window()

    def mouse_over(self, locator):
        self.selenium.mouse_over(locator)

    def press_key(self, locator, key):
        self.selenium.press_key(locator, key)

    def confirm_action(self):
        self.selenium.confirm_action()

    def wait_for_condition(self, condition, timeout= None, error=None):
        self.selenium.wait_for_condition(condition, timeout, error)

    def wait_until_page_contains(self, text, timeout= '10 seconds', error=None):
        self.selenium.wait_until_element_contains(text, timeout, error)

    def wait_until_page_does_not_contain(self, text, timeout= '10 seconds', error=None):
        self.selenium.wait_until_element_does_not_contain(text, timeout, error)

    def wait_until_page_contains_element(self, locator, timeout= '10 seconds', error=None):
        self.selenium.wait_until_page_contains_element(locator, timeout, error)

    def wait_until_page_does_not_contain_element(self, locator, timeout= '10 seconds', error=None):
        self.selenium.wait_until_page_does_not_contain_element(locator, timeout, error)

    def wait_until_element_contains(self, locator, text, timeout= '10 seconds', error=None):
        self.selenium.wait_until_element_contains(locator, timeout, error)

    def go_back(self):
        self.selenium.go_back()

    def get_elements_num(self, locator):
        element_list = self.get_web_elements(locator)
        i=0
        for element in element_list:
            i=i+1
        return i

    def get_cookies(self):
        return self.selenium.get_cookies()

    def set_element_writeable(self,locator):
        locator = locator.replace("css=", "")
        self.execute_javascript('document.querySelector("%s").removeAttribute("readOnly")'%locator)

    def get_window_identifies(self):
        return self.selenium.get_window_identifiers()

if __name__=='__main__':
    a = Selenium3()
    a.open_browser('http://www.baidu.com', 'chrome360')
    a.input_text('css=#kw', 'seleniumHq')
    a.close_browser()
