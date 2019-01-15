#1.找到目录下面前三天的日志，删掉  20180109101010.log
#2.修改day8作业，改为数据库存 用户、商品

#内置函数
# print('%.3f'%66.666666)

# dic={'dalei': {'money': 1003.0, 'role': 2, 'pass': '123456', 'products': ['mac', '宝马', '手机', '手机']},
#      'xg': {'money': 1000, 'role': 1, 'pass': '123456', 'products': ['mac']}}
# lis=[['name','money','role','pass','products'],[]]

#excel
#写
import xlwt,xlrd,xlutils
# write_book=xlwt.Workbook()
# sheet=write_book.add_sheet('sheet1')
# for i in range(len(lis)):
#     sheet.write(0,i,lis[i])
# a=1
# for key in dic:
#     j = 0
#     sheet.write(a, j, key)
#     j+=1
#     for key2 in dic[key]:
#         sheet.write(a, j, str(dic[key][key2]))
#         j+=1
#     a+=1
# write_book.save('tmp.xls')

#读
# read_book=xlrd.open_workbook('tmp.xls')
# sheet=read_book.sheet_by_index(0)
# print(sheet.cell(2,1).value)
# print(sheet.nrows)
# print(sheet.ncols)
# print(sheet.row_values(0))

# from xlutils.copy import copy
# import os
# ubook=xlrd.open_workbook('tmp.xls')#打开一个excel文件对象
# mbook=copy(ubook)#复制读到的文件对象
# msheet=mbook.get_sheet(0)#获取sheet页，注意这里只能用get_sheet(0)方法，指定下标
# msheet.write(1,0,'dagang')#写入数据
# mbook.save('new.xls')#保存数据

#接口测试
# import urllib
# from urllib.request import urlopen
# from urllib.parse import urlencode
# url='http://api.nnzhp.cn/api/product/all'
# data={"username":"admin","password":123456}
# req_data=urlencode(data)#将字典类型的请求数据转变为url编码
# print(req_data)
# res=urlopen(url)#通过urlopen方法访问拼接好的url
# res=res.read().decode()#read()方法是读取返回数据内容，decode是转换返回数据的bytes格式为str
# print(res)

#处理post请求,如果传了data，则为post请求
# import urllib
# from urllib.request import urlopen
# from urllib.request import Request
# from urllib.parse import urlencode
# url='http://api.nnzhp.cn/api/user/user_reg'
# data={"username":"admin123","pwd":'Aa123456',"cpwd":"Aa123456"}
# data=urlencode(data)#将字典类型的请求数据转变为url编码
# data=data.encode('ascii')#将url编码类型的请求数据转变为bytes类型
# req_data=Request(url,data)#将url和请求数据处理为一个Request对象，供urlopen调用
# with urlopen(req_data) as res:
#     res=res.read().decode()#read()方法是读取返回数据内容，decode是转换返回数据的bytes格式为str
# print(res)

 #get请求
import requests
# url='http://api.nnzhp.cn/api/product/choice'
# data={"userid":"1028","sign":"e36d405fa6f359fd0657e1b8736d5089"}
# res=requests.get(url,data)#直接用requests.get(url,data)即可，其中.get表示为get方法，不需要对字典类型的data进行处理
# #res=res.text#text方法是获取到响应为一个str，也不需要对res进行转换等处理
# res=res.json()#当返回的数据是json串的时候直接用.json即可将res转换成字典
# print(res)

shiji={"code":1,"message":"此手表未绑定学生，可以使用","msg":"成功"}
yuqi={"code":1,"message":"此手表未绑定学生，可以使用"}
def check(shiji,yuqi):
    for key in yuqi:
        if key not in shiji or yuqi[key]!=shiji[key]:
            return "fail"
    return "pass"
print( check(shiji,yuqi))







# #post请求
# import requests
# url='http://api.nnzhp.cn/api/user/user_reg'
# data={"username":"admin145","pwd":'Aa123456',"cpwd":"Aa123456"}
# res=requests.post(url,data)#直接用requests.post(url,data)即可，其中.post表示为post方法，不需要对字典类型的data进行处理
# #res=res.text#text方法是获取到响应为一个str，也不需要对res进行转换等处理
# res=res.json()#当返回的数据是json串的时候直接用.json即可将res转换成字典
# print(res)

#当传参格式要求为json串时
import requests
url='http://127.0.0.1:1990/login'
data={"username":"admin","password":123456}
res=requests.post(url,json=data)#只需要在这里指定data为json即可
#res=res.text#text方法是获取到响应为一个str，也不需要对res进行转换等处理
res=res.json()#当返回的数据是json串的时候直接用.json即可将res转换成字典
print(res)
#传参含cookie
import requests
# url='http://127.0.0.1:1990/login'
# data={"username":"admin","password":123456}
# cookie={"sign":"123abc"}
# file=open('new.xls')
# res=requests.post(url,json=data,cookies=cookie,files=file,headers=)#只需要在这里指定cookies位cookie即可，headers，files等类似
# res=res.json()
# print(res)









