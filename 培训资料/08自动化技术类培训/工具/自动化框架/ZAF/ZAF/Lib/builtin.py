#encoding: utf-8
from robot.libraries.BuiltIn import BuiltIn as B

class BuiltIn():
    def __init__(self):
        self.builtin = B()

    def wait(self, s):
        self.builtin.sleep(s)

    def log(self, msg):
        self.builtin.log(msg)

    def check_equal(self, actual, expect, msg=u''):
        print actual
        print expect
        self.builtin.should_be_equal(actual, expect, msg)

    def check_not_equal(self, actual, expect, msg=u''):
        print actual
        print expect
        self.builtin.should_not_be_equal(actual, expect, msg)

    def add(self, i, j):
        return int(i)+int(j)

if __name__=='__main__':
    b = BuiltIn()
    b.log('hello world')
