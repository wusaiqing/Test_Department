#include "stdafx.h"

#include "CounterTest.h"
#include "..\counter\counter.h"

// 把这个TestSuite注册到名字为"CounterTest"的工厂中
CPPUNIT_TEST_SUITE_NAMED_REGISTRATION( IsCodeLineTest,"CounterTest" );

#define RET_OK 0
#define RET_FAIL 1

void IsCodeLineTest::Counter_UT_IsCodeLine_001()
{
    //定义输入参数
	int bIsComment;
	CString  szFileLine;

	//定义期望输出
	int iOkReturn;
	int iOkIsComment;

	//定义测试实际输出
	int iResult;
	
	CCounter m_counter;

	//用例输入
	szFileLine = "int a";
	bIsComment = false;

	//期望输出
	iOkReturn = RET_OK;
	iOkIsComment = false;
	//驱动被测函数
	iResult = m_counter.IsCodeLine(szFileLine,bIsComment);

	//结果比较
	CPPUNIT_ASSERT_EQUAL(iOkReturn,iResult);
	CPPUNIT_ASSERT_EQUAL(iOkIsComment,bIsComment);
}

void IsCodeLineTest::addTest()
{
	int a = 1, b = 2;
	int c = 0;

	c = Add(a, b);

	CPPUNIT_ASSERT_EQUAL(2,c);
}
