#include "web_api.h"

int SumFour(int a,int b,int c,int d) //�Զ����ĸ�����������ͺ���
{
  if ((a<100) || (a>9000) || (b<100) || (b>9000) || (c<100) || (c>9000) || (d<100) || (d>9000)) 
     { return -1; }
  else { return a+b+c+d; }
}
Action()
{
    int invaild[5]={-1,0,1,99,9001};		    //�����Ϻ���Ҫ������ּ���
    int vaild[4]={100,101,8999,9000};		    //���Ϻ���Ҫ������ּ���
    int expect[5]={400,404,35996,36000,18200};  //���vaild�����Ԥ�ڽ������
    int i;					                    //��ʱ����
    lr_output_message("SumFour����Ҫ���ĸ�����������100��9000֮�䣺");
    lr_output_message("��һ�����ݣ������ϲ������������Ӧ����-1:");
    for (i=0;i<=4;i++)
    {
       lr_output_message("%d: SumFour(%d,%d,%d,%d)=%d",i+1,invaild[i],invaild[i],invaild[i],
                           invaild[i],SumFour(invaild[i],invaild[i],invaild[i],invaild[i]));
    };
    lr_output_message("6: SumFour(%d,%d,%d,%d)=%d",invaild[0],invaild[1],invaild[2],invaild[3],
                          SumFour(invaild[0],invaild[1],invaild[2],invaild[3]));
    lr_output_message("�ڶ������ݣ����ϲ������������Ӧ��������ֵ:");
    for (i=0;i<=3;i++)
    {
       lr_output_message("%d: SumFour(%d,%d,%d,%d)=%d ����ֵΪ%d",i+1,vaild[i],vaild[i],vaild[i],
                          vaild[i],SumFour(vaild[i],vaild[i],vaild[i],vaild[i]),expect[i]);
    };       
    lr_output_message("5: SumFour(%d,%d,%d,%d)=%d ����ֵΪ%d",vaild[0],vaild[1],vaild[2],vaild[3],
                       SumFour(vaild[0],vaild[1],vaild[2],vaild[3]),expect[4]);
	return 0;
}
