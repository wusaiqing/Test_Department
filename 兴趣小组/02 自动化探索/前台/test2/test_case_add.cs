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
    public partial class test_case_add : Form
    {
        public test_case_add()
        {
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
            sysname_comboBox.DataSource = dt;
            sysname_comboBox.DisplayMember = "sysname";
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            sysname_comboBox.SelectedIndex = 0;

            DataTable dt_f = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select function_name from config").Tables[0];
            function_name_comboBox.DataSource = dt_f;
            function_name_comboBox.DisplayMember = "function_name";
            DataRow dr_f = dt_f.NewRow();
            dr_f["function_name"] = "请选择";
            dt_f.Rows.InsertAt(dr_f, 0);
            function_name_comboBox.SelectedIndex = 0;

            compary_way_comboBox.SelectedIndex = 0;
            hope_result_way_comboBox.SelectedIndex = 0;
        }

       
        private void add_test_step_button_click(object sender, EventArgs e)
        {
            //显示提示信息
            if (sysname_comboBox.SelectedIndex == 0)
            {
                sysname_label.Visible = true;
            }
            else
            {
                sysname_label.Visible = false;
            }
            if (function_name_comboBox.SelectedIndex == 0)
            {
                function_name_label.Visible = true;
            }
            else
            {
                function_name_label.Visible = false;
            }
            if (test_id_textBox.Text == "")
            {
                test_id_label.Visible = true;
            }
            else
            {
                test_id_label.Visible = false;
            }
           
            if (compary_way_comboBox.SelectedIndex == 0)
            {
                compay_way_label.Visible = true;
            }
            else
            {
                compay_way_label.Visible = false;
            }
            if (hope_result_way_comboBox.SelectedIndex == 0)
            {
                hope_result_way_label.Visible = true;
            }
            else
            {
                hope_result_way_label.Visible = false;
            }

            if (sysname_comboBox.SelectedIndex != 0 && function_name_comboBox.SelectedIndex != 0 && test_id_textBox.Text != "" && compary_way_comboBox.SelectedIndex != 0 && hope_result_way_comboBox.SelectedIndex != 0)
            {
                add_test_button.Visible = true;
                //删除动态控件
                DataTable dt_count = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select count(0) as cun  from page_properties ").Tables[0];
                string aa = dt_count.Rows[0]["cun"].ToString();
                for (int j = 0; j < int.Parse(dt_count.Rows[0]["cun"].ToString()); j++)
                {
                    string str = "col" + j.ToString();
                    if (this.Controls.ContainsKey(str + "_Label") == true)
                    {
                        this.Controls.RemoveByKey(str + "_Label");
                    }
                    if (this.Controls.ContainsKey(str + "_TextBox") == true)
                    {
                        this.Controls.RemoveByKey(str + "_TextBox");
                    }
                    if (this.Controls.ContainsKey("test_add_button") == true)
                    {
                        this.Controls.RemoveByKey("test_add_button");
                    }
                }
                //加载控件
                if (sysname_comboBox.SelectedIndex != 0 && sysname_comboBox.SelectedIndex != 0)
                {
                    instruction_label.Visible = true;

                    string sql = @"select  element_name  from test_page  where  function_name ='" + function_name_comboBox.Text.Trim() + "' and "
                               + "  (sysname='" + sysname_comboBox.Text.Trim() + "' or sysname='all_system') order by test_order ;";

                    DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql).Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string col = "col" + i.ToString();
                        Label lb = new Label();
                        TextBox tb = new TextBox();

                        if (i % 2 != 0)
                        {
                            lb.Top = 165 + (i - 1) * 30;
                            lb.Left = 425;
                            lb.Name = col + "_Label";
                            tb.Top = 150 + (i - 1) * 30;
                            tb.Left = 525;
                            tb.Name = col + "_TextBox";

                        }
                        else
                        {
                            lb.Top = 165 + i * 30;
                            lb.Left = 0;
                            lb.Name = col + "_Label";
                            tb.Top = 150 + i * 30;
                            tb.Left = 100;
                            tb.Name = col + "_TextBox";

                        }
                        lb.TextAlign = ContentAlignment.MiddleRight;
                        tb.Size = new Size(250, 50);
                        tb.Multiline = true;
                        tb.ScrollBars = ScrollBars.Vertical;
                        lb.Text = dt.Rows[i]["element_name"].ToString() + "：";
                        lb.Visible = true;
                        tb.Visible = true;
                        this.Controls.Add(lb);
                        this.Controls.Add(tb);

                        /*
                        Button btn = new Button();
                        btn.Text = "增加";
                        btn.Name = "test_add_button";
                        btn.Location = new Point((this.ClientRectangle.Width - btn.Width) / 2, this.ClientRectangle.Height - btn.Height);
                        btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                        this.Controls.Add(btn);
                        btn.Click += new EventHandler(btn_Click);
                       */
                    }
                }
            }
        }


        private void add_test_button_Click(object sender, EventArgs e)
        {
            string sql_insert1_1 = @"insert into test_case (sysname,function_name,compare_way,hope_way,hope_result,test_id";

            //string sql = @"select page_class  from page_properties where page_class != '检查点' "
            //               + " and sysname ='" + sysname_comboBox.Text.Trim() + "'"
            //               + " and function_name='" + function_name_comboBox.Text.Trim() + "'";
            string sql = @"select  element_name  from test_page  where  function_name ='" + function_name_comboBox.Text.Trim() + "' and "
                               + "  sysname='" + sysname_comboBox.Text.Trim() + "' order by test_order ;";

            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql).Tables[0];
            string sql_insert1_2 = "";
            string sql_insert2_1 = @") values("
                                + "'" + sysname_comboBox.Text.Trim() + "', "
                                + "'" + function_name_comboBox.Text.Trim() + "',"
                                + "'" + compary_way_comboBox.Text.Trim() + "',"
                                + "'" + hope_result_way_comboBox.Text.Trim() + "',"
                                +"'"+hope_result_textBox.Text.Trim()+"',";
            List<string[]> list = new List<string[]>();
            int n = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox txt = (TextBox)this.Controls["col" + i.ToString() + "_TextBox"];
                sql_insert1_2 = sql_insert1_2 + ",col" + i.ToString();
                list.Add(txt.Text.Trim().Split(';','；'));
            }
            string sql_insert = sql_insert1_1 + sql_insert1_2 ;

            strd(list,sql_insert,sql_insert2_1);

            MessageBox.Show("检查点名称、对比方式、期望结果输入方式、期望结果无法产生笛卡尔值。如要修改，请到测试用例表查询页面进行修改");
            //新增完后重置
            add_test_step_button_click(sender,e);
            sysname_comboBox.SelectedIndex = 0;
            function_name_comboBox.SelectedIndex = 0;
            test_id_textBox.Text = "";
            compary_way_comboBox.SelectedIndex = 0;
            hope_result_way_comboBox.SelectedIndex = 0;
            hope_result_textBox.Text = "";
        }


        //笛卡尔函数
        private void strd(List<string[]> list, string str,string str2)
        {
            List<string[]> list2 = new List<string[]>();
            List<string> relist = new List<string>();

            string s = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                bool a = false;
                list2.Add(list[i]);
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (i == j)
                        a = true;
                }
                if (a == true) continue;
               Descartes(list2, 0, relist, null);
            }

            for (int i = 0; i < relist.Count; i++)
            {
                string sql_insert = "";
                sql_insert = str + str2 + "'" + test_id_textBox.Text.Trim() +"_"+i.ToString()+ "'" + relist[i] + ");";
               MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);
            }   
        }

        private string Descartes(List<string[]> list1, int count, List<string> result, string data)
        {
            string temp = data;
            string[] a = list1[count];
            foreach (var m in a)
            {
                if (count + 1 < list1.Count)
                {
                    temp += Descartes(list1, count + 1, result, data + ",'" + m + "'");
                }
                else
                {
                    result.Add(data + ",'" + m + "'");
                }
            }
            return temp;
        }
    }
}
