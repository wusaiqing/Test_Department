import os
import requests
import time
from core.report import HtmlReport
from core.tools import w
from xlrd import open_workbook  # 导入xlrd模块中打开excel模块
from xlutils.copy import copy  # 导入xlutils模块的复制excel模块
from conf.setting import DATA_PATH,MAIL_PASSWD,MAIL_USER,TO_MAIL
from core.sendmail import SendMail
from core.get_case import getCase

class InterfaceTest(object):
    def __init__(self,case_list,file_name):
        self.case_list = case_list
        self.file_name = file_name
    def api_request(self,url,method,req_data):
        try:
            req = url
            if method.upper()=='POST':
                re=requests.post(req,req_data)
                res = re.text
            else:
                res = requests.get(req).text
        except Exception as e:
            w.write_log('访问接口报错'+str(e))
            print(str(e))
            return e
        return req,res
    def check_res(self,case_id,check_data,res):
        new_res = res.replace(' ','').replace('"','').replace(':','=')
        print(new_res)
        for check in check_data.split(';'):
            print(check_data)
            print(check)
            if check in new_res:
                pass
            else:
                w.write_log('case 【%s】测试不通过，预期结果是 【%s】 实际结果是【%s】'%(case_id,check,res))
                return '失败'
        return '通过'
    def write_res(self,res_list):
        # [
        #     ['http://xxx','{"cde":200}','通过']，
        #     ['http://xxx','{"cde":200}','失败']，
        # ]
        book = open_workbook(self.file_name)
        print('文件名',self.file_name)
        # 通过sheet_by_index()获取的sheet
        # 复制一个excel
        new_book = copy(book)
        # 通过获取到新的excel里面的sheet页
        sheet = new_book.get_sheet(0)
        count = 1#这个count是控制excel每一行的
        for line in res_list:
            sheet.write(count, 8, line[0])  # 写入excel，第一个值是行，第二个值是列
            sheet.write(count, 9, line[1])  # 写入excel，第一个值是行，第二个值是列
            sheet.write(count, 10, line[2])  # 写入excel，第一个值是行，第二个值是列
            count+=1
        new_filename = time.strftime('%Y%m%d%H%M%S')+'test_case.xls'
        new_book.save(os.path.join(DATA_PATH,new_filename))  # 保存新的excel，保存excel必须使用后缀名是.xls的，不是能是.xlsx的
    def run(self):
        #就是把刚才那些都串起来
        req_res_list = []#存放所有请求报文和返回报文
        res_list = [] #写结果用的list
        start_time = time.time()#开始时间
        for case in self.case_list:
            res={}#存的是每个用例运行的结果，这个是生成html报告用的
            case_res = []#用例执行结果,写excel用的
            url = case['url']
            method = case['method']
            req_data = case['req_data']
            case_id = case['id']
            check_data = case['check_data']
            res['project']=case['project']
            res['case_id']=case['id']
            res['detail']=case['desc']
            res['data']=case['req_data']
            res['url']=case['url']
            res['tester']=case['tester']
            req,response = self.api_request(url,method,req_data)
            res['request']=req
            res['response']=response
            status = self.check_res(case_id,check_data,response)
            res['status'] =status
            req_res_list.append(res)
            case_res.append(req)
            case_res.append(response)
            case_res.append(status)
            res_list.append(case_res)
        end_time = time.time()#结束时间
        self.write_res(res_list)
        all = {}
        total = len(req_res_list)
        all['all']=total#用例总数
        pass_count = 0 #通过的次数
        for r in req_res_list:
            if r['status']=='通过':
                pass_count+=1
        all['ok'] = pass_count#通过的次数
        all['fail'] = total-pass_count#失败的次数
        all['run_time'] = end_time-start_time
        all['case_res']=req_res_list
        report = HtmlReport(all)#实例化产生html类的对象
        html_name = report.report()#调用生成html的方法，它会返回html的名字
        title = time.strftime('%Y%m%d%H%M%S')+'接口测试报告'
        content = '本次运行%s条用例，通过%s条，失败%s条。'%\
                  (total,pass_count,total-pass_count)
        self.send(title,content,html_name)

    def send(self,title,content,file):
        m = SendMail(MAIL_USER,MAIL_PASSWD,TO_MAIL,title,content,file)
        print(file)
        m.send_mail()

if __name__=='__main__':
    case_list = getCase('../cases/国泰安智慧校园基地易管理平台软件V1.10R4_接口测试用例.xlsx')
    test=InterfaceTest(case_list,'../cases/国泰安智慧校园基地易管理平台软件V1.10R4_接口测试用例.xlsx')
    print(case_list)
    res_list=[]
    req_res_list = []
    start_time = time.time()  # 开始时间
    for i in range(len(case_list)):
        res = {}
        case_res=[]
        url=case_list[i]['url']
        method=case_list[i]['method']
        req_data=case_list[i]['req_data']
        case_id=case_list[i]['id']
        res['project'] = case_list[i]['project']
        res['case_id'] = case_list[i]['id']
        res['model'] = case_list[i]['model']
        res['detail'] = case_list[i]['desc']
        res['url'] = case_list[i]['url']
        res['tester'] = case_list[i]['tester']
        check_data=case_list[i]['check_data']
        req,response=test.api_request(url,method,req_data)
        res['request'] = req
        res['response'] = response
        print(req,res)
        status=test.check_res(case_id,check_data,response)
        res['status'] = status
        req_res_list.append(res)
        case_res.append(req)
        case_res.append(response)
        case_res.append(status)
        res_list.append(case_res)
    test.write_res(res_list)
    end_time = time.time()  # 结束时间
    all = {}
    total = len(req_res_list)
    all['all'] = total  # 用例总数
    pass_count = 0  # 通过的次数
    for r in req_res_list:
        if r['status'] == '通过':
            pass_count += 1
    all['ok'] = pass_count  # 通过的次数
    all['fail'] = total - pass_count  # 失败的次数
    all['run_time'] = end_time - start_time
    all['case_res'] = req_res_list
    report = HtmlReport(all)  # 实例化产生html类的对象
    html_name = report.report()  # 调用生成html的方法，它会返回html的名字
    title = time.strftime('%Y%m%d%H%M%S') + '接口测试报告'
    content = '本次运行%s条用例，通过%s条，失败%s条。' % \
              (total, pass_count, total - pass_count)
    test.send(title, content, html_name)









