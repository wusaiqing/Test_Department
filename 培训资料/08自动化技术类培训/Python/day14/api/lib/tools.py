# -*- coding:utf-8 -*-
def oprate_sql(sql,DBNAME=''):#定义操作sql语句的函数，如果是select或show则返回查询内容
    import pymysql
    from conf.settings import USERTB, HOST, USER, PASSWD,USERTB,CHARSET
    if DBNAME:
        conn = pymysql.connect(host=HOST, user=USER, password=PASSWD, db=DBNAME, charset=CHARSET)
    else:
        conn = pymysql.connect(host=HOST, user=USER, password=PASSWD, charset=CHARSET)
    cur = conn.cursor()
    cur.execute(sql)
    if sql.strip().startswith('select') or sql.strip().startswith('show'):
        res = cur.fetchall()
    else:
        conn.commit()
        res = 'ok'
    cur.close()
    conn.close()
    return res

def secrete_md5(passwd):#密码加密的函数
    import hashlib
    from conf.settings import SALT
    md=hashlib.md5()
    md.update((passwd+SALT).encode())
    first=md.hexdigest()
    md.update(first.encode())
    return md.hexdigest()

def check_in(args,res):#判断a,是否在res的元素里，这里的res必须是sql执行返回的数据,用于注册，登录
    lis=[]
    for i in res:
        lis.append(i[0])
    if args in lis:
        return True

def op_redis(k,v=''):#将用户的登录session写进redis，保留2小时
    import redis
    from conf.settings import REDIS_HOST,REDIS_PORT,REDIS_PASSWD,REDIS_DB
    conn=redis.Redis(host=REDIS_HOST,port=REDIS_PORT,db=REDIS_DB)
    if v:
        conn.setex(k,v,200)
    elif conn.get(k):
        return conn.get(k).decode()