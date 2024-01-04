#include <vector>
#include <iostream>
#include <windows.h>
using namespace std;

#define INF INT_MAX

bool isValidEdge(int a, int b, vector<bool> visited)
{
    if (a == b)
        return false;
    if (visited[a] == false && visited[b] == false)
        return false;
    else if (visited[a] == true && visited[b] == true)
        return false;
    return true;
}

void prima(int graph[][8])
{
    vector<bool> visited(8, false);

    visited[0] = true;

    int countOfVertex = 0, mindist = 0;
    while (countOfVertex < 7) {
        int min = INF, a = -1, b = -1;
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (graph[i][j] < min) {
                    if (isValidEdge(i, j, visited)) {
                        min = graph[i][j];
                        a = i;
                        b = j;
                    }
                }
            }
        }
        if (a != -1 && b != -1) {
            cout << a + 1 << '-' << b + 1 << endl;
            countOfVertex++;
            mindist = mindist + min;
            visited[b] = visited[a] = true;
        }
    }
    cout << '\n' << mindist;
}

int parent[8];

int find(int i)
{
    while (parent[i] != i)
        i = parent[i];
    return i;
}

void union1(int i, int j)
{
    int a = find(i);
    int b = find(j);
    parent[a] = b;
}

void krаskala(int graph[][8])
{
    int mincost = 0;
    for (int i = 0; i < 8; i++)
        parent[i] = i;

    int countOfVertex = 0;
    while (countOfVertex < 7) {
        int min = INF, a = -1, b = -1;
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (find(i) != find(j) && graph[i][j] < min) {
                    min = graph[i][j];
                    a = i;
                    b = j;
                }
            }
        }

        union1(a, b);

        cout << a+1 << '-' << b + 1 << endl;
        mincost += min;
        countOfVertex++;
    }

    cout << "\n" << mincost;
}

int main()
{
    setlocale(LC_ALL, "rus");

    int graph[][8] = {
        {INF, 2, INF, 8, 2, INF, INF, INF},
        {2,INF, 3, 10, 5, INF, INF, INF},
        {INF, 3,INF, INF, 12, INF, INF, 7},
        {8, 10,INF, INF, 14, 3, 1, INF},
        {2, 5, 12, 14, INF, 11, 4, 8},
        {INF, INF, INF, 3, 11, INF, 6, INF},
        {INF, INF, INF, 1, 4, 6, INF, 9},
        {INF, INF, 7, INF, 8,INF, 9, INF},
    };
    cout << "\nАлгоритм Прима:\n";
    prima(graph);

    cout << "\nАлгоритм Краскала:\n";
    krаskala(graph);

    return 0;
}