#encoding: utf-8
from win32com.client import Dispatch
from win32com import *
from robot.libraries.BuiltIn import BuiltIn
import AutoItLibrary
import win32api
class AutoIt():
    def __init__(self, timeout=60):
        self._timeout = timeout
        self.autoit = Dispatch( "AutoItX3.Control")

    def wait_for_active_window(self, title, strText=u'', timeout=None):
        t = 0
        if not timeout:
            timeout = self._timeout
        BuiltIn().log('Wait For "%s" Windows Fail in 60s')
        Result = self.autoit.WinWaitActive(title, strText, timeout)
        if Result == 0 :
            Result = "Window '%s' (%s) failed to be active in %s seconds" % (title, strText, timeout)
            raise Exception, Result

    def control_send(self, title, controlId, txt):
        # Block All Input
        self.autoit.BlockInput(1)
        self.autoit.ControlSend(strTitle=title, strText='', strControl=controlId, strSendText=txt)
        # Unblock input
        self.autoit.BlockInput(0)

    def send (self,  strSend, numMode=0):
        self.autoit.Send(strSendText=strSend, nMode=numMode)

    def control_click(self, title, controlId, btn=u'LEFT'):
        # Block All Input
        self.autoit.BlockInput(1)
        self.autoit.ControlClick(strTitle=title, strText='', strControl=controlId, strButton=btn)
        # Unblock input
        self.autoit.BlockInput(0)

    def control_double_click(self, title, controlId):
        # Block All Input
        self.autoit.BlockInput(1)
        self.autoit.ControlClick(strTitle=title, strText='', strControl=controlId, strButton=u'LEFT', nNumClicks=2)
        # Unblock input
        self.autoit.BlockInput(0)

    def run(self, fileName, workDir=u'', Flag=1):
        self.autoit.Run(fileName, workDir, Flag)

    def win_close(self, title, txt=u''):
        self.autoit.WinClose(title, txt)

    def mouse_click(self, button=u'LEFT', xpos=700, ypos=450, numClick=1):
        self.autoit.MouseClick(strButton=button, nX=xpos, nY=ypos, nClicks=numClick, nSpeed=-1)

    def win_active(self,strTitle, strText=u''):
        self.autoit.WinActive(strTitle)

    def win_wait(self, WindowTitle, WindowText="", TimeOut=-1):
        self.autoit.WinWait(WindowTitle)

    def mouse_move(self, nX, nY, nSpeed=-1):
        self.autoit.MouseMove(nX, nY, nSpeed)

    def control_focus(self, strTitle, strText, strControl):
        self.autoit.ControlFocus(strTitle, strText, strControl)

    def control_set_text(self, strTitle, strText, strControl, strControlText):
        self.autoit.ControlSetText(strTitle, strText, strControl, strControlText)
        
    def show_open_file(self, file_path):
        win32api.ShellExecute(0, 'open', file_path, '','',1)

if __name__=='__main__':
    import time
    a = AutoIt()
    a.run('calc.exe')
    time.sleep(1)
    a.wait_for_active_window(u'计算器')
    a.control_click(u'计算器', 'Button4')
    time.sleep(1)
    a.control_click(u'计算器', 'Button23')
    time.sleep(1)
    a.control_click(u'计算器', 'Button10')
    time.sleep(1)
    a.control_click(u'计算器', 'Button28')
    time.sleep(2)
    a.win_close(u'计算器')

