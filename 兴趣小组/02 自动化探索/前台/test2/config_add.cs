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
    public partial class config_add : Form
    {
        DAL.TotalConfig tc = new DAL.TotalConfig();
        DAL.Config config = new DAL.Config();
        public config_add()
        {
            InitializeComponent();
            DataSet ds = tc.SelectData("sysname","1=1");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            sysname_comboBox.DataSource = dt;
            sysname_comboBox.DisplayMember = "sysname";
            action_yes_no_comboBox.SelectedIndex = 0;
            finish_yes_no_comboBox.SelectedIndex = 0;
            action_yes_no_label.Visible = false;
        }
        public void regest_config()
        {
            function_name_textBox.Text="";
            action_yes_no_comboBox.SelectedIndex = 0;
            finish_yes_no_comboBox.SelectedIndex = 0;
            sysname_comboBox.SelectedIndex = 0;
            function_name_label1.Visible = false;
            finish_yes_no_label.Visible = false;
            sysname_label.Visible = false;
            action_yes_no_label.Visible = false;
        }
       

        private void config_add_button_Click(object sender, EventArgs e)
        {
            if (function_name_textBox.Text == "")
            {
                function_name_label1.Visible = true;
            }
            else
            {
                function_name_label1.Visible = false;
            }
            if (action_yes_no_comboBox.SelectedIndex==0)
            {
                action_yes_no_label.Visible = true;
            }
            else
            {
                action_yes_no_label.Visible = false;
            }
            if (finish_yes_no_comboBox.SelectedIndex==0)
            {
                finish_yes_no_label.Visible = true;
            }
            else
            {
                finish_yes_no_label.Visible = false;
            }
            
            if (sysname_comboBox.SelectedIndex==0)
            {
                sysname_label.Visible = true;
            }
            else
            {
                sysname_label.Visible = false;
            }
             
            if ( function_name_textBox.Text != "" && action_yes_no_comboBox.SelectedIndex!=0 && finish_yes_no_comboBox.SelectedIndex!=0 &&sysname_comboBox.SelectedIndex!=0)
            {
                string str_col1 = "function_name,action_yes_no,finish_yes_no,sysname";
                string str_col2= "'" + function_name_textBox.Text + "',"
                               + "'" + action_yes_no_comboBox.SelectedItem + "',"
                               + "'" + finish_yes_no_comboBox.SelectedItem + "',"
                               + "'" + sysname_comboBox.Text + "' ";
                config.insertData(str_col1, str_col2);
                regest_config();
            }
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            regest_config();
        }
    }
}
