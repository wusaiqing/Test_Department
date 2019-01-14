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
    public partial class add_step : Form
    {
        DAL.Config config = new DAL.Config();
        DAL.page_properties page = new DAL.page_properties();
        string str_function = "";
        public add_step()
        {
            InitializeComponent();
        }
        public void query(string str1, string str2)
        {
            sysname_label.Text = str1;
            function_name_label.Text = str2;
            str_function = str2;
            string str_colName = "distinct page_name as 页面名称";
            string str_Where = "1=1 ";
            if (str1 != "")
            {
                str_Where = str_Where + "  and (sysname = '" + str1 + "' or sysname ='all_system')";
            }
            else
            {
                if (str2 != "")
                {
                    string str_Where1 = "function_name like'%" + str2.Trim() + "%'";
                    DataSet ds = config.SelectData("distinct sysname", str_Where1);
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            str_Where = str_Where + "  and (sysname ='" + dt.Rows[i][0].ToString() + "' or sysname ='all_system')";
                        }
                    }
                }
            }
            if (page_textBox.Text != "")
            {
                str_Where = str_Where + " and page_name like '%" + page_textBox.Text.Trim() + "%'";
            }
            dataGridView1.AutoGenerateColumns = false;
            DataSet ds2 = page.SelectData(str_colName, str_Where);
            dataGridView1.DataSource = ds2.Tables[0];
        }

        private void choose_all_button_Click(object sender, EventArgs e)
        {
            //string sql = sqlclass.add_step_page_sql();
            if (this.dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["choose_Column"].Value = true;
                    //this._selectAll = true;
                }
            }
        }

        private void select_cancel_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count ; i++)
            {
                this.dataGridView1.Rows[i].Cells["choose_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void choose_Inverse_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    bool se = false;
                    if (dataGridView1.Rows[i].Cells["choose_Column"].Value == null)
                    {
                        this.dataGridView1.Rows[i].Cells["choose_Column"].Value = true;
                        // this._selectAll = true;
                        se = true;
                    }
                    else if ((bool)dataGridView1.Rows[i].Cells["choose_Column"].Value == true && se == false)
                    {
                        this.dataGridView1.Rows[i].Cells["choose_Column"].Value = false;
                    }
                    else if ((bool)dataGridView1.Rows[i].Cells["choose_Column"].Value == false)
                    {
                        this.dataGridView1.Rows[i].Cells["choose_Column"].Value = true;
                        //this._selectAll = true;
                    }
                }
            }
        }

        private void step_button_Click(object sender, EventArgs e)
        {
            ArrayList List = new ArrayList();
            int j = 0;
            if (this.dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    if (this.dataGridView1.Rows[i].Cells["choose_Column"].Value == null)
                    {
                        continue;
                    }
                    if ((bool)dataGridView1.Rows[i].Cells["choose_Column"].Value == true)
                    {
                        List.Add(dataGridView1.Rows[i].Cells["page_name_Column"].Value.ToString());
                        j++;
                    }
                }
            }
            add_step_e ae = new add_step_e(List, str_function);
            ae.ShowDialog();
        }

        private void query_button_Click(object sender, EventArgs e)
        {
            query(sysname_label.Text, function_name_label.Text);
        }
    }
}
