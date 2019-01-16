#coding:utf-8
import time
from operateExcel import OperateExcel
from project.SZHJX import *
from common import Common
import sys

class RunTest():
    def __init__(self):
        self.common = Common()
        self.excel_mould_file = self.common.excel_mould_path
        self.all_results = []

    def write_a_result(self, sheet):
        read_excel = OperateExcel(self.excel_mould_file, sheet)
        datas = read_excel.read_excel()
        print datas
        base_info = read_excel.get_base_info()
        self.common.goto_testing_page(base_info[0], base_info[1], base_info[2], base_info[3], base_info[4])
        results = []
        for data in datas:
            err_msg_locator = err_msg_locator_method%data[3]
            print data[4]
            #time.sleep(1)
            result1 = self.common.input_box_verification(get_locator_method(sheet), data[3], data[4], err_msg_locator, data[5])
            result = [data[0], data[2], result1]
            results.append(result)
        self.all_results.append(results)
        self.excel_mould_file = read_excel.write_results(self.common.report_file, results)
        self.common.zaf.close_all_browsers()

    def run_test(self):
        reload(sys)
        sys.setdefaultencoding('utf-8')
        for excel_sheet in excel_sheets:
            print self.excel_mould_file
            self.write_a_result(excel_sheet)
        read_excel = OperateExcel(self.excel_mould_file, 0)
        read_excel.write_sheets_style(self.all_results, self.excel_mould_file, excel_sheet_names)
