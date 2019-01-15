# 1、内置函数
a=int('123')
b=float('123')
# a=str(123)
# a=tuple('123')
# a=set('123')
# a=list('123456')
# a=dict(name='zdd', age=18)
# print(a,type(a))  # 查看类型
# print(len(a))  # 看长度，其实是元素的个数
# # print(id(a))  # 看内存地址
# lis=sorted(a, reverse=True)  # 排序
# print(a,type(a))  # 查看类型
# print(lis)
#http://www.cnblogs.com/znyyy/p/7716077.html
# sorted([1, 0, 5, 9, 9, 3, 453232, 568534], reverse=True)  # 倒叙排列
# lis=reversed(a)  # 反转
# print(list(lis),type(lis))  # 查看类型
# print(isinstance(a, list))  # 判断什么类型，返回true或者false
#
# lis=[1,4,3,8,2,9,10,{}]
# print(all(lis))#判断可迭代对象里头是否存在不为真的元素，如果存在不为真的元素则返回False，否则True
# print(any(lis))#判断可迭代对象里头是否存在为真的元素，如果存在为真的元素则返回True，否则False
# print(bin(10).replace('0b',''))#10进制转换为二进制
# print(bool({}))#把一个对象转换成布尔类型，非空即真，非0即真
# from hashlib import md5
# m=md5()
# print(dir(m))#dir列出m的方法
# eval('print("haha")')
# exec('print("haha")')
# b=exec('[1,2,3]')#exec执行代码时，不返回值，这里b是none
# c=eval('[1,2,3]')#eval执行代码时，返回值，多用于表达式，这里赋值成功
# print(b)#会输出None
# print(c)#会输出[1,2,3]
# exec("def hs():print(123)")#可执行复杂代码，这里正常余兴
# eval("def hs():print(123)")#不可以执行复杂代码，会报错
# print(round(66.66666,3))#round(float,int)保留float小数的int位
# xs=66.66666
# print('%.3f'%xs)
# print(sum([1,6,9]))#求和
# print(min([1,6,9]))#取最小值
# print(max([1,6,9]))#取最大值
# print(hex(34523).replace('0x',''))#10进制转16进制
# print(hash('asd'))#将一个字符串hash成数字
# print(globals())#返回程序内所有的变量，返回的是一个字典
# print(locals())#返回局部变量
lis2=[1,2,3,4,5,6,7,8,9,10]
lis=['123',456,{"age":18},0,[],(1,2,3),(),{},'False']
# def my_char(var):
#     return var
# res=filter(my_char,lis)#filter(fun,list),list只要是可迭代类型即可，循环list里的值，调用fun函数，当fun函数返回为真时，保留list的迭代值，否则，删掉
# print(list(res))#res得到的是一个对象，需要list方法接收值
#
# def maps(var):
#     return str(var)+'值都变咯'
# res1=map(maps,lis)#map(fun,list),list只要是可迭代类型即可，循环list里的值，调用fun函数，fun函数返回值作为新值保存到rese1对象里
# print(list(res1))
# #
#
#读excel
import xlrd,xlwt,xlutils,os
from xlutils.copy import copy
# book=xlrd.open_workbook('自动化课程安排.xlsx')#打开一个excel文件对象
# sheet=book.sheet_by_name('课程安排')#通过sheet 名称指定工作sheet
# # sheet=book.sheet_by_index(0)#通过sheet 索引指定工作sheet
# all_sheets=book.sheet_names()#获取所有sheet名称，返回一个list
# print(all_sheets)
# print(sheet.cell(6,1).value)#（行，列）通过cell获取指定坐标的数据
# print(sheet.nrows)#获取sheet页的行数
# print(sheet.ncols)#获取sheet页的列数
# print(sheet.row_values(0))#获取指定行数的数据
# print(sheet.col_values(0))#获取指定列数的数据
# #写excel
# workbook=xlwt.Workbook()#打开一个excel文件对象
# wsheet=workbook.add_sheet('sheet1')#添加一个sheet
# wsheet.write(0,0,'test')#写入数据
# workbook.save(r'D:\test.xls')#保存excel，后缀必须是.xls，否则报错
#修改excel
ubook=xlrd.open_workbook('自动化课程安排.xlsx')#打开一个excel文件对象
mbook=copy(ubook)#复制读到的文件对象
msheet=mbook.get_sheet(0)#获取sheet页，注意这里只能用get_sheet(0)方法，指定下标
msheet.write(0,0,'静姐')#写入数据
msheet.write(0,2,'星星')#写入数据
mbook.save('new.xls')#保存数据
# os.remove('stu.xls')
# os.rename('new.xls','stu.xls')