#include "web_api.h"

char *strtok(char *, char *); 

Action()
{	char aBuffer[256]; // ��ȡ�ַ����ı���
  	char *cMan; // ���뵥�������ı���
	char cSeparator[] = ","; // �洢�ַ����ָ����ı���
	int i; // ����ָ������ͱ���
	char man[4][20]; // �洢�ָ������������
    
	// Create a parameter named pDate:
	lr_save_string("��ɮ,���,�˽�,ɳɮ", "pman");

	// Put parameter into a string buffer:
	strcpy( aBuffer,lr_eval_string("{pman}"));

	// Show the buffer for debugging:
	lr_output_message("ȡ�����˰�����%s\n",aBuffer);

	lr_output_message("=====================================");
	// get first word (to the first blank):
 	cMan = strtok( aBuffer,cSeparator); 
	i = 1;

	if(!cMan) { 
        // first token was not found:
		lr_output_message("û��ȡ����!");
		return( -1 );
	} 
    else {

		while( cMan != NULL) { // tokens are not NULL:

			// Stuff in another array:
			strcpy( man[i], cMan ); 

			// Get next token:
			cMan = strtok( NULL, cSeparator); 
			i++; // increment 
		}
		lr_output_message("ʦ��: %s", man[1]);
		lr_output_message("��ͽ��: %s", man[2]);
		lr_output_message("��ͽ��: %s", man[3]);
		lr_output_message("��ͽ��: %s", man[4]);
	}
	return 0;

}
