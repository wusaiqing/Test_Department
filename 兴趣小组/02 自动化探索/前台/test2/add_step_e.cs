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
        DAL.page_properties page = new DAL.page_properties();
        DAL.test_page test_page = new DAL.test_page();
        string function_name="";
        public add_step_e(ArrayList list, string str_function)
        {
            InitializeComponent();
            function_name = str_function;
            string str_colName = @"id as 序号,
                         page_name as 页面名称,
                         element_name as 元素名称,
                         sysname as 被测系统名称 ";
            string str_Where = "1=1";
            if (list.Count >= 1)
            {
                str_Where = str_Where + " and  page_name in  (";
                for (int i = 0; i < list.Count - 1; i++)
                {
                    str_Where = str_Where + "'" + list[i].ToString().Trim() + "', ";
                }
                str_Where = str_Where + "'" + list[list.Count - 1].ToString().Trim() + "') ";
                string str_order =" sysname ,page_name,element_name";
                DataSet ds = page.SelectData(str_colName, str_Where, str_order);
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = ds.Tables[0];
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
            int max =1;
            if (function_name != "")
            {
                string str_Where  ="function_name='" + function_name.Trim() + "'";
                DataSet ds = test_page.SelectData("max(test_order) ", str_Where);
                DataTable dt = ds.Tables[0];
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
                    string str_col1 = "test_order,function_name,page_name,element_name,sysname";
                    string str_col2 = "";
                    if (this.dataGridView2.Rows[i].Cells["choose_Column"].Value == null)
                    {
                        continue;
                    }
                    else if ((bool)this.dataGridView2.Rows[i].Cells["choose_Column"].Value == true)
                    {
                        str_col2 = str_col2 + (max + j) + ",";
                        str_col2 = str_col2 + "'" + function_name + "',";
                        str_col2 = str_col2 + "'" + this.dataGridView2.Rows[i].Cells["page_name_e_Column"].Value + "',";
                        str_col2 = str_col2 + "'" + this.dataGridView2.Rows[i].Cells["element_name_e_Column"].Value + "',";
                        str_col2 = str_col2 + "'" + this.dataGridView2.Rows[i].Cells["sysname_e_Column"].Value + "'";
                        test_page.insertData(str_col1, str_col2);
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
