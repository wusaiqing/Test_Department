#include "cppunit/extensions/HelperMacros.h"

class IsCodeLineTest : public CppUnit::TestFixture {
	// 声明一个TestSuite
	CPPUNIT_TEST_SUITE( IsCodeLineTest);
	// 添加测试用例到TestSuite, 定义新的测试用例需要在这儿声明一下
	CPPUNIT_TEST( Counter_UT_IsCodeLine_001);

	CPPUNIT_TEST(addTest);
	// TestSuite声明完成
	CPPUNIT_TEST_SUITE_END();
	

public:
	// 定义测试用例
	void Counter_UT_IsCodeLine_001();
	void addTest();
};
