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
        DAL.TotalConfig tc = new DAL.TotalConfig();
        DAL.check_page check_page = new DAL.check_page();
        DAL.check_point check_point = new DAL.check_point();
        DAL.check_point_temp check_point_temp = new DAL.check_point_temp();
        DAL.t_c_s_temp t_c_s_temp = new DAL.t_c_s_temp();

        public check_step(string str1, string str2)
        {
            InitializeComponent();
            DataSet ds = tc.SelectData("sysname","1=1");
            DataTable dt =ds.Tables[0];
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
            string str_colName = @"id as 序号,
                                check_order as 执行顺序,
                                check_point_name as 检查点名称,
                                page_name as 页面名称,
                                element_name as 元素名称,
                                sysname as 被测系统名称,
                                '编辑' as 编辑,
                                '删除' as 删除";
            string str_Where = "1=1 ";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                str_Where = str_Where + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname='all_system') ";
            }
            if (check_name_textBox.Text != "")
            {
                str_Where = str_Where + " and check_point_name like '%" + check_name_textBox.Text.Trim() + "%'";
            }
            if (page_name_textBox.Text != "")
            {
                str_Where = str_Where + " and page_name like '%" + page_name_textBox.Text.Trim() + "%'";
            }
            if (element_name_textBox.Text != "")
            {
                str_Where = str_Where + " and element_name like '%" + element_name_textBox.Text.Trim() + "%'";
            }
            string str_order =  "  check_point_name,check_order, sysname ";
            dataGridView1.AutoGenerateColumns = false;
            DataSet ds = check_page.SelectData(str_colName, str_Where, str_order);
            dataGridView1.DataSource = ds.Tables[0];
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
                            string str_colName = @" check_order = '" + dr["执行顺序"] + "', " +
                                                  "check_point_name = '" + dr["检查点名称"] + "', " +
                                                  "page_name = '" + dr["页面名称"] + "', " +
                                                  "element_name = '" + dr["元素名称"] + "', " +
                                                  "sysname = '" + dr["被测系统名称"] + "'";
                            string str_Where = " id='" + dr["序号"] + "' ";
                            check_page.updateData(str_colName, str_colName);
                        }
                    }
                }
            }
            else if (di == DialogResult.Yes)
            {
                if (dtc != null)
                {
                    string str_colName = " distinct check_point_name ";
                    string str_Where = "1=1";
                    if (check_name_textBox.Text != "")
                    {
                        str_Where = str_Where + " and  check_point_name like '%" + check_name_textBox.Text.Trim() + "%'  ";
                    }
                    if (check_sysname_comboBox.SelectedIndex != 0)
                    {
                        str_Where = str_Where + " and  ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')";
                    }
                    DataSet ds = check_point.SelectData(str_colName, str_Where);
                    DataTable dt_check = ds.Tables[0];
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
        public void edit_check_step(int RowIndex, string check_point_name)
        {
            string str_colName = "check_order ='" + dataGridView1.Rows[RowIndex].Cells["check_order_Column"].Value + "'  ";
            string str_Where = "id=" + dataGridView1.Rows[RowIndex].Cells["id_Column"].Value;
            check_point_temp.deleteData("1=1");
            string str = dataGridView1.Rows[RowIndex].Cells["element_name_Column"].Value.ToString();
            //删除check_point ，插入 check_point_temp
            string str_table = " select * from check_point where  1=1 ";
            string str_Where2 = "1=1 ";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                str_table = str_table + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')  ";
                str_Where2 = str_Where2 + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system') ";
            }
            str_table = str_table + " and check_point_name = '" + check_point_name + "';";
            check_point_temp.insertData(str_table);
            str_Where2 = str_Where2 + " and check_point_name = '" + check_point_name + "';";
            check_point.deleteData(str_Where2);

            //查询出修改前和修改后的步骤
            string str_Where3 = " ( page_name, sysname) in (select page_name,sysname from page_properties )  ";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                str_Where3 = str_Where3 + " and ( sysname = '" + check_sysname_comboBox.Text.Trim() + "' or sysname='all_system') ";
            }
            str_Where3 = str_Where3 + " and check_point_name = '" + check_point_name + "' ";
            string str_order3 = " check_order ";
            DataSet ds = check_page.SelectData("*", str_Where3, str_order3);
            DataTable dt_back = ds.Tables[0];
            check_page.updateData(str_colName, str_Where);
            DataSet ds2 = check_page.SelectData("*", str_Where3, str_order3);
            DataTable dt_curr = ds2.Tables[0];

            //处理重复数据
            t_c_s_temp.deleteData("1=1");

            DataRow[] drs = null;
            for (int i = 0; i < dt_back.Rows.Count; i++)
            {
                drs = dt_back.Select("element_name='" + dt_back.Rows[i]["element_name"].ToString() + "' ");
                //string sql_col_value_test_case_temp = null;
                string str_colName4 = "col" + i;
                string str_Where4 = "check_point_name ='" + dt_back.Rows[i]["check_point_name"].ToString() + "' ";
                if (dt_back.Rows[i]["sysname"].ToString() != "all_system")
                {
                    str_Where4 = str_Where4 + " and  sysname ='" + dt_back.Rows[i]["sysname"].ToString() + "' ";
                }
                DataSet ds4 = check_point_temp.SelectData(str_colName4, str_Where4);
                DataTable dt_col_value_test = ds4.Tables[0];
                string str_col1 = "id,col,col_value,yes_no";
                string str_col2 = i + ", '" + dt_back.Rows[i]["element_name"].ToString() + "','" + dt_col_value_test.Rows[0][0].ToString() + "','no' ";
                t_c_s_temp.insertData(str_col1, str_col2);
            }

            //把check_point_temp 插入进check_point 表中
            string str_col = " id,check_point_name,sysname ";
            if (dt_back.Rows != null)
            {
                for (int col_i = 0; col_i < dt_back.Rows.Count; col_i++)
                {
                    str_col = str_col + ",col" + col_i.ToString();
                }
                string str_table2 = "select id,check_point_name,sysname";

                for (int i = 0; i < dt_curr.Rows.Count; i++)
                {
                    string sql_t_c_s_temp_query = "select * from t_c_s_temp where col='" + dt_curr.Rows[i]["element_name"].ToString() + "' and yes_no='no' order by id";
                    DataTable dt_t_c_s = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_t_c_s_temp_query).Tables[0];
                    if (dt_t_c_s.Rows.Count > 0)
                    {
                        str_table2 = str_table2 + ",col" + dt_t_c_s.Rows[0]["id"].ToString();
                        string sql_update_t_c_s_temp = @"update t_c_s_temp set yes_no='yes' where id=" + dt_t_c_s.Rows[0]["id"].ToString();
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update_t_c_s_temp);
                    }
                }
                str_table2 = str_table2 + "  from check_point_temp ";
                check_point.insertData2(str_col, str_table2);
            }
            else
            {
                string str_table2 = "select * from check_point_temp";
                check_point.insertData(str_table2);
            }
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
                            string check_point_name = dataGridView1.Rows[e.RowIndex].Cells["check_point_name_Column"].Value.ToString();
                            edit_check_step(e.RowIndex, check_point_name);
                        }
                        else
                        {
                            string str_colName = "check_order= '" + dataGridView1.Rows[e.RowIndex].Cells["check_order_Column"].Value + "'";
                            string str_Where = " id=" + dataGridView1.Rows[e.RowIndex].Cells["id_Column"].Value;
                            check_page.updateData(str_colName, str_Where);
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
            string str_colName = "distinct check_point_name ";
            string str_Where = "1=1";
            if (check_sysname_comboBox.SelectedIndex != 0)
            {
                str_Where = str_Where + "  and (sysname ='" + check_sysname_comboBox.Text.Trim() + "' or sysname ='all_system')";
            }
            if (check_name_textBox.Text != "")
            {
                str_Where = str_Where + "  and check_point_name like'%" + check_name_textBox.Text.Trim() + "%'";
            }
            DataSet ds = check_point.SelectData(str_colName, str_Where);
            DataTable dt = ds.Tables[0];
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
                    string str_Where2 = "check_point_name ='" + List[0].ToString() + "'";
                    string str_colName2 = "distinct  sysname";
                    DataSet ds2 = check_point.SelectData(str_colName2, str_Where2);
                    DataTable dt_s = ds2.Tables[0];
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
                string str_Where = "1=1 ";
                if (check_sysname_comboBox.SelectedIndex != 0)
                {
                    str_Where = str_Where + " and (sysname='" + check_sysname_comboBox.Text + "' or sysname ='all_system')";
                }
                if (check_name_textBox.Text != "")
                {
                    str_Where = str_Where + " and check_point_name like '%" + check_name_textBox.Text.Trim() + "%' ";
                }
                string str_order=" check_point_name,sysname  ";
                DataSet ds = check_point.SelectData("*", str_Where, str_order);
                DataTable dt_check = ds.Tables[0];
                if (dt_check.Rows.Count > 0)
                {
                    int a = 0;
                    ISheet sheet1 = hssfworkbook.CreateSheet("检查点步骤");
                    for (int check_id = 0; check_id < dt_check.Rows.Count; check_id++)
                    {
                        string str_Where2=@"( sysname='" + dt_check.Rows[check_id]["sysname"].ToString() + "' or sysname='all_system') "
                                    + " and check_point_name ='" + dt_check.Rows[check_id]["check_point_name"].ToString() + "'";
                        string str_order2=" check_point_name,check_orde, sysname ";
                        DataSet ds2 = check_page.SelectData("*", str_Where2, str_order2);
                        DataTable dt2 = ds2.Tables[0];

                        DataSet ds3 = check_point.SelectData("*", str_Where2);
                        DataTable dt_check_col = ds3.Tables[0];
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
                            DataSet ds4 = tc.SelectData("sysname","1=1");
                            DataTable dt = ds4.Tables[0];
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
                            
                            string str_Where = "check_point_name='" + str_check_name + "' ";
                            check_page.deleteData(str_Where);
                            ///清除check_point col0至coln的记录。因为表的列数可能会变化，所以删除表的记录，再插入
                            DataSet ds = check_point.SelectData("sysname", str_Where);
                            DataTable dt_sys = ds.Tables[0];
                            if (str_check_name != "")
                            {
                                check_point.deleteData(str_Where);
                                string str_col1 = "check_point_name,sysname,col0";
                                if (str_sys == "all_system")
                                {
                                    for (int j = 1; j < dt.Rows.Count; j++)
                                    {
                                        if (str_check_name == dt.Rows[j][2].ToString() && dt.Rows[j][5].ToString() != "all_system")
                                        {
                                            str_sys = dt.Rows[j][5].ToString();
                                            string str_col2="'" + str_check_name + "', '" + str_sys + "','" + dt.Rows[0][6].ToString() + "'";
                                            check_point.insertData(str_col1, str_col2);
                                        }
                                    }
                                    if (str_sys == "all_system")
                                    {
                                        MessageBox.Show(str_check_name + "全部都是all_system,不能导入！");
                                    }
                                }
                                else
                                {
                                    string str_col2 = "'" + str_check_name + "', '" + str_sys + "','" + dt.Rows[0][6].ToString() + "'";
                                    check_point.insertData(str_col1, str_col2);
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
                                    string str_colName2 = " col" + col_i + "='" + dt.Rows[i][6].ToString();
                                    string str_Where2 = "check_point_name='" + dt.Rows[i][2].ToString() + "' and  sysname='" + str_sys + "' ";
                                    check_point.updateData(str_colName2,str_Where2);   
                                    col_i = col_i + 1;
                                }
                                else
                                {
                                    col_i = 1;
                                    str_sys = dt.Rows[i][5].ToString();
                                    str_check_name = dt.Rows[i][2].ToString();
                                    string str_Where3 = "check_point_name='" + str_check_name + "' ";
                                    check_page.deleteData(str_Where3);

                                    DataSet ds2 = check_point.SelectData("sysname", str_Where3);
                                    DataTable dt_sys2 = ds2.Tables[0];
                                    if (str_check_name != "")
                                    {
                                        if (str_sys == "all_system")
                                        {
                                            for (int j = i; j < dt.Rows.Count; j++)
                                            {
                                                if (str_check_name == dt.Rows[j][2].ToString() && dt.Rows[j][5].ToString() != "all_system")
                                                {
                                                    str_sys = dt.Rows[j][5].ToString();
                                                    check_point.deleteData(str_Where3);
                                                    string str_col1 = "check_point_name,sysname,col0";
                                                    string str_col2 = "'" + str_check_name + "', '" + str_sys + "','" + dt.Rows[i][6].ToString() + "' ";
                                                    check_point.insertData(str_col1, str_col2);
                                                }
                                            }
                                            if (str_sys == "all_system")
                                            {
                                                MessageBox.Show(str_check_name + "全部都是all_system,不能导入！");
                                            }
                                        }
                                        else
                                        {
                                            check_point.deleteData(str_Where3);
                                            string str_col1="check_point_name,sysname,col0";
                                            string str_col2="'" + str_check_name + "', '" + str_sys + "','" + dt.Rows[i][6].ToString() + "'";
                                            check_point.insertData(str_col1, str_col2);
                                        }
                                    }
                                }
                            }

                            //插入check_page记录
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string[] list = new string[5];
                                string str_col1 = "check_order ,check_point_name ,page_name,element_name,sysname";
                                string str_col2 = "";
                                int k2 = 0;
                                for (int k = 1; k < dt.Columns.Count - 2; k++)
                                {
                                    str_col2 = str_col2 + "\"" + dt.Rows[i][k].ToString().Trim() + "\",";
                                    list[k] = dt.Rows[i][k].ToString().Trim();
                                    if (dt.Rows[i][k].ToString().Trim() == "")
                                    {
                                        k2 = k2 + 1;
                                    }
                                }
                                if (k2 != dt.Columns.Count - 3)
                                {
                                    str_col2 = str_col2 + "\"" + dt.Rows[i][dt.Columns.Count - 2].ToString().Trim() + "\" ";
                                    string str_Where2 = @"check_order='" + list[0] + "' "
                                                   + "and check_point_name='" + list[1] + "' "
                                                   + "and page_name='" + list[2] + "' "
                                                   + "and element_name='" + list[3] + "' "
                                                   + "and sysname='" + list[4] + "' ";
                                    DataSet ds2 = check_page.SelectData("count(0)", str_Where2);
                                    DataTable dt2 = ds2.Tables[0];
                                    if (int.Parse(dt2.Rows[0][0].ToString()) == 0)
                                    {
                                        check_page.insertData(str_col1, str_col2);
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
                string str_Where = "id=" + dataGridView1.Rows[i].Cells["id_Column"].Value;
                if (d_Result == "Yes")
                {
                    check_point_temp.deleteData("1=1");
                    string str_colName2 = "distinct check_point_name";
                    string str_Where2 = " check_point_name = '" + dataGridView1.Rows[i].Cells["check_point_name_Column"].Value.ToString().Trim() + "' ";
                    DataSet ds = check_point.SelectData(str_colName2, str_Where2);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("查询出来有多个功能点，不能移动check_point表数据，请确定唯一值！");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        string str = dataGridView1.Rows[i].Cells["element_name_Column"].Value.ToString();
                        string str_table = "select * from check_point where check_point_name like '%" + dt.Rows[0][0].ToString() + "%'";
                        check_point_temp.insertData(str_table);
                        string str_Where3 = " check_point_name = '" + dt.Rows[0][0].ToString() + "';";
                        check_point.deleteData(str_Where3);
                        string str_Where4 = @" ( page_name,sysname) in (select page_name,sysname from page_properties ) "
                                                                + " and  check_point_name = '" + dataGridView1.Rows[i].Cells["check_point_name_Column"].Value.ToString().Trim() + "' ";
                        string str_order4 = " check_order, sysname ,check_point_name ";
                        DataSet ds4 = check_page.SelectData("element_name", str_Where4, str_order4);
                        DataTable dt2 = ds4.Tables[0];
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
                        string str_col1 = "id,check_point_name,sysname ";
                        string str_table2 =  "select id,check_point_name,sysname ";
                        for (int j = 0; j < dt2.Rows.Count - 1; j++)
                        {
                            str_col1 = str_col1 + ",col" + j.ToString();
                            if (j < index)
                            {
                                str_table2 = str_table2 + ",col" + j.ToString();
                            }
                            else
                            {
                                str_table2 = str_table2 + ",col" + (j + 1).ToString();
                            }
                        }
                        str_table2 = str_table2 + "  from check_point_temp ";
                        check_point.insertData2(str_col1, str_table2);        
                    }
                    check_page.deleteData(str_Where);
                }
                else if (d_Result == "No")
                {
                    check_page.deleteData(str_Where);
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
