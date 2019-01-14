# -*- coding: cp936 -*-
import logging,os,time,traceback
class LOG:
    def __init__(self,logger):
        self.fileHandlerName = ''
        self.fileHandler = None
        self.loggerName = logger
        self.logger = logging.getLogger(logger)
        self.logger.setLevel(logging.DEBUG)
        self.formatter = logging.Formatter("========================\ntime:%(asctime)s \nlogger:%(name)s \nlevel:%(levelname)s \nfile:%(filename)s \nfun:%(funcName)s \nlineno:%(lineno)d \nmessage:%(message)s")

        # ����̨
        ch = logging.StreamHandler()
        ch.setLevel(logging.DEBUG)
        ch.setFormatter(self.formatter)
        self.logger.addHandler(ch)

        path = os.path.abspath(os.path.dirname(__file__)) + '/log/'
       # print 'log path=',path

    def setfh(self):
        fname = time.strftime("%Y%m%d%H")
        if fname!=self.fileHandlerName:
        #�Ƴ�ԭ���ľ��
            if self.fileHandler!=None :
                self.logger.removeHandler(self.fileHandler)
                #������־�ļ�����λ��
            path = os.path.abspath(os.path.dirname(__file__)) + '/log/'
            print path
            if os.path.isdir(path) == False:
                os.makedirs(path)
            fh = logging.FileHandler(path+fname+'.log')
            fh.setLevel(logging.DEBUG)
            fh.setFormatter(self.formatter)
            self.logger.addHandler(fh)

            self.fileHandlerName = fname
            self.fileHandler = fh
            #��ʽ����־����
    def _fmtInfo(self,msg):
        if len(msg)==0:
            msg = traceback.format_exc()
            return msg
        else:
            _tmp = [msg[0]]
            _tmp.append(traceback.format_exc())
            return '\n**********\n'.join(_tmp)
            #��װ����
    def debug(self,*msg):
        _info = self._fmtInfo(msg)
        try:
            self.setfh()
            self.logger.debug(_info)
        except:
            print 'mylog debug:' + _info
    def error(self,*msg):
        _info = self._fmtInfo(msg)
        try:
            self.setfh()
            self.logger.error(_info)
        except:
            print 'mylog error:' + _info
    def info(self,*msg):
        _info = self._fmtInfo(msg)
        try:
            self.setfh()
            self.logger.info(_info)
        except:
            print 'mylog info:' + _info
    def warning(self,*msg):
        _info = self._fmtInfo(msg)
        try:
            self.setfh()
            self.logger.warning(_info)
        except:
            print 'mylog warning:' + _info

class WrLog:
    def wrlog(self,message):
        logger=logging.getLogger()
        filename=time.strftime("%Y%m%d%H")
        hdlr=logging.FileHandler("./log/"+filename+'.log')
        formatter=logging.Formatter('time:%(asctime)s %(filename)s[line:%(lineno)d]: %(message)s')
        hdlr.setFormatter(formatter)
        logger.addHandler(hdlr)
        logger.setLevel(logging.INFO)
        logger.info(message)
        hdlr.flush()
        logger.removeHandler(hdlr)
        hdlr.close()

if __name__=='__main__':
    log2=WrLog()
    log2.wrlog("aaaa")
    '''
    log = LOG("fight")

    try:
        print 1/0
    except:
        log.error() #ʹ��ϵͳ�Լ��Ĵ�������
        '''
'''
    try:
        print 2/0
    except:
        log.error('����ˣ���ĸ����Ϊ0') #ʹ���Լ��Ĵ�������
'''