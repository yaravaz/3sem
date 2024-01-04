#include "stdafx.h"
#define BEGIN '|'

namespace PolishNotation
{
	bool Stack::push(LT::Entry input) {
		if (this->currentSize < this->maxCount) {
			lexEntry* temp = new lexEntry(input, this->head);
			this->head = temp;
			this->currentSize++;
		}
		else return false;
	}

	bool Stack::push(PolishNotation::lexEntry input) {
		if (this->currentSize < this->maxCount) {
			lexEntry* temp = new lexEntry(input, this->head);
			this->head = temp;
			this->currentSize++;
		}
		else return false;
	}

	lexEntry* Stack::pop() {
		if (this->currentSize != 0) {
			lexEntry temp(*this->head);
			delete this->head;
			this->head = temp.next;
			this->currentSize--;
			return &temp;
		}
		else return 0;
	}

	char Stack::lastElement(IT::IdTable idTable) {
		if (this->head->lexema == 'v')
			return idTable.table[this->head->idInTI].value.operation;
		return this->head->lexema;
	}

	bool PolishNotation(int lex_position, LT::LexTable& lexTable, IT::IdTable& idTable)
	{
		PolishNotation::Stack* literals = new PolishNotation::Stack;
		PolishNotation::Stack* operators = new PolishNotation::Stack;

		operators->push({ BEGIN, -1, -1 });

		bool flag = true;
		bool is_complete = false;
		LT::Entry temp;
		In::IN in_ex;

		for (int i = lex_position; flag;)
		{
			temp = lexTable.GetEntry(i);

			if (idTable.GetEntry(temp.idInTI).idtype == IT::IDTYPE::F)
			{
				LT::Entry temp_1;
				temp_1 = lexTable.GetEntry(i);
				temp_1.lexema = '\@';
				char buffer[ID_MAXSIZE];
				int parm_quantity = 0;
				i++;
				for (; lexTable.GetEntry(i).lexema != ')'; i++)
				{

					if (in_ex.code[lexTable.GetEntry(i).lexema] != in_ex.D)
					{
						parm_quantity++;
						temp = lexTable.GetEntry(i);
						literals->push(temp);
					}
				}
				_itoa_s(parm_quantity, buffer, 10);
				literals->push(temp_1);
				literals->push({ buffer[0],temp_1.numberOfString,temp_1.idInTI });
				i++;
				continue;
			}
			if (temp.lexema == LEX_ID || temp.lexema == LEX_LITERAL)
			{
				literals->push(temp);
				i++;
				continue;
			}

			switch (operators->lastElement(idTable))
			{
			case BEGIN:
			{
				if (temp.idInTI != -1)
				{
					if (idTable.table[temp.idInTI].value.operation == PLUS ||
						idTable.table[temp.idInTI].value.operation == MINUS ||
						idTable.table[temp.idInTI].value.operation == STAR ||
						idTable.table[temp.idInTI].value.operation == DIRSLASH)
					{
						operators->push(temp);
						i++;
						break;
					}
				}
				else
				{
					if (temp.lexema == LEX_LEFTHESIS)
					{
						operators->push(temp);
						i++;
						break;
					}
				}
				if (temp.lexema == LEX_RIGHTHESIS) { flag = false; }
				if (temp.lexema == LEX_SEMICOLON) { is_complete = true; flag = false; }
				break;
			}
			case PLUS:
			case MINUS:
			{
				if (temp.idInTI != -1)
				{
					if (idTable.table[temp.idInTI].value.operation == PLUS ||
						idTable.table[temp.idInTI].value.operation == MINUS)
					{
						literals->push(*operators->pop());
						break;
					}
				}
				else
				{
					if (temp.lexema == LEX_LEFTHESIS ||
						temp.lexema == LEX_SEMICOLON)
					{
						literals->push(*operators->pop());
						break;
					}
				}

				if (temp.idInTI != -1)
				{
					if (idTable.table[temp.idInTI].value.operation == STAR ||
						idTable.table[temp.idInTI].value.operation == DIRSLASH)
					{
						operators->push(temp);
						i++;
						break;
					}
				}
				else
				{
					if (temp.lexema == LEX_LEFTHESIS)
					{
						operators->push(temp);
						i++;
						break;
					}
				}
			}

			case STAR:
			case DIRSLASH:
			{
				if (temp.idInTI != -1)
				{
					if (idTable.table[temp.idInTI].value.operation == PLUS ||
						idTable.table[temp.idInTI].value.operation == MINUS ||
						idTable.table[temp.idInTI].value.operation == STAR ||
						idTable.table[temp.idInTI].value.operation == DIRSLASH)
					{
						literals->push(*operators->pop());
						break;
					}
				}
				else
				{
					if (temp.lexema == LEX_RIGHTHESIS ||
						temp.lexema == LEX_SEMICOLON)
					{
						literals->push(*operators->pop());
						break;
					}
				}
				if (temp.lexema == LEX_LEFTHESIS)
				{
					operators->push(temp);
					i++;
					break;
				}
			}
			case LEX_LEFTHESIS:
			{
				if (temp.lexema == LEX_SEMICOLON) flag = false;

				if (temp.idInTI != -1)
				{
					if (idTable.table[temp.idInTI].value.operation == PLUS ||
						idTable.table[temp.idInTI].value.operation == MINUS ||
						idTable.table[temp.idInTI].value.operation == STAR ||
						idTable.table[temp.idInTI].value.operation == DIRSLASH)
					{
						operators->push(temp);
						i++;
						break;
					}
				}
				else
				{
					if (temp.lexema == LEX_LEFTHESIS)
					{
						operators->push(temp);
						i++;
						break;
					}
				}
				if (temp.lexema == LEX_RIGHTHESIS)
				{
					operators->pop();
					i++;
					break;
				}
			}
			default:
				flag = false;
			}
		}

		if (is_complete)
		{
			PolishNotation::lexEntry* temp;
			int count = literals->getCount();
			LT::Entry* temp_array = new LT::Entry[count];

			for (int i = count - 1; i >= 0; i--)
			{
				temp = literals->pop();
				if (temp)
				{
					temp_array[i] = *temp;
				}
			}

			for (int i = lex_position, j = 0; lexTable.table[i].lexema != LEX_SEMICOLON; i++)
			{
				if ((i - count) < lex_position)
					lexTable.table[i] = temp_array[j++];
				else
					lexTable.table[i] = { '~', lexTable.table[i].numberOfString, -1 };
			}

			delete[] temp_array;
			delete literals;
			delete operators;
			return true;
		}
		else
		{
			delete literals;
			delete operators;
			return false;
		}
	}
}