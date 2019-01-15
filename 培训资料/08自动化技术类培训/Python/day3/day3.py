# #常用的字符串方法：
# file_name='D:\1自动化\day2\day2笔记.txt'
# name='名字：{name},年龄：{age}'
# print(file_name.startswith('D'))  # 判断是否以x结尾
# print(file_name.endswith('.txt'))  # 判断是否以x结尾
# name.format(name='niuniu', age=18)  # 这个是格式字符串
# print('122'.isdigit())  # 是否是数字
# print(''.join(['hehe', 'haha', 'ee']))  # 拼接字符串
# # 1、把list转成字符串
# # 2、把list里面每个元素连起来
# print('adbefF'.lower())  # 变成小写
# print('adbefF'.upper())  # 变成大写
# print('\nmysql \n'.strip())  #清除字符串前后空格
# print('mysql is db.'.replace('mysql', 'oracle'))    #替换，将字符串里所有的mysql替换成oracle
# print('1+2+3+4'.split('+'))  # 切割字符串，返回一个list
# print('1+2+3\n1+2+3+4'.splitlines())  # 按照换行符分割，返回一个list
#
# # 所有的字符串方法：
# print(name.capitalize())#首字母大写
# print(name.center(50,'\t'))#把字符长度加到50个，如果元字符长度大于50，则字符不变，若大于50，则字符不做改变
# print(name.find('n'))#查找字符的索引，当查不到的时候会返回-1,
# print(name.index('w'))#查找字符的索引，当查不到的时候会报错
# print('a'.isalnum())#判断是否只包含数字或字母
# print('sdSD'.isalpha())#判断是否英文字母
# print('ads'.isidentifier())#判断是一个合法变量名
# print('aaa'.islower())#是否都是小写字母
# print('AAA'.isupper())#是否都是大写字母
# print('\n   mysql   \n'.lstrip())#默认去掉左边的空格和换行
# print('\n   mysql   \n'.rstrip())#默认去掉右边的空格和换行
# print('\n   my\nsql   \n'.strip())#默认去掉左右两边的空格和换行,中间的空行去不掉
# print('asdfdsfsfa'.strip('a'))#去掉首尾两端的字符'a'
# p=str.maketrans('123','abc')#前面的字符串和后面的字符串做映射
# print('123'.translate(p))#输出按照上面maketrans做映射后的字符串
# print('asd gd gfd'.replace(' ','',1))#替换字符串，替换一次，不写数字表示全部替换
# print('mysql is is db'.find('is'))#返回最左边字符的下标
# print('mysql is is db'.rfind('is'))#返回最右边字符的下标
# print('AAAaaa'.swapcase())#字母大小写反转

