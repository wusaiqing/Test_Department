import os,sys
ads_path=os.path.abspath(__file__)
ppath=os.path.dirname(ads_path)
pppath=os.path.dirname(ppath)
sys.path.insert(0,pppath)
from lib.lib import run
run()