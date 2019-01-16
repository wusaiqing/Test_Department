import time
import sys

from conf.setting import LOG_PATH
import os
class WriteLog(object):
    def __init__(self):
        today = time.strftime('%Y%m%d')
        file_name = 'atp.log_'+today
        # atp.log_20170717
        self.file = open(os.path.join(LOG_PATH,file_name),'a+')
    def write_log(self,content):
        self.file.write(time.strftime('%Y%m%d%H%M%S')+'  '+content+'\n')
    def __del__(self):
        self.file.close()
w = WriteLog()