#include "stdafx.h"
#include "Error.h"
namespace Error
{
	// ����� ������: 0 -  99 - ��������� ������
	//				100 - 109 - ������ ����������
	//				110 - 119 - ������ �������� � ������ ������
	ERROR errors[ERROR_MAX_ENTRY] = // ������� ������
	{
		ERROR_ENTRY(0, "������������ ��� ������"),
		ERROR_ENTRY(1, "��������� ����"),
		ERROR_ENRTY_NODEF(2), ERROR_ENRTY_NODEF(3), ERROR_ENRTY_NODEF(4), ERROR_ENRTY_NODEF(5),
		ERROR_ENRTY_NODEF(6), ERROR_ENRTY_NODEF(7), ERROR_ENRTY_NODEF(8), ERROR_ENRTY_NODEF(9),
		ERROR_ENRTY_NODEF10(10), ERROR_ENRTY_NODEF10(20),ERROR_ENRTY_NODEF10(30), ERROR_ENRTY_NODEF10(40), ERROR_ENRTY_NODEF10(50),
		ERROR_ENRTY_NODEF10(70), ERROR_ENRTY_NODEF10(80), ERROR_ENRTY_NODEF10(90),
		ERROR_ENTRY(100, "�������� -in ������ ���� �����"),
		ERROR_ENRTY_NODEF(101), ERROR_ENRTY_NODEF(102), ERROR_ENRTY_NODEF(103),
		ERROR_ENTRY(104, "��������� ����� �������� ���������"),
		ERROR_ENRTY_NODEF(105), ERROR_ENRTY_NODEF(106), ERROR_ENRTY_NODEF(107),
		ERROR_ENRTY_NODEF(108), ERROR_ENRTY_NODEF(109),
		ERROR_ENTRY(110, "������ ��� �������� ����� � �������� ����� (-in)"),
		ERROR_ENTRY(111, "������������ ������ � �������� ����� (-in)"),
		ERROR_ENTRY(112, "������ ��� �������� ����� ��������� (-log)"),
		ERROR_ENRTY_NODEF(113), ERROR_ENRTY_NODEF(114), ERROR_ENRTY_NODEF(115),
		ERROR_ENRTY_NODEF(116), ERROR_ENRTY_NODEF(117), ERROR_ENRTY_NODEF(118), ERROR_ENRTY_NODEF(119),
		ERROR_ENRTY_NODEF10(120), ERROR_ENRTY_NODEF10(130),ERROR_ENRTY_NODEF10(140), ERROR_ENRTY_NODEF10(150),
		ERROR_ENRTY_NODEF10(160), ERROR_ENRTY_NODEF10(170),ERROR_ENRTY_NODEF10(180), ERROR_ENRTY_NODEF10(190),
		ERROR_ENRTY_NODEF100(200), ERROR_ENRTY_NODEF100(300),ERROR_ENRTY_NODEF100(400), ERROR_ENRTY_NODEF100(500),
		ERROR_ENRTY_NODEF100(600), ERROR_ENRTY_NODEF100(700),ERROR_ENRTY_NODEF100(800), ERROR_ENRTY_NODEF100(900)
	};
	ERROR geterror(int id)
	{
		ERROR check;
		check.id = id;
		int i = 0;
		if ((id < 0) || (id > ERROR_MAX_ENTRY)) {
			check = errors[0];
		}
		else {
			while (errors[i].id != id) { i++; }
			check = errors[i];
		}
		return check;
	}
	ERROR geterrorin(int id, int line = -1, int col = -1)
	{
		ERROR check;
		check.id = id;
		int i = 0;
		if ((id < 0) || (id > ERROR_MAX_ENTRY)) {
			check = errors[0];
		}
		else {
			while (errors[i].id != id) { i++; }
			check = errors[i];
		}
		check.inext.line = line;
		check.inext.col = col;
		return check;
	}
};
