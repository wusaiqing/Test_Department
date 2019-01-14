double atof (const char *string); 

Action()
{

    float freememory,totalmemory,maxmemory;

	//web_set_user("admin",lr_decrypt("4993d46de"),"localhost:8089");
	web_set_user("admin","" ,"localhost:8089");

	web_reg_save_param("Free memory",
		"LB=Free memory: ",
		"RB=Total memory:",
		LAST);

	web_reg_save_param("Total memory",
		"LB=Total memory:",
		"RB=Max memory:",
		LAST);

	web_reg_save_param("Max memory",
		"LB=Max memory:",
		"RB=",
		LAST);

	web_url("status", 
		"URL=http://localhost:8089/manager/status", 
		"TargetFrame=", 
		"Resource=0", 
		"RecContentType=text/html", 
		"Referer=", 
		"Snapshot=t1.inf", 
		"Mode=HTML", 
		LAST);

	sleep(5);
	//lr_output_message("%s",lr_eval_string("{Free memory}"));
    freememory=atof(lr_eval_string("{Free memory}"));
	totalmemory=atof(lr_eval_string("{Total memory}"));
	maxmemory=atof(lr_eval_string("{Max memory}"));
    //lr_output_message("%.2f %.2f %.2f",freememory,totalmemory,maxmemory);
  	lr_user_data_point("Tomcat JVM Free memory", freememory);
  	lr_user_data_point("Tomcat JVM Total memory", totalmemory);
  	lr_user_data_point("Tomcat JVM Max memory", maxmemory);
	sleep(5);
	return 0;
}