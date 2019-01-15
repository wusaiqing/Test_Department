# import day8,time
# from day8 import logout as a
# time.sleep(1)
# a()
#安装第三方模块：
#1.pip install 第三方模块的名称
#2.a.下载第三方模块    b.解压  c.进入到解压的这个路径，进入dos窗口输入：python setup.py install
#3.进入settings

#导入模块的时候，顺序：先在当前目录找模块名称的py文件，找不到再去环境变量里
# import sys,os
# # print(os.environ)
# sys.path.append(r'D:\1自动化\Python\day8\test1\test2')
# sys.path.insert(0,r'D:\1自动化\Python\day8\test1\test3')
# print(sys.path)
# from nose_parameterized import parameterized as a



import os,sys
print(sys.path)#获取python的环境变量,以list形式返回
#输出：['E:\\study\\Automantic\\jxz-code\\Course4']
print(os.listdir('./'))#获取指定目录下的文件及文件夹名称，以list形式返回
#输出：['access.log', 'b.txt', 'c.txt', 'course4作业.py', 'goods.txt', 'user_info.txt', '、', '函数.py']
print(os.getcwd())#获取当前目录
#输出：E:\study\Automantic\jxz-code\Course4
# print(os.chdir('E:\study\Automantic\jxz-code'))#更换当前目录
print(os.rename('c.txt','a.txt'))#修改文件名称
print(os.mkdir('新目录'))#创建文件夹
print(os.rmdir('新目录'))#删除文件夹（只能删除空文件夹）
print(os.makedirs('E:\\xixi\\haha'))#依次创建目录
print(os.removedirs('E:\\xixi\\haha'))#依次删除非空目录
print(os.sep)#获取当前操作系统的路径分隔符
#输出：\
print(os.environ)#获取当前操作系统的环境变量
#输出：environ({'ALLUSERSPROFILE': 'C:\\ProgramData'})
print(os.pathsep)#获取当前系统的环境变量中每个路径的分隔符，linux是:，windows是;
#输出：;
print(os.path.abspath(__file__))#获取当前文件的绝对路径
#输出：E:\study\Automantic\jxz-code\Course4\函数.py
print(os.path.dirname(os.path.abspath(__file__)))#获取指定路径的父目录
#输出：E:\study\Automantic\jxz-code\Course4
print(os.path.isdir(os.path.abspath(__file__)))#判断指定路径是不是一个文件夹
#输出：False
print(os.path.isfile(os.path.abspath(__file__)))#判断指定路径是不是一个文件
#输出：True
print(os.path.join('一级','二级','三级','haha.txt'))#将内容以当前操作系统的路径分隔符拼接成一个路径
#输出：一级\二级\三级\haha.txt
print(os.path.split('E:\study\Automantic\jxz-code\Course4\函数.py'))#分割路径和文件名
#输出：('E:\\study\\Automantic\\jxz-code\\Course4', '函数.py')
print(os.path.exists('E:\study\Automantic\jxz-code\Course4\函数.py'))#判断目录或文件是否存在
#输出：True







