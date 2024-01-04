#include <iostream>
#include <string>
#include <queue>
#include "Windows.h"
#include <unordered_map>
using namespace std;

#define EMPTY_STRING ""

// Узел дерева
struct Node
{
    char ch;
    int freq;
    Node* left, * right;
};

// Функция для выделения нового узла дерева
Node* getNode(char ch, int freq, Node* left, Node* right)
{
    Node* node = new Node();

    node->ch = ch;
    node->freq = freq;
    node->left = left;
    node->right = right;

    return node;
}

// Объект сравнения, который будет использоваться для упорядочивания кучи
struct comp
{
    bool operator()(const Node* l, const Node* r) const
    {
        // элемент с наивысшим приоритетом имеет наименьшую частоту
        return l->freq > r->freq;
    }
};

// Вспомогательная функция для проверки, содержит ли дерево Хаффмана только один узел
bool isLeaf(Node* root) {
    return root->left == nullptr && root->right == nullptr;
}

// Проходим по дереву Хаффмана и сохраняем коды Хаффмана на карте.
void encode(Node* root, string str, unordered_map<char, string>& huffmanCode)
{
    if (root == nullptr) {
        return;
    }

    // найден листовой узел
    if (isLeaf(root)) {
        huffmanCode[root->ch] = (str != EMPTY_STRING) ? str : "0";
    }

    encode(root->left, str + "0", huffmanCode);
    encode(root->right, str + "1", huffmanCode);
}

// Проходим по дереву Хаффмана и декодируем закодированную строку
void decode(Node* root, int& index, string str)
{
    if (root == nullptr) {
        return;
    }

    // найден листовой узел
    if (isLeaf(root))
    {
        cout << root->ch;
        return;
    }

    index++;

    if (str[index] == '0') {
        decode(root->left, index, str);
    }
    else {
        decode(root->right, index, str);
    }
}

// Строит дерево Хаффмана и декодирует заданный входной текст
void buildHuffmanTree(string text)
{
    // базовый случай: пустая строка
    if (text == EMPTY_STRING) {
        return;
    }

    // подсчитываем частоту появления каждого символа
    // и сохранить его на карте
    unordered_map<char, int> freq;
    for (char ch : text) {
        freq[ch]++;
    }

    for (auto pair : freq) {
        cout << pair.first << " : " << pair.second << endl;
    }

    // Создаем приоритетную очередь для хранения активных узлов дерева Хаффмана
    priority_queue<Node*, vector<Node*>, comp> pq;

    // Создаем конечный узел для каждого символа и добавляем его
    // в приоритетную очередь.
    for (auto pair : freq) {
        pq.push(getNode(pair.first, pair.second, nullptr, nullptr));
    }

    // делаем до тех пор, пока в queue не окажется более одного узла
    while (pq.size() != 1)
    {
        // Удаляем два узла с наивысшим приоритетом
        // (самая низкая частота) из queue

        Node* left = pq.top(); pq.pop();
        Node* right = pq.top();    pq.pop();

        // создаем новый внутренний узел с этими двумя узлами в качестве дочерних и
        // с частотой, равной сумме частот двух узлов.
        // Добавляем новый узел в приоритетную очередь.

        int sum = left->freq + right->freq;
        pq.push(getNode('\0', sum, left, right));
    }

    // `root` хранит указатель на корень дерева Хаффмана
    Node* root = pq.top();

    // Проходим по дереву Хаффмана и сохраняем коды Хаффмана
    // на карте. Кроме того, распечатайте их
    unordered_map<char, string> huffmanCode;
    encode(root, EMPTY_STRING, huffmanCode);

    for (auto pair : huffmanCode) {
        cout<< pair.first << " : " << pair.second << endl;

    }

    cout << "\nВведённая строка: \t" << text << endl;

    // Печатаем закодированную строку
    string str;
    for (char ch : text) {
        str += huffmanCode[ch];
    }

    cout << "\nЗакодированная строка: \t" << str << endl;

    if (isLeaf(root))
    {
        // Особый случай: для ввода типа a, aa, aaa и т. д.
        while (root->freq--) {
            cout << root->ch;
        }
    }
    else {
        // Снова проходим по дереву Хаффмана и на этот раз
        // декодируем закодированную строку
        int index = -1;
        while (index < (int)str.size() - 1) {
            decode(root, index, str);
        }
    }
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    string text;
    getline(cin, text);
    buildHuffmanTree(text);

    cout << endl << endl << endl;
    system("pause");
    return 0;
}