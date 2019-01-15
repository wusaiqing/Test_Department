# str='sadas,gasdf,asdgfasdg'
# print(str.startswith('hello'))     #判断
# print(str.endswith('hello'))
# #list,tuple/dict,str
# lis=['a','b','c']
# print('*****'.join(lis))
# lis2=str.split(',')
# print(lis2)

#字典
# informations={'星星':{'江西':18,'男':100},'大雷':['合肥',16,'男',190]}
# for i in informations:
#     print(i)
# print(informations['星星']['男'])
# shengxia=informations['星星']['男']-50
# informations['星星']['男']=shengxia
# print(informations['星星']['男'])

# import time
# hmd=[]
# pin=0
# while True:
#     lis=[1,2,3,3,3,4,5,6]
#     with open('a.txt','ab+') as f:
#         f.seek(pin)
#         for i in f:
#             ip=i.decode().split(' ')[0]
#             lis.append(ip)
#         pin=f.tell()
#         set1=set(lis)
#         for j in set1:
#             counts=lis.count(j)
#             if counts>=50:
# #                 hmd.append(j)
# #     print(hmd)
# #     time.sleep(60)
#
#
#
# # import time
# # hmd=[]
# # pin=0
# # with open('a.txt', 'rb') as f:
# #     while True:
# #         lis=[]
# #         for i in f:
# #             ip=i.decode().split(' ')[0]
# #             lis.append(ip)
# #         set1=set(lis)
# #         for j in set1:
# #             counts=lis.count(j)
# #             if counts>=50:
# #                 hmd.append(j)
# #         print(set1)  #58.19.57.100 - -
# #         time.sleep(10)
#
# def hanshuming(a,b):
#     print('调用我了')
#     return(a/b)
# sunm='asdadsfasdf'
# print(sunm)
#
# def select1(qc,jd):
#     sql='select * from table where qc=%s and jd=%s'%((qc,jd))
#     print('zhixing ')
#     return('查询结果')
#
# def select2(qc):
#     sql='select * from table where qc=%s'%((qc))
#     print('zhixing ')
#     return('查询结果')
#
# def select3(jd):
#     sql='select * from table where qc=%s and'%((qc,jd))
#     print('zhixing ')
#     return('查询结果')
#
# dic={1:select1,2:select2,3:select3}
#
# qc=input('shuruqici:').strip()
# jd=input('shuruqijd:').strip()
#
# if qc and jd:
#     dic[1](qc,jd)
# elif qc and not jd:
#     dic[2](qc)
#
#
# def play():
#     print('出去浪')
# def study():
#     print('好好学习')
# def_method={'1':play,'2':study}
# while True:
#     choice=input('请输入你的选择：1代表出去浪；2代表好好学习\n')
#     if choice=='1' or choice=='2':
#         def_method[choice]()
#         break
#     else:
#         print('请输入正确的选择！')
#         continue

#入参
#位置参数
# def hanshuming(a,b):
#     print('调用我了')
#     return(a/b)
# hanshuming(1,2)

#默认参数
# def multi(a,b=2,c=6):
#     return(a**b+c)
# res=multi(3,c=5)
# print(res)
# def read(filename):
#     with open(filename,'r') as f:
#         print(f.read())
#         return f.read()
#
# def write(filename,content=None):
#     if content:
#         with open(filename,'w') as f:
#             f.write(content)
#     else:
#         with open(filename, 'r') as f:
#             print(f.read())
#             return f.read()

#可变参数
# def infos(name,sex,*args):
#     print('name:%s,sex:%s'%((name,sex)))
#     print(args[2])
# infos('星星','男',18,180,'泡妞')

#可变参数
# def infos(name,sex,**kwargs):
#     print('name:%s,sex:%s'%((name,sex)))
#     print(kwargs['age'])
# infos('星星','男',age=18,height=180,爱好='泡妞')

#全局
# bank =[10,5000]#全局变量
# def savemoney():
#     money=100   #局部变量
#     bank.append(200)
# savemoney()
# print(bank)
# # print(money)

# i=5
# def xg(a):
#     # global i    #申明i是一个全局变量
#     a+=1
#     return a
# i=xg(i)
# print(i)

#函数迭代 自己调用自己
# i=0
# def say():
#     global i
#     i+=1
#     print('你调用了我')
#     print(i)
#     if i<997:
#         say()
# say()
# 用迭代函数写斐波拉契数列：[1, 1, 2, 3, 5, 8, 13, 21, 34],数列从第3项开始，每一项都等于前两项之和。
#
# 先用以前的知识来写：[1, 1, 2, 3, 5, 8, 13, 21, 34]
num=int(input('个数:').strip())
lis=[]
a = 1
b = 1
while num>0:
    lis.append(a)
    c=a
    a=b
    b=b+c
    num-=1
print(lis)









