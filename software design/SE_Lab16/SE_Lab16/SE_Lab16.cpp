#include <iostream>
#include <locale>
#include <tchar.h>

#include "FST.h"

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");

	/*FST::FST fst1(
		"aaabbbaba",
		4,
		FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
		FST::NODE(1, FST::RELATION('b', 2)),
		FST::NODE(1, FST::RELATION('a', 3)),
		FST::NODE()
	);*/

	FST::FST fst1(
		(const unsigned char*)"Вовна",
		2,
		CHAIN,
		FST::NODE()
	);

	if (FST::execute(fst1))
		cout << "Цепочка " << fst1.string << " распознана" << endl;
	else cout << "Цепочка " << fst1.string << " не распознана" << endl;

	/*FST::FST fst2(
		"aaabbbabba",
		4,
		FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
		FST::NODE(1, FST::RELATION('b', 2)),
		FST::NODE(1, FST::RELATION('a', 3)),
		FST::NODE()
	);*/

	FST::FST fst2(
		(const unsigned char*)"integer",
		8, 
		FST::NODE(1, FST::RELATION('i', 1)), 
		FST::NODE(1, FST::RELATION('n', 2)), 
		FST::NODE(1, FST::RELATION('t', 3)), 
		FST::NODE(1, FST::RELATION('e', 4)), 
		FST::NODE(1, FST::RELATION('g', 5)), 
		FST::NODE(1, FST::RELATION('e', 6)), 
		FST::NODE(1, FST::RELATION('r', 7)), 
		FST::NODE()
	);

	if (FST::execute(fst2))
		cout << "Цепочка " << fst2.string << " распознана" << endl;
	else cout << "Цепочка " << fst2.string << " не распознана" << endl;

	FST::FST fst3(
		(const unsigned char*)"Ярослава Вовна",
		2,
		CHAIN,
		FST::NODE()
	);

	if (FST::execute(fst3))
		cout << "Цепочка " << fst3.string << " распознана" << endl;
	else cout << "Цепочка " << fst3.string << " не распознана" << endl;

	FST::FST fst4(
		(const unsigned char*)"Vovna",
		2,
		CHAIN,
		FST::NODE()
	);

	if (FST::execute(fst4))
		cout << "Цепочка " << fst4.string << " распознана" << endl;
	else cout << "Цепочка " << fst4.string << " не распознана" << endl;

	FST::FST fst5(
		(const unsigned char*)"Yaroslava",
		2,
		CHAIN,
		FST::NODE()
	);

	if (FST::execute(fst5))
		cout << "Цепочка " << fst5.string << " распознана" << endl;
	else cout << "Цепочка " << fst5.string << " не распознана" << endl;

	FST::FST fst6(
		(const unsigned char*)"Yaroslava Vovna",
		2,
		CHAIN,
		FST::NODE()
	);

	if (FST::execute(fst6))
		cout << "Цепочка " << fst6.string << " распознана" << endl;
	else cout << "Цепочка " << fst6.string << " не распознана" << endl;

	FST::FST fst7(
		(const unsigned char*)"Yaroslava Vovna 2004\nЯрослава Вовна",
		2,
		CHAIN,
		FST::NODE()
	);

	if (FST::execute(fst7))
		cout << "Цепочка " << fst7.string << " распознана" << endl;
	else cout << "Цепочка " << fst7.string << " не распознана" << endl;

	FST::FST fst8(
		(const unsigned char*)"Yaroslava/Вовна",
		2,
		CHAIN,
		FST::NODE()
	);

	if (FST::execute(fst8))
		cout << "Цепочка " << fst8.string << " распознана" << endl;
	else cout << "Цепочка " << fst8.string << " не распознана" << endl;

	FST::FST fst9(
		(const unsigned char*)"Yar",
		2,
		FST::NODE(24, FST::RELATION('Y', 0), FST::RELATION('a', 0), FST::RELATION('r', 0), \
			FST::RELATION('o', 0), FST::RELATION('s', 0), FST::RELATION('l', 0), FST::RELATION('v', 0), \
			FST::RELATION('V', 0), FST::RELATION('n', 0), FST::RELATION('2', 0), FST::RELATION('0', 0), \
			FST::RELATION('4', 0), FST::RELATION('Я', 0), FST::RELATION('р', 0), FST::RELATION('о', 0), \
			FST::RELATION('с', 0), FST::RELATION('л', 0), FST::RELATION('в', 0), FST::RELATION('В', 0), \
			FST::RELATION('а', 0), FST::RELATION('н', 0), FST::RELATION(' ', 0), FST::RELATION('\n', 0), FST::RELATION('\0', 0)),
		FST::NODE()
	);

	if (FST::execute(fst9))
		cout << "Цепочка " << fst9.string << " распознана" << endl;
	else cout << "Цепочка " << fst9.string << " не распознана" << endl;

	FST::FST fst10(
		(const unsigned char*)"slava",
		2,
		FST::NODE(24, FST::RELATION('Y', 0), FST::RELATION('a', 0), FST::RELATION('r', 0), \
			FST::RELATION('o', 0), FST::RELATION('s', 0), FST::RELATION('l', 0), FST::RELATION('v', 0), \
			FST::RELATION('V', 0), FST::RELATION('n', 0), FST::RELATION('2', 0), FST::RELATION('0', 0), \
			FST::RELATION('4', 0), FST::RELATION('Я', 0), FST::RELATION('р', 0), FST::RELATION('о', 0), \
			FST::RELATION('с', 0), FST::RELATION('л', 0), FST::RELATION('в', 0), FST::RELATION('В', 0), \
			FST::RELATION('а', 0), FST::RELATION('н', 0), FST::RELATION(' ', 0), FST::RELATION('\n', 0), FST::RELATION('\0', 0)),
		FST::NODE()
	);

	if (FST::execute(fst10))
		cout << "Цепочка " << fst10.string << " распознана" << endl;
	else cout << "Цепочка " << fst10.string << " не распознана" << endl;

	system("pause");
	return 0;
}