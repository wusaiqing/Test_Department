#include "web_api.h"

Action()
{
	int iflen;    //�ļ���С
	long lfbody;  //��Ӧ�������ݴ�С

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

	//������󳤶�
	web_set_max_html_param_len("10000");

	//����Ӧ��Ϣ��ŵ�fcontent����
	web_reg_save_param("fcontent", "LB=", "RB=", "SEARCH=BODY", LAST);

	web_url("����ҳ��",
		"URL=http://www.cnblogs.com/Files/tester2test/xncssj.pdf",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=http://www.cnblogs.com/tester2test/archive/2006/08/28/487989.html",
		"Snapshot=t3.inf",
		"Mode=HTML",
		LAST);

	//��ȡ��Ӧ��С
	iflen = web_get_int_property(HTTP_INFO_DOWNLOAD_SIZE);

	if(iflen > 0)	
	{
		//��д��ʽ���ļ�
		if((lfbody = fopen("c:\\���ܲ���ʵ������չ��.pdf", "wb")) == NULL)
		{
			lr_output_message("�ļ�����ʧ��!");
			return -1;
		}
		//д���ļ�����
		fwrite(lr_eval_string("{fcontent}"), iflen, 1, lfbody);
		//�ر��ļ�
		fclose(lfbody);
	}
	return 0;
}
