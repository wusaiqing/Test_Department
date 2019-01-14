using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using NPOI;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace test2
{
    public partial class steps_group : Form
    {
        public steps_group(string str1,string str2)
        {
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            steps_sysname_comboBox.DataSource = dt;
            steps_sysname_comboBox.DisplayMember = "sysname";
            steps_sysname_comboBox.Text = str1;
            steps_name_textBox.Text = str2;
            query();
        }
        public void query()
        {
            string sql = @"select id as 序号,
                                  steps_order as 执行顺序,
                                  steps_name as 步骤组名称,
                                  page_name as 页面名称,
                                  element_name as 元素名称,
                                  sysname as 被测系统名称,
                                  '编辑' as 编辑,
                                  '删除' as 删除
                                from steps_page
                                where 1=1 ";
            if (steps_sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and( sysname ='" + steps_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')";
            }
            if (steps_name_textBox.Text != "")
            {
                sql = sql + " and steps_name like '%" + steps_name_textBox.Text.Trim() + "%'";
            }
            if (page_name_textBox.Text != "")
            {
                sql = sql + " and page_name like '%" + page_name_textBox.Text.Trim() + "%'";
            }
            if (element_name_textBox.Text != "")
            {
                sql = sql + " and element_name like '%" + element_name_textBox.Text.Trim() + "%'";
            }
            sql = sql + " order by steps_name,steps_order,sysname";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
        }

        private void query_button_Click(object sender, EventArgs e)
        {
            query();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.RowIndex == dataGridView1.RowCount )
            {
                return;
            }
            else
            {
                try
                {
                    if (e.ColumnIndex == edit_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("修改骤，是否修改对应测试数据", "确认修改页面", MessageBoxButtons.YesNoCancel);
                        if (di == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (di == DialogResult.Yes)
                        {
                            edit_steps(e.RowIndex, dataGridView1.Rows[e.RowIndex].Cells["steps_name_Column"].Value.ToString());
                        }
                        else
                        {
                            string sql_update = @"update steps_page set " +
                                "steps_order= '" + dataGridView1.Rows[e.RowIndex].Cells["steps_order_Column"].Value + "'" +
                                "  where id=" + dataGridView1.Rows[e.RowIndex].Cells["id_Column"].Value;
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                        }
                    }
                    else if (e.ColumnIndex == del_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("确认删除步骤，是否删除该列步骤组数据", "确认删除页面", MessageBoxButtons.YesNoCancel);
                        if (di == DialogResult.Yes)
                        {
                            del_steps(e.RowIndex, "Yes");
                        }
                        else if (di == DialogResult.No)
                        {
                            del_steps(e.RowIndex, "No");
                        }
                        else
                        {
                            del_steps(e.RowIndex, "Cancel");
                        }
                        query();
                    }
                }
                catch
                {
                }
            }
        }

        private void all_edit_button_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            DataTable dtc = dt.GetChanges();
            DialogResult di;
            di = MessageBox.Show("修改骤，是否修改对应测试数据", "确认修改页面", MessageBoxButtons.YesNoCancel);
            if (di == DialogResult.Cancel)
            {
                return;
            }
            else if (di == DialogResult.No)
            {
                if (dtc != null)
                {
                    foreach (DataRow dr in dtc.Rows)
                    {
                        if (dr.RowState == DataRowState.Modified)
                        {
                            string sql_update = @"Update steps_page set "
                                                + "steps_order= '" + dr["执行顺序"].ToString() + "' "
                                                + "  where id=" + dr["序号"].ToString();
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                        }
                    }
                }
            }
            else if (di == DialogResult.Yes)
            {
                if (dtc != null)
                {
                    string sql_test_case_temp = "select distinct steps_name from steps  where 1=1 ";
                    if (steps_name_textBox.Text != "")
                    {
                        sql_test_case_temp = sql_test_case_temp + "and  steps_name like  '%" + steps_name_textBox.Text.Trim() + "%'  ";
                    }
                    if (steps_sysname_comboBox.SelectedIndex != 0)
                    {
                        sql_test_case_temp = sql_test_case_temp + " and (sysname = '" + steps_sysname_comboBox.Text.Trim() + "' or sysname='all_system')";
                    }
                    DataTable dt_steps_g = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_test_case_temp).Tables[0];
                    if (dt_steps_g.Rows.Count > 1)
                    {
                        MessageBox.Show("查询出来有多个功能点，不能移动steps表数据，请确定唯一值！");
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            edit_steps(i,dt_steps_g.Rows[0][0].ToString());
                        }
                    }
                }
            }
            query();
        }

        public void edit_steps(int RowIndex, string steps_name)
        {
            string sql_update = @"Update steps_page  set steps_order ='" + dataGridView1.Rows[RowIndex].Cells["steps_order_Column"].Value + "'  " +
                                                             "  where id=" + dataGridView1.Rows[RowIndex].Cells["id_Column"].Value;
            string sql_del_temp = "delete from steps_temp;";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_temp);

            string str = dataGridView1.Rows[RowIndex].Cells["steps_name_Column"].Value.ToString();
            //删除steps ，插入 steps_temp
            string sql_insert_temp = @"insert  into steps_temp  select * from steps where  1=1 ";
            string sql_test_case_del = "delete from steps where 1=1";
            if (steps_sysname_comboBox.SelectedIndex != 0)
            {
                sql_insert_temp = sql_insert_temp + " and ( sysname = '" + steps_sysname_comboBox.Text.Trim() + "' or sysname='all_system')";
                sql_test_case_del = sql_test_case_del + " and ( sysname = '" + steps_sysname_comboBox.Text.Trim() + "'  or sysname='all_system') ";
            }
            sql_insert_temp = sql_insert_temp + " and steps_name = '" + steps_name + "';";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_temp);
            sql_test_case_del = sql_test_case_del + " and steps_name = '" + steps_name + "';";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_test_case_del);

            //查询出修改前和修改后的步骤
            string sql = @"select t.* from steps_page t
                                                            where ( t.page_name,t.sysname) in
                                                            (select page_name,sysname from page_properties ) ";

            if (steps_sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and ( t.sysname = '" + steps_sysname_comboBox.Text.Trim() + "' or sysname='all_system')";
            }
            sql = sql + " and t.steps_name = '" + steps_name + "'  order by t.steps_order ";
            DataTable dt_back = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql).Tables[0];
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
            DataTable dt_curr = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql).Tables[0];

            //处理重复数据
            string sql_del_tcs_temp = @"delete from  t_c_s_temp";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_tcs_temp);

            DataRow[] drs = null;
            for (int i = 0; i < dt_back.Rows.Count; i++)
            {
                drs = dt_back.Select("element_name='" + dt_back.Rows[i]["element_name"].ToString() + "' ");
                string sql_col_value_test_case_temp = null;
                if (dt_back.Rows[i]["sysname"].ToString() != "all_system")
                {
                    sql_col_value_test_case_temp = @"select col" + i + " from steps_temp where  steps_name ='" + dt_back.Rows[i]["steps_name"].ToString()
                       + "' and  sysname ='" + dt_back.Rows[i]["sysname"].ToString() + "' ";
                }
                else
                {
                    sql_col_value_test_case_temp = @"select col" + i + " from steps_temp where  steps_name ='" + dt_back.Rows[i]["steps_name"].ToString() + "'";
                }
                DataTable dt_col_value_test = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_col_value_test_case_temp).Tables[0];
                string sql_insert_tcs_temp = @"insert into t_c_s_temp (id,col,col_value,yes_no) values(" + i + ", '" + dt_back.Rows[i]["element_name"].ToString() + "','" + dt_col_value_test.Rows[0][0].ToString() + "','no')";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_tcs_temp);
            }

            //把steps_temp 插入进steps 表中
            string sql_insert = "insert into   steps ( id,steps_name,sysname ";
            if (dt_back.Rows != null)
            {
                for (int col_i = 0; col_i < dt_back.Rows.Count; col_i++)
                {
                    sql_insert = sql_insert + ",col" + col_i.ToString();
                }
                sql_insert = sql_insert + ")    select id,steps_name,sysname ";

                for (int i = 0; i < dt_curr.Rows.Count; i++)
                {
                    string sql_t_c_s_temp_query = "select * from t_c_s_temp where col='" + dt_curr.Rows[i]["element_name"].ToString() + "' and yes_no='no' order by id";
                    DataTable dt_t_c_s = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_t_c_s_temp_query).Tables[0];
                    if (dt_t_c_s.Rows.Count > 0)
                    {
                        sql_insert = sql_insert + ",col" + dt_t_c_s.Rows[0]["id"].ToString();
                        string sql_update_t_c_s_temp = @"update t_c_s_temp set yes_no='yes' where id=" + dt_t_c_s.Rows[0]["id"].ToString();
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update_t_c_s_temp);
                    }
                }
                sql_insert = sql_insert + "  from steps_temp ";
            }
            else
            {
                sql_insert = "insert into   steps  select * from steps_temp";
            }
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);
        }
    

        private void add_button_Click(object sender, EventArgs e)
        {
            ArrayList List = new ArrayList();
            string sql = @"select distinct steps_name  from steps  where 1=1";
            if (steps_sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + "  and sysname ='" + steps_sysname_comboBox.Text.Trim() + "'";
            }
            if (steps_name_textBox.Text != "")
            {
                sql = sql + "  and steps_name like'%" + steps_name_textBox.Text.Trim() + "%'";
            }
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    List.Add(dr["steps_name"]);
                }
            }
            if (List.Count > 1)
            {
                MessageBox.Show("查询条件：被测系统:" + steps_sysname_comboBox.Text.Trim() + "步骤组名称:" + steps_name_textBox.Text.Trim() + "存在多值,不能添加多个步骤组的步骤");
            }
            else if (List.Count == 1)
            {
                steps_group_add_step sg = new steps_group_add_step();
                string str = "";
                if (steps_sysname_comboBox.SelectedIndex != 0)
                {
                    str = str + steps_sysname_comboBox.Text;
                }
                else
                {
                    string str_sy = "select distinct  sysname from steps where steps_name ='" + List[0].ToString() + "';";
                    DataTable dt_s = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, str_sy, null).Tables[0];
                    str = str + dt_s.Rows[0][0].ToString();
                }
                sg.query(List[0].ToString(), str);
                sg.ShowDialog();
            }
            else
            {
                MessageBox.Show("查询条件：被测系统:" + steps_sysname_comboBox.Text.Trim() + "步骤组名称:" + steps_name_textBox.Text.Trim() + "的值不存在,不能添加步骤组的步骤");
            }
            
        }

        private void choose_all_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    this.dataGridView1.Rows[i].Cells["select_Column"].Value = true;
                    //this._selectAll = true;
                }
            }
        }

        private void select_cancel_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells["select_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void choose_Inverse_button_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    bool se = false;
                    if (dataGridView1.Rows[i].Cells["select_Column"].Value == null)
                    {
                        this.dataGridView1.Rows[i].Cells["select_Column"].Value = true;
                        // this._selectAll = true;
                        se = true;
                    }
                    else if ((bool)dataGridView1.Rows[i].Cells["select_Column"].Value == true && se == false)
                    {
                        this.dataGridView1.Rows[i].Cells["select_Column"].Value = false;
                    }
                    else if ((bool)dataGridView1.Rows[i].Cells["select_Column"].Value == false)
                    {
                        this.dataGridView1.Rows[i].Cells["select_Column"].Value = true;
                        //this._selectAll = true;
                    }
                }
            }
        }

        public void del_steps(int i, string d_Result)
        {
            if (dataGridView1.Rows[i].Cells["id_Column"].Value.ToString() != "")
            {
                string sql_del = @"delete from  steps_page 
                                    where id=" + dataGridView1.Rows[i].Cells["id_Column"].Value;
                if (d_Result == "Yes")
                {
                    string sql_del_temp = "delete from steps_temp;";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_temp);
                    string sql_check_point_temp = @"select distinct steps_name from steps where "
                                                 + " steps_name like '%" + dataGridView1.Rows[i].Cells["steps_name_Column"].Value.ToString().Trim() + "%' ";
                    DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_check_point_temp).Tables[0];
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("查询出来有多个功能点，不能移动check_point表数据，请确定唯一值！");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        string str = dataGridView1.Rows[i].Cells["element_name_Column"].Value.ToString();
                        string sql_insert_temp = @"insert  into steps_temp  select * from steps where  steps_name = '" + dt.Rows[0][0].ToString() + "';";
                        string sql_check_point_del = "delete from steps where  steps_name = '" + dt.Rows[0][0].ToString() + "';";
                        
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_temp);
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_check_point_del);
                        string sql = @"select element_name from steps_page t where  ( t.page_name,t.sysname) in
                                            (select page_name,sysname from page_properties )"
                                        + " and  steps_name = '" + dataGridView1.Rows[i].Cells["steps_name_Column"].Value.ToString().Trim() + "' "
                                        + "order by steps_order";
                        DataTable dt2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql).Tables[0];
                        int index = 0;
                        for (int k = 0; k < dt2.Rows.Count; k++)
                        {
                            if (dt2.Rows[k][0].ToString() == str)
                            {
                                index = k;
                                break;
                            }
                        }
                        string col = "col" + index.ToString();
                        string sql_insert = "insert into   steps ( id,steps_name,sysname  ";
                        string test_case_col = "";
                        string test_case_temp_col = "";
                        for (int j = 0; j < dt2.Rows.Count - 1; j++)
                        {
                            test_case_col = test_case_col + ",col" + j.ToString();
                            if (j < index)
                            {
                                test_case_temp_col = test_case_temp_col + ",col" + j.ToString();
                            }
                            else
                            {
                                test_case_temp_col = test_case_temp_col + ",col" + (j + 1).ToString();
                            }
                        }
                        test_case_col = test_case_col + ") ";
                        test_case_temp_col = test_case_temp_col + "  from steps_temp ";
                        sql_insert = sql_insert + test_case_col;
                        sql_insert = sql_insert + "select id,steps_name,sysname ";
                        sql_insert = sql_insert + test_case_temp_col;
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);
                    }
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);
                }
                else if (d_Result == "No")
                {
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);
                }
                else
                {
                    return;
                }
            }
        }
        private void all_del_button_Click(object sender, EventArgs e)
        {
            DialogResult di;
            di = MessageBox.Show("确认删除步骤，是否删除该列步骤组数据", "确认删除页面", MessageBoxButtons.YesNoCancel);
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["select_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView1.Rows[i].Cells["select_Column"].Value == true)
                {
                    if (di == DialogResult.Yes)
                    {
                        del_steps(i, "Yes");
                    }
                    else if (di == DialogResult.No)
                    {
                        del_steps(i, "No");
                    }
                    else
                    {
                        del_steps(i, "Cancel");
                    }
                }
            }
            query();
        }

        private void export_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.DefaultExt = "xls";
            dig.Filter = "Excel文件|*.xls";
            if (dig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook = new HSSFWorkbook();
                string sql_steps = @"select * from steps where 1=1 ";
                if (steps_sysname_comboBox.SelectedIndex != 0)
                {
                    sql_steps = sql_steps + "and ( sysname = '" + steps_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')";
                }
                if (steps_name_textBox.Text != "")
                {
                    sql_steps = sql_steps + " and steps_name like '%" + steps_name_textBox.Text.Trim() + "%' ";
                }
                sql_steps = sql_steps + " order by steps_name,sysname";
                DataTable dt_steps = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_steps, null).Tables[0];
                if (dt_steps.Rows.Count > 0)
                {
                    int a = 0;
                    ISheet sheet1 = hssfworkbook.CreateSheet("步骤组");
                    for (int steps_id = 0; steps_id < dt_steps.Rows.Count; steps_id++)
                    {
                        string sql = @"select *  from steps_page where ( sysname='" + dt_steps.Rows[steps_id]["sysname"].ToString() + "'  or sysname ='all_system')"
                                    + " and steps_name='" + dt_steps.Rows[steps_id]["steps_name"].ToString() + "'  order by steps_name,steps_order,sysname";
                        DataTable dt2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
                        string sql_steps_col = @"select *  from steps where ( sysname='" + dt_steps.Rows[steps_id]["sysname"].ToString() + "' or sysname ='all_system')"
                                    + " and steps_name='" + dt_steps.Rows[steps_id]["steps_name"].ToString() + "' ";
                        DataTable dt_steps_col = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_steps_col, null).Tables[0];
                        if (dt2.Rows.Count > 0)
                        {
                            FileStream file = new FileStream(dig.FileName, FileMode.Create);
                            HSSFCellStyle dateStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                            HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
                            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                            IRow row1 = sheet1.CreateRow(0);
                            row1.CreateCell(0).SetCellValue("序号");
                            row1.CreateCell(1).SetCellValue("执行顺序");
                            row1.CreateCell(2).SetCellValue("步骤组名称");
                            row1.CreateCell(3).SetCellValue("页面名称");
                            row1.CreateCell(4).SetCellValue("元素名称");
                            row1.CreateCell(5).SetCellValue("被测系统名称");
                            row1.CreateCell(6).SetCellValue("步骤值");
                            for (int w_i = 0; w_i < 7; w_i++)
                            {
                                sheet1.SetColumnWidth(w_i, 28 * 256);
                            }
                            if (dt2 != null)
                            {   
                                for (int k = 0; k < dt2.Rows.Count; k++)
                                {
                                    HSSFRow dataRow = sheet1.CreateRow(k+a + 1) as HSSFRow;
                                    foreach (DataColumn column in dt2.Columns)
                                    {
                                        HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
                                        string drValue = dt2.Rows[k][column.Ordinal].ToString();
                                        //string drValue = null;
                                        //if (column.Ordinal < 5)
                                        //{
                                        //    drValue = dt2.Rows[k][column.Ordinal].ToString();
                                        //}
                                        //else
                                        //{
                                        //    drValue = dt_steps.Rows[steps_id]["sysname"].ToString();
                                        //}
                                        switch (column.DataType.ToString())
                                        {
                                            case "System.String": //字符串类型
                                                newCell.SetCellValue(drValue);
                                                break;
                                            case "System.DateTime": //日期类型
                                                DateTime dateV;
                                                DateTime.TryParse(drValue, out dateV);
                                                newCell.SetCellValue(dateV);

                                                newCell.CellStyle = dateStyle; //格式化显示
                                                break;
                                            case "System.Boolean": //布尔型
                                                bool boolV = false;
                                                bool.TryParse(drValue, out boolV);
                                                newCell.SetCellValue(boolV);
                                                break;
                                            case "System.Int16": //整型
                                            case "System.Int32":
                                            case "System.Int64":
                                            case "System.Byte":
                                                int intV = 0;
                                                int.TryParse(drValue, out intV);
                                                newCell.SetCellValue(intV);
                                                break;
                                            case "System.Decimal": //浮点型
                                            case "System.Double":
                                                double doubV = 0;
                                                double.TryParse(drValue, out doubV);
                                                newCell.SetCellValue(doubV);
                                                break;
                                            case "System.DBNull": //空值处理
                                                newCell.SetCellValue("");
                                                break;
                                            default:
                                                newCell.SetCellValue("");
                                                break;
                                        }
                                    }
                                    HSSFCell newCell2 = dataRow.CreateCell(6) as HSSFCell;
                                    string str_col = "col" + k;
                                    newCell2.SetCellValue(dt_steps_col.Rows[0][str_col].ToString());
                                }

                                a = a + dt2.Rows.Count;
                            }
                            else
                            {
                                return;
                            }
                            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
                            string[] str = new string[dt.Rows.Count];
                            for (int L = 0; L < dt.Rows.Count; L++)
                            {
                                str[L] = dt.Rows[L]["sysname"].ToString();
                            }
                            CellRangeAddressList sysname = new CellRangeAddressList(1, 65535, 5, 5);
                            DVConstraint sysname2 = DVConstraint.CreateExplicitListConstraint(str);
                            HSSFDataValidation sysname3 = new HSSFDataValidation(sysname, sysname2);
                            sheet1.AddValidationData(sysname3);
                            hssfworkbook.Write(file);
                            file.Close();
                        }
                    }
                }
            }
        }

        private void import_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog di = new OpenFileDialog();
            //di.DefaultExt = "xls";
            di.Filter = "Excel文件|*.xls";
            di.ShowDialog();
            if (di.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(di.FileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
                int sheetcount = hssfworkbook.NumberOfSheets;
                if (sheetcount > 0)
                {
                    for (int sheet_index = 0; sheet_index < sheetcount; sheet_index++)
                    {
                        DataTable dt = new DataTable();
                        ISheet sheet = hssfworkbook.GetSheetAt(sheet_index);
                        System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                        {
                            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                            dt.Columns.Add(column);
                        }
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dt.NewRow();
                            if (row != null)
                            {
                                for (int j = row.FirstCellNum; j < cellCount; j++)
                                {
                                    if (row.GetCell(j) != null)
                                    {
                                        dataRow[j] = row.GetCell(j).ToString();
                                    }
                                }
                                dt.Rows.Add(dataRow);
                            }
                        }
                        if (dt != null)
                        {
                            ///按功能点，删除steps_page 记录
                            string str_sys = dt.Rows[0][5].ToString();
                            string str_steps_name = dt.Rows[0][2].ToString();
                            string sql_del = @"delete from steps_page where steps_name='" + str_steps_name + "' ";
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);
                            ///清除steps col0至coln的记录。因为表的列数可能会变化，所以删除表的记录，再插入
                            string sql_sys = @"select sysname from steps where steps_name='" + str_steps_name + "'";
                            DataTable dt_sys = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_sys).Tables[0];
                            if (str_steps_name != "")
                            {
                                if (str_sys == "all_system")
                                {
                                    for (int j = 1; j < dt.Rows.Count; j++)
                                    {
                                        if (str_steps_name == dt.Rows[j][2].ToString() && dt.Rows[j][5].ToString() != "all_system")
                                        {
                                            str_sys = dt.Rows[j][5].ToString();
                                            string sql_del_steps = "delete from steps where steps_name='" + str_steps_name + "'";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_steps);
                                            string sql_insert_steps = @"insert into steps (steps_name,sysname,col0) values ('" + str_steps_name + "', '" + str_sys + "','" + dt.Rows[0][6].ToString() + "');";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_steps);
                                        }
                                    }
                                    if (str_sys == "all_system")
                                    {
                                        MessageBox.Show(str_steps_name + "全部都是all_system,不能导入！");
                                    }
                                }
                                else
                                {
                                    string sql_del_steps = "delete from steps where steps_name='" + str_steps_name + "';";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_steps);
                                    string sql_insert_steps = @"insert into steps (steps_name,sysname,col0) values ('" + str_steps_name + "', '" + str_sys + "','" + dt.Rows[0][6].ToString() + "');";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_steps);
                                }
                            }
                            
                            int col_i = 1;
                            for (int i = 1; i < dt.Rows.Count; i++)
                            {
                                if (str_steps_name == dt.Rows[i][2].ToString() && (str_sys == dt.Rows[i][5].ToString() ||  dt.Rows[i][5].ToString() == "all_system"))
                                {
                                    string sql_update_steps = @"update  steps  set col" + col_i + "='" + dt.Rows[i][6].ToString() 
                                        + "' where steps_name='" + dt.Rows[i][2].ToString() + "' and sysname='"+str_sys+"'";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update_steps);
                                    col_i = col_i + 1;
                                }
                                else
                                {
                                    col_i = 1;
                                    ///按功能点，删除steps_page 记录
                                    str_sys = dt.Rows[i][5].ToString();
                                    str_steps_name = dt.Rows[i][2].ToString();
                                    sql_del = @"delete from steps_page where steps_name='" + str_steps_name + "' ";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);
                                    ///清除steps col0至coln的记录。因为表的列数可能会变化，所以删除表的记录，再插入
                                    sql_sys = @"select sysname from steps where steps_name='" + str_steps_name + "'";
                                    DataTable dt_sys2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_sys).Tables[0];
                                    if (str_steps_name != "")
                                    {
                                        if (str_sys == "all_system")
                                        {
                                            for (int j = i; j < dt.Rows.Count; j++)
                                            {
                                                if (str_steps_name == dt.Rows[j][2].ToString() && dt.Rows[j][5].ToString() != "all_system")
                                                {
                                                    str_sys = dt.Rows[j][5].ToString();
                                                    string sql_del_steps = "delete from steps where steps_name='" + str_steps_name + "';";
                                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_steps);
                                                    string sql_insert_steps = @"insert into steps (steps_name,sysname,col0) values ('" + str_steps_name + "', '" + str_sys + "','" + dt.Rows[i][6].ToString() + "');";
                                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_steps);
                                                }
                                            }
                                            if (str_sys == "all_system")
                                            {
                                                MessageBox.Show(str_steps_name + "全部都是all_system,不能导入！");
                                            }
                                        }
                                        else
                                        {
                                            string sql_del_steps = "delete from steps where steps_name='" + str_steps_name + "';";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_steps);
                                            string sql_insert_steps = @"insert into steps (steps_name,sysname,col0) values ('" + str_steps_name + "', '" + str_sys + "','" + dt.Rows[i][6].ToString() + "');";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_steps);
                                        }
                                    }
                                }
                            }
                            //插入steps_page记录
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string[] list = new string[5];
                                string sql_insert = @"insert into  steps_page (steps_order ,steps_name ,page_name,element_name,sysname ) values (";
                                int k2 = 0;
                                for (int k = 1; k < dt.Columns.Count - 2; k++)
                                {
                                    sql_insert = sql_insert + "\"" + dt.Rows[i][k].ToString().Trim() + "\",";
                                    list[k] = dt.Rows[i][k].ToString().Trim();
                                    if (dt.Rows[i][k].ToString().Trim() == "")
                                    {
                                        k2 = k2 + 1;
                                    }
                                }
                                if (k2 != dt.Columns.Count - 3)
                                {
                                    sql_insert = sql_insert + "\"" + dt.Rows[i][dt.Columns.Count - 2].ToString().Trim() + "\");";
                                    //list[5] = dt.Rows[i][dt.Columns.Count - 1].ToString().Trim();
                                    string sql_q = @"select count(0) from steps_page where  steps_order='" + list[0] + "' "
                                                   + "and steps_name='" + list[1] + "' "
                                                   + "and page_name='" + list[2] + "' "
                                                   + "and element_name='" + list[3] + "' "
                                                   + "and sysname='" + list[4] + "' ";
                                    DataTable dt2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_q).Tables[0];
                                    if (int.Parse(dt2.Rows[0][0].ToString()) == 0)
                                    {
                                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            query();
        }
    }
}
