import os, sys
path = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
sys.path.insert(0, path)
from conf.settings import *
from lib.get_cases import op_excel
from lib.interface import req_test
from lib.init_data import truncate_tb
truncate_tb(STUTB)#学生表的清空数据库
CASE_PATH=os.path.join(path,'data')
REPORT_PATH=os.path.join(path,'logs')
for file in os.listdir(CASE_PATH):
    if file.endswith('.xls') or file.endswith('.xlsx'):
        files=os.path.join(CASE_PATH,file)
        case_lis = op_excel(files)#读取excel获取用例的list
        req_test(case_lis,REPORT_PATH,files)#根据用例list，发送请求，比较实际与预期结果，将测试执行结果写进一个新的excel
