using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace test2
{
    class sqlclass
    {
        public static string total_config_sql()
        {
            string sql = @"select id as 序号, 
                                  url,  
                                  waittime as 加载时间, 
                                  browser as 浏览器,
                                  sysname as 被测系统名称,
                                  db_class as 数据库类型,
                                  host as 数据库ip地址, 
                                  user as 数据库用户名,
                                  pwd as 数据库密码, 
                                  db as 数据库名称 ,
                                  '编辑' as 编辑 ,
                                  '删除' as 删除 
                            from total_config where 1=1 ";
            return sql;
        }
        public static string config_sql()
        {
            string sql = @"select configid as 序号,
                                  function_name as 功能点名称,
                                  action_yes_no as 是否执行 ,
                                  finish_yes_no as 是否执行完毕,
                                  sysname as 被测系统名称,
                                  '编辑' as 编辑 ,
                                  '删除' as 删除 
                            from config where 1=1  ";
            return sql;

        }
        public static string iframe_sql()
        {
            string sql = @"select id as 序号,
                                  iframe_name,
                                  sysname as 被测系统名称,
                                  '编辑' as 编辑 ,
                                  '删除' as 删除 
                           from iframe where 1=1 ";
            return sql;
        }

        public static string page_properties_sql()
        {
            string sql = @"select 
                                id as 序号,
                                page_name as 页面名称,
                                element_name as 元素名称,
                                page_class as 页面控件类型,
                                page_value as 页面属性值,
                                find_way as 查找方式,
                                sysname as 被测系统名称,
                                check_find as 检测,
                                '编辑' as 编辑 ,
                                '删除' as 删除 
                          from page_properties  where  1=1   ";
            return sql;
        }

        public static string check_point_sql()
        {
            string sql = @"select 
                           check_id as 序号,
                           function_name as 功能点名称,
                           check_point_name as 检查点名称,
                           element_name as 元素名称,
                           element_class as 页面控件类型,
                           find_way as 查找方式,
                           page_value as 页面属性值,
                           sysname as 被测系统名称,
                           '编辑' as 编辑 ,
                           '删除' as 删除 
                           from  check_point  where  1=1   ";
            return sql;
        }


        public static string test_page_sql()
        {
            string sql = @"select 
                             id as 序号,
                             test_order as 执行顺序,
                             function_name as 功能点名称,
                             page_name as 页面名称,
                             element_name as 元素名称,
                             sysname as 被测系统名称,
                             '编辑' as 编辑 ,
                             '删除' as 删除 
                           from  test_page  where  1=1   ";
            return sql;
        }

        public static string add_step_page_sql()
        {
            string sql = @"select distinct page_name as 页面名称 from page_properties where 1=1  ";
            return sql;
        }
        public static string add_step_e_sql()
        {
            string sql = @"select  id as 序号,
                         page_name as 页面名称,
                         element_name as 元素名称,
                         sysname as 被测系统名称
                         from page_properties  where 1=1  ";
            return sql;
        }
    }
}
