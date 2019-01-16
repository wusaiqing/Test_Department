#encoding: utf-8
from ZAF.Project.SZHJX.Conf import *
from ZAF.Project.SZHJX.TestData import *
from ZAF.Project.SZHJX.Login import Login
from TestData import *
import unittest

login = Login()

class TestFunctions(unittest.TestCase):
    def setUp(self):
        #login.open_browser(login_url, browser)
        eval('login.open_browser(login_url, browser)')

    def tearDown(self):
        #login.close_browser()
        eval('login.close_browser()')
        pass

    def test_Login_Pass(self):
        #login.login_batch(users, passwords, login_checks)
        eval('login.login_batch(users, passwords, login_checks)')

    def test_Register(self):
        login.exec_sql_for_szhjx(setup_db_for_reg_user_sql)
        login.register_cancel(reg_user, reg_passwd, reg_repasswd, reg_role2, reg_zz2, reg_cardid, reg_name, reg_contact, reg_email, reg_problem, reg_answer)
        login.register_pass(reg_user, reg_passwd, reg_repasswd, reg_role1, reg_zz1, reg_cardid, reg_name, reg_contact, reg_email, reg_problem, reg_answer, reg_check_txt, check_db_for_reg_user_sql)

if __name__ == '__main__':
    unittest.main()
