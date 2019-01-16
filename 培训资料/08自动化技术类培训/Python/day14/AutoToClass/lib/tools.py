def send_req(url,data,way,datatype):#发送请求，适应不同的入参类型、请求方式
    import requests
    if way.lower()=='post':
        if datatype.lower()=='json':
            res = requests.post(url, json=data)
        else:
            res = requests.post(url, data)
    else:
        res = requests.get(url, data)
    return res.json()

def check_res(req,res):#比较预期结果和实际结果，一致的话返回true，不一致则返回false
    for k in req:
        if str(req[k])!=str(res[k]):
            return False
    return True

def str_dic(old_data):#将请求字符类型数据转变为字典形式
    data = {}
    for i in old_data:
        j = i.split('=')
        data[j[0]] = j[1]
    return data