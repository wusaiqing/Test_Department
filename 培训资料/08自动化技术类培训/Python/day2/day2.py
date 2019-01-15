#回顾
# print('asd')
# name=input('shuru:')
# print(type(name))
#格式化输出
# name='dalei'
# age=123
# # print(name+age)
# print(name,age)
#占位符
# name='xiaogang'
# print('asd{name},asdfas{name},agdasdfasdg{name}'.format(name=name))
# i=0
# while i<10:
#     print(i)
#     if i==5:
#         print('haha')
#         break
#     print('OK')
#     i+=1
# username='dalei'
# password='123456'
# name=input('请输入名字：')
# passwd=input('请输入密码：')
# if username==name or password==passwd:
#     print('OK')
#and,A and B,A为真，取B；A为假，取A
# A or B ,A为真，取A；A为假，取B
# print(0 and 1)
# print(1 and 541654)
# print(1 or 541654)
# print(0 or 541654)
# print(0 and 1 or 4 and 5 or 6)
#        0      or     5  or 6
# print(0 and 1) or 4 and 5 or 6)

#列表
# name='星星，少莲，。。。。'
#下标，角标、索引
# names=['星星',['dalei',123,'',None,[1,2,3],123],'',None,[1,2,3]]
# nums=[1,1,2,3,4,5,6,6,7,8,9,10]
# nums1=nums.copy()
# print(id(nums))
# print(id(nums1))
# # 0 1 2 3 4 5 6 7 8 9 10 11
# #[1, 1, 3, 4, 5, 6, 6, 7, 8, 9, 10]
# for i in nums:
#     if i%2==0:
#         nums1.remove(i)
# print(nums1)

#可变变量：list，dict
#不可变变量：字符串，元组
# str='xiaogang'
# new_str=str+'123'
# print(new_str)
# str[0]='y'
# del str[0]
# str.append('123')




# print(names[-4][-2][-2])
# num=[1,3,4]
# num.insert(8,9)
# num[8]=9
# num.pop(8)
# print(num)


#删除
# del names[0:2]  #删除多个
# names.pop()
# names.pop(2)
# names.clear()
# names.remove('星星',)

#取值
# print(names[1])
# print(names[-1])

#新增
# names.append('左欣')
# names.insert(-2,'云峰')
# print(names)

#列表内置函数
nums=[1,2,3,4,5,6,6,7,8,9]
# print(nums.index(6))#取元素的下标
# print(nums.count(1))#统计元素出现的次数
# alpha=['a','b','c']
# nums.extend(alpha)
# new_lis=nums+alpha
# nums+alpha
# print(nums)
# nums=[1,5,6,6,9,2,3,4,7,8]
# # nums.sort()#默认升序
# nums.sort(reverse=True)#默认升序
# print(nums)
# print(nums[1:3])  #取第二个元素到第三个元素，也就是2,3
# print(nums[3:])  #取所有的元素，一直取到最后，后面的下标可以省略不写
# print(nums[:6])  #取所有的元素，从头开始取，前面的下标可以不写
# print(nums[0:10:3])  #步长2，每两个元素取一个，这里取到1,3,5,7,9
# print(nums[::1])  #取所有的元素,1就是没个元素都取
# print(nums[::-2])  #步长为负数的情况下是从后往前取
# print(nums[8:1:-2])

# nums=[1,2,3,4,5,6,7,8,9]
# nums.pop(-3)
# # del nums(6)
# del nums[-3]
# nums.remove(6)#星星说下标
# nums.remove(7)
# nums.remove('7')
# name='大雷'
# name[0]='小'
# print(name)
# names=
# password=['','']['','']
#
#
# nums=[1,2,3,4,5,6,7,8,9]
# print(nums[4:7])
i='d'
if i in ['a','b']:
    print('yes')
else:
    print('no')



# nums.append(10)
# nums.insert(-1,10)
# print(nums)

