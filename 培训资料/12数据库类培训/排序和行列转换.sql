
create table cj --������cj
( ID Int IDENTITY (1,1) not null, --������ID,����ÿ������һ����¼�ͻ��1
  Name Varchar(50),
  Subject Varchar(50),
  Result Int,
  primary key (ID) --����IDΪ��cj������
);

truncate table cj  
   
Insert into cj
Select '����','����',80 union all
Select '����','��ѧ',90 union all
Select '����','����',85 union all
Select '����','����',85 union all
Select '����','����',82 union all
Select '����','Ӣ��',90 union all
Select '����','����',70 union all
Select '����','Ӣ��',90

insert into cj values('����','��ѧ',89)
insert into cj values('����','����',70)
insert into cj values('��һ','����',90)
insert into cj values('��һ','��ѧ',90)
insert into cj values('��һ','Ӣ��',100)
insert into cj values('�Զ�','����',86)
insert into cj values('�Զ�','��ѧ',78)
insert into cj values('�Զ�','Ӣ��',85)
insert into cj values('����','��ѧ',85)
insert into cj values('����','����',85)


delete from cj where name='����' and Result=70


select name,subject,result from cj order by subject,result

select name,subject,result from cj t order by Subject;
select name,subject,result from cj s order by Subject;


--��������:

Select name,subject,result,row_number() over( partition by SUBJECT order by result desc) rank from cj
Select name,subject,result,dense_rank() over( partition by SUBJECT order by result desc) rank from cj 
Select name,subject,result,rank() over( partition by SUBJECT order by result desc) rank from cj


--Mysqlû�����Ϻ���,ֻ�������·���:

Select t.name,t.subject,t.result,COUNT(s.name)+1 AS ���� from  
cj t left join cj s on t.Subject=s.Subject and t.Result<s.Result
group by t.Name,t.subject,t.result
order by t.subject,t.result desc



select distinct Subject from cj

select * from cj


--����ת��
--ȷ������Щ��Ŀʱ

SELECT NAME,SUM(CASE SUBJECT WHEN '��ѧ' THEN result ELSE 0 END) ��ѧ,
               SUM(CASE SUBJECT WHEN '��ѧ' THEN result ELSE 0 END) ��ѧ, 
               SUM(CASE SUBJECT WHEN '����' THEN result ELSE 0 END) ����,
               SUM(CASE SUBJECT WHEN 'Ӣ��' THEN result ELSE 0 END) Ӣ��, 
               SUM(CASE SUBJECT WHEN '����' THEN result ELSE 0 END) ����,
               SUM(CASE SUBJECT WHEN '����' THEN result ELSE 0 END) ����
FROM  cj GROUP BY NAME 



--����ת��
---��ȷ������Щ��Ŀʱ

Declare @sql varchar(8000)
Set @sql = 'Select Name as ����'
Select @sql = @sql + ',sum(case Subject when '''+Subject+''' then Result else 0 end) ['+Subject+']'
from (select distinct Subject from cj)cj --������Ψһ�Ŀ�Ŀ�����ƶ��оٳ���
Select @sql = @sql+'from cj group by name'
--PRINT @sql
--Exec (@sql)
execute (@sql)











(����������������''��ʾ
��Ҫ��ʾֵ����'��
declare @c varchar(6)
set @c='��''��')

SQL ��ת���ַ��ǣ�'�������ţ�

SELECT '''��'''