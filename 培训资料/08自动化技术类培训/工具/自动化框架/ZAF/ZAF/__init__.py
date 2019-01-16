#encoding: utf-8
from Lib.selenium3 import Selenium3
from Lib.db import DB
from Lib.autoit import AutoIt
from Lib.builtin import BuiltIn
from version import VERSION
from Lib.httpApi import SendRequest


__version__ = VERSION

class ZAF(Selenium3, DB, AutoIt, BuiltIn, SendRequest):
    def __init__(self):
        for base in ZAF.__bases__:
            base.__init__(self)

    def check_element_attr(self, locator, attribute, expected):
        ele_attr = self.get_element_attr(locator, attribute)
        self.check_equal(ele_attr, expected)

    def check_css_value(self, locator, attr, expected):
        css_value = self.get_css_value(locator, attr)
        self.check_equal(css_value, expected)

if __name__=='__main__':
    a = ZAF()
    a.open_browser('http://www.baidu.com', 'chrome')
    a.input_text('css=#kw', 'seleniumHq')
    a.wait(2)
    a.close_browser()