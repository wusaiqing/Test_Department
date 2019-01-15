# print('Hello World!')
# age=18 #int类型
#
# height=180.2 #float类型
# #list dict tuple set
# print(type(height))
# name1='xiaoagng' #str类型
# name2="xiaoagng"
# name3='''xiaoagng'''
# str1="I'm xiaogang" #当字符串有单引号时，外面用双引号
# str2='Xiaogang say:"Hello!"'  #当字符串有双引号时，外面用单引号
# str3='''Xiaogang say:"Hello!I'm xiaogang"'''  #当字符串既有有双引号又有单引号时，外面用三引号
# print('打我啊！')   #被注释掉了，运行结果没有这个
# name='dalei'
# age=18
# height=182.321368435215
# money=100
# print("Welcome to 'From zero single row':"+name)
# print("Welcome to 'From zero single row':",name,'hello')
# print("Welcome to 'From zero single row':%s,hello,%s"%(name,age))
# print("Welcome to 'From zero single row':%s,hello,%d"%(name,age))
# print("Welcome to 'From zero single row':%s,hello,%.4f"%(name,height))
# print("Welcome to 'From zero single row':{host}! 'You have money:{money}元'".format(money=money,host=name))
# print("I'm {name}  {age}".format(name=name,age=age))

# name=input('请输入您的姓名：')
# print(name)

#练习，输入名字和年龄，然后格式化打印：你的名字是：xxx，你的年龄是：xx。
# name=input('请输入您的姓名:')
# age=input('请输入您的年龄：')
# print('你的名字是：%s，你的年龄是：%s。'%(name,age))
# print('你的名字是：::{name}，你的年龄是：{age}。'.format(name=name,age=age))
# i=4
# if i<3:
#     print(i)
# elif i<6:
#     print('aaaa')
# else:
#     print('haha')
#
# age=input('Please input your age:')
# age=int(age)
# if age<=74: #如果满足age<=45这个条件，打印下面这个语句，程序结束
#     print('你是老年')   #注意缩进，python里没有其他的标点符号来标识代码，全部考缩进来处理
# elif age<=59:   #如果满足age<=59这个条件，打印下面这个语句，程序结束
#      print('你是中年')
# elif age<=45:   #如果满足age<=74这个条件，打印下面这个语句，程序结束
#     print('你是青年')
# else :  #如果上诉条件都不满足，打印下面这个语句，程序结束
#     print('你是长寿老人')


# age=input('Please input your age:')

#非空即真
# if '':  #字符串为空，所以为假，进入下一个判断
#     print('假')
# elif 'asd': #字符串有值不为空，所以为真，这里会打印真
#     print('真')
# else:
#     print('over')
#
# #非0即真
# if 0:  #值是0，所以为假，进入下一个判断
#     print('假')
# elif 123: #值不是0，所以为真，这里会打印真
#     print('真')
# else:
#     print('over')
#
# #非None即真
# if None:  #值为None，所以为假，进入下一个判断，这个类似于''
#     print('假')
# elif 'asd': #字符串有值不为空，所以为真，这里会打印真
#     print('真')
# else:
#     print('over')


# print(0 and 1)
# print(1 and 2)
# print(0 or 1)
# print(1 or 0)
#



# lis=[1,2,3]

# i=0
# while i<=10:
#     i += 1
#     if i==5:    #当i的值等于5时，执行下面的break
#         break   #while遇到break时，就结束掉整个循环了，所以这段代码运行的结果是 打印1-4
#     print(i)
# else:   #当上面的while循环正常结束，运行else
#     print('over')   #这里非正常结束，所以打印1-4后，不打印over
#
#
# i=0
# while i<=10:
#     i += 1
#     if i==5:    #当i的值等于5时，执行下面的continue
#         continue   #while遇到continue时，就结束掉本次循环，继续下一个循环，所以这段代码运行的结果是 打印1-4，5-11
#     print(i)
# else:   #当上面的while循环正常结束，运行else
#     print('over')   #这里会正常结束，所以打印1-4，5-11后，会打印over

# name='dalei'
# #list
# lis=['a','b','c',1,3,name]
# for i in lis:
#     print(i)


# names = ['marry','lily','lilei']
# for name in names:
#     if name == 'lily':
#         print(name)
#         break #如果名字等于lily的话，就不执行continue下面的代码了，再循环下一次
#     else:#for也有个else，不过这个一般没人写它，意思是如果正常循环完了去做什么
#         print('over')

#需求分析
#1.生成一个随机数
#2.用输入一个数字
#3.判断数字：
    #a.猜小了，继续2
    #b.猜大了，继续2
    #c.答对了，结束掉

# import random
# num=random.randint(1,101)
# while True:
#     try:
#         user_num=int(input('请输入猜的数字：'))
#         if user_num<num:
#             print('猜小了')
#             continue
#         elif user_num>num:
#             print('猜大了')
#             continue
#         else:
#             print('猜对了，game over！')
#             break
#     except Exception as e:
#         print(e)



# for i in range(2,101):
#     fg = 0
#     for j in range(2,i-1):
#         if i%j == 0:
#             # fg = 1
#             break
#     if fg == 0:
#         print(i)

