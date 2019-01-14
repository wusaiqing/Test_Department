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
        public config_add()
        {
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
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
                string sql_insert = @"insert into config 
                                (function_name,action_yes_no,finish_yes_no,sysname)
                                 values ("
                    + "'" + function_name_textBox.Text + "',"
                    + "'" + action_yes_no_comboBox.SelectedItem + "',"
                    + "'" + finish_yes_no_comboBox.SelectedItem + "',"
                    + "'" + sysname_comboBox.Text + "')";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);
                regest_config();
            }
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            regest_config();
        }
    }
}
