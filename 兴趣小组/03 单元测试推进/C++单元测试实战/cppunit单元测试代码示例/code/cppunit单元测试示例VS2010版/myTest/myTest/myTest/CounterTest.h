#include "cppunit/extensions/HelperMacros.h"

class IsCodeLineTest : public CppUnit::TestFixture {
	// ����һ��TestSuite
	CPPUNIT_TEST_SUITE(IsCodeLineTest);

	// ��Ӳ���������TestSuite, �����µĲ���������Ҫ���������һ��
	CPPUNIT_TEST(Test1);
	CPPUNIT_TEST(addTest);

	// TestSuite�������
	CPPUNIT_TEST_SUITE_END();
	

public:
	// �����������
	void Test1 ();
	void addTest(void);
};
