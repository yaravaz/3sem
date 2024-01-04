#pragma once
#define IN_MAX_LEN_TEXT 1024*1024
#define IN_CODE_ENDL '\n'

#define IN_CODE_TABLE {\
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,   '|',/* \n*/ IN::F, IN::F, IN::I, IN::F, IN::F, \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::T,/*   */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T,/* - */ IN::F, IN::F, \
	IN::T,/* 0 */ IN::F, IN::T,/* 2 */ IN::F, IN::T,/* 4 */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T,/* V */ IN::F, IN::I, IN::T,/* Y */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::F, IN::T,/* a */ IN::F, IN::F, IN::T,/* d */ IN::T,/* e */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T,/* l */ IN::F, IN::T,/* n */ IN::T,/* o */ \
	IN::F, IN::F, IN::T,/* r */ IN::T,/* s */ IN::F, IN::F, IN::T,/* v */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
																													\
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	  '-', IN::F, IN::T,/* Â */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, \
	IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T,/* ß */ \
	IN::T,/* à */ IN::F, IN::T,/* â */ IN::F, IN::F, IN::T,/* å */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::T,/* ë */ IN::F, IN::T,/* í */ IN::T,/* î */ IN::F, \
	IN::T,/* ð */ IN::T,/* c */ IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F  \
}

namespace In
{
	struct IN
	{
		enum { T = 1024, F = 2048, I = 4096 };
		int size;
		int lines;
		int ignor;
		unsigned char* text;
		int code[256] = IN_CODE_TABLE;
	};
	IN getin(wchar_t infile[]);
};