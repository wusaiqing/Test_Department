#include "web_api.h"
Action()
{
	//定义字符串变量name且字符串内容为“于涌”
    char *name="于涌";
    //定义一个事务名称为"登录首页事务"
	lr_start_transaction("登录首页事务");
	web_url("tester2test",
		"URL=http://www.cnblogs.com/tester2test",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=",
		"Snapshot=t2.inf",
		"Mode=HTML",
		LAST);
	lr_end_transaction("登录首页事务", LR_AUTO);
    lr_output_message("测试脚本，作者:%s !",name);
	return 0;
}
