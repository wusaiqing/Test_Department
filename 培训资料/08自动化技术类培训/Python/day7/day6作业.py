# 题目如下：
# 商品文件products.txt里存的内容如下：
# {'mac': 6500, '被子': 100.0, '手机': 1.0, '宝马': 100}
# 用户文件user.txt里存的内容如下：
# {'dalei': {'money': 1003.0, 'role': 2, 'pass': '123456', 'products': ['mac']},'xg': {'money': 1000, 'role': 1, 'pass': '123456', 'products': ['mac']}}
# 管理员可以操作：
# 1.给用户充值，输入用户名，修改money，100000
# 2.添加商品
# 3.logout
# 普通用户可以操作：
# 1.看商品信息
# 2.买东西，a.东西加products，money要修改
# 3.查看自己的商品和余额
# 4.退出
#
# 需求分析：
# 1.商品、用户文件 初始化数据
# 2.登录  读取用户文件
# 3.登录获取角色，给出相应菜单  字典获取用户角色，定义字典 给用户选择相应的操作
# 4.管理员
#     1.给用户充值，输入用户名，修改money，100000
#     2.添加商品
#     3.logout
# 5.用户
#     1.看商品信息
#     2.买东西，a.东西加products，money要修改
#     3.查看自己的商品和余额
#     4.退出

#定义读写文件
def op_file(filename,content=None):
    if content:
        with open(filename,'w',encoding='utf-8') as f:
            f.write(str(content))
    else:
        with open(filename,'r',encoding='utf-8') as f:
            res=eval(f.read())
            return res

#定义校验money的输入合法性
def checkmoney(money):
    if money.isdigit():
        return True
    elif money.count('.')==1:
        if money.split('.')[0].isdigit() and money.split('.')[1].isdigit():
            return True
    return False
#定义登录
def login():
    username=input('用户名：')
    password=input('密码：')
    users=op_file('user.txt')
    if username in users and users[username]['pass']==password:
        print('欢迎【%s】登录'%username)
        return username,users[username]['role']
    else:
        print('登录失败！')
#管理员
#1.给用户充值，输入用户名，修改money，100000
def charge():
    username = input('用户名：').strip()
    money = input('金额：').strip()
    users = op_file('user.txt')
    if username in users and checkmoney(money):
        users[username]['money']+=float(money)
        op_file('user.txt',content=users)
# 2.添加商品
def add():
    sp_name = input('商品名称：').strip()
    sp_money = input('金额：').strip()
    sp = op_file('products.txt')
    if checkmoney(sp_money):
        sp[sp_name]=float(sp_money)
        op_file('products.txt', content=sp)

# 3.logout
def logout():
    exit('退出程序')

#5.用户
# 1.看商品信息
def show():
    sp = op_file('products.txt')
    for i in sp:
        print('商品：%s，价钱：%s'%(i,sp[i]))

# 2.买东西，a.东西加products，money要修改
def buy(user):
    pro=input('买的商品migncheng:')
    sp = op_file('products.txt')
    users = op_file('user.txt')
    if pro in sp:
        if users[user]['money']>=sp[pro]:
            users[user]['money'] -= sp[pro]
            users[user]['products'].append(pro)
            op_file('user.txt', content=users)
        else:
            print('请联系管理员充值！')
    else:
        print('商品未上架！')
        buy(user)

# 3.查看自己的商品和余额
def look(user):
    users = op_file('user.txt')
    print('您的购物车有：%s'%str(users[user]['products']))
    print('您余额为：%.2f'%users[user]['money'])

choice_admin={'1':charge,'2':add,'3':logout}
choice_user={'1':show,'2':buy,'3':look,'4':logout}

def run():
    user,role=login()
    if role==1:
        while True:
            choice=input('请输入您的选择：1.充值；2.添加商品；3.退出')
            if choice=='1' or choice=='2' or choice=='3':
                choice_admin[choice]()
            else:
                print('输入有误！')
    else:
        while True:
            choice=input('请输入您的选择：1.查看商品；2.购买；3.查询购物车和余额；4.退出')
            if choice=='1' or choice=='4':
                choice_user[choice]()
            elif choice=='2' or choice=='3':
                choice_user[choice](user)
            else:
                print('输入有误！')

if __name__=='__main__':
    run()







