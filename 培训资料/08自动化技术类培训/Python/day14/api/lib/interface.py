# -*- coding:utf-8 -*-
import flask,time
from flask import request
from flask import make_response
from lib.tools import op_redis, oprate_sql,secrete_md5
from conf.settings import *
server = flask.Flask(__name__)
@server.route(SERVER_ROUTE, methods=['get','post'])
def login_flask():
    username = request.values.get('username','')
    password = request.values.get('password','')
    sign = request.cookies.get('sign','')
    if username.strip() and sign.strip():
        if sign==op_redis(username):
            sql = 'select id from %s' % USERTB
            id = oprate_sql(sql,DBNAME)
            return '{"code":201,"msg":"你已经登录","sign":"%s","userId":%s}'%(sign,id[0][0])
        else:
            return '{"code":301,"msg":"session失效，请重新登录！"}'
    elif username.strip() and password.strip():
        sql = 'select username,password from %s where username="%s" and password="%s"' % (USERTB,username,secrete_md5(password))
        res = oprate_sql(sql,DBNAME)
        if res:
            session=secrete_md5(username+str(time.time()))
            op_redis(username, session)
            sql='select id from %s'%USERTB
            id = oprate_sql(sql, DBNAME)
            res=make_response('{"code":200,"msg":"成功","sign":"%s","userId":%s}'%(session,id[0][0]))
            res.set_cookie("sign",session)
            return res
        else:
            return '{"code":302,"msg":"用户名或密码错误!"}'
    return '{"code":303,"msg":"参数不能为空"}'

@server.route(ADD_SERVER_ROUTE, methods=['post'])
def add_flask():
    stu_name = request.json.get('stu_name','')
    stu_sex = request.json.get('stu_sex','')
    stu_phone = request.json.get('stu_phone','')
    stu_class = request.json.get('stu_class','')
    stu_type = request.json.get('stu_type','')
    opUserId = request.json.get('opUserId','')
    sign = request.json.get('sign','')
    if stu_name.strip() and stu_sex.strip() and stu_phone.strip() and stu_class.strip() and stu_type.strip() and opUserId.strip() and sign.strip():
        sql='select username from %s where id="%s"'%(USERTB,opUserId)
        username = oprate_sql(sql, DBNAME)
        if username and op_redis(username[0][0])==sign:
            sql = 'select stu_name from %s where stu_phone="%s"' % (STUTB,stu_phone)
            res = oprate_sql(sql, DBNAME)
            if res:
                return '{"code":301,"msg":"手机号已存在"}'
            elif stu_type not in ['1','2']:
                return '{"code":302,"msg":"学习形式不对"}'
            sql='insert into %s(stu_name,stu_sex,stu_phone,stu_class,stu_type,opUserId) values("%s","%s","%s","%s","%s","%s")'%(STUTB,stu_name,stu_sex,stu_phone,stu_class,stu_type,opUserId)
            oprate_sql(sql, DBNAME)
            return '{"code":200,"msg":"成功"}'
        return '{"code":303,"msg":"用户未登录，请重新登录!"}'
    return '{"code":304,"msg":"参数不能为空"}'

@server.route('/upload',methods=['post'])
def upload():
    #上传文件接口
    f = request.files.get('file_name',None)
    if f:
        t = time.strftime('%Y%m%d%H%M%S')#获取当前时间
        new_file_name = t+f.filename#给文件重命名，防止有重复文件覆盖
        f.save(new_file_name)#保存文件
        return '{"code":"ok"}'
    else:
        return '{"msg":"请上传文件！"}'