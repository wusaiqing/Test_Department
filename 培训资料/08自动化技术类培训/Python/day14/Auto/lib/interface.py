def req_test(case_lis,REPORT_PATH,files):
    import requests
    from lib.tools import send_req,check_res
    from lib.get_cases import op_excel
    res_lis=[]
    for req_data in case_lis:
        lis=[]
        moudle=req_data['模块']
        datatype=req_data['入参类型']
        url=req_data['请求url']
        data=req_data['请求数据']
        way=req_data['请求方式']
        expected=req_data['预期结果']
        if moudle!='增加学生信息':
            res=send_req(url, data, way, datatype)
        else:
            login_res=requests.get(case_lis[0]['请求url'],case_lis[0]['请求数据']).json()
            if 'sign' in data:
                if data['sign']=='sign':
                    data['sign']=login_res['sign']
            print(data)
            res = send_req(url, data, way, datatype)
        lis.append(url+'?'+req_data['原始请求数据'])
        lis.append(str(res))
        if check_res(expected, res):
            lis.append('通过')
        else:
            lis.append('失败')
        res_lis.append(lis)
    op_excel(files,REPORT_PATH=REPORT_PATH, content=res_lis)
