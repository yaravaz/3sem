#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <Winsock2.h>
#include <Iphlpapi.h>
//#include <arpa/inet.h>
//
//const char* inet_ntop(int af, const void* src, char* dst, socklen_t size);
//int inet_pton(int af, const char* src, void* dst);


#pragma comment(lib, "WS2_32.lib")
#pragma comment(lib, "IPHlpApi.Lib")

using namespace std;

bool CheckAddr(char* ip_)
{
	int points = 0, // ���������� �����
		numbers = 0; // �������� ������

	char* buff; // ����� ��� ������ ������

	buff = new char[3];

	for (int i = 0; ip_[i] != '\0'; i++)
	{ // ��� ������ IP-������
		if (ip_[i] <= '9' && ip_[i] >= '0') // ���� �����
		{
			if (numbers > 3) return false;
			//���� ������ ���� ����� � ������ � ������
			buff[numbers++] = ip_[i];
			//����������� � �����
		}
		else
			if (ip_[i] == '.') // ���� �����
			{
				if (atoi(buff) > 255)
					// ��������� �������� ������
					return false;

				if (numbers == 0)
					//���� ����� ��� - ������
					return false;

				numbers = 0;
				points++;
				delete[]buff;
				buff = new char[3];
			}
			else return false;
	}
	if (points != 3)
		// ���� ���������� ����� � IP-������ �� 3 - ������
		return false;

	if (numbers == 0 || numbers > 3)
		return false;

	return true;
}

int main() {
	setlocale(LC_ALL, "rus");

	WSADATA wsaData;
	if (WSAStartup(0x0202, &wsaData) != NULL)
		cout << "WSA: ������ !\n";


	char* ip_, * ip_end_;
	DWORD ip, ip_end;
	bool flag = true;
	ip_ = new char[16];
	SOCKET udp_s;
	SOCKADDR_IN udp_sin;
	do
	{
		if (!flag) cout << "�������� IP" << endl;
		cout << "������� IP: ";
		cin >> ip_;
	} while (!(flag = CheckAddr(ip_)));
	udp_s = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (udp_s != SOCKET_ERROR)
	{
		ip = inet_addr(ip_);
		udp_sin.sin_family = AF_INET; //���������
		udp_sin.sin_port = htons(5234); //����
		udp_sin.sin_addr.S_un.S_addr = ip; //IP ������

		unsigned long inet_addr(const char FAR * cp);

		if
			(sendto(udp_s, "TEST", 5, NULL, (SOCKADDR*)&udp_sin,
				sizeof(udp_sin)) > 0)
		{
		}
		else
		{
			cout << "������ ��������! \n " << WSAGetLastError();
		}

		if (connect(udp_s, (sockaddr*)&udp_sin,
			sizeof(udp_sin)))
		{
			cout << "������ ����������! \n "
				<< WSAGetLastError();
			return -1;
		}

		MIB_IPNETTABLE* pIpNetTable =
			(MIB_IPNETTABLE*) new char[0xFFFF];
		ULONG cbIpNetTable = 0xFFFF;
		if (NO_ERROR ==
			GetIpNetTable(pIpNetTable, &cbIpNetTable, true))
		{
			for (DWORD i = 0; i < pIpNetTable->dwNumEntries; i++)
			{
				//���� ����� � ���� dwAddr ��������� � ������� ip
				//� dwType ������� �� 2. 
				//�������� 2 ������������ ����������� ��� 
				//������������� ARP ������
				if (pIpNetTable->table[i].dwAddr == ip
					&& pIpNetTable->table[i].dwType != 2)
				{
					//��������� � ������� MAC
					printf("%s : %X-%X-%X-%X-%X-%X\n", ip_,
						pIpNetTable->table[i].bPhysAddr[0],
						pIpNetTable->table[i].bPhysAddr[1],
						pIpNetTable->table[i].bPhysAddr[2],
						pIpNetTable->table[i].bPhysAddr[3],
						pIpNetTable->table[i].bPhysAddr[4],
						pIpNetTable->table[i].bPhysAddr[5]);
					//����������� �������
					delete[] pIpNetTable;
				}
			}
		}

		if (WSACleanup() == SOCKET_ERROR)
			cout << "ERROR Closesocket "
			<< WSAGetLastError();

	}
	else
	{
		cout << "������ �������� socket\n";
	}
}