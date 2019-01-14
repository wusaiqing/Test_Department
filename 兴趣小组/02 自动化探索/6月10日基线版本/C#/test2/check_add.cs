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
        public check_add()
        {
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
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
                string sql_update = @"insert into check_point(check_point_name,sysname) values("
                                    + "'" + check_name_textBox.Text + "',"
                                    + "'" + sysname_comboBox.Text + "');";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                regest();
            }
        }
    }
}
