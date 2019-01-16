#coding:utf-8

import urllib,urllib2,cookielib
import json, sys
from robot.libraries.BuiltIn import BuiltIn

class SendRequest():
    def __init__(self):
        self.cj = cookielib.CookieJar()
        self.opener = urllib2.build_opener(urllib2.HTTPCookieProcessor(self.cj))

    def send_request_cookie(self, url, data, msg_key, expected_msg):
        if data != {}:
            reload(sys)
            sys.setdefaultencoding('utf-8')
            post_data = urllib.urlencode(data)
            request = urllib2.Request(url,post_data)
        else:
            request = urllib2.Request(url)
        html = self.opener.open(request).read()
        a = json.loads(html)
        BuiltIn().should_be_equal(a[msg_key], expected_msg)

    def send_request(self, url, data, msg_key, expected_msg):
        if data != {}:
            reload(sys)
            sys.setdefaultencoding('utf-8')
            post_data = urllib.urlencode(data)
            request = urllib2.Request(url,post_data)
            html = self.opener.open(request).read()
            a = json.loads(html)
            BuiltIn().should_be_equal(a[msg_key], expected_msg)
            self.cj.clear()
            return a
        else:
            request = urllib2.Request(url)
            html = self.opener.open(request).read()
            return html



if __name__ == '__main__':
    url = 'http://192.168.106.45:8081/account/logon'
    data_1 = {'UserName':'teacher111', 'Password':'teacher'}
    sendRequest = SendRequest()
    a = sendRequest.send_request(url, data_1, 'Message', '您输入的信息不完整或者有错误，请检查！')
    







