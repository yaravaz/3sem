#include <iostream>
#include <stdio.h>
using namespace std;

#define INF INT_MAX

void floydAlgorithm(int shortPath[][6], int sequenceMatrix[6][6]);
void printResult(int dist[][6]);

int main()
{
    setlocale(LC_ALL, "rus");

    int matrixOfShortestPaths[6][6] =
    {
        {  0, 28, 21, 59, 12, 27},
        {  7,  0, 24,INF, 21,  9},
        {  9, 32,  0, 13, 11,INF},
        {  8,INF,  5,  0, 16,INF},
        { 14, 13, 15, 10,  0, 22},
        { 15, 18,INF,INF,  6,  0}
    };

    int vertexSequenceMatrix[6][6] =
    {
        {  0,  2,  3,  4,  5,  6},
        {  1,  0,  3,  4,  5,  6},
        {  1,  2,  0,  4,  5,  6},
        {  1,  2,  3,  0,  5,  6},
        {  1,  2,  3,  4,  0,  6},
        {  1,  2,  3,  4,  5,  0}
    };

    floydAlgorithm(matrixOfShortestPaths, vertexSequenceMatrix);

    return 0;
}

void floydAlgorithm(int shortPath[][6], int sequenceMatrix[6][6])
{
    int dist[6][6];

    for (int i = 0; i < 6; i++) 
    {
        for (int j = 0; j < 6; j++) 
        {
            dist[i][j] = shortPath[i][j];
        }
    }

    for (int m = 0; m < 6; m++)
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (dist[i][m] + dist[m][j] < dist[i][j])
                {
                    dist[i][j] = dist[i][m] + dist[m][j];
                    sequenceMatrix[i][j] = m + 1;
                }
            }
        }
    }

    cout << "Матрица D:\n\n";
    printResult(dist);
    cout << "\nМатрица S:\n\n";
    printResult(sequenceMatrix);
}

void printResult(int dist[][6])
{
    for (int i = 0; i < 6; i++) 
    {
        for (int j = 0; j < 6; j++) 
        {
            if (dist[i][j] == INF)
                cout << "INF\t";
            else
                cout << dist[i][j] << "\t";
        }
        cout << "\n";
    }
}