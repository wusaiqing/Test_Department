#encoding: utf-8
from ZAF.Lib.Page import Page as BasePage
from Page import Page

u'''该目录为【数字化教学平台-登录】的基础场景函数库'''

class Login(BasePage, Page):
    def __init__(self):
        BasePage.__init__(self)
        Page.__init__(self, self.zaf)


