/****** Script for SelectTopNRows command from SSMS  ******/
drop table [master].[dbo].[student_score]
select *from [master].[dbo].[student_score]
drop 


CREATE TABLE student_score
(  id          INT,
   studentname VARCHAR(10),
   class       VARCHAR(10),
   mark        FLOAT NULL
  );
alter TABLE student_score modify id int not null
alter TABLE student_score add primary key(id) 
  
INSERT INTO student_score(id,studentname,class,mark) VALUES(1,'王五','1班',100);
INSERT INTO student_score(id,studentname,class,mark) VALUES(2,'汪一','1班',100);
INSERT INTO student_score(id,studentname,class,mark) VALUES(3,'张三','1班',78);
INSERT INTO student_score(id,studentname,class,mark) VALUES(4,'赵六','2班',85);
INSERT INTO student_score(id,studentname,class,mark) VALUES(5,'李四','2班',85);
INSERT INTO student_score(id,studentname,class,mark) VALUES(6,'周九','2班',90);
INSERT INTO student_score(id,studentname,class,mark) VALUES(7,'何二','3班',56);
INSERT INTO student_score(id,studentname,class,mark) VALUES(8,'刘七','3班',null);


SELECT AVG(mark) FROM student_score
SELECT AVG(IFNULL(mark)) FROM student_score
SELECT *FROM student_score WHERE MARK>78 AND MARK<90 (OR  OR)

SELECT AVG(MARK) FROM student_score 
GROUP BY class





update [master].[dbo].[student_score] set studentname=

delete [master].[dbo].[student_score]
truncate table [master].[dbo].[student_score]  

select *from [master].[dbo].[student_score] a order by  class desc, mark asc

update [master].[dbo].[student_score] set mark = null where studentname='刘七'

select MIN(ifnull(a.mark,0)),max(ifnull(a.mark,0)) from [master].[dbo].[student_score] a









---- 相关子查询测试数据1

drop table S2;
drop table C2
drop table SC2;

delete  S2;
delete  C2
delete  SC2;


create table S2
( SNO   int,  
  SNAME varchar(20) 
);


create table C2
( CNO      int,
  CNAME    varchar(20)
);


create table SC2
( S_SNO   int ,
  C_CNO   int
);



INSERT INTO S2(SNO,SNAME) VALUES(95001,'李勇');
INSERT INTO S2(SNO,SNAME) VALUES(95002,'刘晨');


INSERT INTO C2(CNO,CNAME) VALUES(1,'数据库');
INSERT INTO C2(CNO,CNAME) VALUES(2,'网络');
INSERT INTO C2(CNO,CNAME) VALUES(3,'C语言');


INSERT INTO SC2(S_SNO,C_CNO) VALUES(95001,1);
INSERT INTO SC2(S_SNO,C_CNO) VALUES(95001,2);
INSERT INTO SC2(S_SNO,C_CNO) VALUES(95001,3);
INSERT INTO SC2(S_SNO,C_CNO) VALUES(95002,3);
INSERT INTO SC2(S_SNO,C_CNO) VALUES(95003,2);


select *from S2
select *from C2
select *from SC2


--练习:查询选修了全部课程的学生
SELECT SNO,SNAME FROM S2 WHERE NOT EXISTS 
( SELECT * FROM C2 WHERE NOT EXISTS
 (SELECT * FROM SC2 WHERE SC2.S_SNO=S2.SNO AND SC2.C_CNO=C2.CNO)
)

SELECT SNO,SNAME FROM S2,C2,SC2 WHERE C2.CNO=SC2.C_CNO AND S2.SNO=SC2.S_SNO AND
SC2.C_CNO=1 and SC2.C_CNO=2 and SC2.C_CNO=3




---- 相关子查询测试数据2

create table SC3
( S_SNO   int ,
  C_CNO   int
);

INSERT INTO SC3(S_SNO,C_CNO) VALUES(95001,1);
INSERT INTO SC3(S_SNO,C_CNO) VALUES(95001,2);
INSERT INTO SC3(S_SNO,C_CNO) VALUES(95002,1);
INSERT INTO SC3(S_SNO,C_CNO) VALUES(95002,2);
INSERT INTO SC3(S_SNO,C_CNO) VALUES(95003,2);

select *from SC3;



--练习:查询至少选修了学生95001选修课程的全部课程的学生学号
--对于选修过课程的学生x: P q (如果p，则q)
--p：95001学生选修了课程y， q：学生x选修了课程y
--不存在p真q假的情况


SELECT DISTINCT S_SNO FROM SC3 SCX
WHERE NOT EXISTS
(SELECT * FROM SC3 SCY WHERE SCY.S_SNO='95001' AND NOT EXISTS 
(SELECT * FROM SC3 SCZ WHERE SCZ.S_SNO=SCX.S_SNO AND SCZ.C_CNO=SCY.C_CNO
                       AND SCX.S_SNO<>'95001'))
