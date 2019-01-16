#Login
***
###程序说明：
    读excel用例，然后根据excel里面的用例，来调用接口，再把请报文和返回报文写到excel里面
    1、读excel xlrd ,获取到请求url 请求方式 请求参数
    2、拼好请求报文，发请求，获取到返回的结果,比对返回的结果是否与预期结果一致  requests.post(url).text
    3、修改excel  xlutils

###实现功能如下：  
    1、清空student表数据，读excel xlrd ,获取到请求url 请求方式 请求参数，拼好请求报文，发请求，获取到返回的结果,比对返回的结果是否与预期结果一致
    2、将执行结果写进excel
    
###程序运行：
    python bin/start.py

###程序结构：
	Course8/
	├── README
	├── Auto #在这个下
	│   ├── bin # 执行文件 目录
	│   │   ├── start.py  #启动目录
	│   ├── conf #配置文件
	│   │   ├── settings.py #存放配置文件，数据库
	│   ├── lib #主要程序逻辑都 在这个目录里
	│   │   └── init_data.py #清空数据库函数
	│   │   └── interface.py #处理请求
	│   │   └── get_cases.py #当不传content时，处理测试用例，得到一个用例list；当传了content时，将cotent写进excel的测试结果
	│   │   └── tools.py #一些公共方法，如请求、比对数据等

#1.优化程序健壮性，出错则爆出异常，try  2.自动读取相对路径的测试用例，不用用户自己再去配置路径

	

