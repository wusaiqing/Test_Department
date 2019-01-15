// MyTest.h : main header file for the MYTEST application
//

#if !defined(AFX_MYTEST_H__B7A373C6_1A9C_401F_80E5_4D3446D4D27E__INCLUDED_)
#define AFX_MYTEST_H__B7A373C6_1A9C_401F_80E5_4D3446D4D27E__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CMyTestApp:
// See MyTest.cpp for the implementation of this class
//

class CMyTestApp : public CWinApp
{
public:
	CMyTestApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMyTestApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CMyTestApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MYTEST_H__B7A373C6_1A9C_401F_80E5_4D3446D4D27E__INCLUDED_)
