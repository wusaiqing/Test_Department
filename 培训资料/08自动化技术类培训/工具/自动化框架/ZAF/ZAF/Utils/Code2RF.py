#!/bin/python
#coding:utf-8

def m(s):
    return s.split('def ')[1].split('(')[0].strip()

def z(s):
    t1 = s.split('.')[1].split(')')[0]
    kp = t1.split('(')
    k = kp[0].replace('_', ' ')
    if kp[1].strip():
        ps = kp[1].split(',')
        ps =  ['${%s}'%i.strip() for i in ps]
        return '    %s    %s' % (k, '    '.join(ps))
    else:
        return  '    '+k

kw = {
        'def': m,
        '.': z,
      }

def foo(fn):
    rl = []
    with open(fn, 'r') as f:
        for l in f:
            # print l
            for i in kw:
                if i in l:
                    r = kw[i](l)
                    print r
                    rl.append(r+'\n')
    return rl

def fr(fn, r):
    f = open(r'Temp.txt', 'r')
    lines = f.readlines()
    f.close()
    lines.extend(r)
    f = open(fn, 'w')
    f.writelines(lines)
    f.close()

if __name__=='__main__':
    r = foo(r'code.txt')
    fr('rf.txt', r)
