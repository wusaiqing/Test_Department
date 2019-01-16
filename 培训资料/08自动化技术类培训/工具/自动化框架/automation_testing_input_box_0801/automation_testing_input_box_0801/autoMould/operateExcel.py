#coding:utf-8

import  xlrd, xlwt
from xlutils.copy import copy
from win32com.client import Dispatch

OK_COLOR = 0x00ff00
NG_COLOR = 0xff

class OperateExcel(object):
    def __init__(self, excel_mould_path, sheet_index):
        self.excel_mould_path = excel_mould_path
        self.sheet_index = sheet_index

    def read_excel(self):
        table, data = self.get_table()
        start_rows_cols = self.get_start_rows(table)
        datas = self.get_datas(table, start_rows_cols)
        return datas

    def get_base_info(self):
        table, data = self.get_table()
        base_info = []
        for i in range(0, 5):
            info_value = table.cell(1, i).value
            base_info.append(info_value)
        print base_info
        return base_info

    def write_results(self, record_file, record_list):
        sheet, wb, data = self.get_sheet()
        self.write_record(sheet, record_list)
        wb.save(record_file)
        data.unload_sheet(self.sheet_index)
        return record_file

    def write_sheets_style(self, all_results, report_path, sheets_list):
        xlApp = Dispatch('Excel.Application')
        book = xlApp.Workbooks.Open(report_path)
        i = 0
        for sheet in sheets_list[:-1]:
            sht = book.Worksheets(sheet)
            for result in all_results[i]:
                if result[2] == 'Fail':
                    color = NG_COLOR
                elif result[2] == 'Pass':
                    color = OK_COLOR
                sht.Cells(result[0]+1, result[1]+4).Interior.Color = color
            i = i+1
        book.Save()
        book.Close()
        del xlApp

    def get_sheet(self):
        table, data = self.get_table()
        wb = copy(data)
        sheet = wb.get_sheet(self.sheet_index)
        return sheet, wb, data

    def write_record(self, sheet, record_list):
        style1, style2 = self.excel_type(sheet)
        for record in record_list:
            if record[2] =='Pass':
                style = style1
            else:
                style = style2
            sheet.write(record[0], record[1]+3, record[2], style)

    def excel_type(self, sheet):
        sheet.col(0).width = 256*16
        sheet.col(1).width = 256*12
        sheet.col(2).width = 256*20
        sheet.col(3).width = 256*20
        sheet.col(4).width = 256*20
        partern1 = xlwt.Pattern()
        partern1.pattern=xlwt.Pattern.SOLID_PATTERN
        #绿色
        partern1.pattern_fore_colour = 3
        style1 = xlwt.XFStyle()
        style1.pattern = partern1
        partern2 = xlwt.Pattern()
        partern2.pattern = xlwt.Pattern.SOLID_PATTERN
        #红色
        partern2.pattern_fore_colour = 2
        style2 = xlwt.XFStyle()
        style2.pattern=partern2
        return style1, style2

    def get_table(self):
        data = xlrd.open_workbook(self.excel_mould_path)
        table = data.sheet_by_index(self.sheet_index)
        rows = table.nrows
        return table, data

    def get_start_rows(self, table):
        rows = table.nrows
        cols = table.ncols
        start_rows_cols = []
        j = 5
        flag = 0
        for j in range(0, (cols-5)/4):
            for i in range (3, rows):
                position = []
                controlor_value = table.cell(i, 5+4*j).value
                if controlor_value != '':
                    position.append(i)
                    position.append(5+4*j)
                    start_rows_cols.append(position)
                    flag = 1
                    continue
            if flag==0:
                break
        return start_rows_cols

    def get_datas(self, table, start_rows_cols):
        datas = []
        row_end_num = 0
        for i in start_rows_cols:
            if i[0] == 3:
                row_end_num = 30
            elif i[0] == 31:
                row_end_num = 54
            elif i[0] == 55:
                row_end_num = 70
            elif i[0] == 71:
                row_end_num = 82
            elif i[0] == 83:
                row_end_num = 94
            controlor_label = table.cell(i[0], i[1]).value
            value = table.cell(i[0], i[1]+1).value
            err_msg = table.cell(i[0], i[1]+2).value
            data = [i[0], row_end_num, i[1], controlor_label, value, err_msg]
            datas.append(data)
        return datas


