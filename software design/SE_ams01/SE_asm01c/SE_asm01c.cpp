#include <iostream>
using namespace std;

extern "C" {
	int __stdcall getmin(int*, int);
	int __stdcall getmax(int*, int);
}

int main() {
	int array[10] = { 2,3, 5, 6, 7, 3, 4, 6, 7, 10 };

	cout << "getmax + getmin = " << getmin(array, 10) + getmax(array, 10);
}