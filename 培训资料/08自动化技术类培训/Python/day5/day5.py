# 1、写一个产生密码的程序，存文件（ 选做）
#     输入次数，输入多少次就产生多少条数据，
#     要求密码必须包含大写字母、小写字母和数字，长度8位，不能重复
#      怎么取大小字母、数字组合 参考集合
#      取值参考random模块的使用
# 用法如下：
# passwd_list=random.sample(src_passwd,8) #大小写字母+数字里随机取8个，生成的是一个列表
# passwd=''.join(passwd_list) #将取到的数据拼接为一个字符串
# print(passwd)
#需求分析
#  1.用户input
# 2.大写字母、小写字母和数字 字符串
# 3.不能重复 list
# 4.写到文件里
# import random,string
# lower_words=set(string.ascii_lowercase)  #小写字母
# upper_words=set(string.ascii_uppercase)  #大写字母
# digit=set(string.digits) #数字
# src_passwd=string.ascii_letters+string.digits   #大小写字母+数字
# with open('a.txt','a+') as f:
#     f.seek(0)
#     passwds=(f.readlines())
# while True:
#     num=input('数量：').strip()
#     if num.isdigit():
#         num=int(num)
#         while num>0:
#             passwd_list = set(random.sample(src_passwd, 8))
#             if (lower_words & passwd_list) and (upper_words & passwd_list) and (digit & passwd_list):
#                 passwd = ''.join(passwd_list)+'\n'
#                 if passwd not in passwds:
#                     passwds.append(passwd)
#                     num-=1
#             else:
#                 continue
#         with open('a.txt', 'w') as f:
#             f.writelines(passwds)
#         break
#     else:
#         continue

# with open('a.txt','rb') as f:
#     print(f.read().decode())

# 2、把上周的注册程序改一下，用字典保存，存文件
#     字典格式如下：
#     {
#         "大雷":{"passwd":"123456","role":1"}，
#         "星星":{"passwd":"123456","role":2"}
#      }
#      #role如果是1的话，代表管理员，如果是2代表普通用户,注册的用户都是普通用户
# user={
#         "大雷":{"passwd":"123456","role":"1"},
#         "星星":{"passwd":"123456","role":"2"}
#      }
# while True:
#     name = input('name:').strip()
#     passwd = input('passwd:').strip()
#     if name and passwd:
#         infos={"passwd":passwd,"role":"2"}
#         if name not in user:
#             user[name]=infos
#             with open('a.txt', 'w') as f:
#                 f.write(str(user))
#         else:
#             print('用户已存在')
#         break
#     else:
#         continue
# print(user)

# 3、如下，如果输入这些词，就用**代替，敏感字都在文件里。
#    #然后输出，例如输入今天没吃饭，碰到一个傻逼，原来那个sb是小明。输出今天没吃饭，碰到一个**，原来那个**是小明。
# 傻逼
# 傻b
# 煞笔
# 煞比
# sb
# 傻B
# shabi


# 4、注册和登录连上，能用你之前注册的用户来登录，存文件
# users_dic={}
# with open('a.txt','a+') as f:
#     f.seek(0)
#     users=(f.readlines())
#     for i in users:
#         if i !='\n':
#             lis=i.replace('\n','').split(',')
#             users_dic[lis[0]]=lis[1]
# while True:
#     name = input('name:').strip()
#     passwd = input('passwd:').strip()
#     if name and passwd:
#         if name not in users_dic:
#             with open('a.txt', 'a+') as f:
#                 f.write(name+','+passwd+'\n')
#             break
#         else:
#             print('用户已存在')
#     else:
#         continue
# users_dic = {}
# with open('a.txt', 'a+') as f:
#     f.seek(0)
#     users = (f.readlines())
#     for i in users:
#         if i != '\n':
#             lis = i.replace('\n', '').split(',')
#             users_dic[lis[0]] = lis[1]
# while True:
#     name = input('name:').strip()
#     passwd = input('passwd:').strip()
#     if name and passwd:
#         if users_dic.get(name)!=passwd or name not in users_dic:
#             print('用户或密码错误！')
#             continue
#         else:
#             print('登录成功')
#             break


#文件修改



#集合
# import time
# time.sleep(1)
# print('asd')


#监控日志



#函数

# def wel(name,age,height):  #形参
#     name='xingxing'
#     print('欢迎%s来到从零单排,年龄：%s，身高:%s'%(name,age,height))
# wel('大雷',180,18)    #实参
# print(name)

import requests
url='http://192.168.217.128/bugfree/index.php/testUser/adminedit'
data={'TestUser[lock_version]':'','TestUser[password]':'123456','TestUser[authmode]':'internal','TestUser[realname]':'xiaogang002','TestUser[username]':'xiaogang002','TestUser[email]':'xiaogang002@qq.com'}
res=requests.post(url,data).text
print(res)


