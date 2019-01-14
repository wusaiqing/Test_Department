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
        DAL.TotalConfig tc = new DAL.TotalConfig();
        DAL.Iframe iframe = new DAL.Iframe();
        public iframe_add()
        {
            InitializeComponent();
            DataSet ds = tc.SelectData("sysname", "1=1");
            DataTable dt = ds.Tables[0];
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
                string str_col1 = "iframe_name,sysname";
                string str_col2 = "'" + iframe_textBox.Text + "','" + syname_comboBox.Text + "'";
                iframe.insertData(str_col1, str_col2);
                regest();
            }
        }

        private void iframe_regest_button_Click(object sender, EventArgs e)
        {
            regest();
        }
    }
}
