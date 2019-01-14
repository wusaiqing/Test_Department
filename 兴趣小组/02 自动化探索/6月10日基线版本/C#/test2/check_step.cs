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
    public partial class check_step : Form
    {
        public check_step(string str1, string str2)
        {
            InitializeComponent();
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            check_sysname_comboBox.DataSource = dt;
            check_sysname_comboBox.DisplayMember = "sysname";
            check_sysname_comboBox.Text = str1;
            check_name_textBox.Text = str2;
            query();
        }
        public void query()
        {
            string sql = @"select id as 序号,
                                check_order as 执行顺序,
                                check_point_name as 检查点名称,
                                page_name as 页面名称,
                                element_name as 元素名称,
                                sysname as 被测系统名称,
                                '编辑' as 编辑,
                                '删除' as 删除
                                from 
                                check_page
                                    where 1=1   ";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname='all_system') ";
            }
            if (check_name_textBox.Text != "")
            {
                sql = sql + " and check_point_name like '%" + check_name_textBox.Text.Trim() + "%'";
            }
            if (page_name_textBox.Text != "")
            {
                sql = sql + " and page_name like '%" + page_name_textBox.Text.Trim() + "%'";
            }
            if (element_name_textBox.Text != "")
            {
                sql = sql + " and element_name like '%" + element_name_textBox.Text.Trim() + "%'";
            }
            sql = sql + "order by check_point_name,check_order, sysname ";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
        }
       
        private void query_button_Click(object sender, EventArgs e)
        {
            query();
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
                            string sql_update = @"Update check_page 
                                              set 
                                              check_order = '" + dr["执行顺序"] + "', " +
                                                  "check_point_name = '" + dr["检查点名称"] + "', " +
                                                  "page_name = '" + dr["页面名称"] + "', " +
                                                  "element_name = '" + dr["元素名称"] + "', " +
                                                  "sysname = '" + dr["被测系统名称"] + "'" +
                                                  "  where id='" + dr["序号"] + "';";
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                        }
                    }
                }
            }
            else if (di == DialogResult.Yes)
            {
                if (dtc != null)
                {
                    string sql_test_case_temp = "select distinct check_point_name from check_point where 1=1 ";
                    if (check_name_textBox.Text != "")
                    {
                        sql_test_case_temp = sql_test_case_temp + " and  check_point_name like '%" + check_name_textBox.Text.Trim() + "%'  ";
                    }
                    if (check_sysname_comboBox.SelectedIndex != 0)
                    {
                        sql_test_case_temp = sql_test_case_temp + " and  ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')";
                    }
                    DataTable dt_check = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_test_case_temp).Tables[0];
                    if (dt_check.Rows.Count > 1)
                    {
                        MessageBox.Show("查询出来有多个，不能移动检查点数据，请确定唯一值！");
                    }
                    else if (dt_check.Rows.Count == 1)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            edit_check_step(i, dt_check.Rows[0][0].ToString());
                        }
                    }
                }
            }
            query();
        }
        public void edit_check_step(int RowIndex,string check_point_name)
        {
            string sql_update = @"Update check_page  set check_order ='" + dataGridView1.Rows[RowIndex].Cells["check_order_Column"].Value + "'  " +
                                                             "  where id=" + dataGridView1.Rows[RowIndex].Cells["id_Column"].Value;
            string sql_del_temp = "delete from check_point_temp;";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_temp);

            string str = dataGridView1.Rows[RowIndex].Cells["element_name_Column"].Value.ToString();
            //删除check_point ，插入 check_point_temp
            string sql_insert_temp = @"insert  into check_point_temp  select * from check_point where  1=1 ";
            string sql_check_point_del = "delete from check_point where 1=1";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                sql_insert_temp = sql_insert_temp + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')  ";
                sql_check_point_del = sql_check_point_del + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system') ";
            }
            sql_insert_temp = sql_insert_temp + " and check_point_name = '" + check_point_name + "';";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_temp);
            sql_check_point_del = sql_check_point_del + " and check_point_name = '" + check_point_name + "';";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_check_point_del);

            //查询出修改前和修改后的步骤
            string sql = @"select t.* from check_page t
                                                            where ( t.page_name,t.sysname) in
                                                            (select page_name,sysname from page_properties ) ";

            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and ( t.sysname = '" + check_sysname_comboBox.Text.Trim() + "' or t.sysname='all_system') ";
            }
            sql = sql + " and t.check_point_name = '" + check_point_name + "'  order by t.check_order ";
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
                    sql_col_value_test_case_temp = @"select col" + i + " from check_point_temp where  check_point_name ='" + dt_back.Rows[i]["check_point_name"].ToString()
                       + "' and  sysname ='" + dt_back.Rows[i]["sysname"].ToString() + "' ";
                }
                else
                {
                    sql_col_value_test_case_temp = @"select col" + i + " from check_point_temp where  check_point_name ='" + dt_back.Rows[i]["check_point_name"].ToString() + "'";
                }
                DataTable dt_col_value_test = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_col_value_test_case_temp).Tables[0];
                string sql_insert_tcs_temp = @"insert into t_c_s_temp (id,col,col_value,yes_no) values(" + i + ", '" + dt_back.Rows[i]["element_name"].ToString() + "','" + dt_col_value_test.Rows[0][0].ToString() + "','no')";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_tcs_temp);
            }


            //把check_point_temp 插入进check_point 表中
            string sql_insert = "insert into   check_point ( id,check_point_name,sysname ";
            if (dt_back.Rows != null)
            {
                for (int col_i = 0; col_i < dt_back.Rows.Count; col_i++)
                {
                    sql_insert = sql_insert + ",col" + col_i.ToString();
                }
                sql_insert = sql_insert + ")    select id,check_point_name,sysname ";

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
                sql_insert = sql_insert + "  from check_point_temp ";
            }
            else
            {
                sql_insert = "insert into   check_point  select * from check_point_temp";
            }
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);

            //else
            //{
            //    string sql_update2 = @"Update check_page  set check_order ='" + dataGridView1.Rows[RowIndex].Cells["check_order_Column"].Value + "'  " +
            //                                                 "  where id=" + dataGridView1.Rows[RowIndex].Cells["id_Column"].Value;
            //    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update2);
            //}
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (e.RowIndex == dataGridView1.RowCount)
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
                            string check_point_name =dataGridView1.Rows[e.RowIndex].Cells["check_point_name_Column"].Value.ToString();
                            edit_check_step(e.RowIndex, check_point_name);
                        }
                        else
                        {
                            string sql_update = @"update check_page set " +
                                "check_order= '" + dataGridView1.Rows[e.RowIndex].Cells["check_order_Column"].Value + "'" +
                                "  where id=" + dataGridView1.Rows[e.RowIndex].Cells["id_Column"].Value;
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                        }
                        query();
                    }
                    else if (e.ColumnIndex == del_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("确认删除步骤，是否删除该列检查点数据", "确认删除页面", MessageBoxButtons.YesNoCancel);
                        if (di == DialogResult.Yes)
                        {
                            del_check(e.RowIndex, "Yes");
                        }
                        else if (di == DialogResult.No)
                        {
                            del_check(e.RowIndex, "No");
                        }
                        else
                        {
                            del_check(e.RowIndex, "Cancel");
                        }
                        query();
                    }
                }
                catch
                {
                }
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            ArrayList List = new ArrayList();
            string sql = @"select distinct check_point_name  from check_point  where 1=1";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + "  and (sysname ='" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')";
            }
            if (check_name_textBox.Text != "")
            {
                sql = sql + "  and check_point_name like'%" + check_name_textBox.Text.Trim() + "%'";
            }
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    List.Add(dr["check_point_name"]);
                }
            }
            if (List.Count > 1)
            {
                MessageBox.Show("查询条件：被测系统:" + check_sysname_comboBox.Text.Trim() + "检查点名称:" + check_name_textBox.Text.Trim() + "存在多值,不能添加多个检查点的检查点步骤");
            }
            else if (List.Count == 1)
            {
                check_add_step ca = new check_add_step();
                string str = "";
                if (check_sysname_comboBox.SelectedIndex != 0)
                {
                    str = str + check_sysname_comboBox.Text;
                }
                else
                {
                    string str_sy = "select distinct  sysname from check_point where check_point_name ='" + List[0].ToString() + "';";
                    DataTable dt_s = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, str_sy, null).Tables[0];
                    str = str + dt_s.Rows[0][0].ToString();
                }
                ca.query(List[0].ToString(), str);
                ca.ShowDialog();
            }
            else
            {
                MessageBox.Show("查询条件：被测系统:" + check_sysname_comboBox.Text.Trim() + "检查点名称:" + check_name_textBox.Text.Trim() + "的值不存在,不能添加检查点步骤");
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

        private void export_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.DefaultExt = "xls";
            dig.Filter = "Excel文件|*.xls";
            if (dig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                HSSFWorkbook hssfworkbook = new HSSFWorkbook();
                string sql_check_point = @"select * from  check_point where 1=1 ";
                if (check_sysname_comboBox.SelectedIndex != 0)
                {
                    sql_check_point = sql_check_point + " and (sysname='" + check_sysname_comboBox.Text + "' or sysname ='all_system')";
                }
                if (check_name_textBox.Text != "")
                {
                    sql_check_point = sql_check_point + " and check_point_name like '%" + check_name_textBox.Text.Trim() + "%' ";
                }
                sql_check_point = sql_check_point + " order by  check_point_name,sysname  ";
                DataTable dt_check = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_check_point, null).Tables[0];
                if (dt_check.Rows.Count > 0)
                {
                    int a = 0;
                    ISheet sheet1 = hssfworkbook.CreateSheet("检查点步骤");
                    for (int check_id = 0; check_id < dt_check.Rows.Count; check_id++)
                    {
                        string sql = @"select *  from check_page where ( sysname='" + dt_check.Rows[check_id]["sysname"].ToString() + "' or sysname='all_system') "
                                    + " and check_point_name ='" + dt_check.Rows[check_id]["check_point_name"].ToString() + "' order by check_point_name,check_order, sysname ";
                        DataTable dt2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
                        string sql_check_col = @"select * from check_point where ( sysname='" + dt_check.Rows[check_id]["sysname"].ToString() + "' or sysname='all_system') "
                                    + " and check_point_name ='" + dt_check.Rows[check_id]["check_point_name"].ToString() + "' ";
                        DataTable dt_check_col = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_check_col, null).Tables[0];
                        if (dt2.Rows.Count > 0)
                        {
                            FileStream file = new FileStream(dig.FileName, FileMode.Create);
                            HSSFCellStyle dateStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                            HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
                            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                            IRow row1 = sheet1.CreateRow(0);
                            row1.CreateCell(0).SetCellValue("序号");
                            row1.CreateCell(1).SetCellValue("执行顺序");
                            row1.CreateCell(2).SetCellValue("检查点名称");
                            row1.CreateCell(3).SetCellValue("页面名称");
                            row1.CreateCell(4).SetCellValue("元素名称");
                            row1.CreateCell(5).SetCellValue("被测系统名称");
                            row1.CreateCell(6).SetCellValue("检查点步骤值");
                            for (int w_i = 0; w_i < 7; w_i++)
                            {
                                sheet1.SetColumnWidth(w_i, 28 * 256);
                            }
                            if (dt2 != null)
                            {
                                for (int k = 0; k < dt2.Rows.Count; k++)
                                {
                                    HSSFRow dataRow = sheet1.CreateRow(k+a+ 1) as HSSFRow;
                                    foreach (DataColumn column in dt2.Columns)
                                    {
                                        HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
                                        string drValue = dt2.Rows[k][column.Ordinal].ToString();
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
                                    newCell2.SetCellValue(dt_check_col.Rows[0][str_col].ToString());
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
                            ///按功能点，删除check_page记录
                            string str_sys = dt.Rows[0][5].ToString();
                            string str_check_name = dt.Rows[0][2].ToString();
                            
                            string sql_del = @"delete from check_page where check_point_name='" + str_check_name + "' ";
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);
                            ///清除check_point col0至coln的记录。因为表的列数可能会变化，所以删除表的记录，再插入
                            string sql_sys = @"select sysname from check_point where check_point_name='" + str_check_name + "' ";
                            DataTable dt_sys = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_sys).Tables[0];
                            if (str_check_name != "")
                            {
                                if (str_sys == "all_system")
                                {
                                    for (int j = 1; j < dt.Rows.Count; j++)
                                    {
                                        if (str_check_name == dt.Rows[j][2].ToString() && dt.Rows[j][5].ToString() != "all_system")
                                        {
                                            str_sys = dt.Rows[j][5].ToString();
                                            string sql_del_check = "delete from check_point where check_point_name='" + str_check_name + "'";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_check);
                                            string sql_insert_check = @"insert into check_point (check_point_name,sysname,col0) values ('" + str_check_name + "', '" + str_sys + "','" + dt.Rows[0][6].ToString() + "');";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_check);
                                        }
                                    }
                                    if (str_sys == "all_system")
                                    {
                                        MessageBox.Show(str_check_name + "全部都是all_system,不能导入！");
                                    }
                                }
                                else
                                {
                                    string sql_del_check = "delete from check_point where check_point_name='" + str_check_name + "'";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_check);
                                    string sql_insert_check = @"insert into check_point (check_point_name,sysname,col0) values ('" + str_check_name + "', '" + str_sys + "','" + dt.Rows[0][6].ToString() + "');";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_check);
                                }
                            }

                            if (str_sys == "all_system")
                            {
                                MessageBox.Show(str_check_name + "全部都是all_system,不能导入！");
                            }
                            int col_i = 1;

                            for (int i = 1; i < dt.Rows.Count; i++)
                            {
                                if (str_check_name == dt.Rows[i][2].ToString() && (str_sys == dt.Rows[i][5].ToString() || dt.Rows[i][5].ToString() == "all_system"))
                                {
                                    string sql_update_check = @"update  check_point  set col" + col_i + "='" + dt.Rows[i][6].ToString()
                                        + "' where check_point_name='" + dt.Rows[i][2].ToString() + "' and  sysname='" + str_sys + "' ";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update_check);
                                    col_i = col_i + 1;
                                }
                                else
                                {
                                    col_i = 1;
                                    str_sys = dt.Rows[i][5].ToString();
                                    str_check_name = dt.Rows[i][2].ToString();
                                    sql_del = @"delete from check_page where check_point_name='" + str_check_name + "' ";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);

                                    sql_sys = @"select sysname from check_point where check_point_name='" + str_check_name + "'";
                                    DataTable dt_sys2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_sys).Tables[0];
                                    if (str_check_name != "")
                                    {
                                        if (str_sys == "all_system")
                                        {
                                            for (int j = i; j < dt.Rows.Count; j++)
                                            {
                                                if (str_check_name == dt.Rows[j][2].ToString() && dt.Rows[j][5].ToString() != "all_system")
                                                {
                                                    str_sys = dt.Rows[j][5].ToString();
                                                    string sql_del_check = "delete from check_point where check_point_name='" + str_check_name + "'";
                                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_check);
                                                    string sql_insert_check = @"insert into check_point (check_point_name,sysname,col0) values ('" + str_check_name + "', '" + str_sys + "','" + dt.Rows[i][6].ToString() + "');";
                                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_check);
                                                }
                                            }
                                            if (str_sys == "all_system")
                                            {
                                                MessageBox.Show(str_check_name + "全部都是all_system,不能导入！");
                                            }
                                        }
                                        else
                                        {
                                            string sql_del_check = "delete from check_point where check_point_name='" + str_check_name + "'";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_check);
                                            string sql_insert_check = @"insert into check_point (check_point_name,sysname,col0) values ('" + str_check_name + "', '" + str_sys + "','" + dt.Rows[i][6].ToString() + "');";
                                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_check);
                                        }
                                    }
                                }
                            }

                            //插入check_page记录
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string[] list = new string[5];
                                string sql_insert = @"insert into  check_page (check_order ,check_point_name ,page_name,element_name,sysname ) values (";
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
                                    string sql_q = @"select count(0) from check_page where  check_order='" + list[0] + "' "
                                                   + "and check_point_name='" + list[1] + "' "
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

        public void del_check(int i, string d_Result)
        {
            if (dataGridView1.Rows[i].Cells["id_Column"].Value.ToString() != "")
            {
                string sql_del = @"delete from  check_page 
                                    where id=" + dataGridView1.Rows[i].Cells["id_Column"].Value;
                if (d_Result == "Yes")
                {
                    string sql_del_temp = "delete from check_point_temp;";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_temp);
                    string sql_check_point_temp = @"select distinct check_point_name from check_point where "
                                                 + " check_point_name = '" + dataGridView1.Rows[i].Cells["check_point_name_Column"].Value.ToString().Trim() + "' ";
                    DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_check_point_temp).Tables[0];
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("查询出来有多个功能点，不能移动check_point表数据，请确定唯一值！");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        string str = dataGridView1.Rows[i].Cells["element_name_Column"].Value.ToString();
                        string sql_insert_temp = @"insert  into check_point_temp  select * from check_point where check_point_name like '%" + dt.Rows[0][0].ToString() + "%';";
                        string sql_check_point_del = "delete from check_point where check_point_name = '" + dt.Rows[0][0].ToString() + "';";
                              
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_temp);
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_check_point_del);
                        string sql = @"select element_name from check_page
                                                            where ( page_name,sysname) in
                                                            (select page_name,sysname from page_properties ) "
                                        + " and  check_point_name = '" + dataGridView1.Rows[i].Cells["check_point_name_Column"].Value.ToString().Trim() + "' "
                                        + "order by check_order, sysname ,check_point_name ";
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
                        string sql_insert = "insert into   check_point ( id,check_point_name,sysname  ";
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
                        test_case_temp_col = test_case_temp_col + "  from check_point_temp ";
                        sql_insert = sql_insert + test_case_col;
                        sql_insert = sql_insert + "select id,check_point_name,sysname ";
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
            di = MessageBox.Show("确认删除步骤，是否删除该列检查点数据", "确认删除页面", MessageBoxButtons.YesNoCancel);
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["select_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView1.Rows[i].Cells["select_Column"].Value == true)
                {
                    if (dataGridView1.Rows[i].Cells["id_Column"].Value.ToString() != "")
                    {
                        if (di == DialogResult.Yes)
                        {
                            del_check(i, "Yes");
                        }
                        else if (di == DialogResult.No)
                        {
                            del_check(i, "No");
                        }
                        else
                        {
                            del_check(i, "Cancel");
                        }
                    }
                }
            }
            query();
        }
    }
}
