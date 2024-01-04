#include <iostream>
using namespace std;

void hanoi(int i, int k, int n)
{
	if (n == 1) {
		cout << "Переместить первый диск со стержня " << i << " на стержень " << k << endl;
	}
	else
	{
		int tmp = 6 - i - k;
		hanoi(i, tmp, n - 1);
		cout << "Переместить диск " << n << " со стержня " << i << " на стержень " << k << endl;
		hanoi(tmp, k, n - 1);
	}
}

int main()
{
	setlocale(LC_ALL, "rus");
	hanoi(1, 2, 4);
	return 0;
}