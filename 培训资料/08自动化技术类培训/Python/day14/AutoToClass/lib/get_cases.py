import xlrd, time, os
from xlutils.copy import copy
from lib.tools import str_dic
class Opreate_excel(object):
    def __init__(self,files,content='',REPORT_PATH=''):
        self.files=files
        self.content=content
        self.REPORT_PATH=REPORT_PATH
    def op_excel(self):#当不传content时，处理测试用例，得到一个用例list；当传了content时，将cotent写进excel的测试结果
        if self.content and self.REPORT_PATH:
            book = xlrd.open_workbook(self.files)
            new_book=copy(book)
            sheet=new_book.get_sheet(0)
            for i in range(len(self.content)):
                for j in range(len(self.content[i])):
                    sheet.write(i+1,10+j,self.content[i][j])
            r_file=os.path.split(self.files)[-1].replace('.xlsx','.xls')
            times=time.strftime('%Y%m%d%H%M%S')
            filename=times+r_file
            file=os.path.join(self.REPORT_PATH,filename)
            new_book.save(file)
        else:
            book = xlrd.open_workbook(self.files)
            sheet=book.sheet_by_index(0)
            case_lis=[]
            for i in range(1,sheet.nrows):
                case_dic={}
                old_data=sheet.row_values(i)[7].split('&')
                data=str_dic(old_data)
                old_expected = sheet.row_values(i)[9].split(';')
                expected = str_dic(old_expected)
                case_dic['模块']=sheet.row_values(i)[1]
                case_dic['请求url']=sheet.row_values(i)[4]
                case_dic['请求方式']=sheet.row_values(i)[5]
                case_dic['入参类型'] = sheet.row_values(i)[6]
                case_dic['原始请求数据']=sheet.row_values(i)[7]
                case_dic['请求数据']=data
                case_dic['预期结果']=expected
                case_lis.append(case_dic)
            return case_lis