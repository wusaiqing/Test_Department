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
using MySql.Data;
using MySql.Data.MySqlClient;
using NPOI;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace test2
{
    public partial class step : Form
    {
        public step(int index, int index2,int index3)
        {
            InitializeComponent();
            
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "Select sysname from total_config").Tables[0];
            DataRow dr = dt.NewRow();
            dr["sysname"] = "请选择";
            dt.Rows.InsertAt(dr, 0);
            sysname_comboBox.DataSource = dt;
            sysname_comboBox.DisplayMember = "sysname";
            sysname_comboBox.SelectedIndex = index;
            function_name_comboBox.SelectedIndex = index3;
        }
        public void query()
        {
            string sql = sqlclass.test_page_sql();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
            if (sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and (sysname = '" + sysname_comboBox.Text + "' or sysname ='all_system')";
            }
            sql = sql + " and function_name ='" + function_name_comboBox.Text.Trim() + "'   order by test_order";
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
        }

        private void query_button_Click(object sender, EventArgs e)
        {
            query();
        }

        public void edit_test_step(int RowIndex, string function_name)
        {
            string sql_update = @"Update test_page  set test_order ='" + dataGridView1.Rows[RowIndex].Cells["test_order_Column"].Value + "'  " +
                                                             "  where id=" + dataGridView1.Rows[RowIndex].Cells["id_Column"].Value;
            string sql_del_temp = "delete from test_case_temp;";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_temp);



            string str = dataGridView1.Rows[RowIndex].Cells["element_name_Column"].Value.ToString();
            //删除test_case ，插入 test_case_temp
            string sql_insert_temp = @"insert  into test_case_temp  select * from test_case where  1=1 ";
            string sql_test_case_del = "delete from test_case where 1=1";
            if (sysname_comboBox.SelectedIndex != 0)
            {
                sql_insert_temp = sql_insert_temp + " and ( sysname = '" + sysname_comboBox.Text.Trim() + "' or sysname ='all_system') ";
                sql_test_case_del = sql_test_case_del + " and ( sysname = '" + sysname_comboBox.Text.Trim() + "' or sysname='all_system') ";
            }
            sql_insert_temp = sql_insert_temp + " and function_name = '" + function_name + "';";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_temp);
            sql_test_case_del = sql_test_case_del + " and function_name = '" + function_name + "';";
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_test_case_del);

            //查询出修改前和修改后的步骤
            string sql = @"select t.*  from test_page t
                                                            where ( t.page_name,t.sysname) in
                                                            (select page_name,sysname from page_properties ) ";

            if (sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and ( t.sysname = '" + sysname_comboBox.Text.Trim() + "' or  sysname='all_system') ";
            }
            sql = sql + " and t.function_name = '" + function_name + "'   order by t.test_order ";
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
                    sql_col_value_test_case_temp = @"select col" + i + " from test_case_temp where  function_name ='" + dt_back.Rows[i]["function_name"].ToString()
                       + "' and  sysname ='" + dt_back.Rows[i]["sysname"].ToString() + "' ";
                }
                else
                {
                    sql_col_value_test_case_temp = @"select col" + i + " from test_case_temp where  function_name ='" + dt_back.Rows[i]["function_name"].ToString() + "'";
                }
                DataTable dt_col_value_test = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_col_value_test_case_temp).Tables[0];
                string sql_insert_tcs_temp = @"insert into t_c_s_temp (id,col,col_value,yes_no) values(" + i + ", '" + dt_back.Rows[i]["element_name"].ToString() + "','" + dt_col_value_test.Rows[0][0].ToString() + "','no')";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_tcs_temp);
            }

            //把test_case_temp 插入进test_case 表中
            string sql_insert = "insert into   test_case ( id,test_id,function_name,run_result,compare_way,hope_way,hope_result,result,comments,sysname ";
            if (dt_back.Rows != null)
            {
                for (int col_i = 0; col_i < dt_back.Rows.Count; col_i++)
                {
                    sql_insert = sql_insert + ",col" + col_i.ToString();
                }
                sql_insert = sql_insert + ")    select id,test_id,function_name,run_result,compare_way,hope_way,hope_result,result,comments,sysname ";

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
                sql_insert = sql_insert + "  from test_case_temp ";
            }
            else
            {
                sql_insert = "insert into   test_case  select * from test_case_temp";
            }
            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert);

            //else
            //{
            //    string sql_update2 = @"Update test_page  set test_order ='" + dataGridView1.Rows[RowIndex].Cells["test_order_Column"].Value + "'  " +
            //                                                 "  where id=" + dataGridView1.Rows[RowIndex].Cells["id_Column"].Value;
            //    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update2);
            //}
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
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
                        string sql_update = @"Update test_page  set test_order ='" + dataGridView1.Rows[e.RowIndex].Cells["test_order_Column"].Value + "'  " +
                                                              "  where id=" + dataGridView1.Rows[e.RowIndex].Cells["id_Column"].Value;
                        DialogResult di;
                        di = MessageBox.Show("修改骤，是否修改对应测试数据", "确认修改页面", MessageBoxButtons.YesNoCancel);
                        if (di == DialogResult.Cancel)
                        {
                            return;
                        }
                        else if (di == DialogResult.No)
                        {
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                        }
                        else if (di==DialogResult.Yes)
                        {
                            edit_test_step(e.RowIndex,dataGridView1.Rows[e.RowIndex].Cells["function_name_Column"].Value.ToString());
                        }
                    }
                    else if (e.ColumnIndex == del_Column.Index)
                    {
                        DialogResult di;
                        di = MessageBox.Show("确认删除步骤，是否删除该列测试数据", "确认删除页面", MessageBoxButtons.YesNoCancel);
                        if (di == DialogResult.Yes)
                        {
                            del_test(e.RowIndex, "Yes");
                        }
                        else if (di == DialogResult.No)
                        {
                            del_test(e.RowIndex, "No");
                        }
                        else
                        {
                            del_test(e.RowIndex, "Cancel");
                        }
                        query();
                    }
                }
                catch
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql_update = @"Update test_page  set test_order ='" + dataGridView1.Rows[i].Cells["test_order_Column"].Value + "'  " +
                                                             "  where id=" + dataGridView1.Rows[i].Cells["id_Column"].Value;
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_update);
                }
            }

            else if (di == DialogResult.Yes)
            {
                if (dtc != null)
                {
                    string sql_test_case_temp = "select distinct function_name from test_case where function_name = '"+ function_name_comboBox.Text.Trim() + "'  ";
                    if (sysname_comboBox.SelectedIndex != 0)
                    {
                        sql_test_case_temp = sql_test_case_temp + " and ( sysname = '" + sysname_comboBox.Text.Trim() + "' or sysname='all_system' ) ";
                    }
                    DataTable dt_step = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_test_case_temp).Tables[0];
                    if (dt_step.Rows.Count > 1)
                    {
                        MessageBox.Show("查询出来有多个步骤组，不能移动test_case表数据，请确定唯一值！");
                    }
                    else
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            edit_test_step(i, dt_step.Rows[0][0].ToString());
                        }
                    }
                }
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            ArrayList List = new ArrayList();
            string sql = @"select distinct function_name from config where 1=1 ";
            if (sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and sysname = '" + sysname_comboBox.Text.Trim() + "'  ";
            }
            sql = sql + "  and function_name ='" + function_name_comboBox.Text.Trim() + "'  ";
            DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql).Tables[0];

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    List.Add(dr["function_name"]);
                }
            }

            if (List.Count > 1)
            {
                MessageBox.Show("被测系统:" + sysname_comboBox.Text.Trim() + "功能点名称:" + function_name_comboBox.Text.Trim() + "存在多值,不能添加多个功能点的测试步骤");
            }
            else if (List.Count == 1)
            {
                add_step f = new add_step();
                string str = "";
                if (sysname_comboBox.SelectedIndex != 0)
                {
                    str = str + sysname_comboBox.Text.Trim();
                }
                f.query(str, List[0].ToString());
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("被测系统:" + sysname_comboBox.Text.Trim() + "功能点名称:" + function_name_comboBox.Text.Trim() + "的值不存在,不能添加测试步骤");
            }
        }

        private void step_Load(object sender, EventArgs e)
        {
            query();
        }

        private void select_all_button_Click(object sender, EventArgs e)
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

        private void select_c_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].Cells["select_Column"].Value = false;
                //this._selectAll = false;
            }
        }

        private void select_Inverse_button_Click(object sender, EventArgs e)
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
        public void del_test(int i,string d_Result)
        {
            if (dataGridView1.Rows[i].Cells["id_Column"].Value.ToString() != "")
            {
                string sql_del = @"delete from  test_page 
                                    where id=" + dataGridView1.Rows[i].Cells["id_Column"].Value;
                if (d_Result == "Yes")
                {
                    string sql_del_temp = "delete from test_case_temp;";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del_temp);
                    string sql_test_case_temp = "select distinct function_name from test_case where function_name ='"
                        + dataGridView1.Rows[i].Cells["function_name_Column"].Value.ToString() + "'  ";
                    DataTable dt = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql_test_case_temp).Tables[0];
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("查询出来有多个功能点，不能移动test_case表数据，请确定唯一值！");
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        string str = dataGridView1.Rows[i].Cells["element_name_Column"].Value.ToString();
                        string sql_insert_temp = @"insert  into test_case_temp  select * from test_case where function_name like '%" + dt.Rows[0][0].ToString() + "%';";
                        string sql_test_case_del = "delete from test_case where function_name like '%" + dt.Rows[0][0].ToString() + "%';";
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_insert_temp);
                        MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_test_case_del);
                        string sql = @"select t.element_name from test_page t
                                                            where ( t.page_name,t.sysname) in
                                                            (select page_name,sysname from page_properties ) "                                   
                                        + " and t.function_name ='" + dt.Rows[0][0].ToString() + "'  order by t.test_order ";
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
                        string sql_insert = "insert into   test_case ( id,test_id,function_name,run_result,compare_way,hope_way,hope_result,result,comments,sysname ";
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
                        test_case_temp_col = test_case_temp_col + "  from test_case_temp ";
                        sql_insert = sql_insert + test_case_col;
                        sql_insert = sql_insert + "select id,test_id,function_name,run_result,compare_way,hope_way,hope_result,result,comments,sysname ";
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
            di = MessageBox.Show("确认删除步骤，是否删除该列测试数据", "确认删除页面", MessageBoxButtons.YesNoCancel);
            for (int i = 0; i < this.dataGridView1.Rows.Count ; i++)
            {
                if (dataGridView1.Rows[i].Cells["select_Column"].Value == null)
                {
                    continue;
                }
                if ((bool)dataGridView1.Rows[i].Cells["select_Column"].Value == true)
                {
                    if (di == DialogResult.Yes)
                    {
                        del_test(i, "Yes");
                    }
                    else if (di == DialogResult.No)
                    {
                        del_test(i, "No");
                    }
                    else
                    {
                        del_test(i, "Cancel");
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
                string sql = @"select *  from test_page where  function_name ='" + function_name_comboBox.Text.Trim() + "' ";
                if (sysname_comboBox.SelectedIndex != 0)
                {
                    sql = sql + "and sysname = '" + sysname_comboBox.Text.Trim() + "' ";
                }
                DataTable dt2 = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql, null).Tables[0];
                if (dt2.Rows.Count > 0)
                {
                    ISheet sheet1 = hssfworkbook.CreateSheet("功能点步骤");
                    FileStream file = new FileStream(dig.FileName, FileMode.Create);
                    HSSFCellStyle dateStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                    HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
                    dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                    IRow row1 = sheet1.CreateRow(0);
                    row1.CreateCell(0).SetCellValue("序号");
                    row1.CreateCell(1).SetCellValue("执行顺序");
                    row1.CreateCell(2).SetCellValue("功能点名称");
                    row1.CreateCell(3).SetCellValue("页面名称");
                    row1.CreateCell(4).SetCellValue("元素名称");
                    row1.CreateCell(5).SetCellValue("被测系统名称");
                    for (int w_i = 0; w_i < 6; w_i++)
                    {
                        sheet1.SetColumnWidth(w_i, 28 * 256);
                    }
                    if (dt2 != null)
                    {
                        for (int k = 0; k < dt2.Rows.Count; k++)
                        {
                            HSSFRow dataRow = sheet1.CreateRow(k + 1) as HSSFRow;
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
                        }
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
                            ///按功能点，删除记录
                            string str_sys = dt.Rows[0][dt.Columns.Count - 1].ToString();
                            string str_function_name = dt.Rows[0][2].ToString();
                            string sql_del = @"delete from test_page where function_name='" + str_function_name + "' and sysname='" + str_sys + "';";
                            MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);
                            for (int i = 1; i < dt.Rows.Count; i++)
                            {
                                if (str_sys != dt.Rows[i][dt.Columns.Count - 1].ToString() || str_function_name != dt.Rows[i][2].ToString())
                                {
                                    str_sys = dt.Rows[i][dt.Columns.Count - 1].ToString();
                                    str_function_name = dt.Rows[i][2].ToString();
                                    sql_del = @"delete from test_page where function_name='" + str_function_name + "' and sysname='" + str_sys + "';";
                                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sql_del);
                                }
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string[] list = new string[5];
                                string sql_insert = @"insert into  test_page (test_order ,function_name ,page_name,element_name,sysname ) values (";
                                int k2 = 0;
                                for (int k = 1; k < dt.Columns.Count - 1; k++)
                                {
                                    sql_insert = sql_insert + "\"" + dt.Rows[i][k].ToString().Trim() + "\",";
                                    list[k] = dt.Rows[i][k].ToString().Trim();
                                    if (dt.Rows[i][k].ToString().Trim() == "")
                                    {
                                        k2 = k2 + 1;
                                    }
                                }
                                if (k2 != dt.Columns.Count - 1)
                                {
                                    sql_insert = sql_insert + "\"" + dt.Rows[i][dt.Columns.Count - 1].ToString().Trim() + "\");";
                                    //list[5] = dt.Rows[i][dt.Columns.Count - 1].ToString().Trim();
                                    string sql_q = @"select count(0) from test_page where  test_order='" + list[0] + "' "
                                                   + "and function_name='" + list[1] + "' "
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

        private void sysname_comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "select  distinct function_name  from config where 1=1 ";
            if (sysname_comboBox.SelectedIndex != 0)
            {
                sql = sql + " and sysname ='" + sysname_comboBox.Text.ToString() + "'";
            }
            DataTable dt_function = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sql).Tables[0];
            function_name_comboBox.Text = "";
            function_name_comboBox.DataSource = dt_function.Copy();
            function_name_comboBox.DisplayMember = "function_name";
        }
    }
}
