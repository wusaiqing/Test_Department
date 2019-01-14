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
    public partial class steps_group_add_step_e : Form
    {
        string str_steps_name = "";
        public steps_group_add_step_e(ArrayList list, string str,string sysname)
        {
            InitializeComponent();
            str_steps_name = str;
            // this.Text = "组装功能点：" + str + "的页面元素";
            //function_name = str;
            string sql = sqlclass.add_step_e_sql();
            if (list.Count >= 1)
            if (list != null)
            {
                sql=sql+"  and  page_name in (";
                for (int i = 0; i < list.Count-1; i++)
                {
                    sql = sql + "'"+list[i].ToString().Trim() + "' ,";
                }
                sql = sql + "'"+list[list.Count - 1].ToString().Trim() + "')";
            }
            if (sysname != null)
            {
                sql = sql + "  and ( sysname = '" + sysname + "' or sysname='all_system' )";
            }
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
        }

        private void select_all_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
                {
                    this.dataGridView2.Rows[i].Cells["choose_Column"].Value = true;
                }
            }
        }

        private void select_c_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView2.Rows.Count; i++)
            {
                this.dataGridView2.Rows[i].Cells["choose_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void select_a_button_Click(object sender, EventArgs e)
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

        private void check_step_a_button_Click(object sender, EventArgs e)
        {
            string sql_max = "";
            int max = 1;
            if (str_steps_name != "")
            {
                sql_max = " select max(steps_order)  from steps_page where steps_name='" + str_steps_name.Trim() + "';";
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
                    string sql = @"insert  into steps_page
                        (steps_order,steps_name,page_name,element_name,sysname) values(";
                    if (this.dataGridView2.Rows[i].Cells["choose_Column"].Value == null)
                    {
                        continue;
                    }
                    else if ((bool)this.dataGridView2.Rows[i].Cells["choose_Column"].Value == true)
                    {
                        sql = sql + (max + j) + ",";
                        sql = sql + "'" + str_steps_name + "',";
                        sql = sql + "'" + this.dataGridView2.Rows[i].Cells["page_name_e_Column"].Value + "',";
                        sql = sql + "'" + this.dataGridView2.Rows[i].Cells["element_name_e_Column"].Value + "',";
                        sql = sql + "'" + this.dataGridView2.Rows[i].Cells["sysname_e_Column"].Value + "');";
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql);
                        j++;
                    }
                }
                if (j > 0)
                {
                    MessageBox.Show("组装测试步骤成功");
                    // select_cancel_button_Click(sender, e);
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
