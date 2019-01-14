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
    public partial class iframe_add : Form
    {
        public iframe_add()
        {
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);

            syname_comboBox.DataSource = dt;
            syname_comboBox.DisplayMember = "sysname";
        }
        public void regest()
        {
            iframe_textBox.Text = "";
            syname_comboBox.SelectedIndex = 0;
            iframe_label.Visible = false;
            sysname_label.Visible = false;
        }

        private void iframe_query_button_Click(object sender, EventArgs e)
        {
            if (iframe_textBox.Text == "")
            {
                iframe_label.Visible = true;
            }
            else
            {
                iframe_label.Visible=false;
            }
            if (syname_comboBox.SelectedIndex == 0)
            {
                sysname_label.Visible = true;
            }
            else
            {
                sysname_label.Visible = false;
            }
            if (iframe_textBox.Text != "" && syname_comboBox.SelectedIndex != 0)
            {
                string sql_update = @"insert into iframe(iframe_name,sysname) values("
                                    + "'" + iframe_textBox.Text + "',"
                                    + "'" + syname_comboBox.Text + "');";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                regest();
            }
        }


        private void iframe_regest_button_Click(object sender, EventArgs e)
        {
            regest();
        }

       
    }
}
