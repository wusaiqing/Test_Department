using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace test2
{
    public partial class add_step_e : Form
    {
        string function_name="";
        public add_step_e(ArrayList list, string str_function)
        {
            InitializeComponent();
            function_name = str_function;
            string sql = sqlclass.add_step_e_sql();
            if (list.Count >= 1)
            {
                sql = sql + " and  page_name in  (";
                for (int i = 0; i < list.Count - 1; i++)
                {
                    sql = sql + "'" + list[i].ToString().Trim() + "', ";
                }
                sql = sql + "'" + list[list.Count - 1].ToString().Trim() + "') ";
                sql = sql + " order by sysname ,page_name,element_name";
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
            }
        }

        private void choose_all_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    this.dataGridView2.Rows[i].Cells["choose_Column"].Value = true;
                }
            }
        }

        private void select_cancel_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                this.dataGridView2.Rows[i].Cells["choose_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void choose_Inverse_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    bool se = false;
                    if (dataGridView2.Rows[i].Cells["choose_Column"].Value == null)
                    {
                        this.dataGridView2.Rows[i].Cells["choose_Column"].Value = true;
                        // this._selectAll = true;
                        se = true;
                    }
                    else if ((bool)dataGridView2.Rows[i].Cells["choose_Column"].Value == true && se == false)
                    {
                        this.dataGridView2.Rows[i].Cells["choose_Column"].Value = false;
                    }
                    else if ((bool)dataGridView2.Rows[i].Cells["choose_Column"].Value == false)
                    {
                        this.dataGridView2.Rows[i].Cells["choose_Column"].Value = true;
                        //this._selectAll = true;
                    }
                }
            }
        }
        private void add_button_Click(object sender, EventArgs e)
        {
            string sql_max = "";
            int max =1;
            if (function_name != "")
            {
                sql_max = " select max(test_order)  from test_page where function_name='" + function_name.Trim() + "';";
                DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_max, null).Tables[0];
                if (dt.Rows[0][0].ToString() != "")
                {
                    max = max + int.Parse(dt.Rows[0][0].ToString());
                }
            }
            
            if (this.dataGridView2.Rows.Count > 0)
            {
                int j = 0;
                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    string sql = @"insert  into test_page
                        (test_order,function_name,page_name,element_name,sysname) values(";
                    if (this.dataGridView2.Rows[i].Cells["choose_Column"].Value == null)
                    {
                        continue;
                    }
                    else if ((bool)this.dataGridView2.Rows[i].Cells["choose_Column"].Value == true)
                    {
                        sql = sql + (max + j) + ",";
                        sql = sql + "'" + function_name + "',";
                        sql = sql + "'" + this.dataGridView2.Rows[i].Cells["page_name_e_Column"].Value + "',";
                        sql = sql + "'" + this.dataGridView2.Rows[i].Cells["element_name_e_Column"].Value + "',";
                        sql = sql + "'" + this.dataGridView2.Rows[i].Cells["sysname_e_Column"].Value + "');";
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql);
                        j++;
                    }
                }
                if(j>0)
                {
                MessageBox.Show("组装测试步骤成功");
                select_cancel_button_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("没有选择组装的测试步骤");
                }
            }
            else
            {
                MessageBox.Show("没有添加组装的页面名称");
            }
            this.Close();
        }
    }
}
