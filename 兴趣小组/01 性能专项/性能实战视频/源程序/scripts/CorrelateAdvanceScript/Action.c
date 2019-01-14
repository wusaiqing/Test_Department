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

   //输出符合条件的记录数
   lr_output_message("有%s个符合条件的数据", lr_eval_string("{mystr_count}"));

   //将记录数转换为数字
   cnt=atoi(lr_eval_string("{mystr_count}"));

   for (i=1;i<=cnt;i++)
    {
   //将数组单元名称转换到array_Name
       sprintf(array_Name,"{mystr_%d}",i);
   //打印相应名称数组单元的内容
       lr_output_message("数据为：%s",lr_eval_string(array_Name));
   //把数组中的所有内容放到str中
       strcat(str, lr_eval_string(array_Name));  
    }

	lr_output_message("合并后的数据为：%s",str);
    

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
		"Name=b1", "Value=提交", ENDITEM,
		LAST);

	return 0;
}
