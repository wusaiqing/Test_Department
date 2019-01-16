from conf.conf import SRC_DATA
from lib.tools import data_to_dict
import xlrd
def get_case(filename):
    work_book=xlrd.open_workbook(filename)
    sheet=work_book.sheet_by_index(0)
    lis = []
    for i in range(1,sheet.nrows):
        dic={}
        project=sheet.cell(i,0).value
        id=sheet.cell(i,2).value
        detail=sheet.cell(i,3).value
        url=sheet.cell(i,4).value
        method=sheet.cell(i,5).value
        data_type=sheet.cell(i,6).value
        data=sheet.cell(i,7).value
        hope=sheet.cell(i,9).value
        tester=sheet.cell(i,13).value
        dic['id']=id
        dic['url']=url
        dic['method']=method
        dic['data_type']=data_type
        dic['data']=data_to_dict(data)
        dic['hope']=hope
        dic['project']=project
        dic['detail']=detail
        dic['tester']=tester
        dic['request']=url+'?'+data
        lis.append(dic)
    return lis

if __name__=='__main__':
    import requests
    res=get_case(SRC_DATA)
    for i in res:
        print(i)
    url='http://10.1.130.102:1990/login'
    data={'password': '123456', 'username': 'admin'}
    res=requests.get(url,data)
    print(res.text)