import smtplib,os
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
class SendMail(object):
    def __init__(self,username,passwd,recv,title,content,
                 file=None,
                 email_host='m.gtafe.com',port=587):
        self.username = username
        self.passwd = passwd
        self.recv = recv
        self.title = title
        self.content = content
        self.file = file
        self.email_host = email_host
        self.port = port
    def send_mail(self):
        msg = MIMEMultipart()
        #发送内容的对象
        if self.file:#处理附件的
            att = MIMEText(open(self.file,'rb').read(), 'base64', 'utf-8')
            att["Content-Type"] = 'application/octet-stream'
            att["Content-Disposition"] = 'attachment; filename="%s"'%os.path.basename(self.file)
            print(att)
            msg.attach(att)
        msg.attach(MIMEText(self.content))#邮件正文的内容
        msg['Subject'] = self.title  # 邮件主题
        msg['From'] = self.username  # 发送者账号
        msg['To'] = ';'.join(self.recv)  # 接收者账号列表
        self.smtp = smtplib.SMTP(self.email_host,port=self.port)
        #发送邮件服务器的对象
        self.smtp.login('xiaogang.yang',self.passwd)
        try:
            self.smtp.sendmail(self.username,self.recv,msg.as_string())
        except Exception as e:
            print('出错了。。',e)
        else:
            print('发送成功！')
        self.smtp.quit()


if __name__ == '__main__':
    m = SendMail(
        username='xiaogang.yang@gtafe.com',passwd='3280789@XG',recv=['xiaogang.yang@gtafe.com'],
        title='新的发送邮件',content='哈哈哈啊哈哈哈哈',file='F:\cache\RTX\表情包\sudo.gif'
    )
    # m = SendMail(
    #     'xiaogang.yang@gtafe.com', '3280789@XG', ['qi.zhao@gtafe.com', 'xiaogang.yang@gtafe.com'],
    #     '新鞋的发送邮件', '哈哈哈啊哈哈哈哈', '../data/20171024114346_TestReport.html'
    # )
    m.send_mail()


