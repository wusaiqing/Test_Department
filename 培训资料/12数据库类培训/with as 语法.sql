/****** Script for SelectTopNRows command from SSMS  ******/

SELECT TOP 1000 [username]
      ,[sex]
      ,[money]
  FROM [master].[dbo].[test1]
  
     ALTER TABLE [master].[dbo].[test1]  DROP COLUMN [sex]  
     ALTER TABLE [master].[dbo].[test1]  add  [sex1] varchar(4) null
     --ALTER TABLE [master].[dbo].[test1]  modify [username] varchar(20)
     alter table [master].[dbo].[test1] alter column [sex1] varchar(2)
     
    
     exec sp_rename '[test1].[username]','[username2]','column';
     
 select *from [test1]
 
 
 
 
 --- with as的用法
 
create table tb_list(id int,[user] varchar(20),ddate datetime,mmoney numeric(10,2))
 
insert into tb_list
select 1    ,'用户1'    ,'2014-1-1',     100.00 union all
select 2    ,'用户2'    ,'2014-1-2',     150.00 union all
select 3    ,'用户1'    ,'2013-12-1',    90.00 union all
select 4    ,'用户1'    ,'2014-1-10',    50.00
go
 
 select *from tb_list
 
--注意 user必须写为: [user]
;with temp as
(
select *,rn=row_number()over(order by [user] asc)
from tb_list where [user]='用户1'
)
 
select [user],(select sum(mmoney) from temp t where rn<=temp.rn) 
from temp

select *from tb_list;

--普通查询
select [user],累计值=(select sum(mmoney) from (select *,rn=row_number() over(order by [user] asc ) from tb_list
where [user]='用户1') b where b.rn<=a.rn)
from (select *,rn=row_number() over(order by [user]) from tb_list where [user]='用户1')a













---- 用with as 把以下语句写出来,会简洁很多且提高查询性能

/* 班级名次 */ 
SELECT t.班级,t.学号,t.姓名,t.总分,COUNT(s.班级)+1 AS 名次
FROM('SELECT m.班级,m.学号,m.姓名,IFNULL(m.语文,0)+IFNULL(m.数学,0)+IFNULL(m.英语,0)+IFNULL(m.生物,0)+IFNULL(m.历史,0)+IFNULL(m.地理,0) AS 总分
FROM(SELECT b.name 班级,g.onlyid 学号,g.realname 姓名,
       MAX(CASE f.name WHEN '语文' THEN i.score ELSE NULL END) 语文,
       MAX(CASE f.name WHEN '数学' THEN i.score ELSE NULL END) 数学,
       MAX(CASE f.name WHEN '英语' THEN i.score ELSE NULL END) 英语,
       MAX(CASE f.name WHEN '生物' THEN i.score ELSE NULL END) 生物,
       MAX(CASE f.name WHEN '历史' THEN i.score ELSE NULL END) 历史,
       MAX(CASE f.name WHEN '地理' THEN i.score ELSE NULL END) 地理
FROM edvatest.sys_grade a ,edvatest.sys_classes b ,edvatest.b_exam c ,edvatest.b_exam_subject d,edvatest.b_examtype_log e,edvatest.b_subject_log f
     ,edvatest.sys_users g,b_exam_subject_totalscore i
WHERE d.examid=c.id AND d.subjectid=f.id AND i.examsubjectid=d.id AND i.userid=g.id AND i.classesid=b.id AND a.id=LEFT(NOW(),4)-b.startyear+b.startgrade     
     AND c.STATUS=1 -- 考试状态：0正常、1发布
     AND d.STATUS=1 -- 考试科目状态：0正常、1发布
     AND c.category=0 -- 考试类型：0：综合考试（多科），1：单科考试
     AND d.analysistype=1 -- 分析类型(0:单科分析,1:综合分析,2:一般分析)
     AND g.category=0 -- 分类：0，学生；1：老师；2：教务管理员；3：系统管理员
     AND c.name = '2015-2016年上学期期中考试lm' AND a.name = '八年级' AND e.name = '期中考试' -- AND LEFT(d.examdate,10)='2015-10-19'
     AND i.score IS NOT NULL
     GROUP BY g.`onlyid`
ORDER BY g.onlyid ASC
)m  ORDER BY 班级 ASC,总分 DESC')t LEFT JOIN ('SELECT m.班级,m.学号,m.姓名,IFNULL(m.语文,0)+IFNULL(m.数学,0)+IFNULL(m.英语,0)+IFNULL(m.生物,0)+IFNULL(m.历史,0)+IFNULL(m.地理,0) AS 总分
FROM(SELECT b.name 班级,g.onlyid 学号,g.realname 姓名,
       MAX(CASE f.name WHEN '语文' THEN i.score ELSE NULL END) 语文,
       MAX(CASE f.name WHEN '数学' THEN i.score ELSE NULL END) 数学,
       MAX(CASE f.name WHEN '英语' THEN i.score ELSE NULL END) 英语,
       MAX(CASE f.name WHEN '生物' THEN i.score ELSE NULL END) 生物,
       MAX(CASE f.name WHEN '历史' THEN i.score ELSE NULL END) 历史,
       MAX(CASE f.name WHEN '地理' THEN i.score ELSE NULL END) 地理
FROM edvatest.sys_grade a ,edvatest.sys_classes b ,edvatest.b_exam c ,edvatest.b_exam_subject d,edvatest.b_examtype_log e,edvatest.b_subject_log f
     ,edvatest.sys_users g,b_exam_subject_totalscore i
WHERE d.examid=c.id AND d.subjectid=f.id AND i.examsubjectid=d.id AND i.userid=g.id AND i.classesid=b.id AND a.id=LEFT(NOW(),4)-b.startyear+b.startgrade     
     AND c.STATUS=1 -- 考试状态：0正常、1发布
     AND d.STATUS=1 -- 考试科目状态：0正常、1发布
     AND c.category=0 -- 考试类型：0：综合考试（多科），1：单科考试
     AND d.analysistype=1 -- 分析类型(0:单科分析,1:综合分析,2:一般分析)
     AND g.category=0 -- 分类：0，学生；1：老师；2：教务管理员；3：系统管理员
     AND c.name = '2015-2016年上学期期中考试lm' AND a.name = '八年级' AND e.name = '期中考试' -- AND LEFT(d.examdate,10)='2015-10-19'
     AND i.score IS NOT NULL
     GROUP BY g.`onlyid`
ORDER BY g.onlyid ASC
)m  ORDER BY 班级 ASC,总分 DESC')s ON t.班级=s.班级 AND t.总分<s.总分 GROUP BY t.班级,t.学号,t.姓名
ORDER BY 学号



