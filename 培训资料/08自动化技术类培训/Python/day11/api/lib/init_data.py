import os, sys
path = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
sys.path.insert(0, path)
from conf.settings import HOST, PORT, USER, PASSWD,USERTB,DBNAME,STUTB
from lib.tools import oprate_sql,secrete_md5,check_in
def creat_db(): #创建数据库，不存在时创建，存在则不用管
    sql='show databases;'
    res=oprate_sql(sql)
    if not check_in(DBNAME,res):
        sql = 'create database %s;'%DBNAME
        oprate_sql(sql)

def creat_tb():#创建表，不存在用户或商品表时创建，存在则不用管，然后初始化数据
    create_sql='show tables;'
    create_res = oprate_sql(create_sql,DBNAME)
    if not check_in(USERTB,create_res):
        sql='create table {tbname}(id int(10) primary key auto_increment,username varchar(100),password varchar(100),money float default 1000.0);'.format(tbname=USERTB)
        oprate_sql(sql, DBNAME)
    if not check_in(STUTB,create_res):
        sql = 'create table {tbname}(id int(10) primary key auto_increment,stu_name varchar(100),stu_sex varchar(4),stu_phone varchar(20),stu_class varchar(20),stu_type varchar(2),opUserId varchar(100));'.format(
            tbname=STUTB)
        oprate_sql(sql, DBNAME)
    insert_sql='select * from {tbname}'.format(tbname=USERTB)
    insert_res=oprate_sql(insert_sql, DBNAME)
    if len(insert_res)==0:
        password=secrete_md5('123456')
        sql = "insert into {table}(username,password) values('admin','{pwd}')".format(table=USERTB,pwd=password)
        oprate_sql(sql,DBNAME)

import os, sys
path = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
sys.path.insert(0, path)
password=secrete_md5('123456')
# sql = "insert into {table}(username,password) values('admin','{pwd}')".format(table=USERTB,pwd=password)
sql1 = "insert into {table}(username,password) values('admin1','{pwd}')".format(table=USERTB,pwd=password)
sql2 = "insert into {table}(username,password) values('admin2','{pwd}')".format(table=USERTB,pwd=password)
sql3 = "insert into {table}(username,password) values('admin3','{pwd}')".format(table=USERTB,pwd=password)
sql4 = "insert into {table}(username,password) values('admin4','{pwd}')".format(table=USERTB,pwd=password)
sql5 = "insert into {table}(username,password) values('admin5','{pwd}')".format(table=USERTB,pwd=password)
sql6 = "insert into {table}(username,password) values('admin6','{pwd}')".format(table=USERTB,pwd=password)
sql7 = "insert into {table}(username,password) values('admin7','{pwd}')".format(table=USERTB,pwd=password)

for i in [sql1,sql2,sql3,sql4,sql5,sql6,sql7]:
    oprate_sql(i,DBNAME)