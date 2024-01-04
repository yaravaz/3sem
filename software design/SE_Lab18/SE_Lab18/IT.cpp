#include "stdafx.h"


namespace IT
{
	IdTable::IdTable()
	{
		noname_lexema_count = 0;
		maxsize = TI_MAXSIZE;
		size = 0;
		table = new Entry[TI_MAXSIZE];
	}
	Entry::Entry()
	{
		parrent_function[0] = '\0';
		id[0] = '\0';
		firstApi = 0;
		iddatatype = IT::IDDATATYPE::DEF;
		idtype = IT::IDTYPE::D;
		parmQuantity = 0;

	}

	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first)
	{
		int i = 0;
		if (parrent_function)
			for (i = 0; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		parmQuantity = 0;
	}
	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, int it)
	{
		int i = 0;
		if (parrent_function)
			for (i; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		parmQuantity = 0;
		value.vint = it;
	}
	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, char* ch)
	{
		int i = 0;
		if (parrent_function)
			for (i; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		parmQuantity = 0;
		strcpy_s(value.vstr.str, 255, ch);
		value.vstr.len = strlen(ch);
	}
	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, const char* ch)
	{
		int i = 0;
		if (parrent_function)
			for (i; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		parmQuantity = 0;
		strcpy_s(value.vstr.str, 255, ch);
		value.vstr.len = strlen(ch);
	}
	Entry::Entry(char* parrent_function, char* id, IDDATATYPE iddatatype, IDTYPE idtype)
	{
		int i = 0;
		if (parrent_function)
			for (i; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		parmQuantity = 0;
	}

	IdTable Create(int size)
	{
		IdTable idTable;
		idTable.size = size;
		idTable.maxsize = TI_MAXSIZE;
		idTable.table = new Entry[TI_MAXSIZE];
		return idTable;
	}
	void IdTable::Add(Entry entry)
	{
		if (strlen(entry.id) > ID_MAXSIZE && entry.idtype != IDTYPE::F)
			throw ERROR_THROW(121);

		if (size < maxsize)
		{
			if (entry.idtype != IDTYPE::F)
				entry.id[5] = '\0';
			table[size] = entry;

			switch (entry.iddatatype)
			{
			case IDDATATYPE::INT:
			{
				table[size].value.vint = TI_INT_DEFAULT;
			}
			case IDDATATYPE::STR:
			{
				table[size].value.vstr.str[0] = TI_STR_DEFAULT;
				table[size].value.vstr.len = 0;
			}
			}
			size++;
		}
		else
			throw ERROR_THROW(122);

	}
	Entry IdTable::GetEntry(int n)
	{
		if (n < size && n >= 0)
			return table[n];
	}
	int IdTable::IsId(const char id[ID_MAXSIZE])
	{
		for (int i = 0; i < size; i++)
		{
			if (strcmp(table[i].id, id) == 0)
				return i;
		}
		return TI_NULLIDX;
	}
	int IdTable::IsId(const char id[ID_MAXSIZE], const char parrent_function[ID_MAXSIZE + 5])
	{
		for (int i = 0; i < size; i++)
		{
			if ((strcmp(table[i].id, id) == 0) &&
				(strcmp(table[i].parrent_function, parrent_function) == 0))
				return i;
		}
		return TI_NULLIDX;
	}
	void Delete(IdTable& idtable)
	{
		delete[] idtable.table;
		idtable.table = nullptr;
	}

	char* IdTable::GetLexemaName()
	{
		char buffer[5];
		_itoa_s(noname_lexema_count, buffer, 10);
		strcat_s(buffer, 5, "_l");
		noname_lexema_count++;
		return buffer;
	}

	void IdTable::PrintIdTable(const wchar_t* in)
	{
		ofstream* idStream = new ofstream;
		idStream->open(in);

		if (idStream->is_open())
		{
			bool flagForFirst = false;

			*(idStream) << "##########################################################################################################################\n";
			*(idStream) << "------------------ �������� ------------------\n";

			*(idStream) << setw(15) << "�������������:" << setw(17) << "��� ������:" << setw(15) << "��������:" << setw(27) << "����� ������:" << setw(20) << "������ ���������:\n";


			for (int i = 0; i < size; i++)
			{
				if (table[i].idtype == IT::IDTYPE::L)
				{
					cout.width(25);
					switch (table[i].iddatatype)
					{
					case 1:
					{
						*(idStream) << "   " << table[i].id << "\t\t\t" << "INT " << "\t\t" << table[i].value.vint << "\t\t\t" << "-\t\t" << table[i].firstApi << endl;
						break;
					}
					case 2:
					{
						*(idStream) << "   " << table[i].id << "\t\t\t" << "STR " << "\t    " << table[i].value.vstr.str << setw(30 - strlen(table[i].value.vstr.str)) << (int)table[i].value.vstr.len << "\t\t" << table[i].firstApi << endl;
						break;
					}
					}
				}
			}
			* (idStream) << "\n\n\n";

			flagForFirst = false;

			*(idStream) << "##########################################################################################################################\n";
			*(idStream) << "------------------ ������� ------------------\n";

			*(idStream) << setw(15) << "�������������:" << setw(26) << "��� ������ ��������:" << setw(36) << "���������� ���������� ����������:" << setw(22) << "������ ���������:\n";


			for (int i = 0; i < size; i++)
			{
				if (table[i].idtype == IT::IDTYPE::F)
				{

					switch (table[i].iddatatype)
					{
					case 1:
					{
						*(idStream) << "   " << table[i].id << setw(28 - strlen(table[i].id)) << "INT " << "\t\t\t\t" << table[i].parmQuantity << "\t\t\t\t" << table[i].firstApi << endl;
						break;
					}
					case 2:
					{
						*(idStream) << "   " << table[i].id << setw(28 - strlen(table[i].id)) << "STR " << "\t\t\t\t" << table[i].parmQuantity << "\t\t\t\t" << table[i].firstApi << endl;
						break;
					}
					}

				}


			}

			* (idStream) << "\n\n\n";

			flagForFirst = false;

			*(idStream) << "##########################################################################################################################\n";
			*(idStream) << "------------------ ���������� ------------------\n";
			*(idStream) << setw(25) << "��� ������������� �����:" << setw(20) << "�������������:" << setw(16) << "��� ������:" << setw(24) << "��� ��������������:" << setw(21) << "������ ���������:\n";

			for (int i = 0; i < size; i++)
			{
				if (table[i].idtype == IT::IDTYPE::V)
				{


					switch (table[i].iddatatype)
					{
					case 1:
					{
						*(idStream) << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "INT " << setw(15) << "V" << "\t\t\t" << table[i].firstApi << endl;
						break;
					}
					case 2:
					{
						*(idStream) << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "STR " << setw(15) << "V" << "\t\t\t" << table[i].firstApi << endl;
						break;
					}
					}

					flagForFirst = true;
				}

				if (table[i].idtype == IT::IDTYPE::P)
				{

					switch (table[i].iddatatype)
					{
					case 1:
					{
						*(idStream) << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "INT " << setw(15) << "P" << "\t\t\t" << table[i].firstApi << endl;
						break;
					}
					case 2:
					{
						*(idStream) << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "STR " << setw(15) << "P" << "\t\t\t" << table[i].firstApi << endl;
						break;
					}
					}

					flagForFirst = true;
				}


			}
			* (idStream) << "\n\n\n";

		}
		else
			throw ERROR_THROW(125);
		idStream->close();
		delete idStream;
	}
}