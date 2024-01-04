#include <iostream>
#include <vector>
#include <queue>
#pragma warning (disable: 4996);

using namespace std;

const int INF = 1e9;
const int VMAX = 100, EMAX = VMAX * 2;
int pointer;
int head[VMAX];
int nextElem[EMAX];
int terminal[EMAX];

vector<int> bfs(vector<vector<int>> &graph, int start) {
	vector<int> dist(graph.size(), INF);
	queue<int> q;

	dist[start] = 0;
	q.push(start);

	while (!q.empty()) {
		int v = q.front();
		cout << " -> " << v + 1;
		q.pop();

		for (int to : graph[v]) {
			if (dist[to] > dist[v] + 1) {
				dist[to] = dist[v] + 1;
				q.push(to);
			}
		}
	}

	return dist;
}

void dfs(vector<vector<int>>& graph, int v, vector<int>& visited) {
	visited[v] = 1;
	cout << " -> " << v + 1;

	for (int to : graph[v]) {
		if (!visited[to]) {
			dfs(graph, to, visited);
		}
	}
}

void Add(int v, int u) {
	pointer++;
	terminal[pointer] = u;
	nextElem[pointer] = head[v];
	head[v] = pointer;
}

int main() {
	freopen("input.txt", "r", stdin);
	freopen("output.txt", "w", stdout);

	int vertexCount, edgeCount;
	cin >> vertexCount >> edgeCount;
	
	// список рёбер
	vector<vector<int>> graph(vertexCount);

	// матрица смежности
	vector<vector<int>> adj(vertexCount, vector<int>(vertexCount,0));

	// список смежности


	for (int i = 0; i < edgeCount; i++) {
		int a, b;
		cin >> a >> b;

		graph[a].push_back(b);
		graph[b].push_back(a);

		adj[a][b] = 1;
		adj[b][a] = 1;

		Add(a, b);
		Add(b, a);
	}

	int start;
	cin >> start;

	// список смежности

	vector<int> dist = bfs(graph, start);

	cout << "\n";

	for (int d : dist) {
		if (d != INF)
			cout << d << " ";
		else
			cout << "X";
	}

	cout << "\n\n";

	vector<int> visited(graph.size(), 0);

	for (int v = 0; v < graph.size(); v++) {
		if (!visited[v])
			dfs(graph, v, visited);
	}

	cout << "\n";

	for (int v : visited)
		cout << v << " ";

	fclose(stdin);
	fclose(stdout);
}