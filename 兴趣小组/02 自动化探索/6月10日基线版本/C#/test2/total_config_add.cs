using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace test2
{
    public partial class total_config_add : Form
    {
        public total_config_add()
        {
            InitializeComponent();
            browser_comboBox.SelectedIndex = 0;
            db_class_comboBox.SelectedIndex = 0;
        }
        public void regest_config()
        {
            url_textBox.Text = "";
            sysname_textBox.Text = "";
            waittime_textBox.Text = "";
            user_textBox.Text = "";
            db_textBox.Text = "";
            pwd_textBox.Text = "";
            host_textBox.Text = "";
            browser_comboBox.SelectedIndex = 0;
            db_class_comboBox.SelectedIndex = 0;
            url_label.Visible = false;
            sysname_label.Visible = false;
            waittime_label.Visible = false;
        }

       
        private void add_button_Click(object sender, EventArgs e)
        {

            if (url_textBox.Text == "")
            {
                url_label.Visible = true;
            }
            else
            {
                url_label.Visible = false;
            }
            if (sysname_textBox.Text == "")
            {
                sysname_label.Visible = true;
            }
            else
            {
                sysname_label.Visible = false;
            }
            if (waittime_textBox.Text == "")
            {
                waittime_label.Visible = true;
            }
            else
            {
                waittime_label.Visible = false;
            }
            
            if (url_textBox.Text != "" && sysname_textBox.Text != "" && waittime_textBox.Text != "" )
            {
                string db_class = "";
                if (db_class_comboBox.SelectedIndex != 0)
                {
                    db_class = db_class_comboBox.Text;
                }
                string sql_insert = @"insert into total_config 
                                (url,waittime,browser,sysname,db_class,host,user,pwd,db)
                                 values ("
                                    + "'" + url_textBox.Text + "',"
                                    + "'" + waittime_textBox.Text + "',"
                                    + "'" + browser_comboBox.Text + "',"
                                    + "'" + sysname_textBox.Text + "',"
                                    + "'" + db_class + "',"
                                    + "'" + host_textBox.Text + "',"
                                    + "'" + user_textBox.Text + "',"
                                    + "'" + pwd_textBox.Text + "',"
                                    + "'" + db_textBox.Text + "')";

                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);
                regest_config();
            }
        }

        private void id_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            
            if ((int)e.KeyChar <= 32)  // 特殊键(含空格), 不处理  
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar))  // 非数字键, 放弃该输入  
            {
                e.Handled = true;
                return;
            }
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            regest_config();
        }
    }
}
