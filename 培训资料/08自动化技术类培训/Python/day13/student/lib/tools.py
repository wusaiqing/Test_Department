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

