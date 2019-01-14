#include "web_api.h"


Action()
{
//需要在链接的页面之前定义需保存的关联变量
//把关联传入相应的组件
	web_reg_save_param("mystr",
		"LB=<h1>",
		"RB=</h1>",
		"SaveOffset=0",
		"SaveLen=12",
		 "NotFound=ERROR",
		"Search=Body",
		LAST);

	web_url("index.jsp",
		"URL=http://192.168.1.60:8088/mytest/index.jsp",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=",
		"Snapshot=t7.inf",
		"Mode=HTML",
		LAST);

	web_submit_data("resp.jsp",
		"Action=http://192.168.1.60:8088/mytest/resp.jsp",
		"Method=POST",
		"RecContentType=text/html",
		"Referer=http://192.168.1.60:8088/mytest/index.jsp",
		"Snapshot=t8.inf",
		"Mode=HTML",
		ITEMDATA,
		"Name=t1", "Value={mystr}" ,ENDITEM,
		"Name=b1", "Value=提交", ENDITEM,
		LAST);

	return 0;
}





