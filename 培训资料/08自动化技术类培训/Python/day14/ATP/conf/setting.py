import os
BASE_PATH = os.path.dirname(os.path.dirname(
    os.path.abspath(__file__)))
LOG_PATH = os.path.join(BASE_PATH,'logs')
#日志目录
DATA_PATH = os.path.join(BASE_PATH,'data')
#存放报告的目录
CASE_PATH = os.path.join(BASE_PATH,'cases')
MAIL_USER = 'xiaogang.yang@gtafe.com'
#发送邮件的账号
MAIL_PASSWD = '3280789@XG'
#发送邮件的密码
# TO_MAIL = ['xiaogang.yang@gtafe.com','bingyan.wu@gtafe.com','dongke.li@gtafe.com','tianhe.jiang@gtafe.com','siyuan.chen@gtafe.com']
# TO_MAIL = ['xiaogang.yang@gtafe.com','siyuan.chen@gtafe.com']
TO_MAIL = ['xiaogang.yang@gtafe.com']
#发给谁
