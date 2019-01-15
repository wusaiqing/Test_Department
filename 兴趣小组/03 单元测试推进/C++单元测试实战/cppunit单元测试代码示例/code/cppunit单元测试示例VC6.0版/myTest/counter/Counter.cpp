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
//Function: BOOL CheckParameters��CString szStatFileName,
//              BOOL bStatBlankLineFlag,
//              BOOL bStatCodeLineFlag,
//              BOOL bStatCommLineFlag,
//              BOOL bStatTotalLineFlag��
//Description:  ������������� 
//Calls:        CheckStatFile()��CheckStatItem()
//Input:        zStatFileName����ͳ�Ƶ��ļ�ȫ·��
//              bStatBlankLineFlag��ͳ�ƿ��б�־λ
//              bStatCodeLineFlag��ͳ�ƴ����б�־λ
//              bStatCommLineFlag��ͳ��ע���б�־λ
//              bStatTotalLineFlag��ͳ�����б�־λ
//Output:       ��
//Return:       RET_OK���������Ϸ���RET_FAIL��������鲻�Ϸ�
//Others:       ��
/////////////////////////////////////////////////////////////////////////////////                             
BOOL CCounter::CheckParameters(CString szStatFileName,
								  BOOL bStatBlankLineFlag,
								  BOOL bStatCodeLineFlag,
								  BOOL bStatCommLineFlag,
								  BOOL bStatTotalLineFlag)
{
	CString szErrorMsg; //���û�����ʾ��Ϣ
	int     iRetVal;     //���ú����ķ���ֵ
	
	//��ʼ��鱻ͳ���ļ��ĺϷ���
	iRetVal = CheckStatFile(szStatFileName);
	if ( RET_FAIL == iRetVal)
	{
		szErrorMsg = "��ͳ���ļ�" + szStatFileName + 
			"�����ڣ��������ڱ���������ʹ�ã����ߺ�׺����Ϊ.c������!";

		AfxMessageBox(szErrorMsg);
           
        return RET_FAIL;
	}
	
	//��ʼ���ͳ����Ŀ�ĺϷ���
	iRetVal = CheckStatItem (bStatBlankLineFlag, bStatCodeLineFlag, 
		bStatCommLineFlag, bStatTotalLineFlag);
	
	if ( RET_FAIL == iRetVal)
	{
		szErrorMsg = "������Ҫѡ��һ��ͳ����Ŀ�������޷�ͳ��";
        AfxMessageBox(szErrorMsg);  
           
        return RET_FAIL;
	}

	return RET_OK;
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     BOOL CheckStatFile��CString szStatFileName��
//Description:  ��鱻ͳ���ļ��ĺϷ���
//Calls:        ��
//Input:        szStatFileName����ͳ�Ƶ��ļ�ȫ·��
//Output:       ��
//Return:       RET_OK���������Ϸ���RET_FAIL��������鲻�Ϸ�
//Others:       ��
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
//Function:      BOOL CheckStatItem��BOOL bStatBlankLineFlag,
//                              BOOL bStatCodeLineFlag,
//                              BOOL bStatCommLineFlag,
//                              BOOL bStatTotalLineFlag��
//Description:   ͳ����Ŀ��麯��
//Calls:         ��
//Input:         ��
//Output:        bStatBlankLineFlag��ͳ�ƿ��б�־λ
//               bStatCodeLineFlag��ͳ�ƴ����б�־λ
//               bStatCommLineFlag��ͳ��ע���б�־λ
//               bStatTotalLineFlag��ͳ�����б�־λ
//Return:        RET_OK���������Ϸ���RET_FAIL��������鲻�Ϸ�
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
BOOL CCounter::CheckStatItem (BOOL bStatBlankLineFlag,
					BOOL bStatCodeLineFlag,
					BOOL bStatCommLineFlag,
					BOOL bStatTotalLineFlag)
{
	//����ĸ�ͳ����Ŀ��û�б�ѡ�У��򷵻�ʧ��
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
//Function:     VOID MainStatBlankLine��CString szStatFileName,
//                          BOOL bStatBlankLineFlag��
//Description:  ����StatBlankLine ͳ���ļ��п�����Ŀ
//Calls:        StatBlankLine (CString szStatFileName)
//Input:        g_szStatFileName��ȫ�ֱ�������ͳ�Ƶ��ļ�ȫ·��
//              g_bStatBlankLineFlag��ȫ�ֱ�����ͳ�ƿ��б�־λ
//Output:       ��
//Return:       ��    
//Others:       ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatBlankLine(CString szStatFileName,
					   BOOL bStatBlankLineFlag)
{
    //�ж��Ƿ���Ҫͳ�ƴ�������
    if (STAT == bStatBlankLineFlag)
    {
         StatBlankLine(szStatFileName);
	}
}

/////////////////////////////////////////////////////////////////////////////////
//Function: VOID StatBlankLine��CString szStatFileName��
//Description:   ͳ���ļ��п�����Ŀ
//Calls:        ��
//Input:                g_szStatFileName��ȫ�ֱ�������ͳ�Ƶ��ļ�ȫ·��
//Output:            g_iBlankLineNum��ȫ�ֱ�����ͳ�Ƶõ��Ŀ�����Ŀ
//Return:           
//Others:          ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatBlankLine(CString szStatFileName)
{
	//���屻ͳ���ļ��ľ��
	CStdioFile StatFileHandle;

	//���屣���ļ��е�ǰ���ַ����ı���
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
//Function:     VOID MainStatCodeLine��CString szStatFileName,
//                                 BOOL bStatCodeLineFlag��
//Description:  ����StatCodeLine ͳ���ļ��п�����Ŀ
//Calls:        StatCodeLine (CString szStatFileName)
//Input:        g_szStatFileName��ȫ�ֱ�������ͳ�Ƶ��ļ�ȫ·��
//              g_bStatCodeLineFlag��ȫ�ֱ�����ͳ�ƿ��б�־λ
//Output:       ��
//Return:       ��   
//Others:       ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatCodeLine(CString szStatFileName,
					  BOOL bStatCodeLineFlag)
{
    //�ж��Ƿ���Ҫͳ�ƴ�������
    if (STAT == bStatCodeLineFlag)
    {
         StatCodeLine(szStatFileName);
	}

}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID StatCodeLine��CString szStatFileName��
//Description:   ͳ���ļ��д�������Ŀ
//Calls:         IsCodeLine
//Input:         g_szStatFileName��ȫ�ֱ�������ͳ�Ƶ��ļ�ȫ·��
//Output:        g_iCodeLineNum��ȫ�ֱ�����ͳ�Ƶõ��Ŀ�����Ŀ
//Return:        ��   
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatCodeLine(CString szStatFileName)
{
	//���屻ͳ���ļ��ľ��
	CStdioFile StatFileHandle;
	
	//���屣���ļ��е�ǰ���ַ����ı���
	CString    szStatFileLine;

	//��ʶ��ǰ���Ƿ���ע������,false-û�д���ע������.true-����ע������
	BOOL       bIsComment = false;
	
	//���ú����ķ���ֵ
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

		//��������ǿ��У�����ѭ��
		if( 0 == szStatFileLine.GetLength())
		{
			continue;
		}

		//���ú���IsCodeLine���жϵ�ǰ���Ƿ��Ǵ�����
		bRetVal = IsCodeLine(szStatFileLine, bIsComment);
		
		if (RET_OK == bRetVal)
		{
			g_iCodeLineNum++;
		}
	}

	StatFileHandle.Close();
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     BOOL IsCodeLine��CString szStatFileLine
//                              ,BOOL &bIsComment��
//Description:  �жϵ�ǰ�ַ����Ƿ��Ǵ�����
//Calls:        ��
//Input:        szStatFileLine���ļ��е�ǰ�е��ַ����������ַ������ǿ���
//              bIsComment����ʶ��ǰ���Ƿ���ע�����ڡ�TRUE������ע�����ڣ�
//              FALSE�����Ǵ���ע������
//Output:       bIsComment:�������Ϊע�͵����һ�У�bIsComment��ֵfalse
//Return:       RET_OK���Ǵ�����,RET-FAIL������Ϊע����
//Others:       ��
/////////////////////////////////////////////////////////////////////////////////
BOOL CCounter::IsCodeLine(CString szStatFileLine,BOOL &bIsComment)
{
    //��������б�־
    int     iCodeFlag=RET_FAIL;
    //��¼��ǰ�ַ����ĳ���
    int     iCodeLineLen=0;
    //ѭ������
    int     iLoop=0;
    //���ַ����л�ȡ�������ַ����ж��Ƿ�Ϊ"/*"����"*/"
    CString szTmpCommLine;
    //���ַ����л�ȡ��һ���ַ����ж��Ƿ�Ϊ�����ַ�
    CString szTmpCodeLine;
    
	//ɾ��szStatFileLine����β�ո�,tab,�س�,����
	szStatFileLine.TrimLeft();
	szStatFileLine.TrimRight();

	//iCodeLineLen = szStatFileLine���ַ�������;
    iCodeLineLen = szStatFileLine.GetLength();
	
	//���û�ж�ȡ���ַ����ĵ����ڶ����ַ���ѭ������
	while (iLoop < iCodeLineLen - 1)
	{
		//szTmpCommLine����szStatFileLine�ĵ�iLoop�͵�(iLoop+1)���ַ�;
		szTmpCommLine = (CString)szStatFileLine.GetAt(iLoop) + (CString)szStatFileLine.GetAt(iLoop+1);
		
		//szTmpCodeLine����szStatFileLine�ĵ�iLoop���ַ�;
		szTmpCodeLine = szStatFileLine.GetAt(iLoop);
		
		//���ԭ������δ����ע�Ͷ��У���������ַ���"/*"����ע�Ͷο�ʼ
		if( (szTmpCommLine == "/*") && (bIsComment == FALSE) )
		{
			//ע�ͱ�־λ����Ϊtrue;
			bIsComment = TRUE;
		
			//ѭ��������2��Խ��"/*"����ȡע�����ڵ��ַ�
			iLoop+=2;
			continue;
		}
		//���ԭ�����봦��ע�Ͷ��У���������ַ���"*/"����ע�Ͷν���
		else if ( (szTmpCommLine == "*/") && ( bIsComment == TRUE) )
		{
			//ע�ͱ�־λ����Ϊfalse;
			bIsComment = FALSE;

			//ѭ��������2��Խ��"*/"����ȡע��������ַ�
			iLoop+=2;
			continue;
		}

		//�����ǰ���ַ�����tab�ַ����ǿո��ַ�������û�д���ע�����ڣ���ô
		//�����жϸ���Ϊ������
		if( (szTmpCodeLine != "	") && (szTmpCodeLine != " ")
			&& (bIsComment == false))
		{
			iCodeFlag = RET_OK;
		}

		//ѭ��������1����ȡ�ַ����е���һ���ַ�
		iLoop++;
	}
	
	return iCodeFlag;
}

/////////////////////////////////////////////////////////////////////////////////
//Function:     VOID MainStatCommLine��CString szStatFileName,
//                       BOOL bStatCommLineFlag��
//Description:  ����StatCommLine ͳ���ļ���ע������Ŀ
//Calls:        StatCommLine (CString szStatFileName)
//Input:        g_szStatFileName��ȫ�ֱ�������ͳ�Ƶ��ļ�ȫ·��
//              g_bStatCommLineFlag��ȫ�ֱ�����ͳ�ƿ��б�־λ
//Output:       ��
//Return:       ��    
//Others:       ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatCommLine(CString szStatFileName,BOOL bStatCommLineFlag)
{
    //�ж��Ƿ���Ҫͳ�ƿ�����
    if (STAT == bStatCommLineFlag)
    {
         StatCommLine(szStatFileName);
    }

}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID StatCommLine��CString szStatFileName��
//Description:   ͳ���ļ���ע������Ŀ
//Calls:         IsCodeLine
//Input:         g_szStatFileName��ȫ�ֱ�������ͳ�Ƶ��ļ�ȫ·��
//Output:        g_iCommLineNum��ȫ�ֱ�����ͳ�Ƶõ��Ŀ�����Ŀ
//Return:        �� 
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatCommLine(CString szStatFileName)
{
	//���屻ͳ���ļ��ľ��
	CStdioFile StatFileHandle;
	
	//���屣���ļ��е�ǰ���ַ����ı���
	CString    szStatFileLine;

	//��ʶ��ǰ���Ƿ���ע������,false-û�д���ע������.true-����ע������
	BOOL       bIsComment = false;
	
	//���ú����ķ���ֵ
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

		//��������ǿ��У�����ѭ��
		if( 0 == szStatFileLine.GetLength())
		{
			continue;
		}

		//���ú���IsCodeLine���жϵ�ǰ���Ƿ��Ǵ�����
		bRetVal = IsCodeLine(szStatFileLine, bIsComment);
		
		if (RET_FAIL == bRetVal)
		{
			g_iCommLineNum++;
		}
	}

	StatFileHandle.Close();
}

/////////////////////////////////////////////////////////////////////////////////
//Function: VOID MainStatTotalLine��CString szStatFileName,
//                                  BOOL bStatBlankLineFlag,
//                                  BOOL bStatCodeLineFlag,
//                                  BOOL bStatCommLineFlag,
//                                  BOOL bStatTotalLineFlag��
//Description:  ͳ���ļ��е�������
//Calls:        StatCodeLine (CString szStatFileName)
//Input:        szStatFileName����ͳ�Ƶ��ļ�ȫ·��
//              bStatBlankLineFlag��ͳ�ƿ��б�־λ
//              bStatCodeLineFlag��ͳ�ƿ��б�־λ
//              bStatCommLineFlag��ͳ��ע���б�־λ
//              bStatTotalLineFlag��ͳ����������־λ
//Output:       g_iTotalLineNum-ͳ�Ƶõ���������
//Return:       ��
//Others:       ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::MainStatTotalLine(CString szStatFileName,
					   BOOL bStatBlankLineFlag,
					   BOOL bStatCodeLineFlag,
					   BOOL bStatCommLineFlag,
					   BOOL bStatTotalLineFlag)
{
    //���ͳ���˿��С������к�ע���У��������ͳ��ֵ��ӵõ�������
    if ((STAT == bStatBlankLineFlag) 
		&& (STAT == bStatCodeLineFlag) 
		&& (STAT == bStatCommLineFlag))
    {
         g_iTotalLineNum = g_iBlankLineNum + g_iCodeLineNum + g_iCommLineNum;
	}
	//���򣬵���StatTotalLineͳ��������
	else
	{
		StatTotalLine(szStatFileName);
	}

}

/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID StatTotalLine��CString szStatFileName��
//Description:   ͳ���ļ��е�������
//Calls:         ��
//Input:         szStatFileName��ȫ�ֱ�������ͳ�Ƶ��ļ�ȫ·��
//Output:        g_iTotalLineNum��ȫ�ֱ�����ͳ�Ƶõ���������Ŀ
//Return:        �� 
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
VOID CCounter::StatTotalLine(CString szStatFileName)
{
	//���屻ͳ���ļ��ľ��
	CStdioFile StatFileHandle;

	//���屣���ļ��е�ǰ���ַ����ı���
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
//Function:     VOID StatResultOutput��int iResultType,int iStatVal��
//Description:  ��ͳ�ƽ���ϱ����û�����
//Calls:        ��
//Input:        iResultType�����������͡�ȡֵ��Χ��STAT_BLANK���ϱ�������,
//              STAT_CODE���ϱ���������,STAT_COMM���ϱ�ע������,
//              STAT_TOTAL���ϱ������� 
//              iStatVal����Ӧ��ͳ�ƽ����ֵ
//Output:       ��ͳ�ƽ���ϱ�����ͳ�ƽ�����༭����
//Return:       ��
//Others:       ��
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
		szTmpOutput.Format("��������Ŀ=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	case STAT_COMM:
		szTmpOutput.Format("ע������Ŀ=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	case STAT_BLANK:
		szTmpOutput.Format("������Ŀ=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	case STAT_TOTAL:
		szTmpOutput.Format("������Ŀ=%d\r\n",iStatVal);
		szOutput += szTmpOutput;
		break;
	default:
		break;
	}

//	pOutputEdit->SetWindowText(szOutput);
}


/////////////////////////////////////////////////////////////////////////////////
//Function:      VOID SetStatBlankLineFlag()
//Description:   ��Ӧ�û�������ͳ�ƿ��С���ѡ��
//Calls:         ��
//Input:         ��
//Output:        g_bStatBlankLineFlag��ȫ�ֱ�����ͳ�ƿ��б�־λ 
//Return:        ��
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
void CTest::SetStatBlankLineFlag()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
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
//Description:   ��Ӧ�û�������ͳ�ƴ����С���ѡ��
//Calls:         ��
//Input:         ��
//Output:        g_bStatCodeLineFlag��ȫ�ֱ�����ͳ�ƴ����б�־λ 
//Return:        ��
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
void CTest::SetStatCodeLineFlag()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
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
//Description:   ��Ӧ�û�������ͳ��ע���С���ѡ��
//Calls:         ��
//Input:         ��
//Output:        g_bStatCommLineFlag��ȫ�ֱ�����ͳ��ע���б�־λ 
//Return:        ��
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////

void CTest::SetStatCommLineFlag()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
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
//Description:   ��Ӧ�û�������ͳ������������ѡ��
//Calls:         ��
//Input:         ��
//Output:        g_bStatTotalLineFlag��ȫ�ֱ�����ͳ����������־λ 
//Return:        ��
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
void CTest::SetStatTotalLineFlag()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
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
//Function:      VOID MainStatFun����
//Description:   �ú������û�ͨ�����浥������ʼͳ�ơ���ť�󣬿�ʼ���С������غ�����
//               �е��ȹ��ܣ��ֱ���ò������ģ�顢����ͳ��ģ���ͳ�ƽ�����ģ�飬
//               ���һ��ͳ��ִ�й���
//Calls:         ��
//Input:         ��
//Output:        ��
//Return:        ��
//Others:        ��
/////////////////////////////////////////////////////////////////////////////////
void CTest::MainStatFun()
{
	//Ϊȫ�ֱ�����ֵ����¼ͳ�������ı�������ʼ��Ϊ0
	g_iCodeLineNum  = 0;
	g_iBlankLineNum = 0;
	g_iCommLineNum  = 0;
	g_iTotalLineNum = 0;
	
	//������ú����ķ���ֵ����
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
	
	//ͳ���ļ��п�����Ŀ
	m_Counter.MainStatBlankLine(g_szStatFileName,g_bStatBlankLineFlag);
	
	//ͳ���ļ��д�������
	m_Counter.MainStatCodeLine(g_szStatFileName,g_bStatCodeLineFlag);
	
	//ͳ���ļ��е�ע������
	m_Counter.MainStatCommLine(g_szStatFileName,g_bStatCommLineFlag);
	
	//ͳ���ļ��е�������
	m_Counter.MainStatTotalLine(g_szStatFileName,
		g_bStatBlankLineFlag,
		g_bStatCodeLineFlag,
		g_bStatCommLineFlag,
		g_bStatTotalLineFlag);
	
	//�������ͳ����Ŀ
	StatResultOutput(STAT_BLANK, g_iBlankLineNum,NOT_APPEND);
	
	//���������ͳ����Ŀ
	StatResultOutput(STAT_CODE, g_iCodeLineNum,APPEND);
	
	//���ע����ͳ����Ŀ
	StatResultOutput(STAT_COMM, g_iCommLineNum,APPEND);
	
	//�������ͳ����Ŀ
	StatResultOutput(STAT_TOTAL, g_iTotalLineNum,APPEND);
	
}

int Add(int a, int b)
{
	return a + b;
}