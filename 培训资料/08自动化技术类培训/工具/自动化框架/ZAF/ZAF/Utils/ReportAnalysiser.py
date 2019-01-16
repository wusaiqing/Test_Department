#!/bin/python
#coding:utf-8

import sys
import datetime
import smtplib
from email.mime.text import MIMEText

sendfrom = 'huali.wang@gtafe.com'
username = 'GTADATA\huali.wang'
password = 'abc_571211'
sendto_self = ['huali.wang@gtafe.com']
sendto_daily = ['huali.wang@gtafe.com','xiaojian.zhou1@gtafe.com','minlan.chen@gtafe.com','tianwen.xie@gtafe.com',
                'hong.fang@gtafe.com','jialin.wu@gtafe.com','shangli.wu@gtafe.com','junwei.wu@gtafe.com',
                'anna.lin@gtafe.com','qiaofang.yan@gtafe.com','jing.ran@gtafe.com','yanhui.cao@gtafe.com',
                'bingyan.tan@gtafe.com','wen.huang@gtafe.com','yongqin.chen@gtafe.com']
sendto_ontest = ['huali.wang@gtafe.com']
mail_host = 'm.gtafe.com'
subject = '数字化教学平台自动化脚本daily run报告  %s （63环境）' % datetime.datetime.now().strftime('%Y-%m-%d %H:%M:%S')
attach = ''
my_today = datetime.datetime.now().strftime('%Y-%m-%d')
my_year = my_today.split('-',1)[0]
my_month = my_today.split('-', 2)[1]
my_today = my_today.split('-', 2)[2]

def analysis(fn):
    fl = open(fn).readlines()[-5:]

    nums = fl[0].split(',')
    total = nums[0].split(' ')[0]
    passed = nums[1].split()[0]
    failed = nums[2].split()[0]

    reportername = fl[4].split('\\')[-1]
    reporterpath = fl[4].split(' ')[2]
    return total, passed, failed, reportername, reporterpath

def send_mail(sendfrom, sendto, subject, content, attach):
    # print sendfrom, sendto, subject, content, attach
    msg = MIMEText(content, _subtype='html', _charset='utf-8')    #创建一个实例，这里设置为html格式邮件
    msg['Subject'] = subject    #设置主题
    msg['From'] = sendfrom
    msg['To'] = ";".join(sendto)
    try:
        s = smtplib.SMTP()
        s.connect(mail_host)  #连接smtp服务器
        s.login(username, password)  #登陆服务器
        s.sendmail(sendfrom, sendto, msg.as_string())  #发送邮件
        s.close()
        return True
    except Exception, e:
        print str(e)
        return False

def get_content():
    return  '''<!DOCTYPE HTML>
                <html>
                <head>
                    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
                    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
                    <title>RF Automation Testing Result</title>
                <style>
					.red { color:#ff0000; }
					.green { color:#03AD2E; }
					.org { color:#F9A016; }
					.blue { color:#0A67F7; }
                </style>
                </head>
                <body>
                    <h1>RF自动化测试报告</h1>
                    <div>
						    <p>
							    <span><b class="org">用例总数：97 &nbsp;</b></span>
							    <span><b class="green">通过总数：96 &nbsp;</b></span>
							    <span><b class="red">失败总数：1</b></span>
						    </p>
						    <p>
							    <span><b class="blue">IP地址：192.168.105.54  &nbsp;</b></span>
							    <span><b class="blue">浏览器：Firefox &nbsp;</b></span>
							    <span><b class="blue">版本：43.0</b></span>
						    </p>
                        <p>
                            更多详情结果请猛戳<a href="http://192.168.105.54:8082/%s/%s/firefox/report.html" target="_blank">这里</a>
                            </br>
                            </br>
                            </br>
                            </br>
                            </br>
                            </br>
                            </br>
                            <span class='regard'>Best Regards!</span>
                            </br>
                            </br>
                            <span class='myName'>王华丽</span>
                        </p>
                    </div>
                </body>
                </html>'''%(my_year+my_month,my_today)

if __name__=='__main__':
    #fn = sys.argv[1]
    #log_info = analysis(fn)
    #pic = get_pic(log_info[4])
    content = get_content()
    #if sendfor=='1':
    #    sendto = sendto_self
    #elif sendfor=='2':
    #   sendto = sendto_daily
    #else:
    #    sendto = sendto_ontest
    send_mail(sendfrom, sendto_self, subject, content, attach)

