#cookies是什么？

#requests模块  cookies headers,files
# data={'stu_sex': '男', 'stu_name': 'yxg', 'stu_phone': '23537737007', 'sign': '5f7f6e722e45934fdb81a4d74b011180', 'opUserId': '1', 'stu_type': '1', 'stu_class': '1班'}
login_data={"username":"admin","password":123456}
cookie={'sign':'8ce906d5e3743dbff3dadd650c4ddc36'}
header={"Content-Type":"text/html; charset=utf-8"}
# import requests
# login_url='http://10.1.130.102:1990/login'
# url='http://10.1.130.102:1990/addstu'
res1=requests.post(login_url,login_data,cookies=cookie,headers=header)
# # sign=res1.json()['sign']
# # data['sign']=sign
# res2=requests.post(url,json=data)
# print(res1.json())
# print(res2.text)

#传文件
# import requests
# url='http://10.1.130.102:1990/upload'
# file={
#     "file_name":open('a.txt',encoding='utf-8')
# }
# res=requests.post(url,files=file)

# import http.client
#
# conn = http.client.HTTPConnection("10.1.130.102:1990")
#
# payload = "-----011000010111000001101001\r\nContent-Disposition: form-data; name=\"file_name\"; filename=\"[object Object]\"\r\nContent-Type: false\r\n\r\n\r\n-----011000010111000001101001--"
#
# headers = {
#     'content-type': "multipart/form-data; boundary=---011000010111000001101001",
#     'cache-control': "no-cache",
#     'postman-token': "8ac62ee5-8f7c-1564-d342-f7750865f1bc"
#     }
#
# conn.request("POST", "/upload", payload, headers)
#
# res = conn.getresponse()
# data = res.read()
#
# print(data.decode("utf-8"))


#异常处理
# print(123)
# try:
#     print(123/1)
# except Exception as e:
#     print(e)
# finally:
# else:
#     print(234)
#     print(564)
# raise '撒的发生'


#框架



