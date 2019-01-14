#include "web_api.h"

char *strtok(char *, char *); 

Action()
{	char aBuffer[256]; // 存取字符串的变量
  	char *cMan; // 分离单个人名的变量
	char cSeparator[] = ","; // 存储字符串分隔符的变量
	int i; // 增长指针的整型变量
	char man[4][20]; // 存储分割单个人名的数组
    
	// Create a parameter named pDate:
	lr_save_string("唐僧,悟空,八戒,沙僧", "pman");

	// Put parameter into a string buffer:
	strcpy( aBuffer,lr_eval_string("{pman}"));

	// Show the buffer for debugging:
	lr_output_message("取经四人包括：%s\n",aBuffer);

	lr_output_message("=====================================");
	// get first word (to the first blank):
 	cMan = strtok( aBuffer,cSeparator); 
	i = 1;

	if(!cMan) { 
        // first token was not found:
		lr_output_message("没有取经人!");
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
		lr_output_message("师父: %s", man[1]);
		lr_output_message("大徒弟: %s", man[2]);
		lr_output_message("二徒弟: %s", man[3]);
		lr_output_message("三徒弟: %s", man[4]);
	}
	return 0;

}
