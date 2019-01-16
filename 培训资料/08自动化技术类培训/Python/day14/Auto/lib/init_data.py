def oprate_sql(sql, DBNAME=''):  # 定义操作sql语句的函数，如果是select或show则返回查询内容
    import pymysql
    from conf.settings import  HOST, USER, PASSWD, CHARSET
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

def truncate_tb(tablename):  # 清空表
    from conf.settings import DBNAME
    truncate_sql = 'truncate %s;' % tablename
    oprate_sql(truncate_sql, DBNAME)