import os, sys
path = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
sys.path.insert(0, path)
from conf.settings import STUTB
from lib.get_cases import Opreate_excel
from lib.interface import req_test
from lib.init_data import truncate_tb
class run(object):
    def __init__(self,path,STUTB,req_test,truncate_tb):
        self.path=path
        self.STUTB=STUTB
        # self.op_excel=Opreate_excel
        self.req_test=req_test
        self.truncate_tb=truncate_tb
        self.del_data()
        self.get_path()
    def del_data(self):
        truncate_tb(self.STUTB)#学生表的清空数据库
    def get_path(self):
        self.CASE_PATH=os.path.join(self.path,'data')
        self.REPORT_PATH=os.path.join(self.path,'logs')
    def run_interface(self):
        for file in os.listdir(self.CASE_PATH):
            if file.endswith('.xls') or file.endswith('.xlsx'):
                files=os.path.join(self.CASE_PATH,file)
                read_excel = Opreate_excel(files)
                case_lis = read_excel.op_excel()#读取excel获取用例的list
                req_test(case_lis,self.REPORT_PATH,files)#根据用例list，发送请求，比较实际与预期结果，将测试执行结果写进一个新的excel

runnow=run(path,STUTB,req_test,truncate_tb)
runnow.run_interface()