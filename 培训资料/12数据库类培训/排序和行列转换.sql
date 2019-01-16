
create table cj --创建表cj
( ID Int IDENTITY (1,1) not null, --创建列ID,并且每次新增一条记录就会加1
  Name Varchar(50),
  Subject Varchar(50),
  Result Int,
  primary key (ID) --定义ID为表cj的主键
);

truncate table cj  
   
Insert into cj
Select '张三','语文',80 union all
Select '张三','数学',90 union all
Select '张三','物理',85 union all
Select '李四','语文',85 union all
Select '李四','物理',82 union all
Select '李四','英语',90 union all
Select '李四','政治',70 union all
Select '王五','英语',90

insert into cj values('王五','化学',89)
insert into cj values('王五','语文',70)
insert into cj values('初一','语文',90)
insert into cj values('初一','数学',90)
insert into cj values('初一','英语',100)
insert into cj values('赵二','语文',86)
insert into cj values('赵二','数学',78)
insert into cj values('赵二','英语',85)
insert into cj values('王五','数学',85)
insert into cj values('王五','地理',85)


delete from cj where name='张三' and Result=70


select name,subject,result from cj order by subject,result

select name,subject,result from cj t order by Subject;
select name,subject,result from cj s order by Subject;


--排名问题:

Select name,subject,result,row_number() over( partition by SUBJECT order by result desc) rank from cj
Select name,subject,result,dense_rank() over( partition by SUBJECT order by result desc) rank from cj 
Select name,subject,result,rank() over( partition by SUBJECT order by result desc) rank from cj


--Mysql没有以上函数,只能用如下方法:

Select t.name,t.subject,t.result,COUNT(s.name)+1 AS 名次 from  
cj t left join cj s on t.Subject=s.Subject and t.Result<s.Result
group by t.Name,t.subject,t.result
order by t.subject,t.result desc



select distinct Subject from cj

select * from cj


--行列转换
--确定有哪些科目时

SELECT NAME,SUM(CASE SUBJECT WHEN '化学' THEN result ELSE 0 END) 化学,
               SUM(CASE SUBJECT WHEN '数学' THEN result ELSE 0 END) 数学, 
               SUM(CASE SUBJECT WHEN '物理' THEN result ELSE 0 END) 物理,
               SUM(CASE SUBJECT WHEN '英语' THEN result ELSE 0 END) 英语, 
               SUM(CASE SUBJECT WHEN '语文' THEN result ELSE 0 END) 语文,
               SUM(CASE SUBJECT WHEN '政治' THEN result ELSE 0 END) 政治
FROM  cj GROUP BY NAME 



--行列转换
---不确定有哪些科目时

Declare @sql varchar(8000)
Set @sql = 'Select Name as 姓名'
Select @sql = @sql + ',sum(case Subject when '''+Subject+''' then Result else 0 end) ['+Subject+']'
from (select distinct Subject from cj)cj --把所有唯一的科目的名称都列举出来
Select @sql = @sql+'from cj group by name'
--PRINT @sql
--Exec (@sql)
execute (@sql)











(单引号在引号内用''表示
如要表示值：变'量
declare @c varchar(6)
set @c='变''量')

SQL 的转义字符是：'（单引号）

SELECT '''我'''