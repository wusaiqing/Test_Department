using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test2
{
    public partial class check_add : Form
    {
        DAL.TotalConfig tc = new DAL.TotalConfig();
        DAL.check_point check_point = new DAL.check_point();
        public check_add()
        {
            InitializeComponent();
            DataSet ds = tc.SelectData("sysname","1=1");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            sysname_comboBox.DataSource = dt;
            sysname_comboBox.DisplayMember = "sysname";
        }
        public void regest()
        {
            check_name_textBox.Text = "";
            sysname_comboBox.SelectedIndex = 0;
            check_name_label.Visible = false;
            sysname_label.Visible = false;
        }

        private void iframe_regest_button_Click(object sender, EventArgs e)
        {
            regest();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (check_name_textBox.Text == "")
            {
                check_name_label.Visible = true;
            }
            else
            {
                check_name_label.Visible = false;
            }
            if (sysname_comboBox.SelectedIndex == 0)
            {
                sysname_label.Visible = true;
            }
            else
            {
                sysname_label.Visible = false;
            }
            if (check_name_textBox.Text != "" && sysname_comboBox.SelectedIndex != 0)
            {
                string str_col1 = "check_point_name,sysname";
                string str_col2 = "'" + check_name_textBox.Text + "','" + sysname_comboBox.Text + "'";
                check_point.insertData(str_col1, str_col2);
                regest();
            }
        }
    }
}
