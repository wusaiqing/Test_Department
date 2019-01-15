#函数
# def name():
#     print('这是一个函数')
# name()
# def return_data(a,b):
#     print(a+b)
# res=return_data(1,2)
# print(res)

#参数类型
#1.位置参数
# def infos(name,age):
#     print(name,age)
# infos(18,'dalei')
#2.默认参数
# def infos(name,age,default_value='男'):
#     print(name,age,default_value)
# infos('dalei',18,default_value='女')
#3.可变参数
# def infos(name,age,default_value='男',*args):
#     print(name,age,default_value)
#     print(args[0])
# infos('dalei',18,'女',180,70)
#4.关键字参数
# def infos(name,age,default_value='男',*args,**kwargs):
#     print(name,age,default_value)
#     print(kwargs)
# infos('dalei',18,'女',180,70,money=100,house='1栋')

#判断输入的money是否是小数：
money=input('请输入需要充值的金额：')#1.1,1.2
def checkmoney(money):
    if money.isdigit():
        return True
    elif money.count('.')==1:
        if money.split('.')[0].isdigit() and money.split('.')[1].isdigit():
            return True
    return False
print(checkmoney(money))

