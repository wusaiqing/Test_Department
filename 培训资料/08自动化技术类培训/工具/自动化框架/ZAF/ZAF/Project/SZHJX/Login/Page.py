#encoding: utf-8
from ZAF.Project.SZHJX.Conf import *
from ZAF.Project.SZHJX.TestData import *
from ZAF.Project.SZHJX.Common.Page import Page as CommonPage
from Repository import *

u'''
    登录注册相关操作
'''

class Page(CommonPage):
    def __init__(self, zaf):
        self.zaf = zaf
        CommonPage.__init__(self, zaf)

    def login_batch(self, users, passwords, checks):
        for i in range(len(users)):
            self.login(users[i], passwords[i], checks[i])
            self.zaf.click_element(login_logout)

    def login_single(self, user, pwd):
        CommonPage.login(user, pwd, None)

    def register_pass(self, user, passwd, repasswd, role, zz, id, name, contact, email, problem, answer, check_txt, sql):
        self.zaf.wait(2)
        self.__fill_reg(user, passwd, repasswd, role, zz, id, name, contact, email, problem, answer)
        self.zaf.click_element(reg_submit)
        txt = self.zaf.get_text(reg_pass_txt)
        self.zaf.wait(2)
        self.zaf.check_equal(txt, check_txt, u'注册流程检查失败')
        self.check_db_for_szhjx(sql, 1)

    def register_cancel(self, user, passwd, repasswd, role, zz, id, name, contact, email, problem, answer):
        self.zaf.click_element(login_reg_btn)
        self.zaf.wait(2)
        self.__fill_reg(user, passwd, repasswd, role, zz, id, name, contact, email, problem, answer)
        self.zaf.click_element(reg_cancel)
        self.check_reg_cancel()

    def __fill_reg(self, user, passwd, repasswd, role, zz, id, name, contact, email, problem, answer):
        if user:
            self.zaf.input_text(reg_user, user)
        if passwd:
            self.zaf.input_text(reg_passwd, passwd)
        if repasswd:
            self.zaf.input_text(reg_repasswd, repasswd)
        if role:
            self.zaf.select_radio_button(reg_role, role)
        if zz:
            self.__select_zzjg(reg_zz, reg_zz_menu_items, zz)
        if id:
            self.zaf.input_text(reg_cardid, id)
        if name:
            self.zaf.input_text(reg_name, name)
        if contact:
            self.zaf.input_text(reg_contact, contact)
        if email:
            self.zaf.input_text(reg_email, email)
        if problem:
            self.zaf.input_text(reg_problem, problem)
        if answer:
            self.zaf.input_text(reg_answer, answer)

    def __select_zzjg(self, reg_zz, reg_zz_menu_items, zz):
        self.zaf.click_element(reg_zz)
        items = self.zaf.get_web_elements(reg_zz_menu_items)
        for i in items:
            txt = i.text
            # print txt
            if txt == zz:
                i.click()
                break

    def check_reg_cancel(self):
        user = self.zaf.get_text(reg_user)
        self.zaf.check_equal(user, '')
        passwd = self.zaf.get_text(reg_passwd)
        self.zaf.check_equal(passwd, '')
        repasswd = self.zaf.get_text(reg_repasswd)
        self.zaf.check_equal(repasswd, '')
        self.zaf.check_radiobox(reg_role, u'学生')
        zz = self.zaf.get_text(reg_zz)
        self.zaf.check_equal(zz, '')
        cardid = self.zaf.get_text(reg_cardid)
        self.zaf.check_equal(cardid, '')
        name = self.zaf.get_text(reg_name)
        self.zaf.check_equal(name, '')
        contact = self.zaf.get_text(reg_contact)
        self.zaf.check_equal(contact, '')
        email = self.zaf.get_text(reg_email)
        self.zaf.check_equal(email, '')
        problem = self.zaf.get_text(reg_problem)
        self.zaf.check_equal(problem, '')
        answer = self.zaf.get_text(reg_answer)
        self.zaf.check_equal(answer, '')

    def forgot_password(self):
        self.zaf.click_element(login_forgetPassword)
        self.zaf.wait(2)

