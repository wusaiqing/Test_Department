# class Person(object):
#     a=123   #类变量
#     def __init__(self,name,age): #写死的格式，构造函数
#         self.b=456   #实例变量
#         self.name=name  #实例变量
#         self.age=age
#         # self.pri()
#
#     @classmethod    #类方法
#     def class_pri(self):  #类方法
#         print(self.a)
#
#     @staticmethod #静态方法
#     def sta_pri(a,b):  #静态方法
#         print(a+b)
#
#     @property   #属性方法
#     def pro_pri(self):  #属性方法
#         return(self.name,self.age)
#
#
#     def pri(self):  #实例方法
#         print(self.name,self.age)
#
#     def __del__(self):  #析构函数，在代码运行完成之后，会执行的函数
#         print('done')


# shilihua1=Person('xiaogang',18)
# shilihua2=Person('dalei',16)
# Person.class_pri()
# res=shilihua1.pro_pri()
# print(res)
# print(Person.class_pri())
# print(shilihua1.b)
# shilihua1.pri()
# shilihua2.pri()


# class gtar(Person):
#     def gtaqy(self):
#         print('踏实 激情')
#
# class cl(gtar):
#     pass
#
# cl1=cl('zca',10000)
# cl1.gtaqy()
# cl1.pri()
import pymysql


class Mysql(object):
    def __init__(self,host,port,user,passwd,db,charset='utf8'):
        self.host=host
        self.port=port
        self.user=user
        self.passwd=passwd
        self.db=db
        self.charset=charset
        self.link()

    def link(self):
        try:
            self.conn=pymysql.connect(host=self.host,port=self.port,user=self.user,passwd=self.passwd,db=self.db,charset=self.charset)
            self.cur=self.conn.cursor()
        except Exception as e:
            print(e)

    def exce(self,sql):
        try:
            if sql.startswith('select') or sql.startswith('show'):
                self.cur.execute(sql)
                res = self.cur.fetchall()
                return res
            elif sql.startswith('insert') or sql.startswith('delete') or sql.startswith('update'):
                self.cur.execute(sql)
                self.conn.commit()
            else:
                print('sql语法错误')
        except Exception as e:
            print(e)

    def __del__(self):
        self.cur.close()
        self.conn.close()

stu=Mysql('10.1.130.102',3306,'root','root','login')
res=stu.exce('select * from student')
print(res)



