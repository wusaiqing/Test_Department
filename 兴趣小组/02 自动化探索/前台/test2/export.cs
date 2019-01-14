using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using System.IO;
using NPOI.POIFS.FileSystem;
using NPOI.SS;
using NPOI.SS.UserModel;
using NPOI.Util.Collections;
using NPOI.SS.Util;



namespace test2
{
    public partial class export : Form
    {
        DAL.TotalConfig tc = new DAL.TotalConfig();
        DAL.Config config = new DAL.Config();
        DAL.test_page test_page = new DAL.test_page();
        DAL.test_case test_case = new DAL.test_case();
        public export()
        {
            InitializeComponent();
            DataSet ds = tc.SelectData("sysname", "1=1");
            DataTable dt = ds.Tables[0];
            DataTable newdt = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                sysname_b_listBox.Items.Add(dr["sysname"].ToString());
            }
        }
        public void load()
        {
            function_b_listBox.Items.Clear();
            string str_Where = "1=2";
            for (int i = 0; i < sysname_y_listBox.Items.Count; i++)
            {
                str_Where = str_Where + " or sysname='" + sysname_y_listBox.Items[i].ToString().Trim() + "'";
            }
            DataSet ds = config.SelectData("function_name", str_Where);
            DataTable dt_f = ds.Tables[0];
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

        private void export_test_button_Click(object sender, EventArgs e)
        {
            if (function_y_listBox.Items.Count > 0)
            {
                SaveFileDialog dig = new SaveFileDialog();
                dig.DefaultExt = "xls";
                dig.Filter = "Excel文件|*.xls";
                if (dig.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook();
                    FileStream file = new FileStream(dig.FileName, FileMode.Create);

                    ISheet sheet2 = hssfworkbook.CreateSheet("function_name");
                    DataSet ds = config.SelectData("function_name", "1=1");
                    DataTable dt_function = ds.Tables[0];
                    for (int L = 0; L < dt_function.Rows.Count; L++)
                    {
                        HSSFRow row2 = sheet2.CreateRow(L) as HSSFRow;
                        row2.CreateCell(0).SetCellValue(dt_function.Rows[L]["function_name"].ToString());
                    }
                    IName range = hssfworkbook.CreateName();
                    range.RefersToFormula = "function_name!$A:$A";
                    range.NameName = "dicRange";

                    for (int i = 0; i < sysname_y_listBox.Items.Count; i++)
                    {
                        for (int j = 0; j < function_y_listBox.Items.Count; j++)
                        {
                            string str_Where=" (sysname ='" + sysname_y_listBox.Items[i].ToString().Trim() + "'  "
                                                + " or sysname ='all_system')"
                                                + " and function_name ='" + function_y_listBox.Items[j].ToString().Trim() + "'";
                            DataSet ds2 = test_page.SelectData("element_name", str_Where, "test_order");
                            DataTable dt2 = ds2.Tables[0];
                            if (dt2.Rows.Count > 0)
                            {
                                string sheet_name = sysname_y_listBox.Items[i].ToString().Trim() + "-" + function_y_listBox.Items[j].ToString().Trim();
                                ISheet sheet1 = hssfworkbook.CreateSheet(sheet_name);
                                HSSFCellStyle dateStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
                                HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
                                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                                IRow row1 = sheet1.CreateRow(0);
                                row1.CreateCell(0).SetCellValue("序号");
                                row1.CreateCell(1).SetCellValue("用例名称");
                                row1.CreateCell(2).SetCellValue("功能点名称");
                                row1.CreateCell(3).SetCellValue("运行结果");
                                row1.CreateCell(4).SetCellValue("对比方式");
                                row1.CreateCell(5).SetCellValue("期望输出结果方式");
                                row1.CreateCell(6).SetCellValue("期望结果");
                                row1.CreateCell(7).SetCellValue("结果");
                                row1.CreateCell(8).SetCellValue("运行提示");
                                row1.CreateCell(9).SetCellValue("被测系统名");
                                for (int w_i = 0; w_i < 10; w_i++)
                                {
                                    sheet1.SetColumnWidth(w_i, 13 * 256);
                                }
                                if (dt2 != null)
                                {
                                    string str_colName3 = "id,test_id,function_name,run_result,compare_way,hope_way,hope_result,result,comments,sysname ";
                                    for (int k = 0; k < dt2.Rows.Count; k++)
                                    {
                                        row1.CreateCell(10 + k).SetCellValue(dt2.Rows[k][0].ToString());
                                        str_colName3 = str_colName3 + ", col" + k.ToString();
                                        sheet1.SetColumnWidth(10 + k, 13 * 256);
                                    }
                                    string str_Where3 ="sysname ='" + sysname_y_listBox.Items[i].ToString().Trim() + "' "
                                              + " and function_name ='" + function_y_listBox.Items[j].ToString().Trim() + "';";
                                    DataSet ds3 = test_case.SelectData(str_colName3, str_Where3);
                                    DataTable dt = ds3.Tables[0];
                                    if (dt != null)
                                    {

                                        for (int k = 0; k < dt.Rows.Count; k++)
                                        {
                                            HSSFRow dataRow = sheet1.CreateRow(k + 1) as HSSFRow;
                                            foreach (DataColumn column in dt.Columns)
                                            {
                                                HSSFCell newCell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
                                                string drValue = dt.Rows[k][column.Ordinal].ToString();
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
                                }

                                CellRangeAddressList company = new CellRangeAddressList(1, 65535, 4, 4);
                                DVConstraint company2 = DVConstraint.CreateExplicitListConstraint(new string
                                [] { "等于", "不等于", "运行包含期望", "运行被包含期望", "运行>期望", "运行>=期望", "运行<期望", "运行<=期望" });
                                HSSFDataValidation dataValidate = new HSSFDataValidation(company, company2);
                                sheet1.AddValidationData(dataValidate);
                                CellRangeAddressList hope_way = new CellRangeAddressList(1, 65535, 5, 5);
                                DVConstraint hope_way2 = DVConstraint.CreateExplicitListConstraint(new string
                                [] { "手工", "数据库" });
                                HSSFDataValidation dataValidate2 = new HSSFDataValidation(hope_way, hope_way2);
                                sheet1.AddValidationData(dataValidate2);

                                CellRangeAddressList function_name = new CellRangeAddressList(1, 65535, 2, 2);
                                DVConstraint constraint = DVConstraint.CreateFormulaListConstraint("dicRange");
                                HSSFDataValidation function_name3 = new HSSFDataValidation(function_name, constraint);
                                sheet1.AddValidationData(function_name3);

                                DataSet ds4 = tc.SelectData("sysname","1=1");
                                DataTable dt3 = ds4.Tables[0];
                                string[] str = new string[dt3.Rows.Count];
                                for (int L = 0; L < dt3.Rows.Count; L++)
                                {
                                    str[L] = dt3.Rows[L]["sysname"].ToString();
                                }
                                CellRangeAddressList sysname = new CellRangeAddressList(1, 65535, 9, 9);
                                DVConstraint sysname2 = DVConstraint.CreateExplicitListConstraint(str);
                                HSSFDataValidation sysname3 = new HSSFDataValidation(sysname, sysname2);
                                sheet1.AddValidationData(sysname3);
                            }
                        }
                    }
                    //hssfworkbook.SetSheetHidden(0, true);
                    hssfworkbook.Write(file);
                    file.Close();
                }
            }
            else
            {
                if (sysname_y_listBox.Items.Count > 0)
                {
                    MessageBox.Show("请选择需要导出的功能点");
                }
                else
                {
                    MessageBox.Show("请先选择被测系统名称，再选择需要导出的功能点");
                }
            }
        }
    }
}

