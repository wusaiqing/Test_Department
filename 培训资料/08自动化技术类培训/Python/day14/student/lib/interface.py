from lib.get_cases import get_case
from conf.conf import RES_DATA
from lib.tools import check_res
from lib.report import HtmlReport
from lib.sendmail import send_mail
from lib.tools import data_to_dict,write_excel
import requests,time
def send_req(case_lis):
    start_time = time.time()
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
        case['status']=check_res(hope,res.json())
    end_time = time.time()
    run_time=end_time-start_time
    return case_lis,run_time

def write_report(case_path,case_lis,run_time):
    write_excel(case_path, RES_DATA, case_lis)
    html_lis=[]
    for i in case_lis:
        html_dic={}
        html_dic['project']=i['project']
        html_dic['case_id']=i['id']
        html_dic['detail']=i['detail']
        html_dic['data']=i['data']
        html_dic['url']=i['url']
        html_dic['tester']=i['tester']
        html_dic['request']=i['request']
        html_dic['response']=i['res']
        html_dic['status']=i['status']
        html_lis.append(html_dic)
    all={}
    all['all']=len(html_lis)
    count=0
    for i in html_lis:
        if i['status'].lower()=='pass':
            count+=1
    all['ok']=count
    all['fail']=len(html_lis)-count
    all['run_time']=run_time
    all['case_res'] = html_lis
    all['date']=time.strftime('%Y/%m/%d %H:%M:%S')
    report = HtmlReport(all)
    html_name = report.report()
    title = time.strftime('%Y%m%d%H%M%S') + '接口测试报告'
    content = '本次运行%s条用例，通过%s条，失败%s条。' % (all['all'], count, all['fail'])
    send_mail(username='xiaogang.yang@gtafe.com',passwd='3280789@XG',recv=['xiaogang.yang@gtafe.com','yanyan.liu1@gtafe.com'],
        title=title,content=content,file=html_name)



if __name__=='__main__':
    write_report()