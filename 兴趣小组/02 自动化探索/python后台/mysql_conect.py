# -*- coding: cp936 -*-
#!/usr/bin/env python
import MySQLdb as mdb
import re
import sys
import linecache
import os

reload(sys)
sys.setdefaultencoding('utf-8')

file_object=open("test2.exe.config","r")

count=len(file_object.readlines())
for i in range(count+1):
    Line_value=linecache.getline(r"test2.exe.config",i).decode('gbk','ignore').encode('utf-8')
    if bool(Line_value.find('key')+1)==True:
        break

Line_value=linecache.getline(r"test2.exe.config",i).decode('gbk','ignore').encode('utf-8')
r,r1,a=Line_value.partition("Database='")
Database,s1,b=a.partition("';Data Source='")
Ip,c2,c=b.partition("';User Id='")
username,d1,d=c.partition("';Password='")
password,e2,e3=d.partition("';charset=")


con = mdb.connect(Ip, username, password, Database,charset='utf8')

class sql_value:
    def __init__(self,sql):
        self.sql=sql

    def sql_query(self,*col_value):
        #with con:
        cur=con.cursor(mdb.cursors.DictCursor)
        cur.execute(self.sql)
        #numrows=int(cur.rowcount)
        col_value=str(col_value).strip("()")
        col_value_count=str(col_value).count("'")
        col_value=str(col_value).split(",")
        if col_value_count>2:
            col_count=str(col_value).count(",")
        else:
            col_count=0
        rows = cur.fetchall()
        #arr=[range(0,numrows+col_count),range(0,col_count+1)]
        arr=[[0 for x in range(1000)] for y in range(1000)]
        i=0
        for row in rows:
            for j in range(col_count+1):
                #t=col_single[j]
                t=col_value[j]
                t=t.replace(" ","")
                t=t.strip("''")
                arr[i][j]=row[t]
            i=i+1

        return  arr

    def sql_query_count (self):
        cur=con.cursor()
        #sql="select count(0) from config where action_yes_no='YES' and finish_yes_no!='YES' "
        cur.execute(self.sql)
        rows = cur.fetchall()
        for rowcount in rows:
            return rowcount[0]

    def sql_update(self):
        cur=con.cursor()
        cur.execute(self.sql)
        con.commit()

if __name__=='__main__':
    sql2="update aa set aaa='233'"
    config=sql_value(sql2)
    config.sql_update()

