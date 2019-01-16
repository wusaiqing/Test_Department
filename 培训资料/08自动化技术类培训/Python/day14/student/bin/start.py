import os,sys
from lib.interface import write_report,send_req
from lib.get_cases import get_case
from conf.conf import SRC_DATA,RES_DATA
abs_path=os.path.abspath(__file__)
par_path=os.path.dirname(abs_path)
par_path=os.path.dirname(par_path)
sys.path.insert(0,par_path)
files=os.listdir(SRC_DATA)
for i in files:
    if i.endswith('.xlsx') or i.endswith('.xls'):
        case_path=os.path.join(SRC_DATA,i)
        case_list=get_case(case_path)
        res,run_time=send_req(case_list)
        write_report(case_path, case_list, run_time)



