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
    public partial class add_setps : Form
    {
        DAL.TotalConfig tc = new DAL.TotalConfig();
        DAL.steps steps = new DAL.steps();
        public add_setps()
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
            sysname_label.Visible = false;
            steps_label.Visible = false;
            sysname_comboBox.SelectedIndex = 0;
            setps_textBox.Text ="";
        }
        private void add_button_Click(object sender, EventArgs e)
        {
            if (sysname_comboBox.SelectedIndex==0)
            {
                sysname_label.Visible = true;
            }
            else
            {
                sysname_label.Visible = false;
            }
            if (setps_textBox.Text == "")
            {
                steps_label.Visible = true;
            }
            else
            {
                steps_label.Visible = false;
            }
            if (sysname_comboBox.SelectedIndex != 0 && setps_textBox.Text!="")
            {
                string str_col1 = "steps_name,sysname";
                string str_col2 = "'" + setps_textBox.Text.Trim() + "','" + sysname_comboBox.Text + "'";
                steps.insertData(str_col1, str_col2);
            }
            regest();
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            regest();
        }

    }
}
