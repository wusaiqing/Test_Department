Action()
{

	web_set_user("admin", 
		lr_decrypt("4993d46de"), 
		"localhost:8089");

	web_url("status", 
		"URL=http://localhost:8089/manager/status", 
		"TargetFrame=", 
		"Resource=0", 
		"RecContentType=text/html", 
		"Referer=", 
		"Snapshot=t1.inf", 
		"Mode=HTML", 
		LAST);

	return 0;
}