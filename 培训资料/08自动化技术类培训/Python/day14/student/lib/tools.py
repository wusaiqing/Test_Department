def data_to_dict(data,fh='&'):
    lis=data.split(fh)
    dic={}
    for i in lis:
        key=i.split('=')[0]
        value=i.split('=')[1]
        dic[key]=value
    return dic

def check_res(expected,res):
    for key in expected:
        if key not in res:
            return 'Fail'
        elif str(expected[key])!=str(res[key]):
            return 'Fail'
    return 'Pass'

def write_excel(filename,res_path,case_lis):
    import xlutils,xlrd,os,time
    from xlutils.copy import copy
    work_book=xlrd.open_workbook(filename)
    new_book=copy(work_book)
    sheet=new_book.get_sheet(0)
    for i in range(1,len(case_lis)+1):
        sheet.write(i,11,case_lis[i-1]['res'])
        sheet.write(i,12,case_lis[i-1]['status'])
    cur_time=time.strftime('%Y%m%d%H%M%S')
    name=cur_time+os.path.basename(filename)
    new_name=os.path.join(res_path,name).replace('xlsx','xls')
    new_name=new_name.split('.')[0]+'执行结果.'+new_name.split('.')[1]
    new_book.save(new_name)

if __name__=='__main__':
    content=[{'url': 'http://10.1.130.102:1990/login', 'data_type': '键值对', 'res': '{"code":200,"msg":"成功","sign":"d51516ef99d71c891751743db1b6cc74","userId":1}', 'data': {'username': 'admin', 'password': '123456'}, 'result': 'Pass', 'id': 'login_1', 'method': 'GET', 'hope': 'code=200;msg=成功'}, {'url': 'http://10.1.130.102:1990/login', 'data_type': '键值对', 'res': '{"code":303,"msg":"参数不能为空"}', 'data': {'password': '123456'}, 'result': 'Pass', 'id': 'login_2', 'method': 'GET', 'hope': 'code=303;msg=参数不能为空'}, {'url': 'http://10.1.130.102:1990/login', 'data_type': '键值对', 'res': '{"code":303,"msg":"参数不能为空"}', 'data': {'username': 'niuhanyang'}, 'result': 'Pass', 'id': 'login_3', 'method': 'GET', 'hope': 'code=303;msg=参数不能为空'}, {'url': 'http://10.1.130.102:1990/login', 'data_type': '键值对', 'res': '{"code":302,"msg":"用户名或密码错误!"}', 'data': {'username': 'yxg', 'password': '123456'}, 'result': 'Pass', 'id': 'login_4', 'method': 'GET', 'hope': 'code=302;msg=用户名或密码错误!'}, {'url': 'http://10.1.130.102:1990/login', 'data_type': '键值对', 'res': '{"code":302,"msg":"用户名或密码错误!"}', 'data': {'username': 'admin', 'password': '41687651684'}, 'result': 'Pass', 'id': 'login_5', 'method': 'GET', 'hope': 'code=302;msg=用户名或密码错误!'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":301,"msg":"手机号已存在"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'stu_name': 'yxg', 'sign': 'd51516ef99d71c891751743db1b6cc74', 'stu_type': '1', 'stu_phone': '13437737025', 'stu_class': '1班'}, 'result': 'Fail', 'id': 'add_stu1', 'method': 'POST', 'hope': 'code=200;msg=成功'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":301,"msg":"手机号已存在"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'stu_name': 'yxg', 'sign': 'd51516ef99d71c891751743db1b6cc74', 'stu_type': '1', 'stu_phone': '13537737007', 'stu_class': '1班'}, 'result': 'Pass', 'id': 'add_stu2', 'method': 'POST', 'hope': 'code=301;msg=手机号已存在'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":302,"msg":"学习形式不对"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'stu_name': 'yxg', 'sign': 'd51516ef99d71c891751743db1b6cc74', 'stu_type': '4', 'stu_phone': '13537737000', 'stu_class': '1班'}, 'result': 'Pass', 'id': 'add_stu3', 'method': 'POST', 'hope': 'code=302;msg=学习形式不对'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":304,"msg":"参数不能为空"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'stu_name': 'yxg', 'sign': 'd51516ef99d71c891751743db1b6cc74', 'stu_type': '1', 'stu_phone': '13537737001'}, 'result': 'Pass', 'id': 'add_stu4', 'method': 'POST', 'hope': 'code=304;msg=参数不能为空'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":304,"msg":"参数不能为空"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'sign': 'd51516ef99d71c891751743db1b6cc74', 'stu_type': '1', 'stu_phone': '13537737002', 'stu_class': '1班'}, 'result': 'Pass', 'id': 'add_stu5', 'method': 'POST', 'hope': 'code=304;msg=参数不能为空'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":304,"msg":"参数不能为空"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'stu_name': 'yxg', 'sign': 'd51516ef99d71c891751743db1b6cc74', 'stu_type': '1', 'stu_class': '1班'}, 'result': 'Pass', 'id': 'add_stu6', 'method': 'POST', 'hope': 'code=304;msg=参数不能为空'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":304,"msg":"参数不能为空"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'stu_name': 'yxg', 'stu_type': '1', 'stu_phone': '13547737093', 'stu_class': '1班'}, 'result': 'Pass', 'id': 'add_stu7', 'method': 'POST', 'hope': 'code=304;msg=参数不能为空'}, {'url': 'http://10.1.130.102:1990/addstu', 'data_type': 'JSON', 'res': '{"code":303,"msg":"用户未登录，请重新登录!"}', 'data': {'stu_sex': '男', 'opUserId': '1', 'stu_name': 'yxg', 'sign': '123', 'stu_type': '1', 'stu_phone': '13547737084', 'stu_class': '1班'}, 'result': 'Pass', 'id': 'add_stu8', 'method': 'POST', 'hope': 'code=303;msg=用户未登录，请重新登录!'}]
    write_excel(r'D:\1自动化\Python\day14\student\data\测试用例.xlsx', r'D:\1自动化\Python\day14\student\result', content)






