#-*-coding:cp936-*-
import sys
import mysql_conect

reload(sys)
sys.setdefaultencoding('cp936')

#表total_config
class _total_config_():
    def __init__(self,sysname):
        self.sysname=sysname

    def total_value(self):
        sql_total="select * from total_config where sysname like '%"+self.sysname+"%'"
        total_config=mysql_conect.sql_value(sql_total)
        mysql_total_config=total_config.sql_query("id","url","waittime","browser")
        total_config_id=mysql_total_config[0][0]
        total_config_url=mysql_total_config[0][1]
        total_config_waittime=mysql_total_config[0][2]
        total_browser=mysql_total_config[0][3]
        return total_config_id,total_config_url,total_config_waittime,total_browser
#表config
class _config_():
    def __init__(self,sysname):
        self.sysname=sysname

    def config_count(self):
        sql="select count(0) from config where action_yes_no='YES' and finish_yes_no='NO' and sysname like '%"+self.sysname+"%'"
        config=mysql_conect.sql_value(sql)
        config_count=config.sql_query_count()
        return config_count

    def config_value(self,i):
        sql="select * from  config where action_yes_no='YES' and finish_yes_no='NO' and sysname like '%"+self.sysname+"%'"
        config=mysql_conect.sql_value(sql)
        f_name=config.sql_query("function_name")
        function_name=f_name[i][0]
        return function_name
#表test_case
class _test_case_():
    def __init__(self,sysname,function_name):
        self.sysname=sysname
        self.function_name=function_name

    def test_count(self):
        sql_test_count="select count(0) from test_case where function_name='"+self.function_name+"' and (sysname like '%"+self.sysname+"%' or sysname='all_system') and result='NoRun'"
        test_c=mysql_conect.sql_value(sql_test_count)
        test_count=test_c.sql_query_count()
        return test_count

    def test_value(self):
        sql_test="select * from test_case where function_name='"+self.function_name+"' and (sysname like '%"+self.sysname+"%' or sysname='all_system') and result='NoRun'"
        test=mysql_conect.sql_value(sql_test)
        test_value=test.sql_query("id","test_id","result")
        test_id_value=str(test_value[0][0])
        test_id=str(test_value[0][1]).decode('cp936')
        result=test_value[0][2]
        return  test_id_value,test_id,result

    #字段col的值
    def test_col_value(self,k,test_id_value):
        sql_test_col="select * from test_case where function_name='"+self.function_name+"' and ( sysname like '%"+self.sysname+"%' or sysname='all_system') " \
                     "and id="+test_id_value
        test_col=mysql_conect.sql_value(sql_test_col)
        col="col"+str(k)
        test_col_value=test_col.sql_query(col)
        test_col_value= str(test_col_value[0][0]).decode('cp936')
        return test_col_value

    def test_run_value(self,i):
        sql_test2="select comments,run_result from test_case where function_name='"+self.function_name+"' and (sysname like '%"+self.sysname+"%' or sysname='all_system')"
        test2=mysql_conect.sql_value(sql_test2)
        test_value2=test2.sql_query("comments","run_result")
        comments=test_value2[i][0]
        run_result=test_value2[i][1]
        return comments,run_result

    def update_result_comment(self,test_id,test_result):
        sql_run_result_comment="update test_case set run_result='"+test_result+"' where test_id='"+test_id+"' and (sysname like '%"+self.sysname+"%' or sysname='all_system')"
        run_result_comment=mysql_conect.sql_value(sql_run_result_comment)
        run_result_comment.sql_update()

#测试用例步骤
class _test_page_():
    def __init__(self,sysname,function_name):
        self.sysname=sysname
        self.function_name=function_name

    def test_page_count(self):
        sql_step_c="select  count(0)  from test_page where function_name ='"+self.function_name+"'  and ( sysname like '%"+self.sysname+"%'or sysname='all_system')"
        test_step_c=mysql_conect.sql_value(sql_step_c)
        step_count=test_step_c.sql_query_count()
        return step_count

    def test_page_value(self,i):
        sql_page_value="""select b.element_name , b.page_class, b.find_way, b.page_value from test_page a, page_properties b
                                where  a.page_name=b.page_name and a.element_name=b.element_name """
        sql_page_value=sql_page_value+"and (b.sysname like '%"+self.sysname+"%' or b.sysname ='all_system')"
        sql_page_value=sql_page_value+"and  a.function_name ='"+self.function_name+"' order by a.test_order"
        page=mysql_conect.sql_value(sql_page_value)
        page_value=page.sql_query("element_name","page_class","find_way","page_value")
        element_name=str(page_value[i][0]).decode('cp936')
        page_class=page_value[i][1]
        find_way=page_value[i][2]
        page_value=page_value[i][3]
        return element_name,page_class,find_way,page_value


#步骤组
class _steps_():
    def __init__(self,str_steps_name,sysname):
        self.str_steps_name=str_steps_name
        self.sysname=sysname

    def steps_count(self):
        sql_steps_page_count="""select  count(0)   from steps_page a
                            left join
                            (select   distinct page_name,element_name,page_class,find_way,page_value
                            from page_properties where sysname like '%"""+self.sysname+"%' or sysname ='all_system') b   "
        sql_steps_page_count=sql_steps_page_count+"""on a.page_name=b.page_name and a.element_name=b.element_name
                                where a.steps_name  = '"""+self.str_steps_name+"'   and (a.sysname like '%"+self.sysname+"%' or a.sysname ='all_system')"+" order by a.steps_order"
        sql_steps_page_c=mysql_conect.sql_value(sql_steps_page_count)
        steps_page_count=sql_steps_page_c.sql_query_count()
        return steps_page_count

    def steps_value(self,step_id):
        sql_steps_page="""select  b.*   from steps_page a
                        left join
                        (select   distinct page_name,element_name,page_class,find_way,page_value
                        from page_properties where sysname like '%"""+self.sysname+"%' or sysname ='all_system') b   "
        sql_steps_page=sql_steps_page+"""on a.page_name=b.page_name and a.element_name=b.element_name
                                where a.steps_name  = '"""+self.str_steps_name+"'   and (a.sysname like '%"+self.sysname+"%' or a.sysname ='all_system')"+" order by a.steps_order"
        steps_page=mysql_conect.sql_value(sql_steps_page)
        steps_value=steps_page.sql_query("element_name","page_class","page_value","find_way")
        steps_element_name=steps_value[step_id][0]
        steps_page_class=steps_value[step_id][1]
        steps_page_value=steps_value[step_id][2]
        steps_find_way=steps_value[step_id][3]
        return steps_element_name,steps_page_class,steps_page_value,steps_find_way

    def step_col_value(self,step_id):
        sql_steps_col="select * from steps where steps_name = '"+self.str_steps_name+"' and ( sysname like '%"+self.sysname+"%'or sysname='all_system')"
        steps_col=mysql_conect.sql_value(sql_steps_col)
        steps_col_value=steps_col.sql_query("col"+str(step_id))
        steps_col_value=steps_col_value[0][0]
        return steps_col_value
#检查点
class _check_():
    def __init__(self,check_name,sysname):
        self.check_name=check_name
        self.sysname=sysname

    def check_count(self):
        sql_check_count="""select count(0)  from check_page  t1 ,  check_point t2,page_properties t3
                        where t1.check_point_name=t2.check_point_name
                              and t1.sysname=t3.sysname
                              and t1.page_name=t3.page_name
                              and t1.element_name=t3.element_name
                              and (t3.sysname like '%"""+self.sysname+"%' or t3.sysname='all_system') " \
                                  "and t1.check_point_name  ='"+self.check_name+"' order by t1.check_order"
        check_c=mysql_conect.sql_value(sql_check_count)
        check_count=check_c.sql_query_count()
        return check_count

    def check_value(self,check_index):
        sql_check="""select t3.*  from check_page  t1 ,  check_point t2,page_properties t3
                where t1.check_point_name=t2.check_point_name
                      and t1.sysname=t3.sysname
                      and t1.page_name=t3.page_name
                      and t1.element_name=t3.element_name
                      and (t3.sysname like '%"""+self.sysname+"%' or t3.sysname='all_system') " \
                         "and t1.check_point_name = '"+self.check_name+"' order by t1.check_order"
        check=mysql_conect.sql_value(sql_check)
        check_value=check.sql_query("element_name","page_class","page_value","find_way")
        check_element_name=check_value[check_index][0]
        check_page_class=check_value[check_index][1]
        check_page_value=check_value[check_index][2]
        find_way=check_value[check_index][3]
        return check_element_name,check_page_class,check_page_value,find_way

    def check_col_value(self,check_index):
        sql_check_col="select  *   from check_point  where (sysname  like '%"+self.sysname+"%'or sysname='all_system')"\
                      +"and check_point_name = '"+self.check_name+"'"
        check_col=mysql_conect.sql_value(sql_check_col)
        check_col_value=check_col.sql_query("col"+str(check_index))
        check_col_value=check_col_value[0][0]
        return check_col_value

