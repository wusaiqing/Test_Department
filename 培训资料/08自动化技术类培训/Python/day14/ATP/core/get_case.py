import xlrd
from core.tools import w

def getCase(filename):
    case_list = []
    #存放所有的测试用例
    try:
        book = xlrd.open_workbook(filename)
    except Exception as e:
        w.write_log('文件不存在！'+str(e))
        return e
    else:
        sheet = book.sheet_by_index(0)
        try:
            for line in range(1,sheet.nrows):
                case = {}  # 每次循环都存新的用例
                project = sheet.cell(line,0).value#项目名称
                model = sheet.cell(line,1).value #模块名称
                id = sheet.cell(line,2).value #用例id
                desc = sheet.cell(line,3).value #用例描述
                url = sheet.cell(line,4).value #请求url
                method = sheet.cell(line,5).value #请求的方法
                req_data = eval(sheet.cell(line,6).value) #请求数据
                check_data = sheet.cell(line,7).value #预期结果
                tester = sheet.cell(line,11).value #测试人员
                case['model'] = model
                case['project'] = project
                case['id'] = id
                case['desc'] = desc
                case['url'] = url
                case['method'] = method
                case['req_data'] = req_data
                case['check_data'] = check_data
                case['tester'] = tester
                case_list.append(case)
        except Exception as e:
            w.write_log('excel格式不对'+str(e))
            return e
        else:
            return case_list
if __name__=='__main__':
    res = getCase('../cases/国泰安智慧校园基地易管理平台软件V1.10R4_接口测试用例.xlsx')
    print(res)
