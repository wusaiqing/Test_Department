#include "web_api.h"

Action()
{
	int iflen;    //文件大小
	long lfbody;  //响应数据内容大小

	web_url("487989.html",
		"URL=http://www.cnblogs.com/tester2test/archive/2006/08/28/487989.html",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=",
		"Snapshot=t2.inf",
		"Mode=HTML",
		EXTRARES,
		"Url=http://www.vqq.com/vqq_inset.js?isMin=0&place=RB&Css=2&RoomName=5rWL6K+V6ICF5a625Zut6K665Z2b&encode=1&isTime=0&width=350&height=240&everypage=0", ENDITEM,
		"Url=http://www.vqq.com/image/chat2.gif", ENDITEM,
		LAST);

	//设置最大长度
	web_set_max_html_param_len("10000");

	//将响应信息存放到fcontent变量
	web_reg_save_param("fcontent", "LB=", "RB=", "SEARCH=BODY", LAST);

	web_url("下载页面",
		"URL=http://www.cnblogs.com/Files/tester2test/xncssj.pdf",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=http://www.cnblogs.com/tester2test/archive/2006/08/28/487989.html",
		"Snapshot=t3.inf",
		"Mode=HTML",
		LAST);

	//获取响应大小
	iflen = web_get_int_property(HTTP_INFO_DOWNLOAD_SIZE);

	if(iflen > 0)	
	{
		//以写方式打开文件
		if((lfbody = fopen("c:\\性能测试实践及其展望.pdf", "wb")) == NULL)
		{
			lr_output_message("文件操作失败!");
			return -1;
		}
		//写入文件内容
		fwrite(lr_eval_string("{fcontent}"), iflen, 1, lfbody);
		//关闭文件
		fclose(lfbody);
	}
	return 0;
}
