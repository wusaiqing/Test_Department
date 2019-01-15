#include "stdafx.h"

#include "CounterTest.h"
#include "Counter.h"

// �����TestSuiteע�ᵽ����Ϊ"CounterTest"�Ĺ�����
CPPUNIT_TEST_SUITE_NAMED_REGISTRATION( IsCodeLineTest,"CounterTest" );

#define RET_OK 0
#define RET_FAIL 1

void IsCodeLineTest::Test1()
{
     //�����������
	int bIsComment;
	CString  szFileLine;

	//�����������
	int iOkReturn;
	int iOkIsComment;

	//�������ʵ�����
	int iResult;
	
	CCounter m_counter;

	//��������
	szFileLine = "int a";
	bIsComment = false;

	//�������
	iOkReturn = RET_OK;
	iOkIsComment = false;

	//�������⺯��
	iResult = m_counter.IsCodeLine(szFileLine,bIsComment);

	//����Ƚ�
	CPPUNIT_ASSERT_EQUAL(iOkReturn,iResult);
	CPPUNIT_ASSERT_EQUAL(iOkIsComment,bIsComment);
}

void IsCodeLineTest::addTest(void)
{
	int a = 1, b = 2;
	int c = 0;

	c = add(a ,b);

	CPPUNIT_ASSERT_EQUAL(2, c);
}