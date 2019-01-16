#encoding: utf-8
##================================================
##********************test_Login_Pass********************
##================================================
users = ['teacher', 'teacher']
passwords = ['000000', '000000']
login_checks = [u'您好，教师 教师', u'您好，教师 教师']
##================================================
##********************test_Register********************
##================================================
reg_user = 'testteacher001'
reg_passwd = 'testteacher001'
reg_repasswd = 'testteacher001'
reg_role1 = u'学生'
reg_role2 = u'教师'
reg_zz1 = u'010401班'
reg_zz2 = u'国泰安中学'
reg_cardid = '1231234324234234'
reg_name = u'教师名称'
reg_contact = '12312323213'
reg_email = 'test@teacher.com'
reg_problem = 'testteacher001'
reg_answer = 'testteacher001'
reg_check_txt = u'注册成功，等待审核    点击返回首页'
setup_db_for_reg_user_sql = u'''delete from userregisterinfo where username='%s';''' % reg_user
check_db_for_reg_user_sql = u'''select username from userregisterinfo where username='%s';''' % reg_user
