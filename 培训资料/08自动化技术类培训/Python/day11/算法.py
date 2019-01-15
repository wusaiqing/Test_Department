#递归
# def fun(x):
#     if x>0:
#         fun(x-1)
#         print(x)
# fun(2)

# print(4/2)
# lis=[
# {'id':1001, 'name':"张三", 'age':20},
# {'id':1002, 'name':"李四",'age':25},
# {'id':1003, 'name':"李四2",'age':25},
# {'id':1004, 'name':"王五", 'age':23},
# {'id':1005, 'name':"王五2", 'age':23},
# {'id':1006, 'name':"王五3", 'age':23},
# {'id':1007, 'name':"王五4", 'age':23},
# {'id':1008, 'name':"王五5", 'age':23},
# {'id':1009, 'name':"王五5", 'age':23},
# {'id':10010, 'name':"王五7", 'age':23},
# {'id':10011, 'name':"王五8", 'age':23},
# {'id':10012, 'name':"赵六", 'age':33}
# ]


#二分叉
# def select_stu(list,id):
#     low=0
#     high=len(list)-1
#     while low<=high:
#         mid=int((low+high)/2) #用low+high)//2就不需要转换了，//去掉小数
#         if lis[mid]['id']==id:
#             return lis[mid]['id'],lis[mid]['name'],lis[mid]['age']
#         elif lis[mid]['id']>id:
#             high=mid-1
#         elif lis[mid]['id']<id:
#             low=mid+1
#         else:
#             return '不存在'
# print(select_stu(lis,1001))

# lis=[6,11,3,9,8,9,2,4,5,7,8,7,4]

#冒泡排序,自己写的冗余了
# lis=[11,3,9,8,9,2,4,5,7,8,7,4]
# for i in range(len(lis)):
#     for j in range(i,len(lis)):
#         if lis[i]>lis[j]:
#             lis[i],lis[j]=lis[j],lis[i]

#冒泡排序，正确的冒泡排序
# for i in range(len(lis)-1):
#     for j in range(len(lis)-i-1):
#         if lis[j]<lis[j+1]:
#             lis[j],lis[j+1]=lis[j+1],lis[j]

# lis=[11, 9, 9, 8, 8, 7, 7, 5, 4, 4, 3, 2]
#冒泡排序，优化，如果没有交换两个参数，那么说明排序就是正确的
# for i in range(len(lis)-1):
#     for j in range(len(lis)-i-1):
#         flg=True
#         if lis[j]<lis[j+1]:
#             lis[j],lis[j+1]=lis[j+1],lis[j]
#             flg=False
#         if flg:
#             print(lis)
#             exit('提前结束')

#选择排序，选出最小的数，放左边，然后选出剩下数组的最小数，放左边，依次选下去
# lis=[11,3,9,8,9,2,4,5,7,8,7,4]
# for i in range(len(lis)-1):
#     min_var=i
#     for j in range(i+1,len(lis)):
#         if lis[j]<lis[min_var]:
#             min_var = j
#     if min_var!=i:
#         lis[min_var],lis[i]=lis[i],lis[min_var]
# print(lis)
#自己捣鼓的
# for i in range(len(lis)-1):
#     min_data = lis[i]
#     for j in range(i+1,len(lis)):
#         if lis[j]<min_data:
#             lis[j],min_data=min_data,lis[j]
#         lis[i]=min_data
# for i in range(len(lis)-1):
#     min_data = i
#     for j in range(i+1,len(lis)):
#         if lis[j]<lis[min_data]:
#             min_data=j
#         lis[i],lis[min_data]=lis[min_data],lis[i]
# print(lis)

#插入排序，有序区和无序区，第一个元素为有序区，其他元素为无序区，从无序区调一个元素到有序区，进行插入排序，直到无序区没有数据
#冒泡排序+插入排序，不是正宗的插入排序
# lis=[11,3,9,8,9,2,4,5,7,8,7,4]
# for i in range(len(lis)-1):
#     for j in range(i+1,len(lis)):
#         for k in range(j):
#             if lis[k]>lis[j]:
#                 lis[k], lis[j] = lis[j], lis[k]
# print(lis)

#自己捣鼓的插入排序
# def insert_sort(lis):
#     for i in  range(len(lis)-1):
#         tmp=lis[i+1]
#         while i>=0 and lis[i] > tmp:
#             lis[i+1]=lis[i]
#             i-=1
#         lis[i+1]=tmp
#     return lis
# print(insert_sort(lis))

#使用list的pop属性的插入排序
# def insert_sort(lis):
#     for i in  range(len(lis)-1):
#         tmp=lis.pop(i+1)
#         while i>=0 and lis[i] > tmp:
#             i-=1
#         lis.insert(i+1,tmp)
#     return lis
# print(insert_sort(lis))

# lis=[6,11,3,9,8,9,2,4,5,7,8,7,4]
#使用二分叉的插入排序
# def insert_sort(lis):
#     for i in  range(len(lis)-1):
#         tmp=lis.pop(i+1)
#         low=0
#         high=i
#         while low<=high:
#             mid=(low+high)//2
#             if lis[mid]>=tmp:
#                 high=mid-1
#             elif lis[mid]<=tmp:
#                 low=mid+1
#         if lis[mid] >= tmp:
#             lis.insert(mid, tmp)
#         else:
#             lis.insert(mid+1, tmp)
#     return lis
# print(insert_sort(lis))

# 正宗的插入排序：依次取出无序区的元素和有序区的元素对比(从末尾比对到最前面)，如过元素大于有序区末尾元素，那么在有序区后面添加取出的元素；
# 否则添加元素为之前的末尾元素，取出的元素继续与前面的元素比，一直执行下去。
# lis=[11,3,9,8,9,2,4,5,7,8,7,4]
# for i in range(1,len(lis)):
#     tmp=lis[i]
#     j=i-1
#     while j >=0 and lis[j]>tmp:
#         lis[j+1]=lis[j]
#         j-=1
#     lis[j+1]=tmp
# print(lis)


#快速排序
#1.归位，先把第一个元素拿出来，用一个临时变量tmp存储，接下来需要把大的放右边，小的放左边
#2.lit[-1]和tmp比较，如果lit[-1]>tmp,继续比较lit[-2]和tmp，如果lit[-2]<=tmp,那么需要把lit[-2]放到之前tmp的位置0，即lis[0]=lit[-2]
#3.上面把lis[-2]这个提前面来了，那么，lis[-2]这个位置空粗来了，需要找一个比tmp大的数填进去
#4.lis[0]后面就开始比较lis[1]和ltmp了，如果lit[1]<tmp，那么lit[1]不用动，接着比较lis[2]与tmp，如果lit[2]>tmp,那么把lit[2]放到之前lis[-2]这个位置
#5.现在lis[2]这个位置空出来了，那么需要找一个比tmp小的数塞进去，就从lis[-3]开始找，重复234的步骤，一直找下去，直到都比对完成，最后把拿出来的tmp再塞回去
#6.塞tmp，当最后只剩下一个位置的时候，那这个位置就是tmp的，这个位置下标是多少呢？6
#比如lis=[6,11,3,9,8]，那么比对完成的结果是：lis=[3,11,11,9,8]  塞进去的位置就是1
#7.上面的过程就是归位，这个步骤完成后，就需要左边的再来一次上述的步骤，右边再来一次上述的步骤，也就是递归，一直递归下去，直到下标重合，也就是左下标等于右下标
lis=[6,11,3,9,8,9,2,4,5,7,8,7,4]
def quick_sort(lis,left,right):
    if left<right:
        mid=partition(lis,left,right)
        quick_sort(lis, left, mid-1)
        quick_sort(lis, mid+1, right)
# def partition(lis,left,right):
    # if left<right:












