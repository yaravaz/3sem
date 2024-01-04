#pragma once
#pragma once
#include "IT.h"
#define LEXEMA_FIXSIZE  1			//������������� ������ �������
#define	LT_MAXSIZE		4096		// ������������ ���������� ����� � ������� ������	
#define	LT_TI_NULLIDX	-1	// ��� �������� ������� ���������������				
#define	LEX_INTEGER		't'			
#define	LEX_STRING		't'			
#define	LEX_ID			'i'			
#define	LEX_LITERAL		'l'			
#define	LEX_FUNCTION	'f'			
#define	LEX_DECLARE		'd'			
#define	LEX_RETURN		'r'			
#define	LEX_PRINT		'p'			
#define	LEX_STRLEN		'e'			
#define	LEX_SEMICOLON	';'			
#define	LEX_COMMA		','			
#define	LEX_LEFTBRACE	'{'			
#define	LEX_RIGHTBRACE	'}'			
#define	LEX_LEFTHESIS	'('			
#define	LEX_RIGHTHESIS	')'			
#define	LEX_PLUS		'v'			
#define	LEX_MINUS		'v'			
#define	LEX_STAR		'v'			
#define	LEX_DIRSLASH	'v'			
#define	LEX_EQUAL_SIGN	'='			

#define PLUS '+'
#define MINUS '-'
#define STAR '*'
#define DIRSLASH '/'


namespace LT									// ������� ������
{
	struct Entry								// ������ ������� ������
	{
		char lexema;							// �������
		int numberOfString;						// ����� ������ � �������� ������
		int idInTI;								// ������ � ������� ��������������� ��� LT_TI_NULLIDX
		Entry();
		Entry(const char lex, int stringNumber, int idInTI);
	};

	struct LexTable								// �������� ������� ������
	{
		int maxsize;							// ������� ������� ������ < LT_MAXSIZE
		int size;								// ������� ������ ������� ������ < maxsize
		Entry* table;							// ������ ����� ������� ������


		Entry GetEntry(								// �������� ������ ������� ������
			int n									// ����� ���������� ������
		);

		void PrintLexTable(const wchar_t* in);
		LexTable();
	};

	void Add(									// �������� ������ � ������� ������
		LexTable& lextable,						// ��������� ������� ������
		Entry entry								// ������ ������� ������
	);

	void Delete(LexTable& lextable);			// ������� ������� ������ (���������� ������)
};