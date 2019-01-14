using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class Base
    {
        string TableName { get; set; }
        public Base(string tableName)
        {
            TableName = tableName;
        }
        /// <summary>
        /// 全部查询；select * from table_name where 1=1;
        /// </summary>
        /// <returns></returns>
        public virtual DataSet SelectData()
        {
            return SelectData(" 1 = 1");
        }
        /// <summary>
        /// 带条件查询：select * from table_name where 条件
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public virtual DataSet SelectData(string strWhere)
        {
            return SelectData("*", strWhere);
        }
        /// <summary>
        /// 带条件查询：select 字段值  from table_name where 条件
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public virtual DataSet SelectData(string columnNames ,string strWhere)
        {
            return MySqlHelper.GetDataSet(CommandType.Text, "Select " + columnNames + " From " + TableName + " Where " + strWhere);
        }
        /// <summary>
        /// 带条件查询：select 字段值  from table_name where 条件 order by  字段
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public virtual DataSet SelectData(string columnNames, string strWhere,string str_oder)
        {
            return MySqlHelper.GetDataSet(CommandType.Text, "Select " + columnNames + " From " + TableName + " Where " + strWhere + " order by " + str_oder); 
        }
        /// <summary>
        /// update 表名 set 字段=值 where 条件
        /// </summary>
        /// <param name="columnNames"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void  updateData(string columnNames, string strWhere)
        {
             MySqlHelper.GetDataSet(CommandType.Text, "update " + TableName + " set " + columnNames + " Where " + strWhere);
        }

        /// <summary>
        /// delete from 表名 where 条件
        /// </summary>
        public void deleteData(string strWhere)
        {
            MySqlHelper.GetDataSet(CommandType.Text, "delete from " + TableName + " Where " + strWhere);
        }
        /// <summary>
        /// insert into 表名 (字段) values(值)
        /// </summary>
        /// <param name="columnNames1"></param>
        /// <param name="columnNames2"></param>
        public void insertData(string columnNames1, string columnNames2)
        {
            MySqlHelper.GetDataSet(CommandType.Text, "insert  into  " + TableName + " ( " + columnNames1 + ") values ( " + columnNames2+" )");
        }
        
        /// <summary>
        /// insert  into 表名  select * from 表名 where  条件
        /// </summary>
        /// <param name="str_table"></param>
        public void insertData(string str_table)
        {
            MySqlHelper.GetDataSet(CommandType.Text, "insert  into  " + TableName +" "+ str_table );
        }
        /// <summary>
        /// insert  into 表名(字段)  select * from 表名 where  条件
        /// </summary>
        /// <param name="str_table"></param>
        public void insertData2(string columnNames1,string str_table)
        {
            MySqlHelper.GetDataSet(CommandType.Text, "insert  into  " + TableName + " (  " + columnNames1 +" ) "+ str_table);
        }
    }
}
