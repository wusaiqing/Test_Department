#include "web_api.h"

//double atof ( const char *string );
Action()
{
    char  totalprice[64]="6279.60";
    float price[3]={1380.00,859.80,450.00};
    int   quantity[3]={2,2,4};
    char  strtmpres[64];
    float ftotalprice=0;
    int  i;
    for (i=0;i<=2;i++)
	{
       ftotalprice=ftotalprice+price[i]*quantity[i];
	}
    lr_output_message("��atof��ʽ�����totalprice��%f",atof(totalprice));
    lr_output_message("������ȡ���ǽ���ֵ�뿴��������������%f",ftotalprice);
    sprintf(strtmpres,"%.2f",ftotalprice); 
    lr_output_message("������λС����ʽ���ĸ�����Ϊ��%s ",strtmpres);
    if (*strtmpres==*totalprice) 
    {
       lr_output_message("Ԥ�ڽ����ʵ�ʽ�����!");
     }
    else 
    {
       lr_output_message("Ԥ�ڽ����ʵ�ʽ������!");
     } 
	return 0;
}

