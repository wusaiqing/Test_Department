import datetime, time
# #输入时间戳，打印格式化时间  年月日 时分秒；输入格式化时间，输出时间戳
# print(time.timezone)  # 和标准时间相差的时间，单位是s
# print(time.time())  # 获取当前时间戳，从unix元年开始到现在过了多少秒
# print(time.sleep(1))  # 休息几s
# print(112)
# print(time.gmtime())  # 把时间戳转换成时间元组，如果不传的话，默认取标准时区的时间戳
# print(time.localtime())  # 把时间戳转换成时间元组，如果不传的话，默认取当前时区的时间戳
# # today=time.localtime()
# # print(today)
# # print(time.mktime(time.localtime()))  # 把时间元组转换成时间戳
# print(time.strftime("%Y%m%d%H%M%S",time.localtime()))  # 将时间元组转换成格式化输出的字符串
# print(time.strptime("20160204 191919", "%Y%m%d %H%M%S"))  # 将格式化的时间转换成时间元组
# print(time.struct_time)  # 时间元组
# print(time.asctime())  # 时间元转换成格式化时间
# print(time.ctime())  # 时间戳转换成格式化时间
# import datetime
# now = datetime.datetime.now()  # 当然时间格式化输出
#
# print(now)
# print(str(now))
# print(datetime.datetime.now() + datetime.timedelta(3))  # 3天后的时间
# print(datetime.datetime.now() + datetime.timedelta(-3))  # 3天前的时间
# print(time.strftime("%Y%m%d"))
# import time
# today_timestamp=334234200 #当前时间戳
# time.localtime()#当前的时间元组
# time_tuple=time.gmtime(today_timestamp)#把时间戳转成时间元祖
# res=time.strftime('%Y-%m-%d',time_tuple)
# def transfer(timestamp,format='%Y-%m-%d %H:%M:%S'):
#     '''
#     把时间戳转成格式化输出的字符串
#     '''
#     time_tuple = time.gmtime(timestamp)#先把时间戳转成时间元组
#     res = time.strftime(format, time_tuple) #格式化时间
#     return res
# def transfer2(time_str,format='%Y%m%d%H%M%S'):
#     '''
#     把格式化好的时间字符串转成时间戳
#     '''
#     time_tuple = time.strptime(time_str, format)
#     res = time.mktime(time_tuple)
#     print(res)
#     return int(res)
# import datetime
# now = datetime.datetime.now()  # 当然时间格式化输出
# # print(str(now))
# print(datetime.datetime.now() + datetime.timedelta(3))  # 3天后的时间
# print(datetime.datetime.now() + datetime.timedelta(-3))  # 3天前的时间
# #
#  transfer2(three_day,'%Y-%m-%d %H%M%S.')


# def transfer(timestamp,format='%Y-%m-%d %H:%M:%S'):
#     import time
#     '''
#     把时间戳转成格式化输出的字符串
#     '''
#     time_tuple = time.gmtime(timestamp)#先把时间戳转成时间元组
#     res = time.strftime(format, time_tuple) #格式化时间
#     return res
# def transfer2(time_str,format='%Y%m%d%H%M%S'):
#     import time
#     '''
#     把格式化好的时间字符串转成时间戳
#     '''
#     time_tuple = time.strptime(time_str, format)
#     res = time.mktime(time_tuple)
#     print(res)
#     return int(res)
# def get_other_time(day,format='%Y%m%d%H%M%S'):
#     #这个函数是用来获取N天前的时间，或者N天后的时间
#     #day如果传入负数，那么就是几天前的。传入正数，就是几天后的
#     import datetime
#     res = datetime.datetime.now()+datetime.timedelta(day)#取几天后的
#     res_time = res.strftime(format)#格式化时间
#     print(res_time)
#     return res_time

#执行sql，如果是查询，返回查询结果；如果增删改，我们执行。

import pymysql
# from pymysql.cursors import DictCursor
coon = pymysql.connect(host='127.0.0.1',port=3306,user='root',passwd='root',db='test',charset='utf8')
cur = coon.cursor()#建立游标,仓库管理员,指定游标类型，返回字典
# sql='select * from stu;'
insert_sql = 'insert into stu(name,age) VALUE ("小刚",18);'
# cur.execute(insert_sql)
cur.execute(insert_sql)#执行sql语句
# for c in cur:#直接循环游标，每次循环的时候就是每一行的数据
#     print(c)
# res = cur.fetchall()#获取sql语句执行的结果,一次性全部获取
coon.commit()#提交
# print(res)
cur.close()
coon.close()
def op_mysql(host,user,passwd,db,sql,charset='utf8',port=3306):
    import pymysql
    from pymysql.cursors import DictCursor
    coon = pymysql.connect(host=host,user=user,passwd=passwd,db=db,charset=charset,port=port)
    cur = coon.cursor(DictCursor)#指订返回数据的类型是字典
    cur.execute(sql)
    if sql.strip().startswith('select'):
        res = cur.fetchall()
    else:
        coon.commit()
        res = 'ok'
    cur.close()
    coon.close()
    print(res)
    return res
# sql1='insert into stu(name,age) VALUE ("杨一","18");'
# sql2='update stu set name="杨二" where id=1;'
# sql3='delete from stu where id=8;'
# sql4='select * from stu;'
# op_mysql(host='127.0.0.1',user='root',passwd='root',db='test',sql=sql1)
# op_mysql(host='127.0.0.1',user='root',passwd='root',db='test',sql=sql2)
# op_mysql(host='127.0.0.1',user='root',passwd='root',db='test',sql=sql3)
# op_mysql(host='127.0.0.1',user='root',passwd='root',db='test',sql=sql4)



def op_mysql(host,port,user,passwd,dbname,sql,charset='utf8'):
    try:
        conn=pymysql.connect(host=host,port=port,user=user,passwd=passwd,db=dbname,charset=charset)
    except Exception as e:
        print(e)
    try:
        cur=conn.cursor()
    except Exception as e:
        print(e)
    try:
        if sql.startswith('select') or sql.startswith('show'):
            cur.execute(sql)
            res=cur.fetchall()
            return res
        elif sql.startswith('insert') or sql.startswith('delete') or sql.startswith('update'):
            cur.execute(sql)
            conn.commit()
        else:
            print('sql语法错误')
    except Exception as e:
        print(e)
    finally:
        cur.close()
        conn.close()
sql='select * from student;'
insert_sql = 'insert into stu(name,age) VALUE ("小刚",28);'
print(op_mysql('10.1.130.102',3306,'root','root','login',sql))

#1.找到目录下面前三天的日志，删掉  20180109101010.log
#2.修改day8作业，改为数据库存 用户、商品










