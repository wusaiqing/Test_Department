# -*- coding: cp936 -*-
import mysql_conect
import writelog
import sqlserver
logerr=writelog.LOG("执行对比函数")
class comparison():
    def __init__(self,test_id,function_name,sysname):
        self.sysname=sysname
        self.function_name=function_name
        sql="select run_result,compare_way,hope_way,hope_result,comments from test_case where test_id='"+test_id+"' "
        sql=sql+" and function_name='"+self.function_name+"'  and sysname='"+self.sysname+"'"
        test=mysql_conect.sql_value(sql)
        test_comp=test.sql_query("run_result","compare_way","hope_way","hope_result","comments")
        self.run_result=str(test_comp[0][0])
        self.compare_way=str(test_comp[0][1])
        self.hope_way=str(test_comp[0][2])
        self.hope_result=str(test_comp[0][3])
        self.run_comments=str(test_comp[0][4])
        self.test_id=test_id

    def run_result_pass(self):
        sql="update test_case set result='PASS' where test_id='"+self.test_id+"' "
        sql=sql+"  and function_name='"+self.function_name+"' and sysname='"+self.sysname+"'"
        run_result=mysql_conect.sql_value(sql)
        run_result.sql_update()

    def run_result_fail(self):
        sql="update test_case set result='FAIL' where test_id='"+self.test_id+"' and sysname='"+self.sysname+"' and function_name='"+self.function_name+"'"
        run_result=mysql_conect.sql_value(sql)
        run_result.sql_update()

    def result(self):
        try:
            if self.hope_way=="数据库":
                ms=sqlserver.MSSQL(self.sysname)
                hope_result=str(ms.ExecQuery(self.hope_result))
            else:
                hope_result=self.hope_result
        except:
            logerr.error()
        try:
            if self.compare_way=="等于":
                if self.run_result==hope_result:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                    
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()

            elif self.compare_way=="不等于":
                if self.run_result!=hope_result:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()

            elif self.compare_way=="运行包含期望":
                if bool(self.run_result.find(hope_result)+1)==True:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()

            elif self.compare_way=="运行被包含期望":
                if bool(hope_result.find(self.run_result)+1)==True:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()

            elif self.compare_way=="运行>期望":
                if self.run_result>hope_result:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()

            elif self.compare_way=="运行>=期望":
                if self.run_result>=hope_result:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()

            elif self.compare_way=="运行<期望":
                if self.run_result<hope_result:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()

            elif self.compare_way=="运行<=期望":
                if self.run_result<=hope_result:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_pass()
                else:
                    comparison(test_id=self.test_id,function_name=self.function_name,sysname=self.sysname).run_result_fail()
        except:
            logerr.error()

if __name__=='__main__':
    comparison("login_2","ve").result()