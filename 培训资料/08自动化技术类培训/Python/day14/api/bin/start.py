# -*- coding:utf-8 -*-
import os, sys
path = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
sys.path.insert(0, path)
from lib.interface import server
from conf.settings import SERVER_HOST,SERVER_PORT
server.run(host=SERVER_HOST, port=SERVER_PORT)

