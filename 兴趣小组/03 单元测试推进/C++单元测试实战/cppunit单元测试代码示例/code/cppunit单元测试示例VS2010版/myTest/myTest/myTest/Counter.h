#ifndef COUNTER_H
#define COUNTER_H

class CCounter
{
private:
	enum	{STAT=0,NOT_STAT};
	enum	{STAT_BLANK=0,STAT_COMM,STAT_CODE,STAT_TOTAL};
	enum	{RET_OK=0,RET_FAIL};
	enum    {APPEND=0,NOT_APPEND};

public:
	BOOL CheckParameters(CString szStatFileName,
		BOOL bStatBlankLineFlag,
		BOOL bStatCodeLineFlag,
		BOOL bStatCommLineFlag,
		BOOL bStatTotalLineFlag);
	
	BOOL CheckStatFile(CString szStatFileName);
	
	BOOL CheckStatItem (BOOL bStatBlankLineFlag,
		BOOL bStatCodeLineFlag,
		BOOL bStatCommLineFlag,
		BOOL bStatTotalLineFlag);
	
	VOID MainStatBlankLine(CString szStatFileName,
		BOOL bStatBlankLineFlag);
	
	VOID StatBlankLine(CString szStatFileName);
	
	VOID MainStatCodeLine(CString szStatFileName,BOOL bStatCodeLineFlag);
	
	VOID StatCodeLine(CString szStatFileName);
	
	BOOL IsCodeLine(CString szStatFileLine,BOOL &bIsComment);
	
	VOID MainStatCommLine(CString szStatFileName,BOOL bStatCommLineFlag);
	
	VOID StatCommLine(CString szStatFileName);
	
	VOID MainStatTotalLine(CString szStatFileName,
					   BOOL bStatBlankLineFlag,
					   BOOL bStatCodeLineFlag,
					   BOOL bStatCommLineFlag,
					   BOOL bStatTotalLineFlag);
	
	VOID StatTotalLine(CString szStatFileName);
}; 

int add(int a, int b);

#endif