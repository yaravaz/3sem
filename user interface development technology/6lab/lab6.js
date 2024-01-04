// 1 ЗАДАНИЕ

// получить 1 элемент
let numbers = [2, 4, 5, 6, 3];

let [elem] = numbers;
console.log(elem); 

// 2 ЗАДАНИЕ

// добавить в admin св-ва user
let user = {
    name: "Ivan",
    age:30
};

let admin = {admin: true, ...user};

console.log(admin);

// 3 ЗАДАНИЕ

// деструктуризация объекта
let store = {
    state: { // 1 уровень
        profilePage: { // 2 уровень
            posts: [ // 3 уровень
                {id: 1, message: 'Hi', likesCount: 12},
                {id: 2, message: 'By', likesCount: 1},
            ],
            newPostText: 'About me',
        },
        dialogsPage: {
            dialogs: [
                {id: 1, name: 'Valeria'},
                {id: 2, name: 'Andrey'},
                {id: 3, name: 'Sasha'},
                {id: 4, name: 'Viktor'},
            ],
            messages: [
                {id: 1, message: 'hi'},
                {id: 2, message: 'hi hi'},
                {id: 3, message: 'hi hi hi'},
            ],
        },
        sidebar: [],
    },
}

// деструктуризация
console.log({state: {profilePage: {posts, newPostText}, dialogsPage: {dialogs, messages}, sidebar}} = store);

console.log(dialogs[3].name);

// вывод эдементов массива
console.log("likeCount:");
posts.forEach(elem => {
    console.log(elem.likesCount);
})

// фильтрация массива по четным id

console.log(dialogs.filter((elem) => elem.id % 2 == 0));

// замена всех сообщений на "Hello user" с помощью map

let newMessages = messages.map((m) => 
    {return m = {id: m.id, message: "Hello user"};})

console.log(newMessages);

// 4 ЗАДАНИЕ

// добавить новую задачу с помощью spread

let tasks = [
    { id: 1, title: "HTML&CSS", isDone: true },
    { id: 2, title: "JS", isDone: true },
    { id: 3, title: "ReactJS", isDone: false },
    { id: 4, title: "Rest API", isDone: false },
    { id: 5, title: "GraphQL", isDone: false },
];

tasks = [...tasks, { id: 6, title: "Sass", isDone: true }];
console.log(tasks);

// 5 ЗАДАНИЕ

// передать массив в качетсве параметра

function sumValues(x, y, z){
    return x + y + z;
}

console.log(sumValues(...[1, 2, 3]));
