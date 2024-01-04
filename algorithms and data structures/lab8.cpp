#include<stdio.h>
#include<stdlib.h>
#include <iostream>

using namespace std;

typedef struct items
{
    char name[20];
    unsigned int weight;
    float profit;
};

float max(float a, float b)
{
    return ((a > b) ? a : b);
}

float knapsack(unsigned int n, struct items object[], unsigned int capacity)
{
    float** table = new float* [n + 1];

    for (unsigned int i = 0; i <= n; i++)
    {
        table[i] = new float[capacity + 1];
        for (unsigned int j = 0; j <= capacity; j++)
        {
            if (i == 0 || j == 0)
                table[i][j] = 0.0;
            else if (object[i - 1].weight <= j)
                table[i][j] = max((object[i - 1].profit + table[i - 1][j - object[i - 1].weight]), table[i - 1][j]);
            else
                table[i][j] = table[i - 1][j];
        }
    }

    int i = n;
    int j = capacity;

    cout << "\n Прведметы и их цена: \n\n";

    while (i > 0 && j > 0)
    {
        if (table[i][j] != table[i - 1][j])
        {
            cout << object[i - 1].name << " " << object[i -1].profit << endl;
            j -= object[i - 1].weight;
        }
        i--;
    }
    
    cout << endl;
    system("pause");


    return table[n][capacity];
}

void main()
{
    setlocale(LC_ALL, "rus");

    unsigned int capacity;
    cout << "Введите вмещаемость рюкзака: \n > ";
    cin >> capacity;

    unsigned int n;
    printf("Введите кол-во всех предметов: \n > ");
    cin >> n;

    items* item = new items[n];

    printf("Введите предметы и их описание:\n\n");
    for (unsigned int i = 0; i < n; i++)
    {
        printf(" - Предмет %d : \n", i + 1);
        printf("Имя : ");
        cin >> item[i].name;
        printf("Вес : ");
        cin >> item[i].weight;
        printf("Цена: ");
        cin >> item[i].profit;
        printf("<><><><><><><><><><><><><><>\n");
    }

    float max_profit = knapsack(n, item, capacity);

    printf("\n-----------------------------------------------\n");
    printf("Вы подняли за сегодня = %.2f рублей! :)\n", max_profit);\

    printf("-----------------------------------------------\n");
}