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
    lr_output_message("用atof格式化输出totalprice＝%f",atof(totalprice));
    lr_output_message("浮点数取的是近似值请看函数的输出结果：%f",ftotalprice);
    sprintf(strtmpres,"%.2f",ftotalprice); 
    lr_output_message("保留两位小数格式化的浮点数为：%s ",strtmpres);
    if (*strtmpres==*totalprice) 
    {
       lr_output_message("预期结果与实际结果相等!");
     }
    else 
    {
       lr_output_message("预期结果与实际结果不等!");
     } 
	return 0;
}

