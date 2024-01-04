#include "stdafx.h"
#include "Out.h"
#pragma warning(disable:4996)

namespace Out
{
	OUT getout(wchar_t outfile[]) {
		OUT out;
		out.stream = new ofstream;
		out.stream->open(outfile);
		if (!out.stream->is_open()) {
			throw ERROR_THROW(112);
		}
		wcscpy_s(out.outfile, outfile);
		return out;
	}

	void WriteOut(OUT out, In::IN in) {

		*out.stream << in.text << endl;
	}

	void WriteError(OUT out, Error::ERROR error)
	{
		if (out.stream)
		{
			*out.stream << "������ " << error.id << ": " << error.message << endl;
			if (error.inext.line != -1)
			{
				*out.stream << "������: " << error.inext.line << endl << "�������: " << error.inext.col << endl << endl;
			}
		}
		else
			cout << "������ " << error.id << ": " << error.message << ", ������ " << error.inext.line << ", ������� " << error.inext.col << endl << endl;
	}
	void Close(OUT out) {
		out.stream->close();
		delete out.stream;
	}
}