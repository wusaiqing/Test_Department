from lib.get_cases import get_case
from conf.conf import SRC_DATA
from lib.tools import check_res
from lib.tools import data_to_dict
import requests
def send_req():
    case_lis=get_case(SRC_DATA)
    for case in case_lis:
        url = case['url']
        method = case['method']
        data_type = case['data_type']
        data = case['data']
        hope = case['hope']
        if method.lower()=='get':
            res = requests.get(url, data)
            if res.json().get('sign'):
                sign = res.json().get('sign')
        else:
            if data_type.lower()=='json':
                if data.get('sign')=='sign':
                    data['sign']=sign
                res=requests.post(url,json=data)
            else:
                if data.get('sign')=='sign':
                    data['sign']=sign
                res = requests.post(url, data)
        case['res']=res.text
        hope=data_to_dict(hope,fh=';')
        case['result']=check_res(hope,res.json())
    return case_lis
if __name__=='__main__':
    res=send_req()
    for i in res :
        print(i)