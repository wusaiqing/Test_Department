import time
def stamp_to_format(a):
    time_tuple=time.gmtime(a) #时间戳转换成时间元祖
    format_time=time.strftime('%Y%m%d %H%M%S',time_tuple)   #时间元祖转换成格式化时间
    return format_time

def format_to_stamp(format_time):
    time_tuple=time.strptime(format_time,'%Y%m%d') #格式化时间转换成时间元祖
    stamp_time=time.mktime(time_tuple)   #时间元祖转换成时间戳
    return stamp_time

print(format_to_stamp('20180101'))