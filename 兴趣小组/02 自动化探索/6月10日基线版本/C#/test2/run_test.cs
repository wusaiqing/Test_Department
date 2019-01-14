using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace test2
{
    public partial class run_test : Form
    {
        public run_test()
        {
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
            DataTable newdt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                sysname_b_listBox.Items.Add(dr["sysname"].ToString());
            }
        }
        public void load()
        {
            function_b_listBox.Items.Clear();
            string sql_f = "select function_name from config where 1=2";
            for (int i = 0; i < sysname_y_listBox.Items.Count; i++)
            {
                sql_f = sql_f + " or sysname='" + sysname_y_listBox.Items[i].ToString().Trim() + "'";
            }
            DataTable dt_f = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_f).Tables[0];
            DataTable newdt = dt_f.Clone();
            foreach (DataRow dr_f in dt_f.Rows)
            {
                function_b_listBox.Items.Add(dr_f["function_name"].ToString());
            }

        }

        private void sysname_sing_label_Click(object sender, EventArgs e)
        {
            int cunt = sysname_b_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                sysname_y_listBox.Items.Add(sysname_b_listBox.Text);
                sysname_b_listBox.Items.Remove(sysname_b_listBox.SelectedItem);
            }
            load();
        }

        private void sysname_all_label_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sysname_b_listBox.Items.Count; i++)
            {
                sysname_b_listBox.SelectedIndex = i;
            }
            int cunt = sysname_b_listBox.Items.Count;
            for (int i = 0; i < cunt; i++)
            {
                sysname_y_listBox.Items.Add(sysname_b_listBox.Text);
                sysname_b_listBox.Items.Remove(sysname_b_listBox.SelectedItem);
            }
            load();
        }

        private void sysname_a_sing_label_Click(object sender, EventArgs e)
        {
            int cunt = sysname_y_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                sysname_b_listBox.Items.Add(sysname_y_listBox.Text);
                sysname_y_listBox.Items.Remove(sysname_y_listBox.SelectedItem);
            }
            load();
        }

        private void sysname_a_all_label_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sysname_y_listBox.Items.Count; i++)
            {
                sysname_y_listBox.SelectedIndex = i;
            }
            int cunt = sysname_y_listBox.Items.Count;
            for (int i = 0; i < cunt; i++)
            {
                sysname_b_listBox.Items.Add(sysname_y_listBox.Text);
                sysname_y_listBox.Items.Remove(sysname_y_listBox.SelectedItem);
            }
            load();
        }

        private void funtion_single_label_Click(object sender, EventArgs e)
        {
            int cunt = function_b_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                function_y_listBox.Items.Add(function_b_listBox.Text);
                function_b_listBox.Items.Remove(function_b_listBox.SelectedItem);
            }
        }

        private void funtion_all_label_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < function_b_listBox.Items.Count; i++)
            {
                function_b_listBox.SelectedIndex = i;
            }
            int cunt = function_b_listBox.Items.Count;
            for (int i = 0; i < cunt; i++)
            {
                function_y_listBox.Items.Add(function_b_listBox.Text);
                function_b_listBox.Items.Remove(function_b_listBox.SelectedItem);
            }
        }

        private void funtion_a_single_label_Click(object sender, EventArgs e)
        {
            int cunt = function_y_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                function_b_listBox.Items.Add(function_y_listBox.Text);
                function_y_listBox.Items.Remove(function_y_listBox.SelectedItem);
            }
        }

        private void funtion_a_all_label_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < function_y_listBox.Items.Count; i++)
            {
                function_y_listBox.SelectedIndex = i;
            }
            int cunt = function_y_listBox.Items.Count;
            for (int i = 0; i < cunt; i++)
            {
                function_b_listBox.Items.Add(function_y_listBox.Text);
                function_y_listBox.Items.Remove(function_y_listBox.SelectedItem);
            }
        }

        private void sysname_b_listBox_DoubleClick(object sender, EventArgs e)
        {
            int cunt = sysname_b_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                sysname_y_listBox.Items.Add(sysname_b_listBox.Text);
                sysname_b_listBox.Items.Remove(sysname_b_listBox.SelectedItem);
            }
            load();
        }

        private void sysname_y_listBox_DoubleClick(object sender, EventArgs e)
        {
            int cunt = sysname_y_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                sysname_b_listBox.Items.Add(sysname_y_listBox.Text);
                sysname_y_listBox.Items.Remove(sysname_y_listBox.SelectedItem);
            }
            load();
        }

        private void function_b_listBox_DoubleClick(object sender, EventArgs e)
        {
            int cunt = function_b_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                function_y_listBox.Items.Add(function_b_listBox.Text);
                function_b_listBox.Items.Remove(function_b_listBox.SelectedItem);
            }
        }

        private void function_y_listBox_DoubleClick(object sender, EventArgs e)
        {
            int cunt = function_y_listBox.SelectedItems.Count;
            for (int i = 0; i < cunt; i++)
            {
                function_b_listBox.Items.Add(function_y_listBox.Text);
                function_y_listBox.Items.Remove(function_y_listBox.SelectedItem);
            }
        }

        private string[] s = new string[1];

        private void run_button_Click(object sender, EventArgs e)
        {
            //初始化数据
            string sql = @"update config set  action_yes_no='NO'  ,  finish_yes_no='YES' ";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql);
            string sql_c = @"update config set  action_yes_no='YES'  ,  finish_yes_no='NO' where 1=2 ";
            string sql_t = @"update test_case set run_result='' ,comments='', result='NoRun' where  1=2 ";
            for (int i = 0; i < function_y_listBox.Items.Count; i++)
            {
                sql_c = sql_c + " or function_name='" + function_y_listBox.Items[i].ToString().Trim() + "'";
                sql_t = sql_t + " or function_name='" + function_y_listBox.Items[i].ToString().Trim() + "'";
            }
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_c);
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_t);
            Process p = Process.Start(".//main.exe");
            //Process p = Process.Start(@"D:\VE_UI\test2\test2\bin\Debug\main.exe");
            p.WaitForExit();
        }
    }
}
    