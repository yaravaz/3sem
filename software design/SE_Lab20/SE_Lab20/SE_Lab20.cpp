#include "stdafx.h"
#include <iostream>
#include <locale>
#include <cwchar>

#include "Error.h"
#include "Parm.h"
#include "Log.h"
#include "In.h"
#include "Out.h"
using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	/*cout << "----    ���� Error::geterror    ----\n\n";
	try { throw ERROR_THROW(100); }
	catch (Error::ERROR e)
	{
		cout << "������ " << e.id << ": " << e.message << "\n\n";
	};

	cout << "----    ���� Error::geterrorin    ----\n\n";
	try { throw ERROR_THROW_IN(111, 7, 7); }
	catch (Error::ERROR e)
	{
		cout << "������ " << e.id << ": " << e.message << ", ������ " << e.inext.line << ", ������� " << e.inext.col << " \n\n";
	};*/

	/*cout << "---- ���� Parm::getparm ----\n\n";
	try {
		Parm::PARM parm = Parm::getparm(argc, argv);
		wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << "\n\n";
	}
	catch (Error::ERROR e)
	{
		cout << "������ " << e.id << ": " << e.message << "\n\n";
	}*/

	/*cout << "---- ���� In::getin -----\n\n";
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);
		In::IN in = In::getin(parm.in);
		cout << in.text << endl;
		cout << "����� ��������: " << in.size << endl;
		cout << "����� �����: " << in.lines << endl;
		cout << "���������: " << in.ignor << endl;
	}
	catch (Error::ERROR e)
	{
		cout << "������ " << e.id << ": " << e.message << endl;
		cout << "C����� " << e.inext.line << " ������� " << e.inext.col << "\n\n";
	}*/


	Log::LOG log = Log::INITLOG;
	Out::OUT out = Out::INITOUT;
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);
		log = Log::getlog(parm.log);
		out = Out::getout(parm.out);
		Log::WriteLine(log, (char*)"����:", (char*)" ��� ������ \n", "");
		Log::WriteLine(log, (wchar_t*)L"����:", (wchar_t*)L" ��� ������ \n", L"");
		Log::WriteLog(log);
		Log::WriteParm(log, parm);
		In::IN in = In::getin(parm.in);
	Log:WriteIn(log, in);
		Out::WriteOut(out, in);

		LT::LexTable lexTable;
		IT::IdTable	idTable;

		LA::FindLex(in, lexTable, idTable);

		lexTable.PrintLexTable(L"TableOfLexems.txt");
		idTable.PrintIdTable(L"TableOfIdentificators.txt");

		MFST_TRACE_START
			MFST::Mfst mfst(lexTable, GRB::getGreibach());
		mfst.start();

		mfst.savededucation();

		mfst.printrules();

		for (int i = 0, lex_position; i < lexTable.size; i++) {
			if (lexTable.table[i - 1].lexema == LEX_EQUAL_SIGN) {
				if (PolishNotation::PolishNotation(i, lexTable, idTable))
					cout << lexTable.table[i].numberOfString << ": �������� ������ ���������" << endl;
				else
					cout << lexTable.table[i].numberOfString << ": �������� ������ �� ���������" << endl;
			}
		}

		lexTable.PrintLexTable(L"NewTableOfLexems.txt");

		LT::Delete(lexTable);
		IT::Delete(idTable);
		Log::Close(log);
		Out::Close(out);
	}
	catch (Error::ERROR e)
	{
		Log::WriteError(log, e);
		Out::WriteError(out, e);
	}
	return 0;
};