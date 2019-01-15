#定义读写文件
def op_file(filename,content=None):
    if content:
        with open(filename,'w',encoding='utf-8') as f:
            f.write(str(content))
    else:
        with open(filename,'r',encoding='utf-8') as f:
            res=eval(f.read())
            return res

#定义校验money的输入合法性
def checkmoney(money):
    if money.isdigit():
        return True
    elif money.count('.')==1:
        if money.split('.')[0].isdigit() and money.split('.')[1].isdigit():
            return True
    return False