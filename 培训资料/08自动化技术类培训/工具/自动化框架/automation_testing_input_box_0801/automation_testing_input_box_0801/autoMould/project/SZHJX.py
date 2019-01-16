#coding:utf-8

#input_box输入框定位
locator_method_sheet2 = '''jquery=div:contains('%s')+input'''
locator_method_sheet1 = '''jquery=span:contains('%s')+input'''
#错误验证定位
err_msg_locator_method = '''Xpath=//div[contains(text(), '%s')]/following-sibling::input[1]/following-sibling::span[1]/span[1]'''
browser = "ie"
excel_sheets = [0, 1, 2]
excel_sheet_names = ['register', 'login', 'personal info']

def get_locator_method(sheet_index):
    if sheet_index == 0:
        locator_method = locator_method_sheet1
    else:
        locator_method = locator_method_sheet2
    return locator_method





