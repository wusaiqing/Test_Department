#include "web_api.h"


Action()
{

   char array_Name[256];
   char str[1024];
   int i;
   int cnt;
   char str1[1024];

	web_reg_save_param("mystr",
		"LB=<h1>",
		"RB=</h1>",
		"Ord=All",
		"Search=All",
		LAST);

	web_url("index.jsp",
		"URL=http://192.168.1.60:8088/mytest/index.jsp",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=",
		"Snapshot=t1.inf",
		"Mode=HTML",
		LAST);

	lr_think_time( 3 );

   //������������ļ�¼��
   lr_output_message("��%s����������������", lr_eval_string("{mystr_count}"));

   //����¼��ת��Ϊ����
   cnt=atoi(lr_eval_string("{mystr_count}"));

   for (i=1;i<=cnt;i++)
    {
   //�����鵥Ԫ����ת����array_Name
       sprintf(array_Name,"{mystr_%d}",i);
   //��ӡ��Ӧ�������鵥Ԫ������
       lr_output_message("����Ϊ��%s",lr_eval_string(array_Name));
   //�������е��������ݷŵ�str��
       strcat(str, lr_eval_string(array_Name));  
    }

	lr_output_message("�ϲ��������Ϊ��%s",str);
    

	lr_save_string( lr_eval_string(str), "word"); 

	web_submit_data("resp.jsp",
		"Action=http://192.168.1.60:8088/mytest/resp.jsp",
		"Method=POST",
		"RecContentType=text/html",
		"Referer=http://192.168.1.60:8088/mytest/index.jsp",
		"Snapshot=t2.inf",
		"Mode=HTML",
		ITEMDATA,
		"Name=t1", "Value={word}", ENDITEM,
		"Name=b1", "Value=�ύ", ENDITEM,
		LAST);

	return 0;
}
