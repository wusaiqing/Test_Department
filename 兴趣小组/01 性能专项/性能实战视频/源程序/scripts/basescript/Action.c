#include "web_api.h"
Action()
{
	//�����ַ�������name���ַ�������Ϊ����ӿ��
    char *name="��ӿ";
    //����һ����������Ϊ"��¼��ҳ����"
	lr_start_transaction("��¼��ҳ����");
	web_url("tester2test",
		"URL=http://www.cnblogs.com/tester2test",
		"Resource=0",
		"RecContentType=text/html",
		"Referer=",
		"Snapshot=t2.inf",
		"Mode=HTML",
		LAST);
	lr_end_transaction("��¼��ҳ����", LR_AUTO);
    lr_output_message("���Խű�������:%s !",name);
	return 0;
}
