// MyTest.cpp : Defines the class behaviors for the application.
//

#include "stdafx.h"
#include "MyTest.h"
#include "MyTestDlg.h"
#include <cppunit/extensions/TestFactoryRegistry.h>
#include <cppunit/ui/mfc/TestRunner.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMyTestApp

BEGIN_MESSAGE_MAP(CMyTestApp, CWinApp)
	//{{AFX_MSG_MAP(CMyTestApp)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMyTestApp construction

CMyTestApp::CMyTestApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CMyTestApp object

CMyTestApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CMyTestApp initialization

BOOL CMyTestApp::InitInstance()
{
	AfxEnableControlContainer();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif
/*
	CMyTestDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with Cancel
	}
*/

    	//添加CppUnit的MFC类型的测试执行器
	CppUnit::MfcUi::TestRunner runner; 

	//为被测试类（这里是CCounter）定义一个测试工厂(这里取名叫CounterTest):
	CppUnit::TestFactoryRegistry &registry
                          = CppUnit::TestFactoryRegistry::getRegistry("CounterTest");

	//并将工厂添加到测试执行器中
    runner.addTest( registry.makeTest() );

	//运行执行器，显示执行器GUI界面
	runner.run(); 



	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
