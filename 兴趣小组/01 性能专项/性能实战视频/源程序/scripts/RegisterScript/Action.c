#include "web_api.h"

Action()
{
	lr_rendezvous("同时登录注册");

	lr_start_transaction("登录注册事务");

	web_url("MercuryWebTours",
		"URL=http://localhost/MercuryWebTours/",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=",
		"Snapshot=t2.inf",
		"Mode=HTML",
		LAST);

	web_submit_form("login.pl",
		"Snapshot=t3.inf",
		ITEMDATA,
		"Name=username", "Value=", ENDITEM,
		"Name=password", "Value=", ENDITEM,
		"Name=signup.x", "Value=54", ENDITEM,
		"Name=signup.y", "Value=12", ENDITEM,
		LAST);

	web_submit_form("login.pl_2",
		"Snapshot=t4.inf",
		ITEMDATA,
		"Name=username", "Value={username}", ENDITEM,
		"Name=password", "Value={password}", ENDITEM,
		"Name=passwordConfirm", "Value={password}", ENDITEM,
		"Name=firstName", "Value=John", ENDITEM,
		"Name=lastName", "Value=Tomas", ENDITEM,
		"Name=address1", "Value=Peking", ENDITEM,
		"Name=address2", "Value=100084", ENDITEM,
		"Name=register.x", "Value=72", ENDITEM,
		"Name=register.y", "Value=12", ENDITEM,
		LAST);

	web_find("检查点",
		"What={username}",
		LAST);

	lr_end_transaction("登录注册事务", LR_AUTO);

	return 0;
}


