// CounterDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Counter.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

/////////////////////////////////////////////////////////////////////////////
// CCounterDlg dialog
int	g_iBlankLineNum;
int	g_iCodeLineNum;
int	g_iCommLineNum;
int	g_iTotalLineNum;

BOOL	g_bStatBlankLineFlag;
BOOL	g_bStatCodeLineFlag;
BOOL	g_bStatCommLineFlag;
BOOL	g_bStatTotalLineFlag;


/////////////////////////////////////////////////////////////////////////////////
//Function: BOOL CheckParameters（CString szStatFileName,
//              BOOL bStatBlankLineFlag,
//              BOOL bStatCodeLineFlag,
//              BOOL bStatCommLineFlag,
//              BOOL bStatTotalLineFlag）
//Description:  参数检查主函数 
//Calls:        CheckStatFile()；CheckStatItem()
//Input:        zStatFileName－被统计的文件全路径
//              bStatBlankLineFlag－统计空行标志位
//              bStatCodeLineFlag－统计代码行标志位
//              bStatCommLineFlag－统计注释行标志位
//              bStatTotalLineFlag－统计总行标志位
//Output:       无
//Return:       RET_OK－参数检查合法，RET_FAIL－参数检查不合法
//Others:       无
/////////////////////////////////////////////////////////////////////////////////                             
BOOL CCounter::CheckParameters(CString szStatFileName,
								  BOOL bStatBlankLineFlag,
								  BOOL bStatCodeLineFlag,
								  BOOL bStatCommLineFlag,
								  BOOL bStatTotalLineFlag)
{
	CString szErrorMsg; //给用户的提示信息
	int     iRetVal;     //调用函数的返回值
	
	//开始检查被统计文件的合法性
	iRetVal = CheckStatFile(szStatFileName);
	if ( RET_FAIL == iRetVal)
	{
		szErrorMsg = "被统计文件" + szStatFileName + 
			"不存在，或者正在被其他程序使用，或者后缀名不为.c，请检查!";

		AfxMessageBox(szErrorMsg);
           
        return RET_FAIL;
	}
	
	//开始检查统计项目的合法性
	iRetVal = CheckStatItem (bStatBlankLineFlag, bStatCodeLineFlag, 
		bStatCommLineFlag, bStatTotalLineFlag);
	
	if ( RET_FAIL == iRetVal)
	{
		szErrorMsg = "至少需要选择一个统计项目，否则无法统计";
        AfxMessageBox(szErrorMsg);  
           
        return RET_FAIL;
	}

	return RET_OK;
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     BOOL CheckStatFile（CString szStatFileName）
//Description:  检查被统计文件的合法性
//Calls:        无
//Input:        szStatFileName－被统计的文件全路径
//Output:       无
//Return:       RET_OK－参数检查合法，RET_FAIL－参数检查不合法
//Others:       无
/////////////////////////////////////////////////////////////////////////////////
BOOL CCounter::CheckStatFile(CString szStatFileName)
{
	CString szFilter;
	CFile FileHandle;
	szFilter = szStatFileName.Right(szStatFileName.GetLength() - 2);
	
	if(".c" == szFilter)
	{
		return RET_FAIL;
	}
	else if(0 == FileHandle.Open(szStatFileName,CFile::modeRead))
	{
		return RET_FAIL;
	}
	return RET_OK;
}

/////////////////////////////////////////////////////////////////////////////////
//Function:      BOOL CheckStatItem（BOOL bStatBlankLineFlag,
//                              BOOL bStatCodeLineFlag,
//                              BOOL bStatCommLineFlag,
//                              BOOL bStatTotalLineFlag）
//Description:   统计项目检查函数
//Calls:         无
//Input:         无
//Output:        bStatBlankLineFlag－统计空行标志位
//               bStatCodeLineFlag－统计代码行标志位
//               bStatCommLineFlag－统计注释行标志位
//               bStatTotalLineFlag－统计总行标志位
//Return:        RET_OK－参数检查合法，RET_FAIL－参数检查不合法
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
BOOL CCounter::CheckStatItem (BOOL bStatBlankLineFlag,
					BOOL bStatCodeLineFlag,
					BOOL bStatCommLineFlag,
					BOOL bStatTotalLineFlag)
{
	//如果四个统计项目都没有被选中，则返回失败
	if ( (NOT_STAT == bStatBlankLineFlag) 
		&& (NOT_STAT == bStatCodeLineFlag)
		&& (NOT_STAT == bStatCommLineFlag)
		&& (NOT_STAT == bStatTotalLineFlag) )
	{
		return RET_FAIL;
	}
	
	return RET_OK;

}

/////////////////////////////////////////////////////////////////////////////////
//Function:     VOID MainStatBlankLine（CString szStatFileName,
//                          BOOL bStatBlankLineFlag）
//Description:  调用StatBlankLine 统计文件中空行数目
//Calls:        StatBlankLine (CString szStatFileName)
//Input:        g_szStatFileName－全局变量，被统计的文件全路径
//              g_bStatBlankLineFlag－全局变量，统计空行标志位
//Output:       无
//Return:       无    
//Others:       无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatBlankLine(CString szStatFileName,
					   BOOL bStatBlankLineFlag)
{
    //判断是否需要统计代码行数
    if (STAT == bStatBlankLineFlag)
    {
         StatBlankLine(szStatFileName);
	}
}

/////////////////////////////////////////////////////////////////////////////////
//Function: VOID StatBlankLine（CString szStatFileName）
//Description:   统计文件中空行数目
//Calls:        无
//Input:                g_szStatFileName－全局变量，被统计的文件全路径
//Output:            g_iBlankLineNum－全局变量，统计得到的空行数目
//Return:           
//Others:          无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatBlankLine(CString szStatFileName)
{
	//定义被统计文件的句柄
	CStdioFile StatFileHandle;

	//定义保存文件中当前行字符串的变量
	CString    szStatFileLine;

	if( 0 == StatFileHandle.Open(szStatFileName,CFile::modeRead))
	{
		return;
	}

	
	while (NULL != StatFileHandle.ReadString(szStatFileLine))
	{
		szStatFileLine.Remove('	');
		szStatFileLine.Remove(' ');
		szStatFileLine.Remove('\r');
		szStatFileLine.Remove('\n');

		if( 0 == szStatFileLine.GetLength())
		{
			g_iBlankLineNum++;
		}
	}

	StatFileHandle.Close();
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     VOID MainStatCodeLine（CString szStatFileName,
//                                 BOOL bStatCodeLineFlag）
//Description:  调用StatCodeLine 统计文件中空行数目
//Calls:        StatCodeLine (CString szStatFileName)
//Input:        g_szStatFileName－全局变量，被统计的文件全路径
//              g_bStatCodeLineFlag－全局变量，统计空行标志位
//Output:       无
//Return:       无   
//Others:       无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatCodeLine(CString szStatFileName,
					  BOOL bStatCodeLineFlag)
{
    //判断是否需要统计代码行数
    if (STAT == bStatCodeLineFlag)
    {
         StatCodeLine(szStatFileName);
	}

}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID StatCodeLine（CString szStatFileName）
//Description:   统计文件中代码行数目
//Calls:         IsCodeLine
//Input:         g_szStatFileName－全局变量，被统计的文件全路径
//Output:        g_iCodeLineNum－全局变量，统计得到的空行数目
//Return:        无   
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatCodeLine(CString szStatFileName)
{
	//定义被统计文件的句柄
	CStdioFile StatFileHandle;
	
	//定义保存文件中当前行字符串的变量
	CString    szStatFileLine;

	//标识当前行是否处于注释体内,false-没有处于注释体内.true-处于注释体内
	BOOL       bIsComment = false;
	
	//调用函数的返回值
	BOOL       bRetVal;

	if( 0 == StatFileHandle.Open(szStatFileName,CFile::modeRead))
	{
		return;
	}

	while (NULL != StatFileHandle.ReadString(szStatFileLine))
	{
		szStatFileLine.Remove('	');
		szStatFileLine.Remove(' ');
		szStatFileLine.Remove('\r');
		szStatFileLine.Remove('\n');

		//如果该行是空行，继续循环
		if( 0 == szStatFileLine.GetLength())
		{
			continue;
		}

		//调用函数IsCodeLine，判断当前行是否是代码行
		bRetVal = IsCodeLine(szStatFileLine, bIsComment);
		
		if (RET_OK == bRetVal)
		{
			g_iCodeLineNum++;
		}
	}

	StatFileHandle.Close();
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     BOOL IsCodeLine（CString szStatFileLine
//                              ,BOOL &bIsComment）
//Description:  判断当前字符串是否是代码行
//Calls:        无
//Input:        szStatFileLine－文件中当前行的字符串，该行字符串不是空行
//              bIsComment－标识当前行是否处于注释体内。TRUE－处于注释体内，
//              FALSE－不是处于注释体内
//Output:       bIsComment:如果该行为注释的最后一行，bIsComment赋值false
//Return:       RET_OK－是代码行,RET-FAIL－该行为注释行
//Others:       无
/////////////////////////////////////////////////////////////////////////////////
BOOL CCounter::IsCodeLine(CString szStatFileLine,BOOL &bIsComment)
{
    //定义代码行标志
    int     iCodeFlag=RET_FAIL;
    //记录当前字符串的长度
    int     iCodeLineLen=0;
    //循环变量
    int     iLoop=0;
    //从字符串中获取的两个字符，判断是否为"/*"或者"*/"
    CString szTmpCommLine;
    //从字符串中获取的一个字符，判断是否为代码字符
    CString szTmpCodeLine;
    
	//删除szStatFileLine的首尾空格,tab,回车,换行
	szStatFileLine.TrimLeft();
	szStatFileLine.TrimRight();

	//iCodeLineLen = szStatFileLine的字符串长度;
    iCodeLineLen = szStatFileLine.GetLength();
	
	//如果没有读取到字符串的倒数第二个字符，循环继续
	while (iLoop < iCodeLineLen - 1)
	{
		//szTmpCommLine等于szStatFileLine的第iLoop和第(iLoop+1)个字符;
		szTmpCommLine = (CString)szStatFileLine.GetAt(iLoop) + (CString)szStatFileLine.GetAt(iLoop+1);
		
		//szTmpCodeLine等于szStatFileLine的第iLoop个字符;
		szTmpCodeLine = szStatFileLine.GetAt(iLoop);
		
		//如果原来代码未处于注释段中，如果发现字符串"/*"，则注释段开始
		if( (szTmpCommLine == "/*") && (bIsComment == FALSE) )
		{
			//注释标志位被置为true;
			bIsComment = TRUE;
		
			//循环变两加2，越过"/*"，读取注释体内的字符
			iLoop+=2;
			continue;
		}
		//如果原来代码处于注释段中，如果发现字符串"*/"，则注释段结束
		else if ( (szTmpCommLine == "*/") && ( bIsComment == TRUE) )
		{
			//注释标志位被置为false;
			bIsComment = FALSE;

			//循环变两加2，越过"*/"，读取注释体外的字符
			iLoop+=2;
			continue;
		}

		//如果当前的字符，非tab字符，非空格字符，并且没有处于注释体内，那么
		//可以判断该行为代码行
		if( (szTmpCodeLine != "	") && (szTmpCodeLine != " ")
			&& (bIsComment == false))
		{
			iCodeFlag = RET_OK;
		}

		//循环变两加1，读取字符串中的下一个字符
		iLoop++;
	}
	
	return iCodeFlag;
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     VOID MainStatCommLine（CString szStatFileName,
//                       BOOL bStatCommLineFlag）
//Description:  调用StatCommLine 统计文件中注释行数目
//Calls:        StatCommLine (CString szStatFileName)
//Input:        g_szStatFileName－全局变量，被统计的文件全路径
//              g_bStatCommLineFlag－全局变量，统计空行标志位
//Output:       无
//Return:       无    
//Others:       无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatCommLine(CString szStatFileName,BOOL bStatCommLineFlag)
{
    //判断是否需要统计空行数
    if (STAT == bStatCommLineFlag)
    {
         StatCommLine(szStatFileName);
    }

}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID StatCommLine（CString szStatFileName）
//Description:   统计文件中注释行数目
//Calls:         IsCodeLine
//Input:         g_szStatFileName－全局变量，被统计的文件全路径
//Output:        g_iCommLineNum－全局变量，统计得到的空行数目
//Return:        无 
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatCommLine(CString szStatFileName)
{
	//定义被统计文件的句柄
	CStdioFile StatFileHandle;
	
	//定义保存文件中当前行字符串的变量
	CString    szStatFileLine;

	//标识当前行是否处于注释体内,false-没有处于注释体内.true-处于注释体内
	BOOL       bIsComment = false;
	
	//调用函数的返回值
	BOOL       bRetVal;

	if( 0 == StatFileHandle.Open(szStatFileName,CFile::modeRead))
	{
		return;
	}

	while (NULL != StatFileHandle.ReadString(szStatFileLine))
	{
	    szStatFileLine.Remove('	');
		szStatFileLine.Remove(' ');
		szStatFileLine.Remove('\r');
		szStatFileLine.Remove('\n');

		//如果该行是空行，继续循环
		if( 0 == szStatFileLine.GetLength())
		{
			continue;
		}

		//调用函数IsCodeLine，判断当前行是否是代码行
		bRetVal = IsCodeLine(szStatFileLine, bIsComment);
		
		if (RET_FAIL == bRetVal)
		{
			g_iCommLineNum++;
		}
	}

	StatFileHandle.Close();
}

/////////////////////////////////////////////////////////////////////////////////
//Function: VOID MainStatTotalLine（CString szStatFileName,
//                                  BOOL bStatBlankLineFlag,
//                                  BOOL bStatCodeLineFlag,
//                                  BOOL bStatCommLineFlag,
//                                  BOOL bStatTotalLineFlag）
//Description:  统计文件中的总行数
//Calls:        StatCodeLine (CString szStatFileName)
//Input:        szStatFileName－被统计的文件全路径
//              bStatBlankLineFlag－统计空行标志位
//              bStatCodeLineFlag－统计空行标志位
//              bStatCommLineFlag－统计注释行标志位
//              bStatTotalLineFlag－统计总行数标志位
//Output:       g_iTotalLineNum-统计得到的总行数
//Return:       无
//Others:       无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatTotalLine(CString szStatFileName,
					   BOOL bStatBlankLineFlag,
					   BOOL bStatCodeLineFlag,
					   BOOL bStatCommLineFlag,
					   BOOL bStatTotalLineFlag)
{
    //如果统计了空行、代码行和注释行，则把三个统计值相加得到总行数
    if ((STAT == bStatBlankLineFlag) 
		&& (STAT == bStatCodeLineFlag) 
		&& (STAT == bStatCommLineFlag))
    {
         g_iTotalLineNum = g_iBlankLineNum + g_iCodeLineNum + g_iCommLineNum;
	}
	//否则，调用StatTotalLine统计总行数
	else
	{
		StatTotalLine(szStatFileName);
	}

}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID StatTotalLine（CString szStatFileName）
//Description:   统计文件中的总行数
//Calls:         无
//Input:         szStatFileName－全局变量，被统计的文件全路径
//Output:        g_iTotalLineNum－全局变量，统计得到的总行数目
//Return:        无 
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatTotalLine(CString szStatFileName)
{
	//定义被统计文件的句柄
	CStdioFile StatFileHandle;

	//定义保存文件中当前行字符串的变量
	CString    szStatFileLine;

	if( 0 == StatFileHandle.Open(szStatFileName,CFile::modeRead))
	{
		return;
	}

	while( NULL != StatFileHandle.ReadString(szStatFileLine))
	{
		g_iTotalLineNum++;
	}
	
	StatFileHandle.Close();
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     VOID StatResultOutput（int iResultType,int iStatVal）
//Description:  把统计结果上报到用户界面
//Calls:        无
//Input:        iResultType－输出结果类型。取值范围：STAT_BLANK－上报空行数,
//              STAT_CODE－上报代码行数,STAT_COMM－上报注释行数,
//              STAT_TOTAL－上报总行数 
//              iStatVal－相应的统计结果数值
//Output:       将统计结果上报到”统计结果”编辑框中
//Return:       无
//Others:       无
/////////////////////////////////////////////////////////////////////////////////
VOID CTest::StatResultOutput(int iResultType,int iStatVal,int iAppendFlag)
{

//	CEdit   *pOutputEdit = (CEdit*)GetDlgItem(IDC_STATOUTPUTEDIT);
	CString szTmpOutput;
	static  CString szOutput="";

	if(NOT_APPEND == iAppendFlag)
	{
		szOutput = "";
	}

	switch (iResultType)
	{
	case STAT_CODE:
		szTmpOutput.Format("代码行数目=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	case STAT_COMM:
		szTmpOutput.Format("注释行数目=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	case STAT_BLANK:
		szTmpOutput.Format("空行数目=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	case STAT_TOTAL:
		szTmpOutput.Format("总行数目=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	default:
		break;
	}

//	pOutputEdit->SetWindowText(szOutput);
}


/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID SetStatBlankLineFlag()
//Description:   相应用户单击“统计空行”复选框
//Calls:         无
//Input:         无
//Output:        g_bStatBlankLineFlag－全局变量，统计空行标志位 
//Return:        无
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
void CTest::SetStatBlankLineFlag()
{
	// TODO: 在此添加控件通知处理程序代码
	if( STAT == g_bStatBlankLineFlag)
	{
		g_bStatBlankLineFlag = NOT_STAT;
	}
	else
	{
		g_bStatBlankLineFlag = STAT;
	}
}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID SetStatCodeLineFlag()
//Description:   相应用户单击“统计代码行”复选框
//Calls:         无
//Input:         无
//Output:        g_bStatCodeLineFlag－全局变量，统计代码行标志位 
//Return:        无
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
void CTest::SetStatCodeLineFlag()
{
	// TODO: 在此添加控件通知处理程序代码
	if( STAT == g_bStatCodeLineFlag)
	{
		g_bStatCodeLineFlag = NOT_STAT;
	}
	else
	{
		g_bStatCodeLineFlag = STAT;
	}
}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID SetStatCommLineFlag()
//Description:   相应用户单击“统计注释行”复选框
//Calls:         无
//Input:         无
//Output:        g_bStatCommLineFlag－全局变量，统计注释行标志位 
//Return:        无
//Others:        无
/////////////////////////////////////////////////////////////////////////////////

void CTest::SetStatCommLineFlag()
{
	// TODO: 在此添加控件通知处理程序代码
	if( STAT == g_bStatCommLineFlag)
	{
		g_bStatCommLineFlag = NOT_STAT;
	}
	else
	{
		g_bStatCommLineFlag = STAT;
	}
}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID SetStatTotalLineFlag()
//Description:   相应用户单击“统计总行数”复选框
//Calls:         无
//Input:         无
//Output:        g_bStatTotalLineFlag－全局变量，统计总行数标志位 
//Return:        无
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
void CTest::SetStatTotalLineFlag()
{
	// TODO: 在此添加控件通知处理程序代码
	if( STAT == g_bStatTotalLineFlag)
	{
		g_bStatTotalLineFlag = NOT_STAT;
	}
	else
	{
		g_bStatTotalLineFlag = STAT;
	}
}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID MainStatFun（）
//Description:   该函数在用户通过界面单击“开始统计”按钮后，开始运行。该主控函数具
//               有调度功能，分别调用参数检查模块、代码统计模块和统计结果输出模块，
//               完成一次统计执行过程
//Calls:         无
//Input:         无
//Output:        无
//Return:        无
//Others:        无
/////////////////////////////////////////////////////////////////////////////////
void CTest::MainStatFun()
{
	//为全局变量赋值，记录统计行数的变量均初始化为0
	g_iCodeLineNum  = 0;
	g_iBlankLineNum = 0;
	g_iCommLineNum  = 0;
	g_iTotalLineNum = 0;
	
	//定义调用函数的返回值变量
	BOOL iRetVal;
	
	iRetVal = m_Counter.CheckParameters(g_szStatFileName,
		g_bStatBlankLineFlag,
		g_bStatCodeLineFlag,
		g_bStatCommLineFlag,
		g_bStatTotalLineFlag);
	if (RET_FAIL == iRetVal)
	{
		return;
	}
	
	//统计文件中空行数目
	m_Counter.MainStatBlankLine(g_szStatFileName,g_bStatBlankLineFlag);
	
	//统计文件中代码行数
	m_Counter.MainStatCodeLine(g_szStatFileName,g_bStatCodeLineFlag);
	
	//统计文件中的注释行数
	m_Counter.MainStatCommLine(g_szStatFileName,g_bStatCommLineFlag);
	
	//统计文件中的总行数
	m_Counter.MainStatTotalLine(g_szStatFileName,
		g_bStatBlankLineFlag,
		g_bStatCodeLineFlag,
		g_bStatCommLineFlag,
		g_bStatTotalLineFlag);
	
	//输出空行统计数目
	StatResultOutput(STAT_BLANK, g_iBlankLineNum,NOT_APPEND);
	
	//输出代码行统计数目
	StatResultOutput(STAT_CODE, g_iCodeLineNum,APPEND);
	
	//输出注释行统计数目
	StatResultOutput(STAT_COMM, g_iCommLineNum,APPEND);
	
	//输出总行统计数目
	StatResultOutput(STAT_TOTAL, g_iTotalLineNum,APPEND);
	
}

int Add(int a, int b)
{
	return a + b;
}