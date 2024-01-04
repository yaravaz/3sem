#pragma once

#define CHAIN FST::NODE(24, FST::RELATION('Y', 0), FST::RELATION('a', 0), FST::RELATION('r', 0),\
			FST::RELATION('o', 0), FST::RELATION('s', 0), FST::RELATION('l', 0), FST::RELATION('v', 0),\
			FST::RELATION('V', 0), FST::RELATION('n', 0), FST::RELATION('2', 0), FST::RELATION('0', 0),\
			FST::RELATION('4', 0), FST::RELATION('ß', 0), FST::RELATION('ð', 0), FST::RELATION('î', 0),\
			FST::RELATION('ñ', 0), FST::RELATION('ë', 0), FST::RELATION('â', 0), FST::RELATION('Â', 0),\
			FST::RELATION('à', 0), FST::RELATION('í', 0), FST::RELATION(' ', 0), FST::RELATION('\n', 0), FST::RELATION('\0', 1))

namespace FST
{
	struct RELATION
	{
		unsigned char symbol;
		short nnode;
		RELATION(
			unsigned char c = 0x00,
			short ns = NULL
		);
	};

	struct NODE
	{
		short n_relation;
		RELATION* relations;
		NODE();
		NODE(
			short n,
			RELATION rel, ...
		);
	};

	struct FST
	{
		const unsigned char* string;
		short position;
		short nstates;
		NODE* nodes;
		short* rstates;
		FST(
			const unsigned char* s,
			short ns,
			NODE n, ...
		);
	};

	bool execute(
		FST& fst
	);
};