# -*- coding: cp936 -*-
import pymssql
import mysql_conect
import MySQLdb as mdb

class MSSQL:
    def __init__(self,sysname):
        sql="select * from total_config where sysname='"+sysname+"'"
        test=mysql_conect.sql_value(sql)
        value=test.sql_query("host","user","pwd","db","db_class")
        self.host=str(value[0][0]).strip()
        self.user=str(value[0][1]).strip()
        self.pwd=str(value[0][2]).strip()
        self.db=str(value[0][3]).strip()
        self.db_class=str(value[0][4]).strip()

    def _GetConnect(self):
        if not self.db:
            raise (NameError,"没有设置数据库信息")
        if self.db_class=="SQLServer":
            self.conn=pymssql.connect(host=self.host,user=self.user,password=self.pwd,database=self.db,charset="utf8")
            cur=self.conn.cursor()
        elif self.db_class=="Mysql":
            self.conn = mdb.connect(self.host, self.user, self.pwd, self.db,charset='utf8')
            cur=self.conn.cursor()
        if not cur:
            raise (NameError,"连接数据库失败")
        else:
            return  cur

    def ExecQuery(self,sql):
        cur=self._GetConnect()
        cur.execute(sql)
        resList = cur.fetchall()
        #查询完毕后必须关闭连接
        self.conn.close()
        return resList

    def ExecUpDate(self,sql):
        cur=self._GetConnect()
        cur.execute(sql)
        self.conn.commit()
        self.conn.close()

if __name__ == '__main__':
    ms=MSSQL('wl')
    hope_result="select function_name from test_case where id=17 "
    hope_result=str(ms.ExecQuery(hope_result))
    print "function_name=",hope_result