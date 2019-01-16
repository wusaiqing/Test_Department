#单线程
import os,sys
BASE_PATH = os.path.dirname(os.path.dirname(
    os.path.abspath(__file__)))
sys.path.insert(0,BASE_PATH)
from core.get_case import getCase
from core.interface_test import InterfaceTest
from conf.setting import CASE_PATH

for file in os.listdir(os.path.join(BASE_PATH,'cases')):
    if (file.endswith('.xls') or file.endswith('.xlsx')):
        file = os.path.join(CASE_PATH,file)
        case_list= getCase(file)
        intface = InterfaceTest(case_list,file)
        intface.run()
    else:
        print('没有可以运行的测试用例！')
