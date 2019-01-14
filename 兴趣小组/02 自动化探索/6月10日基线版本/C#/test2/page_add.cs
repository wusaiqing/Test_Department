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
    public partial class page_add : Form
    {
        public page_add()
        {
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
            sysname_comboBox.DataSource = dt;
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            DataRow dr2 = dt.NewRow();
            dr2["sysname"] = "all_system";
            dt.Rows.InsertAt(dr2, 1);
            sysname_comboBox.SelectedIndex = 0;
            sysname_comboBox.DisplayMember = "sysname";
            page_class_comboBox.SelectedIndex = 0;
            find_way_comboBox.SelectedIndex = 0;
        }
        public void reset()
        {
            page_name_textBox.Text = "";
            element_name_textBox.Text = "";
            page_class_comboBox.SelectedIndex = 0;
            page_value_textBox.Text = "";
            find_way_comboBox.SelectedIndex = 0;
            sysname_comboBox.SelectedIndex = 0;
            page_name_label.Visible = false;
            element_name_label.Visible = false;
            page_class_label.Visible = false;
            sysname_label.Visible = false;
        }
        private void reset_button_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            string find_way_str = "";
            if (page_name_textBox.Text=="")
            {
                page_name_label.Visible = true;
            }
            else
            {
                page_name_label.Visible=false;
            }
            if (element_name_textBox.Text=="")
            {
                element_name_label.Visible = true;
            }
            else
            {
                element_name_label.Visible=false;
            }
            if (page_class_comboBox.SelectedIndex == 0)
            {
                page_class_label.Visible = true;
            }
            else
            {
                page_class_label.Visible = false;
            }
            if (sysname_comboBox.SelectedIndex == 0)
            {
                sysname_label.Visible = true;
            }
            else
            {
                sysname_label.Visible = false;
            }
            if (find_way_comboBox.SelectedIndex != 0)
            {
                find_way_str = find_way_comboBox.Text.Trim();
            }
            if (page_name_textBox.Text!="" && element_name_textBox.Text != "" && page_class_comboBox.SelectedIndex != 0 && sysname_comboBox.SelectedIndex != 0)
            {
                string str = page_value_textBox.Text.ToString();
                str = str.Replace("'", @"\'");
                str = str.Replace("\"", @"\'");
                string sql_insert = @"insert into page_properties (page_name,element_name,page_class,page_value,find_way,sysname) 
                                      values ("
                                      + "'" + page_name_textBox.Text.Trim() + "',"
                                      + "'" + element_name_textBox.Text.Trim()+ "',"
                                      + "'" + page_class_comboBox.Text.Trim() + "',"
                                      + "'" + str.Trim() + "',"
                                      + "'" + find_way_str + "',"
                                      + "'" + sysname_comboBox.Text.Trim()+ "');";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);
                reset();
            }
        }
    }
}
