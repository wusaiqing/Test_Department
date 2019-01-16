#encoding: utf-8
from ZAF.Project.SZHJX.Conf import *
from ZAF.Project.SZHJX.TestData import *
from Repository import *

u'''
    该文件内容包含【数字化教学平台】公共页面的所有操作
'''

class Page(object):
    def __init__(self, zaf):
        self.zaf = zaf

    def login(self, username, password, check=None):
        self.zaf.input_text(login_username_txt, username)
        self.zaf.input_text(login_password_txt, password)
        self.zaf.click_element(login_btn)
        self.zaf.wait(2)
        txt = self.zaf.get_text(login_tipinfo)
        if check:
            self.zaf.check_equal(txt, check, u'用户登录检查失败')

    def check_db_for_szhjx(self, sql, n):
        self.zaf.check_db_num(dbtype, dbconn, sql, n)

    def exec_sql_for_szhjx(self, sql):
        self.zaf.sql_execute(dbtype, dbconn, sql)

    def query_sql_for_szhjx(self, sql):
        return self.zaf.sql_query(dbtype, dbconn, sql)

