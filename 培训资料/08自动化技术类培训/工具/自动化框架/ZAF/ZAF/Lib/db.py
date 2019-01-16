#encoding: utf-8
from DatabaseLibrary import DatabaseLibrary

class DB():
    def __init__(self):
        self.db = DatabaseLibrary()

    def sql_execute(self, dbtype, dbconn, sql):
        self.db.connect_to_database_using_custom_params(dbtype, dbconn)
        self.db.execute_sql_string(sql)
        self.db.disconnect_from_database()

    def sql_query(self, dbtype, dbconn, sql):
        self.db.connect_to_database_using_custom_params(dbtype, dbconn)
        r = self.db.query(sql)
        self.db.disconnect_from_database()
        return r

    def check_db_num(self, dbtype, dbconn, sql, n):
        self.db.connect_to_database_using_custom_params(dbtype, dbconn)
        self.db.row_count_is_equal_to_x(sql, n)
        self.db.disconnect_from_database()

    def check_db_empty(self, dbtype, dbconn, sql):
        self.db.connect_to_database_using_custom_params(dbtype, dbconn)
        self.db.check_if_not_exists_in_database(sql)
        self.db.disconnect_from_database()

    def check_db_not_empty(self, dbtype, dbconn, sql):
        self.db.connect_to_database_using_custom_params(dbtype, dbconn)
        self.db.check_if_exists_in_database(sql)
        self.db.disconnect_from_database()

    def row_count(self, dbtype, dbconn, sql):
        self.db.connect_to_database_using_custom_params(dbtype, dbconn)
        r = self.db.row_count(sql)
        self.db.disconnect_from_database()
        return r

if __name__=='__main__':
    db = DB()

    #rs = db.sql_query('MySQLdb',
    #             "host='10.1.130.82',port=3307,user='root',passwd='root',db='ecloud'",
    #             'select FunId, ClsId from d_funlib limit 0,10')

    ts = db.sql_query('MySQLdb',"host='10.1.134.63',port=3306,user='root',passwd='root',db='szhjxpt',charset='utf8'",
                        "select FullName, Gender, Contact, Email from userinfo where LoginName like 'teacher1'")
    if ts:
        for r in ts:
            print r