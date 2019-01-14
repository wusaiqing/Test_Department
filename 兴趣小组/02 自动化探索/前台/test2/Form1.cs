using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;
using NPOI;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS;
using NPOI.SS.UserModel;
using NPOI.SS.Util;


namespace test2
{
    public partial class Form1 : Form
    {
        DAL.TotalConfig tc = new DAL.TotalConfig();
        DAL.Config config = new DAL.Config();
        DAL.page_properties page = new DAL.page_properties();
        DAL.Iframe iframe = new DAL.Iframe();
        DAL.check_point check_point = new DAL.check_point();
        DAL.check_point_temp check_temp = new DAL.check_point_temp();
        DAL.check_page check_page = new DAL.check_page();
        DAL.test_case test_case = new DAL.test_case();
        DAL.test_case_temp test_case_temp = new DAL.test_case_temp();
        DAL.test_page test_page = new DAL.test_page();
        DAL.steps steps = new DAL.steps();
        DAL.steps_page steps_page = new DAL.steps_page();


        public Form1()
        {
            InitializeComponent();
            load();
            GetInfo();
        }

        public void load()
        {
            DataSet ds = tc.SelectData(" sysname ", "1=1");
            DataTable dt = ds.Tables[0];
            sysname_config_Column.DataSource = dt;
            sysname_config_Column.DisplayMember = "sysname";
            sysname_config_Column.ValueMember = "sysname";
            iframe_sysname_Column.DataSource = dt;
            iframe_sysname_Column.DisplayMember = "sysname";
            test_sysname_Column.DataSource = dt;
            test_sysname_Column.DisplayMember = "sysname";
            check_sysname2_Column.DataSource = dt;
            check_sysname2_Column.DisplayMember = "sysname";
            check_sysname2_2_Column.DataSource = dt;
            check_sysname2_2_Column.DisplayMember = "sysname";
            group_sysname_Column.DataSource = dt;
            group_sysname_Column.DisplayMember = "sysname";
            group_sysname_2_Column.DataSource = dt;
            group_sysname_2_Column.DisplayMember = "sysname";

            DataTable dt_p = ds.Copy().Tables[0];
            DataRow dr_p = dt_p.NewRow();
            DataRow dr_p2 = dt_p.NewRow();
            dr_p["sysname"] = "all_system";
            dt_p.Rows.InsertAt(dr_p, 0);
            dr_p2["sysname"] = "请选择";
            dt_p.Rows.InsertAt(dr_p2, 0);
            page_sysname_Column.DataSource = dt_p;
            page_sysname_Column.DisplayMember = "sysname";

            DataTable dt2 = ds.Copy().Tables[0];
            DataRow dr = dt2.NewRow();
            dr["sysname"] = "请选择";
            dt2.Rows.InsertAt(dr, 0);
            config_sysname_comboBox.DataSource = dt2;
            config_sysname_comboBox.DisplayMember = "sysname";
            config_sysname_comboBox.SelectedIndex = 0;

            sysname_comboBox.DataSource = dt2;
            sysname_comboBox.DisplayMember = "sysname";
            sysname_comboBox.SelectedIndex = 0;

            page_sysname_comboBox.DataSource = dt2;
            page_sysname_comboBox.DisplayMember = "sysname";
            page_sysname_comboBox.SelectedIndex = 0;

            iframe_sysname_comboBox.DataSource = dt2;
            iframe_sysname_comboBox.DisplayMember = "sysname";
            iframe_sysname_comboBox.SelectedIndex = 0;

            test_sysname_comboBox.DataSource = dt2;
            test_sysname_comboBox.DisplayMember = "sysname";
            test_sysname_comboBox.SelectedIndex = 0;

            check_sysname_comboBox.DataSource = dt2;
            check_sysname_comboBox.DisplayMember = "sysname";
            check_sysname_comboBox.SelectedIndex = 0;

            DataSet ds_c = config.SelectData(" distinct function_name","1=1");
            DataTable dt_function = ds_c.Tables[0];
            test_function_name_Column.DataSource = dt_function;
            test_function_name_Column.DisplayMember = "function_name";
           

            //加载检查点名称下拉框的代码
            DataSet ds_page = page.SelectData("element_name","page_class='检查点'");
            DataTable dt_check = ds_page.Tables[0];

            check_point_name_Column.DataSource = dt_check;
            check_point_name_Column.DisplayMember = "element_name";

            action_yes_no_comboBox.SelectedIndex = 0;
            finish_yes_no_comboBox.SelectedIndex = 0;
            test_c_comboBox.SelectedIndex = 0;
            test_hope_way_comboBox.SelectedIndex = 0;
            test_result_comboBox.SelectedIndex = 0;
        }
        public void total_query()
        {
            string strWhere = " 1 = 1 ";
            if (total_config_sysname.Text != "")
            {
                strWhere = " sysname like '%" + total_config_sysname.Text.Trim() + "%'";
            }
            string str_colName = @"id as 序号, 
                                  url as url,  
                                  waittime as 加载时间, 
                                  browser as 浏览器,
                                  sysname as 被测系统名称,
                                  db_class as 数据库类型,
                                  host as 数据库ip地址, 
                                  user as 数据库用户名,
                                  pwd as 数据库密码, 
                                  db as 数据库名称 ,
                                  '编辑' as 编辑 ,
                                  '删除' as 删除  ";
            DataSet ds = tc.SelectData(str_colName,strWhere);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
        }

        public void config_query()
        {
            string strWhere=" 1=1 ";
            string str_colName = @"configid as 序号,
                                  function_name as 功能点名称,
                                  action_yes_no as 是否执行 ,
                                  finish_yes_no as 是否执行完毕,
                                  sysname as 被测系统名称,
                                  '编辑' as 编辑 ,
                                  '删除' as 删除 ";
            if (config_sysname_comboBox.SelectedIndex != 0)
            {
                strWhere = strWhere + " and sysname = '" + config_sysname_comboBox.Text.Trim() + "'";
            }
            if (function_name_textBox.Text != "")
            {
                strWhere = strWhere + " and function_name like '%" + function_name_textBox.Text.Trim() + "%'";
            }
            if (action_yes_no_comboBox.SelectedIndex != 0)
            {
                strWhere = strWhere + " and action_yes_no ='" + action_yes_no_comboBox.Text + "'";
            }
            if (finish_yes_no_comboBox.SelectedIndex != 0)
            {
                strWhere = strWhere + " and finish_yes_no like '" + finish_yes_no_comboBox.Text + "'";
            }
            DataSet ds = config.SelectData(str_colName, strWhere);
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = ds.Tables[0];
        }
        public void iframe_query()
        {
            string strWhere = " 1=1 ";
            string str_colName = @"id as 序号,
                                 iframe_name,
                                 sysname as 被测系统名称,
                                 '编辑' as 编辑 ,
                                 '删除' as 删除 ";
            if (iframe_sysname_comboBox.SelectedIndex != 0)
            {
                strWhere = strWhere + " and sysname = '" + iframe_sysname_comboBox.Text.Trim() + "'";
            }
            DataSet ds = iframe.SelectData(str_colName, strWhere);
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = ds.Tables[0];
        }
        public void page_query()
        {
            string strWhere = " 1=1 ";
            string str_colName = @"id as 序号,
                                page_name as 页面名称,
                                element_name as 元素名称,
                                page_class as 页面控件类型,
                                page_value as 页面属性值,
                                find_way as 查找方式,
                                sysname as 被测系统名称,
                                check_find as 检测,
                                '编辑' as 编辑 ,
                                '删除' as 删除 ";
            if (page_sysname_comboBox.SelectedIndex != 0)
            {
                strWhere = strWhere + "  and( sysname = '" + page_sysname_comboBox.Text.Trim() + "' or sysname='all_system') ";
            }
            if (page_name_textBox.Text != "")
            {
                strWhere = strWhere + " and page_name like '%" + page_name_textBox.Text.Trim() + "%'";
            }
            if (page_element_name_textBox.Text != "")
            {
                strWhere =strWhere+ " and element_name like '%" + page_element_name_textBox.Text.Trim() + "%'";
            }
            if (page_class_textBox.Text != "")
            {
                strWhere = strWhere + " and page_class like '%" + page_class_textBox.Text.Trim() + "%'";
            }
            if (page_find_way_textBox.Text != "")
            {
                strWhere = strWhere + " and find_way like '%" + page_find_way_textBox.Text.Trim() + "%'";
            }
            strWhere = strWhere + "  order by sysname,page_name";
            DataSet ds = page.SelectData(str_colName, strWhere);
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 检查点
        /// </summary>
        public void check_point_query()
        {
            //删除动态的列
            for (int i = 0; i < dataGridView7.Columns.Count; i++)
            {
                if (dataGridView7.Columns[i].Name.Contains("col"))
                {
                    dataGridView7.Columns.RemoveAt(i);
                    i = i - 1;
                }
            }
            string strWhere = " 1=1 ";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                strWhere = strWhere + "  and sysname = '" + check_sysname_comboBox.Text.Trim() + "' ";
            }
            if (check_name_textBox.Text != "")
            {
                strWhere = strWhere + " and check_point_name like '%" + check_name_textBox.Text.Trim() + "%'";
            }
            DataSet ds = check_point.SelectData(" count(0) ", strWhere);
            DataTable sql_check_ct = ds.Tables[0];
            int sql_check_count = int.Parse(sql_check_ct.Rows[0][0].ToString());
            if (sql_check_count == 1)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                DataTable data = new DataTable();
                string strWhere2 = " 1=1 ";
                string strColName3 = @"id as 序号,
                                      check_point_name as 检查点名称,
                                      sysname as 被测系统名称 , ";
                string strWhere3 = " 1=1 ";

                if (check_sysname_comboBox.SelectedIndex != 0)
                {
                    strWhere3 = strWhere3 + " and sysname = '" + check_sysname_comboBox.Text.Trim() + "' ";
                    strWhere2 = strWhere2 + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system' )";
                }
                if (check_name_textBox.Text != "")
                {
                    strWhere3 = strWhere3 + " and check_point_name like '%" + check_name_textBox.Text.Trim() + "%'";
                    strWhere2 = strWhere2 + " and check_point_name like '%" + check_name_textBox.Text.Trim() + "%'";
                }
                strWhere2 = strWhere2 + " order by check_order ";
                DataSet ds2 = check_page.SelectData(" element_name ", strWhere2);
                DataTable dt = ds2.Tables[0];

                //动态加载列
                string str_col = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    col = new DataGridViewTextBoxColumn();
                    str_col = str_col + " col" + i.ToString() + ",";
                    col.Name = "col" + i.ToString();
                    col.HeaderText = dt.Rows[i][0].ToString();
                    col.DataPropertyName = "col" + i.ToString();
                    dataGridView7.Columns.Insert(check_edit2_Column.Index, col);
                }

                strColName3 = strColName3 + str_col + " '编辑' as 编辑, '删除' as 删除  ";
                DataSet ds3 = check_point.SelectData(strColName3, strWhere3);
                DataTable dt2 = ds3.Tables[0];
                //data.Columns.Add("element_name");
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    data.Columns.Add(dt2.Columns[i].ColumnName);
                }

                ///动态加载行数据
                DataRow row;
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    row = data.NewRow();

                    row["序号"] = dt2.Rows[j][0];
                    row["检查点名称"] = dt2.Rows[j][1];
                    row["被测系统名称"] = dt2.Rows[j][2];
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        string c = "col" + k.ToString();
                        row[c] = dt2.Rows[j][3 + k];
                    }
                    row["编辑"] = dt2.Rows[j][3 + dt.Rows.Count];
                    row["删除"] = dt2.Rows[j][3 + dt.Rows.Count + 1];
                    data.Rows.Add(row);
                }
                dataGridView7.AutoGenerateColumns = false;
                data.AcceptChanges();
                dataGridView7.DataSource = data;
            }
            else
            {
                string strWhere4 = " 1=1 ";
                string strColName4 = @" id as 序号,
                                check_point_name as 检查点名称,
                                sysname as 被测系统名称 ,
                                '编辑' as 编辑, 
                                '删除' as 删除  ";
                if (check_sysname_comboBox.SelectedIndex != 0)
                {
                    strWhere4 = strWhere4 + " and sysname = '" + check_sysname_comboBox.Text.Trim() + "'";
                }
                if (check_name_textBox.Text != "")
                {
                    strWhere4 = strWhere4 + " and  check_point_name like '%" + check_name_textBox.Text.Trim() + "%'";
                }
                DataSet ds4 = check_point.SelectData(strColName4, strWhere4);
                dataGridView7.AutoGenerateColumns = false;
                dataGridView7.DataSource = ds4.Tables[0];
            }
            check_detail_t();
        }
        public void check_detail_t()
        {
            if (dataGridView9.Visible == true)
            {
                string strWhere = "id =" + this.dataGridView9.Rows[0].Cells["check_point_2_Column"].Value;
                string strColName = " sysname,check_point_name ";
                DataSet ds = check_point.SelectData(strColName, strWhere);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int check_id = int.Parse(this.dataGridView9.Rows[0].Cells["check_point_2_Column"].Value.ToString());
                    object sysname = dt.Rows[0][0].ToString();
                    object check_name = dt.Rows[0][1].ToString();
                    check_detail(check_id, sysname, check_name);
                }
                else
                {
                    dataGridView9.Visible = false;
                }
            }
        }
        
        /// <summary>
        /// 测试用例页面的查询
        /// </summary>
        public void test_query()
        {
            //删除动态的列
            for (int i = 0; i < dataGridView5.Columns.Count; i++)
            {
                if (dataGridView5.Columns[i].Name.Contains("col"))
                {
                    dataGridView5.Columns.RemoveAt(i);
                    i = i - 1;
                }
            }
            //查询条件值
            string query = "";
            string query_page = "";
            string query_s = "";
            if (test_sysname_comboBox.SelectedIndex != 0)
            {
                string query2 = " and sysname = '" + test_sysname_comboBox.Text.Trim() + "'";
                query_s = query2;
                query = query + query2;
                query_page = query_page + query2;
            }

            if (test_run_result_textBox.Text != "")
            {
                string query2 = "  and run_result like '%" + test_run_result_textBox.Text.Trim() + "%'";
                query = query + query2;
            }
            if (test_c_comboBox.SelectedIndex != 0)
            {
                string query2 = "  and compare_way ='" + test_c_comboBox.Text.Trim() + "'";
                query = query + query2;
            }
            if (test_hope_way_comboBox.SelectedIndex != 0)
            {
                string query2 = "  and hope_way ='" + test_hope_way_comboBox.Text.Trim() + "'";
                query = query + query2;
            }
            if (test_hope_result_textBox.Text != "")
            {
                string query2 = "  and hope_result  like '%" + test_hope_result_textBox.Text.Trim() + "%'";
                query = query + query2;
            }
            if (test_result_comboBox.SelectedIndex != 0)
            {
                string query2 = "  and result ='" + test_result_comboBox.Text.Trim() + "'";
                query = query + query2;
            }

            string query_f = "  and function_name ='" + test_f_comboBox.Text.Trim() + "'";
            string query_f2 = "  and t2.function_name ='" + test_f_comboBox.Text.Trim() + "'";
            query = query + query_f;

            //加载列名和列数据
            string str_ColName2 = @" id as 序号,
                                test_id as 用例名称,
                                function_name as 功能点名称,
                                run_result as 运行结果,
                                compare_way as 对比方式,
                                hope_way as 期望输出结果方式,
                                hope_result as 期望结果,
                                result as 结果,
                                comments 备注,
                                sysname 被测系统名,";
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();

            DataTable data = new DataTable();
            string str_Where = "function_name ='" + test_f_comboBox.Text.Trim() + "'  ";
            if (test_sysname_comboBox.SelectedIndex != 0)
            {
                str_Where = str_Where + "  and ( sysname = '" + test_sysname_comboBox.Text.Trim() + "' or sysname='all_system')";
            }

            str_Where = str_Where + " order by test_order";
            DataSet ds = test_page.SelectData("element_name", str_Where);
            DataTable dt = ds.Tables[0];
            //动态加载列名
            string col_s = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                col = new DataGridViewTextBoxColumn();
                col.Name = "col" + i.ToString();
                col.HeaderText = dt.Rows[i][0].ToString();
                col.DataPropertyName = "col" + i.ToString();
                dataGridView5.Columns.Insert(test_edit_Column.Index, col);
                col_s = col_s + "col" + i + ",";
            }
            str_ColName2 = str_ColName2 + col_s + @"'编辑' as 编辑 ,
                                                    '删除' as 删除 ";
            string str_Where2 = " 1=1 ";
            str_Where2 = str_Where2 + query ;
            DataSet ds2 = test_case.SelectData(str_ColName2, str_Where2);
            DataTable dt2 = ds2.Tables[0];
            
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                data.Columns.Add(dt2.Columns[i].ColumnName);
            }
            ///动态加载行数据
            DataRow row;
            for (int j = 0; j < dt2.Rows.Count; j++)
            {
                row = data.NewRow();
                row["序号"] = dt2.Rows[j][0];
                row["用例名称"] = dt2.Rows[j][1];
                row["功能点名称"] = dt2.Rows[j][2];
                row["运行结果"] = dt2.Rows[j][3];
                row["对比方式"] = dt2.Rows[j][4];
                row["期望输出结果方式"] = dt2.Rows[j][5];
                row["期望结果"] = dt2.Rows[j][6];
                row["结果"] = dt2.Rows[j][7];
                row["备注"] = dt2.Rows[j][8];
                row["被测系统名"] = dt2.Rows[j][9];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string c = "col" + i.ToString();
                    row[c] = dt2.Rows[j][10 + i];
                }
                row["编辑"] = dt2.Rows[j][10 + dt.Rows.Count];
                row["删除"] = dt2.Rows[j][10 + dt.Rows.Count + 1];
                data.Rows.Add(row);
            }
            dataGridView5.AutoGenerateColumns = false;
            data.AcceptChanges();
            dataGridView5.DataSource = data;

            //dataGridView 根据上面的查询条件，自动显示值
            DataTable dt_f = new DataTable();
            dt_f.Columns.Add("function", typeof(string));
            DataRow newRow;
            newRow = dt_f.NewRow();
            newRow["function"] = test_f_comboBox.Text.Trim();
            dt_f.Rows.Add(newRow);
            test_function_name_Column.DataSource = dt_f;
            test_function_name_Column.DisplayMember = "function";
        }

        public void steps_group_query(string sysname, string steps_group_name)
        {
            //删除动态的列
            for (int i = 0; i < dataGridView6.Columns.Count; i++)
            {
                if (dataGridView6.Columns[i].Name.Contains("col"))
                {
                    dataGridView6.Columns.RemoveAt(i);
                    i = i - 1;
                }
            }
            string str_Where = " 1=1 ";
            if (sysname == "")
            {
                if (sysname_comboBox.SelectedIndex != 0)
                {
                    str_Where = str_Where + " and sysname = '" + sysname_comboBox.Text.Trim() + "' ";
                }
            }
            else
            {
                str_Where = str_Where + " and sysname = '" + sysname + "' ";
            }
            if (steps_group_name == "")
            {
                if (steps_group_textBox.Text != "")
                {
                    str_Where = str_Where + " and steps_name like '%" + steps_group_textBox.Text.Trim() + "%'";
                }
            }
            else
            {
                str_Where = str_Where + " and steps_name like '" + steps_group_name + "'";
            }
            DataSet ds = steps.SelectData(" count(0) ", str_Where);
            DataTable dt_steps_c = ds.Tables[0];
            int sql_steps_count = int.Parse(dt_steps_c.Rows[0][0].ToString());
            if (sql_steps_count == 1)
            {
                string str_ColName3 = @"id as 序号,
                                        steps_name as 步骤组名称,
                                        sysname as 被测系统名称,";
                string str_Where3= " 1=1 ";
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                DataTable data = new DataTable();
                string str_Where2 = " 1=1 ";
                if (sysname_comboBox.SelectedIndex != 0)
                {
                    str_Where2 = str_Where2 + " and sysname = '" + sysname_comboBox.Text.Trim() + "' ";
                    str_Where3 = str_Where3 + " and sysname = '" + sysname_comboBox.Text.Trim() + "' ";
                }
                if (steps_group_textBox.Text != "")
                {
                    str_Where2 = str_Where2 + "  and steps_name like '%" + steps_group_textBox.Text.Trim() + "%'";
                    str_Where3 = str_Where3 + "  and steps_name like '%" + steps_group_textBox.Text.Trim() + "%'";
                }
                str_Where2 = str_Where2 + " order by steps_order ";
                DataSet ds2 = steps_page.SelectData("element_name", str_Where2);
                DataTable dt = ds2.Tables[0];

                //动态加载列
                string str_col = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    col = new DataGridViewTextBoxColumn();
                    str_col = str_col + " col" + i.ToString() + ",";
                    col.Name = "col" + i.ToString();
                    col.HeaderText = dt.Rows[i][0].ToString();
                    col.DataPropertyName = "col" + i.ToString();
                    dataGridView6.Columns.Insert(step_edit_Column.Index, col);
                }
                str_ColName3 = str_ColName3 + str_col + " '编辑' as 编辑, '删除' as 删除  ";
                DataSet ds3 = steps.SelectData(str_ColName3, str_Where3);
                DataTable dt2 = ds3.Tables[0];
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    data.Columns.Add(dt2.Columns[i].ColumnName);
                }
                ///动态加载行数据
                DataRow row;
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    row = data.NewRow();
                    row["序号"] = dt2.Rows[j][0];
                    row["步骤组名称"] = dt2.Rows[j][1];
                    row["被测系统名称"] = dt2.Rows[j][2];
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        string c = "col" + k.ToString();
                        row[c] = dt2.Rows[j][3 + k];
                    }
                    row["编辑"] = dt2.Rows[j][3 + dt.Rows.Count];
                    row["删除"] = dt2.Rows[j][3 + dt.Rows.Count + 1];
                    data.Rows.Add(row);
                }
                dataGridView6.AutoGenerateColumns = false;
                data.AcceptChanges();
                dataGridView6.DataSource = data;
            }
            else
            {
                string str_ColName4 = @"id as 序号,
                                steps_name as 步骤组名称,
                                sysname as 被测系统名称 ,
                                '编辑' as 编辑, 
                                '删除' as 删除";
                string str_Where4 = " 1=1 ";
                if (sysname_comboBox.SelectedIndex != 0)
                {
                    str_Where4 = str_Where4 + " and sysname = '" + sysname_comboBox.Text.Trim() + "' ";
                }
                if (steps_group_textBox.Text != "")
                {
                    str_Where4 = str_Where4 + " and steps_name like '%" + steps_group_textBox.Text.Trim() + "%'";
                }
                DataSet ds4 = steps.SelectData(str_ColName4, str_Where4);
                dataGridView6.AutoGenerateColumns = false;
                dataGridView6.DataSource = ds4.Tables[0];
            }
            steps_detail_query();
        }
        public void GetInfo()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                total_query();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                config_query();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                iframe_query();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                page_query();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                test_query();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                check_point_query();
            }
            else if (tabControl1.SelectedIndex == 6)
            {
                string a = "";
                string b = "";
                steps_group_query(a, b);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            total_query();
        }
        public void update_sysname(string str1, string str2)
        {
            string str_colName = " sysname ='" + str2 + "' ";
            string str_Where = " sysname = '" + str1.Trim() + "'";
            check_page.updateData(str_colName, str_Where);
            check_point.updateData(str_colName, str_Where);
            config.updateData(str_colName, str_Where);
            iframe.updateData(str_colName, str_Where);
            page.updateData(str_colName, str_Where);
            steps.updateData(str_colName, str_Where);
            steps_page.updateData(str_colName, str_Where);
            test_case.updateData(str_colName, str_Where);
            test_page.updateData(str_colName, str_Where);
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == dataGridView1.RowCount - 1)
            {
                return;
            }
            else
            {
                try
                {
                    string str_Where = "id=" + dataGridView1.Rows[e.RowIndex].Cells["ID_Column"].Value;
                    DataSet ds = tc.SelectData("sysname", str_Where);
                    DataTable dt = ds.Tables[0];
                    if (e.ColumnIndex == Edit_Column.Index)
                    {
                        string str = "";
                        if (dataGridView1.Rows[e.RowIndex].Cells["url_Colmun"].Value.ToString() == "")
                        {
                            str = str + "url、";
                        }
                        if (dataGridView1.Rows[e.RowIndex].Cells["waittime_Colmun"].Value.ToString() == "")
                        {
                            str = str + "加载时间、";
                        }
                        if (dataGridView1.Rows[e.RowIndex].Cells["sysname_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (dataGridView1.Rows[e.RowIndex].Cells["browser_Column"].Value.ToString() == "")
                        {
                            str = str + "浏览器、";
                        }
                        if (str != "")
                        {
                            str = str + "不能为空！";
                            MessageBox.Show(str);
                        }
                        else
                        {
                            string str_colName2 = @"waittime = '" + dataGridView1.Rows[e.RowIndex].Cells["waittime_Colmun"].Value.ToString().Trim() + "', " +
                                                     "url = '" + dataGridView1.Rows[e.RowIndex].Cells["url_Colmun"].Value.ToString().Trim() + "', " +
                                                     "browser = '" + dataGridView1.Rows[e.RowIndex].Cells["browser_Column"].Value.ToString().Trim() + "', " +
                                                     "sysname = '" + dataGridView1.Rows[e.RowIndex].Cells["sysname_Column"].Value.ToString().Trim() + "', " +
                                                     "db_class = '" + dataGridView1.Rows[e.RowIndex].Cells["db_class_Column"].Value.ToString().Trim() + "', " +
                                                     "host = '" + dataGridView1.Rows[e.RowIndex].Cells["host_Column"].Value.ToString().Trim() + "', " +
                                                     "user = '" + dataGridView1.Rows[e.RowIndex].Cells["user_Column"].Value.ToString().Trim() + "', " +
                                                     "pwd = '" + dataGridView1.Rows[e.RowIndex].Cells["pwd_Column"].Value.ToString().Trim() + "', " +
                                                     "db = '" + dataGridView1.Rows[e.RowIndex].Cells["db_Column"].Value.ToString().Trim() + "'";
                            string str_Where2 = " id=" + dataGridView1.Rows[e.RowIndex].Cells["ID_Column"].Value.ToString().Trim();

                            if (dt.Rows[0][0] == dataGridView1.Rows[e.RowIndex].Cells["sysname_Column"].Value)
                            {
                                tc.updateData(str_colName2, str_Where2);
                            }
                            else
                            {
                                DialogResult di;
                                di = MessageBox.Show("被测系统名称数据被修改，是否要修改之后的使用到被测系统名称", "确认修改页面", MessageBoxButtons.YesNoCancel);
                                if (di == DialogResult.Yes)
                                {
                                    tc.updateData(str_colName2, str_Where2);
                                    update_sysname(dt.Rows[0][0].ToString(), dataGridView1.Rows[e.RowIndex].Cells["sysname_Column"].Value.ToString());
                                }
                                else if (di == DialogResult.No)
                                {
                                    tc.updateData(str_colName2, str_Where2);
                                }
                                else
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else if (e.ColumnIndex == Del_Column.Index)
                    {
                        string str_Where3 ="  sysname='" + dataGridView1.Rows[e.RowIndex].Cells["sysname_Column"].Value + "'";
                        DataSet ds3 = config.SelectData(str_Where3);
                        DataTable dt_config = ds3.Tables[0];

                        DataSet ds4 = page.SelectData(str_Where3);
                        DataTable dt_page_properties = ds4.Tables[0];

                        DataSet ds5 = iframe.SelectData(str_Where3);
                        DataTable dt_iframe = ds5.Tables[0];

                        if (dt_config.Rows.Count != 0 || dt_page_properties.Rows.Count != 0 || dt_iframe.Rows.Count!=0)
                        {
                            string mes_str = "被测系统名称：" + dataGridView1.Rows[e.RowIndex].Cells["sysname_Column"].Value + " 在";
                            if (dt_config.Rows.Count != 0)
                            {
                                mes_str = mes_str + "配置表、";
                            }
                            if (dt_page_properties.Rows.Count != 0)
                            {
                                mes_str = mes_str + "配置页面属性、";
                            }
                            if (dt_iframe.Rows.Count != 0)
                            {
                                mes_str = mes_str + "iframe表、";
                            }
                            MessageBox.Show(mes_str + " 中使用，不能删除！");
                        }
                        else
                        {
                            string str_Where6 = " id=" + dataGridView1.Rows[e.RowIndex].Cells["ID_Column"].Value;
                            DialogResult di;
                            di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                            if (di == DialogResult.Yes)
                            {
                                tc.deleteData(str_Where6);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                catch
                {
                }
              
                total_query();
            }
            load();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            DataTable dtC = dt.GetChanges();
            if (dtC != null)
            {
                foreach (DataRow dr in dtC.Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        string str = "";
                        if (dr["url"].ToString() == "")
                        {
                            str = str + "url、";

                        }
                        if (dr["加载时间"].ToString() == "")
                        {
                            str = str + "加载时间、";
                        }
                        if (dr["浏览器"].ToString() == "")
                        {
                            str = str + "浏览器、";
                        }

                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            str = str + "不能为空！";
                            MessageBox.Show(str);
                        }
                        else
                        {
                            string col_Name2 = @"'" + dr["url"] + "',"
                                                     + "'" + dr["加载时间"] + "',"
                                                     + "'" + dr["浏览器"] + "',"
                                                     + "'" + dr["被测系统名称"] + "',"
                                                     + "'" + dr["数据库类型"] + "',"
                                                     + "'" + dr["数据库ip地址"] + "',"
                                                     + "'" + dr["数据库用户名"] + "',"
                                                     + "'" + dr["数据库密码"] + "',"
                                                     + "'" + dr["数据库名称"] + "' ";
                            tc.insertData("url,waittime,browser,sysname,db_class,host,user,pwd,db", col_Name2);
                            total_query();
                            //load();
                        }
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        string str = "";
                        if (dr["url"].ToString() == "")
                        {
                            str = str + "url、";
                        }
                        if (dr["加载时间"].ToString() == "")
                        {
                            str = str + "加载时间、";
                        }
                        if (dr["浏览器"].ToString() == "")
                        {
                            str = str + "浏览器、";
                        }

                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            str = str + "不能为空！";
                            MessageBox.Show(str);
                        }
                        else
                        {
                            string str_Where = "id='" + dr["序号"] + "';";
                            DataSet ds = tc.SelectData("sysname", str_Where);
                            DataTable dt2 = ds.Tables[0];
                            string str_colName = @"  url = '" + dr["url"] + " ', " +
                                                "waittime = '" + dr["加载时间"] + "', " +
                                                "browser = '" + dr["浏览器"] + "', " +
                                                "sysname = '" + dr["被测系统名称"] + "', " +
                                                "db_class = '" + dr["数据库类型"] + "', " +
                                                "host = '" + dr["数据库ip地址"] + "', " +
                                                "user = '" + dr["数据库用户名"] + "', " +
                                                "pwd = '" + dr["数据库密码"] + "', " +
                                                "db = '" + dr["数据库名称"] + "'";

                            DialogResult di;
                            di = MessageBox.Show("被测系统名称数据被修改，是否要修改之后的使用到被测系统名称", "确认修改页面", MessageBoxButtons.YesNoCancel);
                            if (di == DialogResult.Yes)
                            {
                                update_sysname(dt2.Rows[0][0].ToString(), dr["被测系统名称"].ToString());
                                tc.updateData(str_colName, str_Where);
                            }
                            else if (di == DialogResult.No)
                            {
                                tc.updateData(str_colName, str_Where);
                            }
                            else
                            {
                                return;
                            }
                            total_query();
                        }
                    }
                }
                dtC.AcceptChanges();
                load();
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            total_config_add taframe = new total_config_add();
            taframe.ShowDialog();
            load();
        }

        private void config_button_query_Click(object sender, EventArgs e)
        {
            config_query();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == dataGridView2.RowCount - 1)
            {
                return;
            }
            else
            {
                try
                {
                    if (e.ColumnIndex == config_Edit_Column.Index)
                    {
                        string str = "";
                        if (dataGridView2.Rows[e.RowIndex].Cells["function_name_Column"].Value.ToString() == "")
                        {
                            str = str + "功能点名称、";
                        }
                        if (dataGridView2.Rows[e.RowIndex].Cells["action_yes_no_Column"].Value.ToString() == "")
                        {
                            str = str + "是否执行、";
                        }
                        if (dataGridView2.Rows[e.RowIndex].Cells["finish_yes_no_Column"].Value.ToString() == "")
                        {
                            str = str + "是否执行完毕、";
                        }
                        if (dataGridView2.Rows[e.RowIndex].Cells["sysname_config_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_Where = " configid=" + dataGridView2.Rows[e.RowIndex].Cells["configid_Column"].Value;
                            string str_Colname = @" function_name= '" + dataGridView2.Rows[e.RowIndex].Cells["function_name_Column"].Value + "'," +
                                                  "action_yes_no= '" + dataGridView2.Rows[e.RowIndex].Cells["action_yes_no_Column"].Value + "'," +
                                                  "finish_yes_no= '" + dataGridView2.Rows[e.RowIndex].Cells["finish_yes_no_Column"].Value + "'," +
                                                  "sysname= '" + dataGridView2.Rows[e.RowIndex].Cells["sysname_config_Column"].Value + "' ";
                            DialogResult di;
                            di = MessageBox.Show("功能点名称数据被修改，是否要修改之后的使用到功能点名称", "确认修改页面", MessageBoxButtons.YesNoCancel);
                            if (di == DialogResult.Yes)
                            {
                                DataSet ds = config.SelectData("function_name", str_Where);
                                DataTable dt_f = ds.Tables[0];
                                
                                update_function(dt_f.Rows[0][0].ToString(), dataGridView2.Rows[e.RowIndex].Cells["function_name_Column"].Value.ToString());
                                config.updateData(str_Colname, str_Where);
                            }
                            else if (di == DialogResult.No)
                            {
                                config.updateData(str_Colname, str_Where);
                            }
                            else
                            {
                                return;
                            }
                            config_query();
                            load();
                        }
                    }
                    else if (e.ColumnIndex == config_Del_Column.Index)
                    {
                        string str_Where=" configid=  " + dataGridView2.Rows[e.RowIndex].Cells["configid_Column"].Value;
                        DialogResult di;
                        di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                        if (di == DialogResult.Yes)
                        {
                            config.deleteData(str_Where);
                        }
                        else
                        {
                            return;
                        }
                        GetInfo();
                    }
                    load();
                }
                catch
                {
                }
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //load();
            GetInfo();
        }

        private void all_edit_button_Click(object sender, EventArgs e)
        {
            DataTable dt2 = dataGridView2.DataSource as DataTable;
            DataTable dtc2 = dt2.GetChanges();
            if (dtc2 != null)
            {
                foreach (DataRow dr2 in dtc2.Rows)
                {
                    if (dr2.RowState == DataRowState.Added)
                    {
                        string str = "";
                        if (dr2["功能点名称"].ToString() == "")
                        {
                            str = str + "功能点名称、";
                        }
                        if (dr2["是否执行"].ToString() == "")
                        {
                            str = str + "是否执行、";
                        }
                        if (dr2["是否执行完毕"].ToString() == "")
                        {
                            str = str + "是否执行完毕、";
                        }
                        if (dr2["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_colName2=@" '" + dr2["功能点名称"] + "',"
                                                    + "'" + dr2["是否执行"] + "',"
                                                    + "'" + dr2["是否执行完毕"] + "',"
                                                    + "'" + dr2["被测系统名称"] + "');";
                            config.insertData("function_name,action_yes_no,finish_yes_no,sysname", str_colName2);
                            config_query();
                        }
                    }
                    else if (dr2.RowState == DataRowState.Modified)
                    {
                        string str = "";
                        if (dr2["功能点名称"].ToString() == "")
                        {
                            str = str + "功能点名称、";
                        }
                        if (dr2["是否执行"].ToString() == "")
                        {
                            str = str + "是否执行、";
                        }
                        if (dr2["是否执行完毕"].ToString() == "")
                        {
                            str = str + "是否执行完毕、";
                        }
                        if (dr2["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_Where = " configid='" + dr2["序号"] + "';";
                            string str_Colname = " function_name = '" + dr2["功能点名称"] + "', " +
                                                  "action_yes_no = '" + dr2["是否执行"] + "', " +
                                                  "finish_yes_no = '" + dr2["是否执行完毕"] + "', " +
                                                  "sysname = '" + dr2["被测系统名称"] + "'";                           
                            DialogResult di;
                            di = MessageBox.Show("功能点名称数据被修改，是否要修改之后的使用到功能点名称", "确认修改页面", MessageBoxButtons.YesNoCancel);
                            if (di == DialogResult.Yes)
                            {
                                string sql_function = "select function_name from config where configid=" + int.Parse(dr2["序号"].ToString());
                                DataSet ds = config.SelectData("function_name", str_Where);
                                DataTable dt_f = ds.Tables[0];
                                update_function(dt_f.Rows[0][0].ToString(), dr2["功能点名称"].ToString());
                                config.updateData(str_Colname, str_Where);
                            }
                            else if (di == DialogResult.No)
                            {
                                config.updateData(str_Colname, str_Where);
                            }
                            else
                            {
                                return;
                            }
                            config_query();
                        }
                    }
                }
            }
            load();
        }
        public void update_function(string str1,string str2)
        {
            string str_Where = "  function_name='" + str1 + "'";
            string str_colName = " function_name='" + str2 + "' ";
            test_case.updateData(str_colName, str_Where);
            test_page.updateData(str_colName, str_Where);
        }

        private void config_add_button_Click(object sender, EventArgs e)
        {
            config_add ca = new config_add();
            ca.ShowDialog();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == dataGridView3.RowCount - 1)
            {
                return;
            }
            else
            {
                try
                {
                    string str_Where = "  id=" + dataGridView3.Rows[e.RowIndex].Cells["iframe_id_Column"].Value;
                    if (e.ColumnIndex == iframe_edit_Column.Index)
                    {
                        string str = "";
                        if (dataGridView3.Rows[e.RowIndex].Cells["iframe_name_Column"].Value.ToString() == "")
                        {
                            str = str + "iframe_name";
                        }
                        if (dataGridView3.Rows[e.RowIndex].Cells["iframe_sysname_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_colName=@"iframe_name= '" + dataGridView3.Rows[e.RowIndex].Cells["iframe_name_Column"].Value + "'," +
                                                 "sysname='" + dataGridView3.Rows[e.RowIndex].Cells["iframe_sysname_Column"].Value + "' ";
                            iframe.updateData(str_colName,str_Where);
                        }
                    }
                    else if (e.ColumnIndex == iframe_del_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                        if (di == DialogResult.Yes)
                        {
                            iframe.deleteData(str_Where);
                        }
                        else
                        {
                            return;
                        }
                        GetInfo();
                    }
                }
                catch
                {
                }
            }
        }

        private void iframe_all_edit_button_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView3.DataSource as DataTable;
            DataTable dtc = dt.GetChanges();
            if (dtc != null)
            {
                foreach (DataRow dr in dtc.Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        string str = "";
                        if (dr["iframe_name"].ToString() == "")
                        {
                            str = str + "iframe_name";
                        }
                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_col=@"'" + dr["iframe_name"] + "', '" + dr["被测系统名称"] + "');";
                            iframe.insertData("iframe_name,sysname", str_col);
                            iframe_query();
                        }
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        string str = "";
                        if (dr["iframe_name"].ToString() == "")
                        {
                            str = str + "iframe_name";
                        }
                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_colName = " iframe_name = '" + dr["iframe_name"] + "', sysname = '" + dr["被测系统名称"] + "'";
                            string str_Where = " id='" + dr["序号"] + "';";
                            iframe.updateData(str_colName, str_Where);
                        iframe_query();
                        }
                    }
                }
            }
        }

        private void iframe_query_button_Click(object sender, EventArgs e)
        {
            string str_colName = @" id as 序号,
                                  iframe_name,
                                  sysname as 被测系统名称,
                                  '编辑' as 编辑 ,
                                  '删除' as 删除 ";
            string str_Where = " 1=1 ";
            if (iframe_sysname_comboBox.SelectedIndex != 0)
            {
                str_Where = str_Where + " and sysname = '" + iframe_sysname_comboBox.Text.Trim() + "'";
            }
            DataSet ds = iframe.SelectData(str_colName, str_Where);
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = ds.Tables[0];
        }

        private void iframe_add_button_Click(object sender, EventArgs e)
        {
            iframe_add ifr = new iframe_add();
            ifr.ShowDialog();
        }

        private void page_query_button_Click(object sender, EventArgs e)
        {
            page_query();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            { return; }
            if (e.RowIndex == dataGridView4.RowCount - 1)
            { return; }
            else
            {
                try
                {
                    string str_colName = " page_name,element_name,sysname ";
                    string str_Where = " id=" + dataGridView4.Rows[e.RowIndex].Cells["page_id_Column"].Value + ";";
                    DataSet ds = page.SelectData(str_colName, str_Where);
                    DataTable dt_page = ds.Tables[0];

                    string str_page_value = dataGridView4.Rows[e.RowIndex].Cells["page_value_Column"].Value.ToString().Replace("'", @"\'");
                    str_page_value = str_page_value.Replace("\"", @"\'");
                    string str_colName3 = @"page_name='" + dataGridView4.Rows[e.RowIndex].Cells["page_function_name_Column"].Value + "'," +
                                                "element_name='" + dataGridView4.Rows[e.RowIndex].Cells["page_element_name_Column"].Value + "'," +
                                                "page_class='" + dataGridView4.Rows[e.RowIndex].Cells["page_class_Column"].Value + "'," +
                                                "page_value='" + str_page_value + "'," +
                                                "find_way='" + dataGridView4.Rows[e.RowIndex].Cells["page_find_way_Column"].Value + "'," +
                                                "sysname='" + dataGridView4.Rows[e.RowIndex].Cells["page_sysname_Column"].Value + "' ";

                    string str_colName2 = @" page_name='" + dataGridView4.Rows[e.RowIndex].Cells["page_function_name_Column"].Value + "'," +
                                          " element_name='" + dataGridView4.Rows[e.RowIndex].Cells["page_element_name_Column"].Value + "'";
                    string str_Where2 = @" page_name like '%"
                                            + dt_page.Rows[0][0].ToString() + "%' "
                                            + " and element_name like '%" + dt_page.Rows[0][1].ToString() + "%' "
                                            + " and sysname = '" + dt_page.Rows[0][2].ToString() + "' ";

                    if (e.ColumnIndex == page_edit_Column.Index)
                    {
                        string str = "";
                        if (dataGridView4.Rows[e.RowIndex].Cells["page_function_name_Column"].Value.ToString() == "")
                        {
                            str = str + "页面名称、";
                        }
                        if (dataGridView4.Rows[e.RowIndex].Cells["page_element_name_Column"].Value.ToString() == "")
                        {
                            str = str + "元素名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            test_page.updateData(str_colName2, str_Where2);
                            check_page.updateData(str_colName2, str_Where2);
                            steps_page.updateData(str_colName2, str_Where2);
                            page.updateData(str_colName3, str_Where);
                        }
                    }
                    if (e.ColumnIndex == page_del_Column.Index)
                    {
                        //先检查测试步骤没有用到该元素属性
                        string str_Where4 = @" page_name = '"
                                             + dt_page.Rows[0][0].ToString() + "' "
                                             + " and element_name ='" + dt_page.Rows[0][1].ToString() + "' "
                                             + " and sysname = '" + dt_page.Rows[0][2].ToString() + "' ";

                        DataSet ds4 = test_page.SelectData(" count(0) ", str_Where4);
                        DataTable dt_test_count = ds4.Tables[0];

                        //检查点步骤没有用到该元素属性
                        DataSet ds2 = check_page.SelectData("count(0)", str_Where2);
                        DataTable dt_check_count = ds2.Tables[0];

                        if (int.Parse(dt_test_count.Rows[0][0].ToString()) > 0 && int.Parse(dt_check_count.Rows[0][0].ToString()) > 0)
                        {
                            MessageBox.Show("该元素在组装测试步骤和检查点步骤中都使用到，不能删除");
                            return;
                        }
                        else if (int.Parse(dt_test_count.Rows[0][0].ToString()) > 0)
                        {
                            MessageBox.Show("该元素在组装测试步骤中使用到，不能删除");
                            return;
                        }
                        else if (int.Parse(dt_check_count.Rows[0][0].ToString()) > 0)
                        {
                            MessageBox.Show("该元素在组装检查点步骤中使用到，不能删除");
                            return;
                        }
                        else
                        {
                            DialogResult di;
                            di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                            if (di == DialogResult.Yes)
                            {
                                page.deleteData(str_Where);
                            }
                            else
                            {
                                return;
                            }
                            page_query();
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void page_all_edit_button_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView4.DataSource as DataTable;
            DataTable dtc = dt.GetChanges();
            if (dtc != null)
            {
                foreach (DataRow dr in dtc.Rows)
                {
                    string str_page_value = dr["页面属性值"].ToString();
                    str_page_value = str_page_value.Replace("'", @"\'");
                    str_page_value = str_page_value.Replace("\"", @"\'");
                    string str_Where2 = "  id=" + dr["序号"];
                    if (dr.RowState == DataRowState.Added)
                    {
                        string str = "";
                        if (dr["页面名称"].ToString() == "")
                        {
                            str = str + "页面名称、";
                        }
                        if (dr["元素名称"].ToString() == "")
                        {
                            str = str + "元素名称、";
                        }
                        if (dr["页面控件类型"].ToString() == "")
                        {
                            str = str + "页面控件类型、";
                        }
                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_col2 = @"'" + dr["页面名称"] + "',"
                                        + "'" + dr["元素名称"] + "',"
                                        + "'" + dr["页面控件类型"] + "',"
                                        + "\"" + str_page_value + "\","
                                        + "'" + dr["查找方式"] + "',"
                                        + "'" + dr["被测系统名称"] + "' ";
                            page.insertData("page_name,element_name,page_class,page_value,find_way,sysname", str_col2);
                            page_query();
                        }
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        string str = "";
                        if (dr["页面名称"].ToString() == "")
                        {
                            str = str + "页面名称、";
                        }
                        if (dr["元素名称"].ToString() == "")
                        {
                            str = str + "元素名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_colName2 = @"page_name='" + dr["页面名称"] + "',"
                                        + "element_name='" + dr["元素名称"] + "',"
                                        + "page_class='" + dr["页面控件类型"] + "',"
                                        + "page_value=\"" + str_page_value + "\","
                                        + "find_way='" + dr["查找方式"] + "',"
                                        + "sysname='" + dr["被测系统名称"] + "' ";
                            string str_colName = "page_name,element_name,sysname";
                            string str_Where = @"id=" + dr["序号"].ToString() + ";";
                            DataSet ds = page.SelectData(str_colName, str_Where);
                            DataTable dt_page = ds.Tables[0];
                            string str_colName3 = "page_name='" + dr["页面名称"].ToString() + "'," +
                                                    " element_name='" + dr["元素名称"].ToString() + "'";
                            string str_Where3=    "  page_name ='"+ dt_page.Rows[0][0].ToString() + "' "
                                                    + " and element_name = '" + dt_page.Rows[0][1].ToString() + "' "
                                                    + " and sysname = '" + dt_page.Rows[0][2].ToString() + "' ";
                            test_page.updateData(str_colName3, str_Where3);
                            check_page.updateData(str_colName3, str_Where3);
                            steps_page.updateData(str_colName3, str_Where3);
                            page.updateData(str_colName2, str_Where2);
                            page_query();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            page_add page = new page_add();
            page.Show();
        }

        private void test_query_button_Click(object sender, EventArgs e)
        {
            test_query();
        }

        private void dataGridView5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView5.Columns[e.ColumnIndex]; // 获取当前单元格，判断是否是指定的列
            if (col.Name == "result_Column")
            {
                //e.FormattingApplied = true; // 人为的设置装换是成功的
                var row = this.dataGridView5.Rows[e.RowIndex];
                if (row != null)
                {
                    try
                    {
                        if (row.Cells["result_Column"].Value.ToString().ToUpper().Equals("FAIL"))
                        {
                            this.dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                        }
                        else if (row.Cells["result_Column"].Value.ToString().ToUpper().Equals("NORUN"))
                        {
                            this.dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                        }
                        else if (row.Cells["result_Column"].Value.ToString().ToUpper().Equals("PASS"))
                        {
                            this.dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Green;
                        }
                    }
                    catch { }
                }
            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == dataGridView5.RowCount - 1)
            {
                return;
            }
            else
            {
                try
                {
                    string str_Where = "id=" + dataGridView5.Rows[e.RowIndex].Cells["test_id_x_Column"].Value;
                    if (e.ColumnIndex == test_edit_Column.Index)
                    {
                        string str = "";
                        if (dataGridView5.Rows[e.RowIndex].Cells["test_id_Column"].Value.ToString() == "")
                        {
                            str = str + "用例名称、";
                        }
                        if (dataGridView5.Rows[e.RowIndex].Cells["test_function_name_Column"].Value.ToString() == "")
                        {
                            str = str + "功能点名称、";
                        }
                        if (dataGridView5.Rows[e.RowIndex].Cells["compare_way_Column"].Value.ToString() == "")
                        {
                            str = str + "对比方式、";
                        }
                        if (dataGridView5.Rows[e.RowIndex].Cells["hope_way_Column"].Value.ToString() == "")
                        {
                            str = str + "期望输出结果方式、";
                        }
                        if (dataGridView5.Rows[e.RowIndex].Cells["test_sysname_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_colName = @"test_id='" + dataGridView5.Rows[e.RowIndex].Cells["test_id_Column"].Value + "'," +
                                                 "function_name='" + dataGridView5.Rows[e.RowIndex].Cells["test_function_name_Column"].Value + "'," +
                                                 "compare_way='" + dataGridView5.Rows[e.RowIndex].Cells["compare_way_Column"].Value + "'," +
                                                 "hope_way='" + dataGridView5.Rows[e.RowIndex].Cells["hope_way_Column"].Value + "'," +
                                                 "hope_result=\"" + dataGridView5.Rows[e.RowIndex].Cells["hope_result_Column"].Value + "\", ";
                            for (int i = 0; i < this.dataGridView5.ColumnCount - 13; i++)
                            {
                                str_colName = str_colName + " col" + i.ToString() + "='" + dataGridView5.Rows[e.RowIndex].Cells["col" + i.ToString()].Value + "',";
                            }
                            str_colName = str_colName + " sysname='" + dataGridView5.Rows[e.RowIndex].Cells["test_sysname_Column"].Value + "' ";
                            test_case.updateData(str_colName, str_Where);
                            GetInfo();
                        }
                    }
                    else if (e.ColumnIndex == test_del_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                        if (di == DialogResult.Yes)
                        {
                            test_case.deleteData(str_Where);
                        }
                        else
                        {
                            return;
                        }
                        GetInfo();
                    }
                }
                catch
                {
                }
            }
        }

        private void test_addbutton_Click(object sender, EventArgs e)
        {
            test_case_add test_f = new test_case_add();
            test_f.ShowDialog();

        }

        // bool _selectAll = false;
        private void choose_all_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView5.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView5.Rows.Count - 1; i++)
                {
                    this.dataGridView5.Rows[i].Cells["choose_Column"].Value = true;
                    //this._selectAll = true;
                }
            }
        }

        private void select_cancel_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView5.Rows.Count - 1; i++)
            {
                this.dataGridView5.Rows[i].Cells["choose_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void choose_Inverse_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView5.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView5.Rows.Count - 1; i++)
                {
                    bool se = false;
                    if (dataGridView5.Rows[i].Cells["choose_Column"].Value == null)
                    {
                        this.dataGridView5.Rows[i].Cells["choose_Column"].Value = true;
                        // this._selectAll = true;
                        se = true;
                    }
                    else if ((bool)dataGridView5.Rows[i].Cells["choose_Column"].Value == true && se == false)
                    {
                        this.dataGridView5.Rows[i].Cells["choose_Column"].Value = false;
                    }
                    else if ((bool)dataGridView5.Rows[i].Cells["choose_Column"].Value == false)
                    {
                        this.dataGridView5.Rows[i].Cells["choose_Column"].Value = true;
                        //this._selectAll = true;
                    }
                }
            }
        }

        private void test_all_edit_button_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView5.DataSource as DataTable;
            DataTable dtc = dt.GetChanges();
            if (dtc != null)
            {
                foreach (DataRow dr in dtc.Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        string str = "";
                        if (dr["用例名称"].ToString() == "")
                        {
                            str = str + "用例名称、";
                        }
                        if (dr["功能点名称"].ToString() == "")
                        {
                            str = str + "功能点名称、";
                        }
                        if (dr["对比方式"].ToString() == "")
                        {
                            str = str + "对比方式、";
                        }
                        if (dr["期望输出结果方式"].ToString() == "")
                        {
                            str = str + "期望输出结果方式、";
                        }
                        if (dr["被测系统名"].ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_col1 = "test_id,function_name,compare_way,hope_way,hope_result,sysname ";
                            string str_col2 = @"'" + dr["用例名称"] + "',"
                                                   + "'" + dr["功能点名称"].ToString().Trim() + "',"
                                                   + "'" + dr["对比方式"] + "',"
                                                   + "'" + dr["期望输出结果方式"] + "',"
                                                   + "'" + dr["期望结果"] + "',"
                                                   + "'" + dr["被测系统名"] + "' ";
                            if (this.dataGridView5.ColumnCount > 13)
                            {
                                for (int i = 0; i < this.dataGridView5.ColumnCount - 13; i++)
                                {
                                    str_col1 = str_col1 + " ,col" + i;
                                    str_col2 = str_col2 + " ,'" + dr["col" + i] + "'";
                                }
                                test_case.insertData(str_col1, str_col2);
                            }
                            else
                            {
                                test_case.insertData(str_col1, str_col2);
                            }
                            test_query();
                        }
                    }
                    if (dr.RowState == DataRowState.Modified)
                    {
                        string str = "";
                        if (dr["用例名称"].ToString() == "")
                        {
                            str = str + "用例名称、";
                        }
                        if (dr["功能点名称"].ToString() == "")
                        {
                            str = str + "功能点名称、";
                        }
                        if (dr["对比方式"].ToString() == "")
                        {
                            str = str + "对比方式、";
                        }
                        if (dr["期望输出结果方式"].ToString() == "")
                        {
                            str = str + "期望输出结果方式、";
                        }
                        if (dr["被测系统名"].ToString() == "")
                        {
                            str = str + "被测系统名称、";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空！");
                        }
                        else
                        {
                            string str_colName = @"test_id='" + dr["用例名称"] + "',"
                                                  + "function_name='" + dr["功能点名称"].ToString().Trim() + "',"
                                                  + "compare_way='" + dr["对比方式"] + "',"
                                                  + "hope_way='" + dr["期望输出结果方式"] + "',"
                                                  + "hope_result=\"" + dr["期望结果"] + "\","
                                                  + "sysname='" + dr["被测系统名"] + "'";
                            string str_Where = "id='" + dr["序号"] + "';";
                            for (int i = 0; i <= this.dataGridView5.ColumnCount - 14; i++)
                            {
                                str_colName = str_colName + ",col" + i + "='" + dr["col" + i] + "'";
                            }
                            test_case.updateData(str_colName, str_Where);
                        }
                        test_query();
                    }
                }
            }
        }

        private void all_del_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView5.Rows.Count - 1; i++)
            {
                if (dataGridView5.Rows[i].Cells["choose_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView5.Rows[i].Cells["choose_Column"].Value == true)
                {
                    if (dataGridView5.Rows[i].Cells["test_id_x_Column"].Value.ToString() != "")
                    {
                        string str_Where=" id=" + dataGridView5.Rows[i].Cells["test_id_x_Column"].Value;
                        test_case.deleteData(str_Where);
                    }
                }
            }
            test_query();
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            run_test rt = new run_test();
            rt.ShowDialog();
        }

        private void add_setp_button_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (test_sysname_comboBox.SelectedIndex != 0)
            {
                index = test_sysname_comboBox.SelectedIndex;
            }

            step step = new step(index, test_f_comboBox.SelectedIndex, test_f_comboBox.SelectedIndex);
            step.ShowDialog();
        }

        private void check_querybutton_Click(object sender, EventArgs e)
        {
            check_point_query();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == dataGridView7.RowCount)
            {
                return;
            }
            else
            {
                try
                {
                    string str_Where = "id=" + dataGridView7.Rows[e.RowIndex].Cells["check_point_Column"].Value ;
                    if (e.ColumnIndex == check_edit2_Column.Index)
                    {
                        string str = "";
                        if (dataGridView7.Rows[e.RowIndex].Cells["check_point2_Column"].Value.ToString() == "")
                        {
                            str = str + "检查点名称";
                        }
                        if (dataGridView7.Rows[e.RowIndex].Cells["check_sysname2_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            string str_colName = "distinct check_point_name";
                            DataSet ds = check_page.SelectData(str_colName, str_Where);
                            DataTable dt2 = ds.Tables[0];
                            string str_colName2 = " check_point_name='" + dataGridView7.Rows[e.RowIndex].Cells["check_point2_Column"].Value + "' ";
                            if (dt2.Rows.Count == 1)
                            {
                                string str_Where2 = " check_point_name='" + dt2.Rows[0][0].ToString() + "'";
                                check_page.updateData(str_colName2, str_Where2);
                            }
                            for (int i = 0; i < dataGridView7.ColumnCount - 6; i++)
                            {
                                str_colName2 = str_colName2 + "  col" + i.ToString() + "='" + dataGridView7.Rows[e.RowIndex].Cells["col" + i.ToString()].Value + "', ";
                            }
                            str_colName2 = str_colName2 + "sysname = '" + dataGridView7.Rows[e.RowIndex].Cells["check_sysname2_Column"].Value + "'";
                            check_point.updateData(str_colName2, str_Where);
                        }
                        check_point_query();
                    }
                    else if (e.ColumnIndex == check_del2_Column.Index)
                    {
                        string str_Where2 = "check_point_name='"
                                                     + dataGridView7.Rows[e.RowIndex].Cells["check_point2_Column"].Value + "' "
                                                     + " and ( sysname ='" + dataGridView7.Rows[e.RowIndex].Cells["check_sysname2_Column"].Value + "' or sysname='all_system')";
                        DialogResult di;
                        di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                        if (di == DialogResult.Yes)
                        {
                            check_point.deleteData(str_Where);
                            check_page.deleteData(str_Where2);
                        }
                        else
                        {
                            return;
                        }
                        check_point_query();
                    }
                    else if (e.ColumnIndex == check_point2_Column.Index)
                    {
                        string check_sysname = dataGridView7.Rows[e.RowIndex].Cells["check_sysname2_Column"].Value.ToString();
                        string check_name = dataGridView7.Rows[e.RowIndex].Cells["check_point2_Column"].Value.ToString();
                        check_step cs = new check_step(check_sysname, check_name);
                        cs.ShowDialog();
                        this.dataGridView7.Rows[e.RowIndex].Cells["check_point2_Column"].Style.ForeColor = Color.Black;
                    }
                }
                catch
                {
                }
            }
        }

        private void check_all_edit_button_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView7.DataSource as DataTable;
            DataTable dtc = dt.GetChanges();
            if (dtc != null)
            {
                foreach (DataRow dr in dtc.Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        string str = "";
                        if (dr["检查点名称"].ToString() == "")
                        {
                            str = str + "检查点名称";
                        }
                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            string str_col1 = "check_point_name,sysname";
                            string str_col2 = "'" + dr["检查点名称"] + "'," + "'" + dr["被测系统名称"] + "'";
                            check_point.insertData(str_col1, str_col2);
                            check_point_query();
                        }
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        string str = "";
                        if (dr["检查点名称"].ToString() == "")
                        {
                            str = str + "检查点名称";
                        }
                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            string str_colName = "distinct check_point_name ";
                            string str_Where = "id=" + dr["序号"] + ";";
                            DataSet ds = check_page.SelectData(str_colName, str_Where);
                            DataTable dt2 = ds.Tables[0];
                            string str_colName2 = "check_point_name='" + dr["检查点名称"] + "'  ";
                            if (dt2.Rows.Count == 1)
                            {
                                string str_Where2 = " check_point_name='" + dt2.Rows[0][0].ToString() + "'";
                                check_page.updateData(str_colName2, str_Where2);
                            }
                            for (int i = 0; i < dataGridView7.ColumnCount - 6; i++)
                            {
                                str_colName2 = str_colName2 + "  col" + i.ToString() + "=\"" + dr["col" + i.ToString()] + "\",";
                            }
                            str_colName2 = str_colName2 + @"sysname = '" + dr["被测系统名称"] + "'  ";
                            string str_Where3 = "   id=" + dr["序号"] + ";";
                            check_point.updateData(str_colName2, str_Where3);
                            check_point_query();
                        }
                    }
                }
            }
        }

        private void check_step_button_Click(object sender, EventArgs e)
        {
            check_step cs = new check_step(check_sysname_comboBox.Text, check_name_textBox.Text);
            cs.ShowDialog();
            check_point_query();
        }

        private void export_button_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView5.DataSource as DataTable;
            export export = new export();
            export.ShowDialog();
        }

        private void check_add_button_Click(object sender, EventArgs e)
        {
            check_add c_add = new check_add();
            c_add.ShowDialog();
        }

        private void import_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog di = new OpenFileDialog();
            //di.DefaultExt = "xls";
            di.Filter = "Excel文件|*.xls";
            di.ShowDialog();
            if (di.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(di.FileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);

                }
                int sheetcount = hssfworkbook.NumberOfSheets;
                if (sheetcount > 0)
                {
                    for (int sheet_index = 0; sheet_index < sheetcount; sheet_index++)
                    {
                        string SheetName = hssfworkbook.GetSheetName(sheet_index);
                        if (SheetName == "function_name")
                        {
                            continue;
                        }
                        DataTable dt = new DataTable();
                        ISheet sheet = hssfworkbook.GetSheetAt(sheet_index);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;

                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            if (i != 0 && i != 3 && i != 7 && i != 8)
                            {
                                DataColumn column;
                                if (dt.Columns.Contains(headerRow.GetCell(i).StringCellValue))
                                {
                                    column = new DataColumn(headerRow.GetCell(i).StringCellValue + "a"+i);
                                }
                                else
                                {
                                    column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                                }
                                dt.Columns.Add(column);
                            }
                        }

                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dt.NewRow();
                            if (row != null)
                            {
                                int a = 0;
                                int b = 0;

                                if (row.GetCell(1) != null && row.GetCell(2) != null && row.GetCell(9) != null)
                                {
                                    for (int j = 0; j < cellCount; j++)
                                    {
                                        if (j == 0 || j == 3 || j == 7 || j == 8 )
                                        {
                                            b = b + 1;
                                        }
                                        if (row.GetCell(j) == null && j != 0 && j != 3 && j != 7 && j != 8)
                                        {
                                            a = a + 1;
                                            b = b + 1;
                                        }
                                        if (row.GetCell(j) != null && j != 0 && j != 3 && j != 7 && j != 8)
                                        {
                                            dataRow[a] = row.GetCell(b).ToString();
                                            a = a + 1;
                                            b = b + 1;
                                        }
                                    }
                                }
                                dt.Rows.Add(dataRow);
                            }
                        }

                        if (dt != null)
                        {

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string str_col1="test_id,function_name,compare_way,hope_way,hope_result,sysname";
                                string str_col2 = "";
                                for (int j = 0; j < dt.Columns.Count - 6; j++)
                                {
                                    str_col1 = str_col1 + ",col" + j.ToString();
                                }
                                int k2 = 0;
                                for (int k = 0; k < dt.Columns.Count - 1; k++)
                                {
                                    str_col2 = str_col2 + "'" + dt.Rows[i][k].ToString().Trim() + "',";
                                    if (dt.Rows[i][k].ToString().Trim() == "")
                                    {
                                        k2 = k2 + 1;
                                    }
                                }
                                if (k2 != dt.Columns.Count - 1)
                                {
                                    str_col2 = str_col2 + "'" + dt.Rows[i][dt.Columns.Count - 1].ToString().Trim() + "');";
                                    string str_Where = @"test_id='" + dt.Rows[i][0].ToString().Trim() + "' "
                                                 + " and function_name='" + dt.Rows[i][1].ToString().Trim() + "' "
                                                 + " and compare_way='" + dt.Rows[i][2].ToString().Trim() + "' "
                                                 + " and hope_way='" + dt.Rows[i][3].ToString().Trim() + "' "
                                                 + " and hope_result='" + dt.Rows[i][4].ToString().Trim() + "' "
                                                 + " and sysname='" + dt.Rows[i][5].ToString().Trim() + "' ";
                                    if (dt.Columns.Count > 6)
                                    {
                                        for (int j = 0; j < dt.Columns.Count - 6; j++)
                                        {
                                            str_Where = str_Where + " and col" + j.ToString() + "='" + dt.Rows[i][6 + j].ToString().Trim() + "' ";
                                        }
                                    }
                                    DataSet ds= test_case.SelectData("count(0)", str_Where);
                                    DataTable dt_t_c = ds.Tables[0];
                                    if (int.Parse(dt_t_c.Rows[0][0].ToString()) == 0)
                                    {
                                        test_case.insertData(str_col1, str_col2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
       
        private void export_excel_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.DefaultExt = "xls";
            dig.Filter = "Excel文件|*.xls";
            if (dig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook = new HSSFWorkbook();
                string str_colName = "page_name,element_name,page_class,page_value,find_way,sysname";
                string str_order = " sysname,page_name ";
                DataSet ds = page.SelectData(str_colName, "1=1", str_order);
                DataTable dt2 = ds.Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    ISheet sheet1 = hssfworkbook.CreateSheet("配置页面属性");
                    FileStream file = new FileStream(dig.FileName, FileMode.Create);
                    HSSFCellStyle dateStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
                    dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                    IRow row1 = sheet1.CreateRow(0);
                    row1.CreateCell(0).SetCellValue("页面名称");
                    row1.CreateCell(1).SetCellValue("元素名称");
                    row1.CreateCell(2).SetCellValue("页面控件类型");
                    row1.CreateCell(3).SetCellValue("元素属性值");
                    row1.CreateCell(4).SetCellValue("元素查找方式");
                    row1.CreateCell(5).SetCellValue("被测系统名称");
                    for (int w_i = 0; w_i < 5; w_i++)
                    {
                        sheet1.SetColumnWidth(w_i, 28 * 256);
                    }
                    if (dt2 != null)
                    {
                        for (int k = 0; k < dt2.Rows.Count; k++)
                        {
                            HSSFRow dataRow = sheet1.CreateRow(k + 1) as HSSFRow;
                            foreach (DataColumn column in dt2.Columns)
                            {
                                HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
                                string drValue = dt2.Rows[k][column.Ordinal].ToString();
                                switch (column.DataType.ToString())
                                {
                                    case "System.String": //字符串类型
                                        newCell.SetCellValue(drValue);
                                        break;
                                    case "System.DateTime": //日期类型
                                        DateTime dateV;
                                        DateTime.TryParse(drValue, out dateV);
                                        newCell.SetCellValue(dateV);

                                        newCell.CellStyle = dateStyle; //格式化显示
                                        break;
                                    case "System.Boolean": //布尔型
                                        bool boolV = false;
                                        bool.TryParse(drValue, out boolV);
                                        newCell.SetCellValue(boolV);
                                        break;
                                    case "System.Int16": //整型
                                    case "System.Int32":
                                    case "System.Int64":
                                    case "System.Byte":
                                        int intV = 0;
                                        int.TryParse(drValue, out intV);
                                        newCell.SetCellValue(intV);
                                        break;
                                    case "System.Decimal": //浮点型
                                    case "System.Double":
                                        double doubV = 0;
                                        double.TryParse(drValue, out doubV);
                                        newCell.SetCellValue(doubV);
                                        break;
                                    case "System.DBNull": //空值处理
                                        newCell.SetCellValue("");
                                        break;
                                    default:
                                        newCell.SetCellValue("");
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        return;
                    }

                    CellRangeAddressList company = new CellRangeAddressList(1, 65535, 2, 2);
                    DVConstraint company2 = DVConstraint.CreateExplicitListConstraint(new string
                    [] { "输入框", "复选框", "单选框", "下拉框", "文本框", "按钮", "双击", "iframe", "检查点", "步骤组", "刷新", "等待时间" });
                    HSSFDataValidation dataValidate = new HSSFDataValidation(company, company2);
                    sheet1.AddValidationData(dataValidate);
                    CellRangeAddressList hope_way = new CellRangeAddressList(1, 65535, 4, 4);
                    DVConstraint hope_way2 = DVConstraint.CreateExplicitListConstraint(new string
                    [] {"by_id", "by_xpath", "by_name", "by_class_name", "by_tag_name", "by_link_text", "by_partial_link_text", "by_css_selector" });
                    HSSFDataValidation dataValidate2 = new HSSFDataValidation(hope_way, hope_way2);
                    sheet1.AddValidationData(dataValidate2);

                    DataSet ds2 = tc.SelectData("sysname","1=1");
                    DataTable dt = ds2.Tables[0];
                    string[] str = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str[i] = dt.Rows[i]["sysname"].ToString();
                    }
                    CellRangeAddressList sysname = new CellRangeAddressList(1, 65535, 5, 5);
                    DVConstraint sysname2 = DVConstraint.CreateExplicitListConstraint(str);
                    HSSFDataValidation sysname3 = new HSSFDataValidation(sysname, sysname2);
                    sheet1.AddValidationData(sysname3);
                    hssfworkbook.Write(file);
                    file.Close();
                }
            }
        }
        private void import_page_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog di = new OpenFileDialog();
            //di.DefaultExt = "xls";
            di.Filter = "Excel文件|*.xls";
            di.ShowDialog();
            if (di.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(di.FileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);

                }
                int sheetcount = hssfworkbook.NumberOfSheets;
                if (sheetcount > 0)
                {
                    for (int sheet_index = 0; sheet_index < sheetcount; sheet_index++)
                    {
                        DataTable dt = new DataTable();
                        ISheet sheet = hssfworkbook.GetSheetAt(sheet_index);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                            dt.Columns.Add(column);
                        }
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dt.NewRow();
                            if (row != null)
                            {
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    if (row.GetCell(j) != null)
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                                }
                                dt.Rows.Add(dataRow);
                            }
                        }

                        if (dt != null)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string[] list = new string[6];
                                string str_col1 = "page_name ,element_name ,page_class,page_value,find_way,sysname";
                                string str_col2 = "";
                                int k2 = 0;
                                for (int k = 0; k < dt.Columns.Count - 1; k++)
                                {
                                    dt.Rows[i][k] = dt.Rows[i][k].ToString().Replace("'", @"\'");
                                    dt.Rows[i][k] = dt.Rows[i][k].ToString().Replace("\"", @"\'");
                                    str_col2 = str_col2 + "\"" + dt.Rows[i][k].ToString().Trim() + "\",";
                                    list[k] = dt.Rows[i][k].ToString().Trim();
                                    if (dt.Rows[i][k].ToString().Trim() == "")
                                    {
                                        k2 = k2 + 1;
                                    }
                                }
                                if (k2 != dt.Columns.Count - 1)
                                {
                                    str_col2 = str_col2 + "\"" + dt.Rows[i][dt.Columns.Count - 1].ToString().Trim() + "\"";
                                    list[5] = dt.Rows[i][dt.Columns.Count - 1].ToString().Trim();
                                    string str_Where =@" page_name='" + list[0] + "' "
                                                   + "and element_name='" + list[1] + "' "
                                                   + "and page_class='" + list[2] + "' "
                                                   + "and page_value='" + list[3] + "' "
                                                   + "and find_way='" + list[4] + "' "
                                                   + "and sysname='" + list[5] + "' ";
                                    DataSet ds = page.SelectData(" count(0)", str_Where);
                                    DataTable dt2 = ds.Tables[0];
                                    if (int.Parse(dt2.Rows[0][0].ToString()) == 0)
                                    {
                                        page.insertData(str_col1, str_col2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void query_button_Click(object sender, EventArgs e)
        {
            string a = "";
            string b = "";
            steps_group_query(a, b);
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.RowIndex == dataGridView6.RowCount)
            {
                return;
            }
            else
            {
                try
                {
                    string str_Where ="id=" + dataGridView6.Rows[e.RowIndex].Cells["steps_id_Column"].Value ;
                    if (e.ColumnIndex == step_edit_Column.Index)
                    {
                        string str = "";
                        if (dataGridView6.Rows[e.RowIndex].Cells["step_name_Column"].Value.ToString() == "")
                        {
                            str = str + "步骤组名称";
                        }
                        if (dataGridView6.Rows[e.RowIndex].Cells["group_sysname_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            DataSet ds = steps.SelectData("distinct steps_name ",str_Where);
                            DataTable dt2 = ds.Tables[0];
                            string str_colName2 = "steps_name='" + dataGridView6.Rows[e.RowIndex].Cells["step_name_Column"].Value.ToString().Trim() + "'";
                            if (dt2.Rows.Count == 1)
                            {
                                string str_Where2=" steps_name='" + dt2.Rows[0][0].ToString() + "'";
                                steps_page.updateData(str_colName2,str_Where2);
                            }
                            for (int i = 0; i < dataGridView6.ColumnCount - 6; i++)
                            {
                                str_colName2 = str_colName2 + " ,col" + i.ToString() + "='" + dataGridView6.Rows[e.RowIndex].Cells["col" + i.ToString()].Value.ToString().Trim() + "' ";
                            }
                            str_colName2 = str_colName2 + " ,sysname = '" + dataGridView6.Rows[e.RowIndex].Cells["group_sysname_Column"].Value + "'";
                            steps.updateData(str_colName2, str_Where);
                            string a = "";
                            string b = "";
                            steps_group_query(a, b);
                        }
                    }
                    else if (e.ColumnIndex == step_del_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                        if (di == DialogResult.Yes)
                        {
                            steps.deleteData(str_Where);
                            string str_Where2 = @"steps_name='" + dataGridView6.Rows[e.RowIndex].Cells["step_name_Column"].Value + "' "
                                        + " and (sysname='" + dataGridView6.Rows[e.RowIndex].Cells["group_sysname_Column"].Value + "' or sysname='all_system')";
                            steps_page.deleteData(str_Where2);
                        }
                        else
                        {
                            return;
                        }
                        string a = "";
                        string b = "";
                        steps_group_query(a, b);
                    }
                    else if (e.ColumnIndex == step_name_Column.Index)
                    {
                        string sysname_s_g = dataGridView6.Rows[e.RowIndex].Cells["group_sysname_Column"].Value.ToString();
                        string steps_groups_name = dataGridView6.Rows[e.RowIndex].Cells["step_name_Column"].Value.ToString();
                        steps_group s_g = new steps_group(sysname_s_g, steps_groups_name);
                        s_g.ShowDialog();
                        this.dataGridView6.Rows[e.RowIndex].Cells["step_name_Column"].Style.ForeColor = Color.Black;
                    }
                }
                catch
                {
                }
            }
        }

        private void steps_alledit_button_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView6.DataSource as DataTable;
            DataTable dtc = dt.GetChanges();
            if (dtc != null)
            {
                foreach (DataRow dr in dtc.Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        string str = "";
                        if (dr["步骤组名称"].ToString() == "")
                        {
                            str = str + "步骤组名称";
                        }
                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            string str_col1 = "steps_name,sysname";
                            string str_col2="'" + dr["步骤组名称"] + "', '" + dr["被测系统名称"] + "') ";
                            steps.insertData(str_col1, str_col2);
                        }
                    }
                    if (dr.RowState == DataRowState.Modified)
                    {
                        string str = "";
                        if (dr["步骤组名称"].ToString() == "")
                        {
                            str = str + "步骤组名称";
                        }
                        if (dr["被测系统名称"].ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            string str_Where = "id=" + dr["序号"];
                            DataSet ds = steps.SelectData("distinct steps_name",str_Where);
                            DataTable dt2 = ds.Tables[0];
                            if (dt2.Rows.Count == 1)
                            {
                                string str_colName2 = "steps_name='" + dr["步骤组名称"] + "',  sysname ='" + dr["被测系统名称"] + "'";
                                string str_Where2=" steps_name='" + dt2.Rows[0][0].ToString() + "'";
                                steps_page.updateData(str_colName2, str_Where2);
                            }
                            string str_colName3 = "steps_name='" + dr["步骤组名称"] + "',";
                            for (int i = 0; i < dataGridView6.ColumnCount - 6; i++)
                            {
                                str_colName3 = str_colName3 + "  col" + i.ToString() + "=\"" + dr["col" + i.ToString()] + "\",";
                            }
                            str_colName3 = str_colName3 + "sysname = '" + dr["被测系统名称"] + "'  ";
                            steps.updateData(str_colName3, str_Where);
                        }
                        string a = "";
                        string b = "";
                        steps_group_query(a, b);
                    }
                }
            }
            if (dataGridView8.Visible == true)
            {
                string str = "";
                if (dataGridView8.Rows[0].Cells["group_sysname_2_Column"].Value.ToString()== "")
                {
                    str = str + "被测系统名称";
                }
                if (dataGridView8.Rows[0].Cells["step_name_2_Column"].Value.ToString() == "")
                {
                    str = str + "步骤组名称";
                }
                if (str != "")
                {
                    MessageBox.Show(str + "不能为空!");
                }
                else
                {
                    string str_Where = "  id=" + dataGridView8.Rows[0].Cells["steps_id_2_Column"].Value + ";";
                    string str_colName = "distinct steps_name ";
                    DataSet ds = steps.SelectData(str_colName, str_Where);
                    DataTable dt2 = ds.Tables[0];
                    string str_colName2 = "steps_name='" + dataGridView8.Rows[0].Cells["step_name_2_Column"].Value + "', "
                                                   + " sysname ='" + dataGridView8.Rows[0].Cells["group_sysname_2_Column"].Value + "'";
                    if (dt2.Rows.Count == 1)
                    {
                        string str_Where2 =" steps_name='" + dt2.Rows[0][0].ToString() + "'";
                        steps_page.updateData(str_colName2, str_Where2);
                    }
                    for (int i = 0; i < dataGridView8.ColumnCount - 5; i++)
                    {
                        str_colName2 = str_colName2 + ",  col" + i.ToString() + "='" + dataGridView8.Rows[0].Cells["col" + i.ToString()].Value.ToString().Trim() + "' ";
                    }
                    steps.updateData(str_colName2, str_Where);
                    string a = "";
                    string b = "";
                    steps_group_query(a, b);
                }
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            add_setps add_s = new add_setps();
            add_s.ShowDialog();
        }

        private void add_steps_button_Click(object sender, EventArgs e)
        {
            steps_group s_g = new steps_group(sysname_comboBox.Text, steps_group_textBox.Text);
            s_g.ShowDialog();
            string a = "";
            string b = "";
            steps_group_query(a, b);
        }

        private void select_all_p_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView4.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView4.Rows.Count - 1; i++)
                {
                    this.dataGridView4.Rows[i].Cells["select_Column"].Value = true;
                    //this._selectAll = true;
                }
            }
        }

        private void select_c_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView4.Rows.Count - 1; i++)
            {
                this.dataGridView4.Rows[i].Cells["select_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void select_Inverse_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView4.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView4.Rows.Count - 1; i++)
                {
                    bool se = false;
                    if (dataGridView4.Rows[i].Cells["select_Column"].Value == null)
                    {
                        this.dataGridView4.Rows[i].Cells["select_Column"].Value = true;
                        // this._selectAll = true;
                        se = true;
                    }
                    else if ((bool)dataGridView4.Rows[i].Cells["select_Column"].Value == true && se == false)
                    {
                        this.dataGridView4.Rows[i].Cells["select_Column"].Value = false;
                    }
                    else if ((bool)dataGridView4.Rows[i].Cells["select_Column"].Value == false)
                    {
                        this.dataGridView4.Rows[i].Cells["select_Column"].Value = true;
                        //this._selectAll = true;
                    }
                }
            }
        }

        private void page_all_del_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView4.Rows.Count - 1; i++)
            {
                if (dataGridView4.Rows[i].Cells["select_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView4.Rows[i].Cells["select_Column"].Value == true)
                {
                    if (dataGridView4.Rows[i].Cells["page_id_Column"].Value.ToString() != "")
                    {
                        string str_Where = "id=" + dataGridView4.Rows[i].Cells["page_id_Column"].Value;
                        page.deleteData(str_Where);
                    }
                }
            }
            page_query();
        }

        private void c_select_all_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView7.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView7.Rows.Count - 1; i++)
                {
                    this.dataGridView7.Rows[i].Cells["check_select_Column"].Value = true;
                    //this._selectAll = true;
                }
            }
        }

        private void c_select_cancel_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView7.Rows.Count - 1; i++)
            {
                this.dataGridView7.Rows[i].Cells["check_select_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void c_Inverse_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView7.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView7.Rows.Count - 1; i++)
                {
                    bool se = false;
                    if (dataGridView7.Rows[i].Cells["check_select_Column"].Value == null)
                    {
                        this.dataGridView7.Rows[i].Cells["check_select_Column"].Value = true;
                        // this._selectAll = true;
                        se = true;
                    }
                    else if ((bool)dataGridView7.Rows[i].Cells["check_select_Column"].Value == true && se == false)
                    {
                        this.dataGridView7.Rows[i].Cells["check_select_Column"].Value = false;
                    }
                    else if ((bool)dataGridView7.Rows[i].Cells["check_select_Column"].Value == false)
                    {
                        this.dataGridView7.Rows[i].Cells["check_select_Column"].Value = true;
                        //this._selectAll = true;
                    }
                }
            }
        }

        private void c_all_del_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView7.Rows.Count - 1; i++)
            {
                if (dataGridView7.Rows[i].Cells["check_select_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView7.Rows[i].Cells["check_select_Column"].Value == true)
                {
                    if (dataGridView7.Rows[i].Cells["check_point_Column"].Value.ToString() != "")
                    {
                        string str_Where = " id=" + dataGridView7.Rows[i].Cells["check_point_Column"].Value;
                        check_point.deleteData(str_Where);
                        string str_Where2 = "check_point_name='"+ dataGridView7.Rows[i].Cells["check_point2_Column"].Value + "' "
                                                      + " and ( sysname ='" + dataGridView7.Rows[i].Cells["check_sysname2_Column"].Value + "' or sysname='all_system')";
                        check_page.deleteData(str_Where2);
                    }
                }
            }
            check_point_query();
        }

        private void s_select_all_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView6.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView6.Rows.Count - 1; i++)
                {
                    this.dataGridView6.Rows[i].Cells["steps_select_Column"].Value = true;
                    //this._selectAll = true;
                }
            }
        }

        private void s_select_cancel_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView6.Rows.Count - 1; i++)
            {
                this.dataGridView6.Rows[i].Cells["steps_select_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void s_Inverse_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView6.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView6.Rows.Count - 1; i++)
                {
                    bool se = false;
                    if (dataGridView6.Rows[i].Cells["steps_select_Column"].Value == null)
                    {
                        this.dataGridView6.Rows[i].Cells["steps_select_Column"].Value = true;
                        // this._selectAll = true;
                        se = true;
                    }
                    else if ((bool)dataGridView6.Rows[i].Cells["steps_select_Column"].Value == true && se == false)
                    {
                        this.dataGridView6.Rows[i].Cells["steps_select_Column"].Value = false;
                    }
                    else if ((bool)dataGridView6.Rows[i].Cells["steps_select_Column"].Value == false)
                    {
                        this.dataGridView6.Rows[i].Cells["steps_select_Column"].Value = true;
                        //this._selectAll = true;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView6.Rows.Count - 1; i++)
            {
                if (dataGridView6.Rows[i].Cells["steps_select_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView6.Rows[i].Cells["steps_select_Column"].Value == true)
                {
                    if (dataGridView6.Rows[i].Cells["steps_select_Column"].Value.ToString() != "")
                    {
                        string str_Where = "id=" + dataGridView6.Rows[i].Cells["steps_id_Column"].Value;
                        steps.deleteData(str_Where);
                        string str_Where2 = " steps_name='" + dataGridView6.Rows[i].Cells["step_name_Column"].Value + "' "
                                             + " and (sysname='" + dataGridView6.Rows[i].Cells["group_sysname_Column"].Value + "' or sysname='all_system')";
                        steps_page.deleteData(str_Where2);
                    }
                }
            }
            string a = "";
            string b = "";
            steps_group_query(a, b);
        }

        private void Repeat_button_Click(object sender, EventArgs e)
        {
            string str_colName = @"id as 序号,
                                   page_name as 页面名称,
                                   element_name as 元素名称,
                                   page_class as 页面控件类型,
                                   page_value as 页面属性值,
                                   find_way as 查找方式,
                                   sysname as 被测系统名称,
                                   '编辑' as 编辑 ,
                                   '删除' as 删除 ";
            string str_Where = @"(page_name ,element_name,sysname) in
                                 (select page_name ,element_name,sysname from page_properties
                                  group by page_name ,element_name,sysname
                                  having count(*)>1) ";
            string str_order = "sysname,page_name,element_name";
            dataGridView4.AutoGenerateColumns = false;
            DataSet ds= page.SelectData(str_colName, str_Where, str_order);
            dataGridView4.DataSource = ds.Tables[0];
        }

        private void test_sysname_comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string str_colName = " distinct function_name ";
            string str_Where = " 1=1 ";
            if (test_sysname_comboBox.SelectedIndex != 0)
            {
                str_Where = str_Where + " and sysname ='" + test_sysname_comboBox.Text.ToString() + "'";
            }
            DataSet ds = config.SelectData(str_colName, str_Where);
            DataTable dt_function = ds.Tables[0];
            test_f_comboBox.Text = "";
            test_f_comboBox.DataSource = dt_function.Copy();
            test_f_comboBox.DisplayMember = "function_name";

            this.test_f_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.test_f_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            string str_Where = " sysname !='all_system' and page_class!='iframe'";
            string str_colName = "check_find='N'";
            page.updateData(str_colName, str_Where);
            for (int i = 0; i < this.dataGridView4.Rows.Count - 1; i++)
            {
                if (dataGridView4.Rows[i].Cells["select_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView4.Rows[i].Cells["select_Column"].Value == true)
                {
                    if (dataGridView4.Rows[i].Cells["page_id_Column"].Value.ToString() != "")
                    {
                        string str_colName2 = "check_find='Y' ";
                        string str_Where2 = "id=" + dataGridView4.Rows[i].Cells["page_id_Column"].Value 
                                             + "  and sysname !='all_system' and page_class!='iframe'";
                        page.updateData(str_colName2,str_Where2);
                    }
                }
            }
            page_query();
            Process p = Process.Start(".//check.exe");
        }

        private void reset_check_button_Click(object sender, EventArgs e)
        {
            string str_colName = "check_find='N'";
            string str_Where = "sysname !='all_system' and page_class!='iframe'";
            page.updateData(str_colName, str_Where);
            page_query();
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridView4.Columns[e.ColumnIndex]; // 获取当前单元格，判断是否是指定的列
            if (col.Name == "check_find_Column")
            {
                //e.FormattingApplied = true; // 人为的设置装换是成功的
                var row = this.dataGridView4.Rows[e.RowIndex];
                if (row != null)
                {
                    try
                    {
                        if (row.Cells["check_find_Column"].Value.ToString().ToLower().Equals("not_found"))
                        {
                            this.dataGridView4.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else if (row.Cells["check_find_Column"].Value.ToString().ToLower().Equals("found"))
                        {
                            this.dataGridView4.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                        }
                    }
                    catch { }
                }
            }

        }
        public void steps_detail_query()
        {
            if (this.dataGridView8.Visible == true)
            {
                string str_colName = "id,sysname,steps_name ";
                string str_Where = "id =" + this.dataGridView8.Rows[0].Cells["steps_id_2_Column"].Value;
                DataSet ds = steps.SelectData(str_colName, str_Where);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count >= 1)
                {
                    steps_detail(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                }
                else
                {
                    dataGridView8.Visible = false;
                }
            }
        }
        public void steps_detail(int steps_id, object sysname, object step_name)
        {
            //删除动态的列
            for (int i = 0; i < dataGridView8.Columns.Count; i++)
            {
                if (dataGridView8.Columns[i].Name.Contains("col"))
                {
                    dataGridView8.Columns.RemoveAt(i);
                    i = i - 1;
                }
            }
            string str_colName2 = @"id as 序号,
                                        steps_name as 步骤组名称,
                                        sysname as 被测系统名称,";
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            DataTable data = new DataTable();
            string str_Where = @" (sysname = '" + sysname + "' or sysname='all_system')"
                                  + "  and steps_name ='" + step_name + "' ";
            DataSet ds = steps_page.SelectData("element_name", str_Where, "steps_order");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                dataGridView8.Visible = true;
                //动态加载列
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    col = new DataGridViewTextBoxColumn();
                    str_colName2 = str_colName2 + " col" + i.ToString() + ",";
                    col.Name = "col" + i.ToString();
                    col.HeaderText = dt.Rows[i][0].ToString();
                    col.DataPropertyName = "col" + i.ToString();
                    dataGridView8.Columns.Insert(step_edit_2_Column.Index, col);
                }
                str_colName2 = str_colName2 +  " '编辑' as 编辑, '删除' as 删除  ";
                string str_Where2= "id =" + steps_id;
                DataSet ds2 = steps.SelectData(str_colName2, str_Where2);
                DataTable dt2 = ds2.Tables[0];
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    data.Columns.Add(dt2.Columns[i].ColumnName);
                }
                ///动态加载行数据
                DataRow row;
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    row = data.NewRow();
                    row["序号"] = dt2.Rows[j][0];
                    row["步骤组名称"] = dt2.Rows[j][1];
                    row["被测系统名称"] = dt2.Rows[j][2];
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        string c = "col" + k.ToString();
                        row[c] = dt2.Rows[j][3 + k];
                    }
                    row["编辑"] = dt2.Rows[j][3 + dt.Rows.Count];
                    row["删除"] = dt2.Rows[j][3 + dt.Rows.Count + 1];
                    data.Rows.Add(row);
                }
                dataGridView8.AutoGenerateColumns = false;
                data.AcceptChanges();
                dataGridView8.DataSource = data;
            }
            else
            {
                dataGridView8.Visible = false;
            }
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dataGridView6.RowCount - 1 || e.ColumnIndex > 3)
            {
                return;
            }
            else
            {
                try
                {
                    object sysname = this.dataGridView6.Rows[e.RowIndex].Cells["group_sysname_Column"].Value;
                    object step_name = this.dataGridView6.Rows[e.RowIndex].Cells["step_name_Column"].Value;
                    int steps_id = int.Parse(this.dataGridView6.Rows[e.RowIndex].Cells["steps_id_Column"].Value.ToString());
                    steps_detail(steps_id, sysname, step_name);
                }
                catch
                {
                }
            }
        }

        public void steps_detail_edit(int RowIndex)
        {
            string str_Where = "id=" + dataGridView8.Rows[RowIndex].Cells["steps_id_2_Column"].Value ;
            DataSet ds = steps.SelectData("distinct steps_name", str_Where);
            DataTable dt2 = ds.Tables[0];
            if (dt2.Rows.Count == 1)
            {
                string str_colName2 = "id,sysname from steps_page ";
                string str_Where2 ="steps_name='" + dt2.Rows[0][0].ToString() + "'";
                DataSet ds2= steps_page.SelectData(str_colName2, str_Where2);
                DataTable dt_c = ds2.Tables[0];
                for (int i = 0; i < dt_c.Rows.Count; i++)
                {
                    string str_Where3 = " steps_name='" + dt2.Rows[0][0].ToString() + "' and id=" + int.Parse(dt_c.Rows[i][0].ToString());
                    string str_colName3 = " steps_name='" + dataGridView8.Rows[RowIndex].Cells["step_name_2_Column"].Value.ToString().Trim() + "'";

                    if (dt_c.Rows[i][1].ToString() == "all_system")
                    {
                        steps_page.updateData(str_colName3, str_Where3);
                    }
                    else
                    {
                        str_colName3 = str_colName3 + " , sysname='" + dataGridView8.Rows[RowIndex].Cells["group_sysname_2_Column"].Value + "' ";
                        steps_page.updateData(str_colName3, str_Where3);
                    }
                }
            }
            string str_colName = "steps_name='" + dataGridView8.Rows[RowIndex].Cells["step_name_2_Column"].Value.ToString().Trim() + "',  ";
            for (int i = 0; i < dataGridView8.ColumnCount - 5; i++)
            {
                str_colName = str_colName + "  col" + i.ToString() + "='" + dataGridView8.Rows[RowIndex].Cells["col" + i.ToString()].Value.ToString().Trim() + "', ";
            }
            str_colName = str_colName + "sysname = '" + dataGridView8.Rows[RowIndex].Cells["group_sysname_2_Column"].Value + "'";
            steps.updateData(str_colName,str_Where);
        }
        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0||e.RowIndex == dataGridView8.RowCount)
            {
                return;
            }
            else
            {
                try
                {
                    if (e.ColumnIndex == step_edit_2_Column.Index)
                    {
                        string str = "";
                        if (dataGridView8.Rows[e.RowIndex].Cells["step_name_2_Column"].Value.ToString() == "")
                        {
                            str = str + "步骤组名称";
                        }
                        if (dataGridView8.Rows[e.RowIndex].Cells["group_sysname_2_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            steps_detail_edit(e.RowIndex);
                        }
                        string a = "";
                        string b = "";
                        steps_group_query(a, b);
                    }
                    else if (e.ColumnIndex == step_del_2_Column.Index)
                    {
                        string str_Where = "id=" + dataGridView8.Rows[e.RowIndex].Cells["steps_id_2_Column"].Value;
                        string str_Where2 = @"steps_name='" + dataGridView8.Rows[e.RowIndex].Cells["step_name_2_Column"].Value + "' "
                                        + " and (sysname='" + dataGridView8.Rows[e.RowIndex].Cells["group_sysname_2_Column"].Value + "' or sysname='all_system')";
                        DialogResult di;
                        di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                        if (di == DialogResult.Yes)
                        {
                            steps.deleteData(str_Where);
                            steps_page.deleteData(str_Where2);
                        }
                        else
                        {
                            return;
                        }
                        dataGridView8.Visible = false;
                        string a = "";
                        string b = "";
                        steps_group_query(a, b);
                    }
                }
                catch
                {
                }
            }
        }
        public void check_detail(int check_id, object sysname, object check_name)
        {
            //删除动态的列
            for (int i = 0; i < dataGridView9.Columns.Count; i++)
            {
                if (dataGridView9.Columns[i].Name.Contains("col"))
                {
                    dataGridView9.Columns.RemoveAt(i);
                    i = i - 1;
                }
            }
            string str_colName2 = @" id as 序号,
                          check_point_name as 检查点名称,
                          sysname as 被测系统名称 ,";
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            DataTable data = new DataTable();
            string str_Where = " ( sysname = '" + sysname + "' or sysname ='all_system' )" + " and check_point_name = '" + check_name + "'";
            DataSet ds = check_page.SelectData("element_name", str_Where, "check_order");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                dataGridView9.Visible = true;
                //动态加载列
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    col = new DataGridViewTextBoxColumn();
                    str_colName2 = str_colName2 + " col" + i.ToString() + ",";
                    col.Name = "col" + i.ToString();
                    col.HeaderText = dt.Rows[i][0].ToString();
                    col.DataPropertyName = "col" + i.ToString();
                    dataGridView9.Columns.Insert(check_edit2_2_Column.Index, col);
                }
                str_colName2 = str_colName2 + " '编辑' as 编辑, '删除' as 删除 ";
                string str_Where2=" id=" + check_id;
                DataSet ds2 = check_point.SelectData(str_colName2, str_Where2);
                DataTable dt2 = ds2.Tables[0];
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    data.Columns.Add(dt2.Columns[i].ColumnName);
                }
                ///动态加载行数据
                DataRow row;
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    row = data.NewRow();
                    row["序号"] = dt2.Rows[j][0];
                    row["检查点名称"] = dt2.Rows[j][1];
                    row["被测系统名称"] = dt2.Rows[j][2];
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        string c = "col" + k.ToString();
                        row[c] = dt2.Rows[j][3 + k];
                    }
                    row["编辑"] = dt2.Rows[j][3 + dt.Rows.Count];
                    row["删除"] = dt2.Rows[j][3 + dt.Rows.Count + 1];
                    data.Rows.Add(row);
                }
                dataGridView9.AutoGenerateColumns = false;
                data.AcceptChanges();
                dataGridView9.DataSource = data;
            }
            else
            {
                dataGridView9.Visible = false;
            }
        }

        private void dataGridView7_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dataGridView7.RowCount - 1 || e.ColumnIndex > 3)
            {
                return;
            }
            else
            {
                try
                {
                    object sysname = this.dataGridView7.Rows[e.RowIndex].Cells["check_sysname2_Column"].Value;
                    object check_name = this.dataGridView7.Rows[e.RowIndex].Cells["check_point2_Column"].Value;
                    int check_id = int.Parse(this.dataGridView7.Rows[e.RowIndex].Cells["check_point_Column"].Value.ToString());
                    check_detail(check_id, sysname, check_name);
                }
                catch
                {
                }
            }
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex == dataGridView9.RowCount)
            {
                return;
            }
            else
            {
                try
                {
                    string str_Whereid = " id=" + dataGridView9.Rows[e.RowIndex].Cells["check_point_2_Column"].Value;
                    if (e.ColumnIndex == check_edit2_2_Column.Index)
                    {
                        string str = "";
                        if (dataGridView9.Rows[e.RowIndex].Cells["check_point2_2_Column"].Value.ToString() == "")
                        {
                            str = str + "检查点名称";
                        }
                        if (dataGridView9.Rows[e.RowIndex].Cells["check_sysname2_2_Column"].Value.ToString() == "")
                        {
                            str = str + "被测系统名称";
                        }
                        if (str != "")
                        {
                            MessageBox.Show(str + "不能为空!");
                        }
                        else
                        {
                            string str_Where = "id ="+ dataGridView9.Rows[e.RowIndex].Cells["check_point_2_Column"].Value;
                            DataSet ds = check_point.SelectData("distinct check_point_name", str_Where);
                            DataTable dt2 = ds.Tables[0];
                            if (dt2.Rows.Count == 1)
                            {
                                string str_Where2 = "check_point_name='" + dt2.Rows[0][0].ToString() + "'";
                                string str_colName2 = "id,sysname ";
                                DataSet ds2 = check_page.SelectData(str_colName2, str_Where2);
                                DataTable dt_c = ds2.Tables[0];
                                for (int i = 0; i < dt_c.Rows.Count; i++)
                                {
                                    string str_Where3="check_point_name='" + dt2.Rows[0][0].ToString() + "' and id =" + int.Parse(dt_c.Rows[i][0].ToString());
                                    string str_colName3 = "check_point_name='" + dataGridView9.Rows[e.RowIndex].Cells["check_point2_2_Column"].Value + "' ";
                                    if (dt_c.Rows[i][1].ToString() == "all_system")
                                    {
                                        check_page.updateData(str_colName3, str_Where3);
                                    }
                                    else
                                    {
                                        str_colName3 =str_colName3+ ", sysname ='" + dataGridView9.Rows[e.RowIndex].Cells["check_sysname2_2_Column"].Value;
                                        check_page.updateData(str_colName3, str_Where3);
                                    }
                                    
                                }
                            }
                            string str_colName4="check_point_name = '" + dataGridView9.Rows[e.RowIndex].Cells["check_point2_2_Column"].Value + "', ";
                            for (int i = 0; i < dataGridView9.ColumnCount - 5; i++)
                            {
                                str_colName4 = str_colName4 + "  col" + i.ToString() + "='" + dataGridView9.Rows[e.RowIndex].Cells["col" + i.ToString()].Value + "', ";
                            }
                            str_colName4 = str_colName4 + "sysname = '" + dataGridView9.Rows[e.RowIndex].Cells["check_sysname2_2_Column"].Value + "'";

                            check_point.updateData(str_colName4, str_Whereid);
                        }
                        check_point_query();
                    }
                    else if (e.ColumnIndex == check_del2_2_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("确认删除", "确认删除页面", MessageBoxButtons.YesNo);
                        if (di == DialogResult.Yes)
                        {
                            check_point.deleteData(str_Whereid);
                            string str_Where5 = "check_point_name='"+ dataGridView9.Rows[e.RowIndex].Cells["check_point2_2_Column"].Value + "' "
                                               + " and ( sysname ='" + dataGridView9.Rows[e.RowIndex].Cells["check_sysname2_2_Column"].Value + "' or sysname='all_system')";
                            check_page.deleteData(str_Where5);
                        }
                        else
                        {
                            return;
                        }
                        dataGridView9.Visible = false;
                        check_point_query();
                    }
                }
                catch
                {
                }
            }
        }

        private void total_export_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.DefaultExt = "xls";
            dig.Filter = "Excel文件|*.xls";
            if (dig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook = new HSSFWorkbook();
                DataSet ds = config.SelectData("*", "1=1", "sysname,function_name");
                DataTable dt2 = ds.Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    ISheet sheet1 = hssfworkbook.CreateSheet("配置表");
                    FileStream file = new FileStream(dig.FileName, FileMode.Create);
                    HSSFCellStyle dateStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
                    dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                    IRow row1 = sheet1.CreateRow(0);
                    row1.CreateCell(0).SetCellValue("序号");
                    row1.CreateCell(1).SetCellValue("功能点名称");
                    row1.CreateCell(2).SetCellValue("是否执行");
                    row1.CreateCell(3).SetCellValue("是否执行完毕");
                    row1.CreateCell(4).SetCellValue("被测系统名");
                    for (int w_i = 0; w_i < 4; w_i++)
                    {
                        sheet1.SetColumnWidth(w_i, 28 * 256);
                    }
                    if (dt2 != null)
                    {
                        for (int k = 0; k < dt2.Rows.Count; k++)
                        {
                            HSSFRow dataRow = sheet1.CreateRow(k + 1) as HSSFRow;
                            foreach (DataColumn column in dt2.Columns)
                            {
                                HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
                                string drValue = dt2.Rows[k][column.Ordinal].ToString();
                                switch (column.DataType.ToString())
                                {
                                    case "System.String": //字符串类型
                                        newCell.SetCellValue(drValue);
                                        break;
                                    case "System.DateTime": //日期类型
                                        DateTime dateV;
                                        DateTime.TryParse(drValue, out dateV);
                                        newCell.SetCellValue(dateV);

                                        newCell.CellStyle = dateStyle; //格式化显示
                                        break;
                                    case "System.Boolean": //布尔型
                                        bool boolV = false;
                                        bool.TryParse(drValue, out boolV);
                                        newCell.SetCellValue(boolV);
                                        break;
                                    case "System.Int16": //整型
                                    case "System.Int32":
                                    case "System.Int64":
                                    case "System.Byte":
                                        int intV = 0;
                                        int.TryParse(drValue, out intV);
                                        newCell.SetCellValue(intV);
                                        break;
                                    case "System.Decimal": //浮点型
                                    case "System.Double":
                                        double doubV = 0;
                                        double.TryParse(drValue, out doubV);
                                        newCell.SetCellValue(doubV);
                                        break;
                                    case "System.DBNull": //空值处理
                                        newCell.SetCellValue("");
                                        break;
                                    default:
                                        newCell.SetCellValue("");
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                    hssfworkbook.Write(file);
                    file.Close();
                }
            }
        }

        private void total_import_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog di = new OpenFileDialog();
            //di.DefaultExt = "xls";
            di.Filter = "Excel文件|*.xls";
            di.ShowDialog();
            if (di.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(di.FileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
                int sheetcount = hssfworkbook.NumberOfSheets;
                if (sheetcount > 0)
                {
                    for (int sheet_index = 0; sheet_index < sheetcount; sheet_index++)
                    {
                        DataTable dt = new DataTable();
                        ISheet sheet = hssfworkbook.GetSheetAt(sheet_index);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                            dt.Columns.Add(column);
                        }
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dt.NewRow();
                            if (row != null)
                            {
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    if (row.GetCell(j) != null)
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                                }
                                dt.Rows.Add(dataRow);
                            }
                        }

                        if (dt != null)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string[] list = new string[6];
                                string str_col1 = "function_name ,action_yes_no,finish_yes_no,sysname";
                                string str_col2 = "";
                                int k2 = 0;
                                for (int k = 1; k < dt.Columns.Count ; k++)
                                {
                                    if (k == dt.Columns.Count - 1)
                                    {
                                        str_col2 = str_col2 + "'" + dt.Rows[i][k].ToString().Trim() + "' ";
                                    }
                                    else
                                    {
                                        str_col2 = str_col2 + "'" + dt.Rows[i][k].ToString().Trim() + "',  ";
                                    }
                                    list[k] = dt.Rows[i][k].ToString().Trim();
                                    if (dt.Rows[i][k].ToString().Trim() == "")
                                    {
                                        k2 = k2 + 1;
                                    }
                                }
                                if (k2 != dt.Columns.Count - 1)
                                {
                                    list[5] = dt.Rows[i][dt.Columns.Count - 1].ToString().Trim();
                                    string str_Where = @"function_name='" + list[1] + "' and sysname='" + list[4] + "' ";
                                    DataSet ds = config.SelectData("count(0)", str_Where);
                                    DataTable dt2 = ds.Tables[0];
                                    if (int.Parse(dt2.Rows[0][0].ToString()) == 0)
                                    {
                                        config.insertData(str_col1, str_col2);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}