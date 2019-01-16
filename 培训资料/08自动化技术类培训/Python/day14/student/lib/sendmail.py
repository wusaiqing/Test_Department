import smtplib,os
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
def send_mail(username,passwd,recv,title,content,
                 file=None,
                 email_host='m.gtafe.com',port=587):
        msg = MIMEMultipart()
        #发送内容的对象
        if file:#处理附件的
            att = MIMEText(open(file,'rb').read(), 'base64', 'utf-8')
            att["Content-Type"] = 'application/octet-stream'
            att["Content-Disposition"] = 'attachment; filename="%s"'%os.path.basename(file)
            print(att)
            msg.attach(att)
        msg.attach(MIMEText(content))#邮件正文的内容
        msg['Subject'] = title  # 邮件主题
        msg['From'] = username  # 发送者账号
        msg['To'] = ';'.join(recv)  # 接收者账号列表
        smtp = smtplib.SMTP(email_host,port=port)
        #发送邮件服务器的对象
        smtp.login('xiaogang.yang',passwd)
        try:
            smtp.sendmail(username,recv,msg.as_string())
        except Exception as e:
            print('出错了。。',e)
        else:
            print('发送成功！')
        smtp.quit()


if __name__ == '__main__':
    send_mail(
        username='xiaogang.yang@gtafe.com',passwd='3280789@XG',recv=['xiaogang.yang@gtafe.com'],
        title='新的发送邮件',content='哈哈哈啊哈哈哈哈',file='F:\cache\RTX\表情包\sudo.gif'
    )
    # send_mail(
    #     'xiaogang.yang@gtafe.com', '3280789@XG', ['qi.zhao@gtafe.com', 'xiaogang.yang@gtafe.com'],
    #     '新鞋的发送邮件', '哈哈哈啊哈哈哈哈', '../data/20171024114346_TestReport.html'
    # )



