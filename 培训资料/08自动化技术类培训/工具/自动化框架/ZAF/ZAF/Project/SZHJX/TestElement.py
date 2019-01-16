#encoding: utf-8

###################导航##################
 #首页按钮
home_btn = u"link=首页"
#教学中心
teacherHome_btn = "link=教学中心"
#资源中心
resourceHome_btn = "link=资源中心"
 #微课堂
microclassHome_btn = "link=微课堂"
#数据分析中心
dataAnalusisCenter_btn = "link=数据分析中心"

#设置按钮
setup_btn = "css=span.setup"

#退出按钮
quit_btn = "css=span.exit>a[href='/account/logoff']"

#页顶信息
topinfo_real_name = "css=div[class='topinfo']>span[class='']>i"

home_btn_class_attr = "Xpath=//*[@class='menu pa tc l-nenav']/ul/li[1]/a"
teacherHome_btn_class_attr = "Xpath=//*[@class='menu pa tc']/ul/li[2]/a"
resourceHome_btn_class_attr = "Xpath=//*[@class='menu pa tc']/ul/li[3]/a"
microclassHome_btn_class_attr = "Xpath=//*[@class='menu pa tc']/ul/li[4]/a"
dataAnalusisCenter_btn_class_attr = "Xpath=//*[@class='menu pa tc']/ul/li[5]/a"

###################首页##################
#首页
homePage1 = "Xpath=//*[@class='pr']"
homePage = "css=.pr"
#课程导航按钮
courseNavigation_btn = 'id=categorys'
#语文
courseMenu = "css=div.item.fore0>span>h3>a[title='语文']"
courseArrow = "css=div.item.fore0>span>h3>a[title='语文']>i"
#国泰安
versionShow = "css=.fore0>dt>a"
#必修5
numShow1 = "Xpath=//*[@class='fore0']/dd/em[1]/a"
numShow = "css=.fore0>dd>em>a"

#显示图片
showImage = "Xpath=//*[@class='kinMaxShow_image_box']"
#显示图片原点
showImage_btn = "Xpath=//*[@class='kinMaxShow_button']"
#最新资源
newResource = "Xpath=//*[@class='l-inacting']"
#课程推荐
recommentCourse = "Xpath=//*[@class='l-crocusto']"
#最新课程
newCourse = "Xpath=//*[@class='l-newres']"
#资源统计
resourceStatistics = "Xpath=//*[@class='1-newres']"
#友情链接
links = "Xpath=//*[@class='l-holink1']"
#教学中心页面
page = "title=数字化教学平台--教学中心"
#三张图片
three_imgs = "css=div.kinMaxShow_image_item"

first_img = "div.kinMaxShow_image_item"
second_img = "div.kinMaxShow_image_item+div.kinMaxShow_image_item"
third_img = "div.kinMaxShow_image_item+div.kinMaxShow_image_item+div.kinMaxShow_image_item"

#三个圆点
three_dots = "Xpath=//*[@class='kinMaxShow_button']/li"

first_dot = "Xpath=//*[@class='kinMaxShow_button']/li[1]"
second_dot = "Xpath=//*[@class='kinMaxShow_button']/li[2]"
third_dot = "Xpath=//*[@class='kinMaxShow_button']/li[3]"

###################登录页面##################
#登录页面,元素包含‘用户登录’
loginPage1 = "Xpath=//*[@class='content-RC pr']"
loginPage = "css=.content-RC.pr"
#登录按钮
login_btn1 = "Xpath=//*[@class='login' and @href='/account/logon']"
login_btn = "css=.login[href='/account/logon']"
#用户名
username_btn = "id=UserName"
#密码
password_btn = "id=Password"
#提交（登录）按钮
submit_btn = 'id=btn_submit'
register_btn1 = 'id=btn_register'

error_submit1 = "Xpath=//*[@class='xubox_msg xubox_text']"
error_submit = "css=.xubox_msg.xubox_text"
forgot_password_btn1 = "Xpath=//a[@class='forgetPassword']"
forgot_password_btn = "css=a.forgetPassword"
error_alert1 = "Xpath=//*[@class='xubox_msg xubox_text']"
error_alert = error_submit

###################忘记密码##################
#第一步：用户名
forgot_password_username1 = "Xpath=//input[@id='UserName']"
forgot_password_username = "id=UserName"
forgot_password_next_step_btn = submit_btn

#第二步：提示答案；新密码
forgot_password_answer = 'id=Answer'
forgot_password_password = 'id=Password'
forgot_password_save_btn = submit_btn
forgot_password_cancel_btn = 'id=btn_cancel'
forgot_password_answer_error_tip = "Xpath=//*[@class='validation-summary-errors']/ul/li"
forgot_password_answer_blank_tip = "Xpath=//div[@class='accRow'][3]/span/span"
forgot_password_passwprd_blank_tip = "Xpath=//div[@class='accRow'][4]/span/span"
#第三步
forgot_password_login_btn = 'css=a.forgetPassword'

###################注册页面##################
#组织架构
reg_organization_school = "Xpath=//ul[@id='treePosition']/li[1]/div[1]/span[3]"
reg_organization_specialty ="Xpath=//ul[@id='treePosition']/li[1]/ul/li/div/span[4]"
reg_organization_grade = "Xpath=//ul[@id='treePosition']/li[1]/ul/li/ul/li/div/span[5]"
reg_organization_class = "Xpath=//ul[@id='treePosition']/li[1]/ul/li/ul/li/ul/li/div/span[6]"

###################教学中心页面##################
#教学中心页面，包含元素‘我要开课’，内容“教学中心”
teachingPage = loginPage
teacherCourse_btn = "css=div>span[2]>a"
#“我要开课”按钮
start_course_btn = "Xpath=//*[@class='l-myope']/a"
table = "Xpath=//*[@id='form1']"
start_course1 = "title=u'数字化教学平台--教学中心'"
start_course='/teachercenter/addcourse'
start_course2 = "Xpath=//iframe[@id='ifr_popup0']"
###################学习中心页面##################
#教学中心页面，包含内容‘学习中心’，不包含元素“我要开课”
studyPage = loginPage

###################个人资料页面##################
#修改密码按钮
#修改密码按钮
modify_password_btn = "Xpath=//div[2]/ul/li[2]"
old_pwd_btn = "id=Pwd"
new_pwd_btn = "id=NewPwd"
confirm_pwd_btn = "id=ConfirmPwd"
save_btn = "Xpath=//a[contains(text(),'保存')]"
#个人资料
#个人资料页面
personal_info_page = "css=div.fl.userinfo.mt-27"
#修改个人资料按钮
modify_personal_info = "css=div.list-L>ul>li[stype='1']"
#用户名
username_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][1]"
username_R = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-R'][1]"
#角色
role_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][2]"
role_R = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-R'][2]"
#所属学校
school_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][3]"
school_R = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-R'][3]"
#真实姓名
real_name_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][4]"
real_name_R = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-R'][4]"
#性别
gender_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][5]"
gender_R = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-R'][5]"

#联系方式
contact_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][6]"
contact_R = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-R'][6]"
#邮件
email_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][7]"
email_R = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-R'][7]"
#简介
brif_introduction_L = "Xpath=//div[@class='fl userinfo mt-27']/span[@class='text-L'][8]"
brif_introduction_R = "Xpath=//div[@class='fl userinfo mt-27']/div[@class='text-R'][1]"

#上传图片
file_upload_btn = "id=fileUpload"
personal_photo = "id=PersonPhoto"

#修改资料按钮
modify_personal_info_btn = "css=a[title='修改资料']>img[src='/images/ic_modInfo.png']"
#修改个人资料页面
modify_personal_info_page = "id=EditUserInfoForm"
modify_real_name = "id=FullName"
modify_gender_male = "css=input[value='M']"
modify_gender_female = "css=input[value='W']"
modify_gender_secrecy = "css=input[value='S']"
modify_contact = "id=Contact"
modify_email = "id=Email"
modify_resume = "id=Resume"
modify_save_btn = "css=a.btn-01[onclick='SaveUserInfo();']"
modify_cancel_btn = "css=a.btn-01[onclick='Undo();']"

##########修改密码
#修改密码按钮
modify_personal_password_btn = "css=div.list-L>ul>li[stype='2']"
modify_password_password = "id=Pwd"
modify_password_new_password = "id=NewPwd"
modify_password_confirm_password = "id=ConfirmPwd"
modify_password_save_btn = "css=a.btn-01[onclick='EditPwd();']"
modify_password_cancel_btn = "css=a.btn-01[onclick='Undo2();']"

##########修改密保
modify_password_security_btn = "css=div.list-L>ul>li[stype='3'"
modify_password_security_password = "id=CurrentPwd"
modify_password_security_question = "id=PasswordQuestion"
modify_password_security_answer = "id=PasswordAnswer"
modify_password_security_save_btn = "css=a.btn-01[onclick='EditUserQuestion();']"
modify_password_security_cancel_btn = "css=a.btn-01[onclick='Undo2();']"

###################后台系统页面##################
back_stage_username = "id=UserName"
back_stage_password = "id=Password"
back_stage_login_btn = "id=loginBtn"
back_stage_resource_manage = "Xpath=//div[@class='panel-title panel-with-icon'][1]"
back_stage_teaching_manage = "Xpath=//div[contains(text(), '教材管理')]"
back_stage_teaching_detail = "Xpath=//span[contains(text(), '教材管理')]"
back_stage_user_manage = "Xpath=//div[contains(text(), '用户管理')]"
back_stage_organization = "Xpath=//span[contains(text(), '组织架构')]"
back_stage_organization_detail = "Xpath=//ul[@id='treePosition']/li/ul/li"
back_stage_organization_school = "Xpath=//ul[@id='treePosition']/li/ul/li/div/span[4]"
back_stage_organization_specialty ="Xpath=//ul[@id='treePosition']/li/ul/li/ul/li/div/span[5]"
back_stage_organization_grade = "Xpath=//ul[@id='treePosition']/li/ul/li/ul/li/ul/li/div/span[6]"
back_stage_organization_class = "Xpath=//ul[@id='treePosition']/li/ul/li/ul/li/ul/li/ul/li/div/span[7]"
#教材管理
back_stage_teaching_course = "Xpath=//tr[1]/td[1]/div"
back_stage_teaching_version = "Xpath=//tr[1]/td[2]/div"
back_stage_teaching_num = "Xpath=//tr[1]/td[3]/div"
back_stage_teaching_disable = "Xpath=//tr[1]/td[5]/div"
back_stage_material_course = "Xpath=//tbody/tr[@id='datagrid-row-r1-2-0']/td[1]/div"
back_stage_material_version = "Xpath=//tbody/tr[@id='datagrid-row-r1-2-0']/td[2]/div"
back_stage_material_num = "Xpath=//tbody/tr[@id='datagrid-row-r1-2-0']/td[3]/div"
#用户管理
back_stage_teacher_manage = "Xpath=//span[contains(text(), '教师管理')]"

#teacher1信息
back_stage_teacher1_usename = "css=#datagrid-row-r1-2-1>td[field='LoginName']>div"
back_stage_teacher1_full_name = "css=#datagrid-row-r1-2-1>td[field='FullName']>div"
back_stage_teacher1_gender = "css=#datagrid-row-r1-2-1>td[field='Gender']>div"
back_stage_teacher1_contact = "css=#datagrid-row-r1-2-1>td[field='Contact']>div"
back_stage_teacher1_class_name = "css=#datagrid-row-r1-2-1>td[field='ClassName']>div"
back_stage_teacher1_user_no = "css=#datagrid-row-r1-2-1>td[field='UserNo']>div"

#teacher禁用按钮/启用按钮
back_stage_user_teacher1_disable =  "Xpath=//tr[@id='datagrid-row-r1-2-4']/td[10]/div[1]/a"

#########################消息邮件 2016-04-08#########################################
#后台学生管理
back_stage_student_manage = "Xpath=//span[contains(text(), '学生管理')]"
#邮件图标
email_icon = "css=span.mail>a[href='/email']"

#“写邮件”按钮
add_email_btn = "css=a[href='/email/addemail']"

#“收件箱”按钮
email_box_btn = "css=a[href='/email']"

#“发件箱”按钮
email_outbox_btn = "css=a[href='/email/outbox']"

#“草稿箱”按钮
email_draffbox_btn = "css=a[href='/email/draffbox']"

######写邮件页面#######
#写邮件页面
add_email_page = "Xpath=//li[@class='beike onn']/a[contains(text(), '写邮件')]"

#发送按钮
send_btn = "id=btnSend"

#存草稿按钮
draff_btn = "id=btnDraff"
#上传附件
upload_attachment_btn = "css=#fileUpload"
#删除附件
delete_attachment_btn = "css=a[title='删除附件']"
#第一个附件
attachment_1 = "css=#fileName0"

#组织架构中班级
organization_class = "Xpath=//ul[@id='zTreeUl_4_ul']/li"
#组织架构：三级目录
organization_teacher = "Xpath=//ul[@id='zTreeUl_2_ul']/li"
#写邮件组织架构
#班级切换按钮
switch_class2 =  "Xpath=//span[contains(text(), '20160323')]"
#学生王丽姓名
student02_name = u"css=a[title='王丽']"
#第一个教师
teacher_1 = u"css=a[title='小小']"
#第二个教师
teacher_2 = "Xpath=//ul[@class='level0']/li[@class='level1'][3]"
#收件人
email_receiver = "id=txtReUsername"
#主题
mail_title = "css=#txtTitle"
#内容表单
frame_content = "css=#ueditor_0"
#内容
mail_content = "css=body.view>p"

################收件箱##############
#收件箱页面
email_box_page = "Xpath=//li[@class='beike onn']/a[contains(text(), '收件箱')]"
#邮件个数
email_num_element = "Xpath=//span[@class='tc-blue'][2]"
#搜索框
search_box = "id=txtkeyword"
#搜索按钮
search_btn = "id=btnSearch"
#“标记为已读”按钮
tab_read_btn = "id=A1"
#"标记为未读"按钮
tab_unread_btn = "id=A2"
#回复按钮
email_send_back_btn = "id=A3"
#选择全部邮件的checkbox
email_all_checkbox = "id=checkAll"
#删除按钮
email_delete_btn = "id=btnDel"
#发件人
email_sender = "Xpath=//div[@class='hd-list']/ul/li[contains(text(), '发件人')]"
#主题
email_title = "Xpath=//div[@class='hd-list']/ul/li[contains(text(), '主题')]"
#时间
email_date = "Xpath=//div[@class='hd-list']/ul/li[contains(text(), '时间')]"
#向后翻页按钮
email_next_btn = "Xpath=//div/a[contains(text(), '>')]"
#向前翻页按钮
email_previous_btn = "Xpath=//div/a[contains(text(), '<')]"

#收件箱最近一封邮件
mail_unread_latest = "id=hyper0"
mail_received_latest = "Xpath=//div[@class='bd-list']"
mail_reveiced_latest_title = "Xpath=//div[@class='bd-list'][1]/ul/li[@class='W288']"
mail_box_element = "css=.l-bdx.list-lesson"
mail_unread = "css=.mail01"
mail_read = "css=.mail02"
mail_time = "Xpath=li[@class='W150 noboder']"
#########收件箱邮件打开页面#########
#主题
email_box_title = "Xpath=//div[@class='mailinfo']/ul/li[2]/span[2]"
#收件人
email_box_reciver = "Xpath=//div[@class='mailinfo']/ul/li[4]/span[2]"
#附件
email_box_attachment = "Xpath=//div[@class='mailinfo']/ul/li[5]/a[@class='ziplink']"

#内容
email_box_content = "Xpath=//div[@class='maildetail']/p[2]"
#回复按钮
send_back_btn = "id=btnReview"
#转发按钮
send_again_btn = "id=btnSendAgain"
#删除按钮
delete_btn = "id=btnDel"

############邮件转发页面##############
####内容####
content_sender = "Xpath=//body[@class='view']/p[3]"
content_title = "Xpath=//body[@class='view']/p[4]"
content_receiver = "Xpath=//body[@class='view']/p[6]"
content_detail = "Xpath=//body[@class='view']/p[8]"

#######################发件箱###################
#发件箱页面
email_outbox_page = "Xpath=//li[@class='beike onn']/a[contains(text(), '发件箱')]"

#######################草稿箱###################
#草稿箱页面
email_draffbox_page = "Xpath=//li[@class='beike onn']/a[contains(text(), '草稿箱')]"
#收件人
draffbox_receiver = "Xpath=//div[@class='hd-list']/ul/li[contains(text(), '收件人')]"
#邮件页面"编辑"按钮
draffbox_email_edit_btn = "id=btnEdit"