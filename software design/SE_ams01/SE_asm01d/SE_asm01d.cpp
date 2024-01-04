#include <iostream>

extern "C" {
	int getmin(int* arr, int size) {
		int min = INT_MAX;
		for (int i = 0; i < size; i++) {
			if (arr[i] < min) {
				min = arr[i];
			}
		}
		return min;
	}

	int getmax(int* arr, int size) {
		int max = 0;
		for (int i = 0; i < size; i++) {
			if (arr[i] > max) {
				max = arr[i];
			}
		}
		return max;
	}
}

//#include <algorithm>
//
//using namespace std;
//
//extern "C" {
//    int getMin(int arr[], int size) {
//        int min_val = *min_element(arr, arr + size);
//        return min_val;
//    }
//
//    int getMax(int arr[], int size) {
//        int max_val = *max_element(arr, arr + size);
//        return max_val;
//    }
//}