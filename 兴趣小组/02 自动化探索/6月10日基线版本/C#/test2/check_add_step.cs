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
    public partial class check_add_step : Form
    {
        string str_check_name = "";
        public check_add_step()
        {
            InitializeComponent();
        }
        public void query(string str1,string str2)
        {
            sysname_name_label.Text = str2;
            check_point_name_label.Text = str1;
            str_check_name = str1;
            string sql = sqlclass.add_step_page_sql();
            if (sysname_name_label.Text != "")
            {
                sql = sql + "  and (sysname = '" + sysname_name_label.Text.Trim() + "' or sysname = 'all_system')";
            }
            sql = sql + " and page_name !='检查点'";
            if (page_textBox.Text != "")
            {
                sql=sql+" and page_name like '%"+page_textBox.Text.Trim()+"%' ";
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
        }

        private void select_all_button_Click(object sender, EventArgs e)
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
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
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
            //add_step_e ae = new add_step_e(dataGridView1.DataSource as DataTable);
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
            check_add_step_e ae = new check_add_step_e(List, str_check_name,sysname_name_label.Text.Trim());
            ae.ShowDialog();
        }

        private void query_button_Click(object sender, EventArgs e)
        {
            query(check_point_name_label.Text,sysname_name_label.Text);
        }

    }
}
