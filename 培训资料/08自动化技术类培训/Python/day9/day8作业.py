# #2.找到一个目录下所有的文件 .txt结尾 删掉
# import os
# path = r'D:\1自动化\Python\day8\a'
# def  del_file(path):
#     for i in os.listdir(path):
#         # print(i)
#         path_file = os.path.join(path,i)#将内容以当前操作系统的路径分隔符拼接成一个路径
#         print(path_file)
#         if os.path.isfile(path_file):
#             os.remove(path_file)
#         else:
#             del_file(path_file)
# res=os.walk(r'D:\1自动化\Python\day8\a')
# import os
# def del_files(path):
#     for root , dirs, files in os.walk(path):
#         for name in files:
#             if name.endswith(".txt"):
#                 os.remove(os.path.join(root, name))
#                 print ("Delete File: " + os.path.join(root, name))
# # test
# if __name__ == "__main__":
#     path = r'C:\Users\zhang.jianyu\PycharmProjects\Test\day8\a'
#     del_files(path

# 模块的本质：从上至下执行一遍python文件
#导入模块优先级：显示当前目录里面找模块名称，然后再是去python环境变量里找

target=9
list=[1,2,5,6,3,4,7]
list2=list.copy()
for i in range(len(list)-1):
    for j in list2[i+1:]:
        if list[i]+j==target:
            print(list[i],j)



