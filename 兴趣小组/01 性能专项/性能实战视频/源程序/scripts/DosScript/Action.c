#include "web_api.h"

Action()
{

//dos命令DIR将文件列表放到文件C:\mytest.txt

	system("dir c:\\ *.* > c:\\mytest.txt");
	return 0;
}
