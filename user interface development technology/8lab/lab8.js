// 1 
let  user = {
    name: 'Masha',
    age: 21
};

let userCopy = {...user};
console.log(userCopy);
// ------------------------------

// 2
let numbers = [1, 2, 3];

let numbersCopy = [...numbers];
console.log(numbersCopy);
// ------------------------------

// 3
let user1 = {
    name: 'Masha',
    age: 23,
    location: {
        city: 'Minsk',
        country: 'Belarus'
    }
};

let user1Copy = {...user1, location: {...user1.location}}
console.log(user1Copy);
// ------------------------------

// 4
let user2 = {
    name: 'Masha',
    age: 28,
    skills: ["HTML", "CSS", "JavaScript", "React"]
};

let user2Copy = {...user2, skills: [...user2.skills]}
console.log(user2Copy);
// ------------------------------

// 5
const array = [
    {id: 1, name: 'Vasya', group: 10},
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

let arrayCopy = array.map(el => ({...el}));
console.log(arrayCopy);
// ------------------------------

// 6
let user4 = {
    name: 'Masha',
    age: 19,
    studies:{
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        exams: {
            maths: true,
            programming: false
        }
    }
};

let user4Copy = {
    ...user4, 
    studies:{
        ...user4.studies, 
        exams:{
            ...user4.studies.exams
        }
    }
};
console.log(user4Copy);
// ------------------------------

// 7
let user5 = {
    name: 'Masha',
    age: 22,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            {maths: true, mark: 8},
            {programming: true, mark: 4},
        ]
    }
};

let user5Copy = {
    ...user5,
    studies:{
        ...user5.studies,
        department:{
            ...user5.studies.department
        },
        exams: user5.studies.exams.map(exam => ({ ...exam}))
    }
}
console.log(user5Copy);
// ------------------------------

// 8
let user6 = {
    name: 'Masha',
    age: 21,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { 
                maths: true,
                mark: 8,
                professor: {
                    name: 'Ivan Ivanov',
                    degree: 'PhD'
                }
            },
            {
                programming: true,
                mark: 10,
                professor:{
                    name: 'Petr Pertov',
                    degree: 'PhD'
                }
            },
        ]
    }
};

let user6Copy = {
    ...user6,
    studies: {
        ...user6.studies,
        exams: user6.studies.exams.map(exam => ({
            ...exam,
            professor: {...exam.professor},
        }))
    }
}
console.log(user6Copy);
// ------------------------------

// 9
let user7 = {
    name: 'Masha',
    age: 20,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { 
		maths: true,
		mark: 8,
		professor: {
		    name: 'Ivan Petrov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		}
	     },
            { 
		programming: true,
		mark: 10,
		professor: {
		    name: 'Petr Ivanov',
		    degree: 'PhD',
		    articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		}
	     },
        ]
    }
};

let user7Copy = {... user7};
user7Copy.studies = {... user7.studies};
user7Copy.studies.department = {... user7.studies.department};
user7Copy.studies.exams = [...user7Copy.studies.exams];
user7Copy.studies.exams[0] = {...user7.studies.exams[0]};
user7Copy.studies.exams[1] = {...user7.studies.exams[1]};
user7Copy.studies.exams[0].professor = {...user7.studies.exams[0].professor};
user7Copy.studies.exams[0].professor.articles = [...user7.studies.exams[0].professor.articles];
user7Copy.studies.exams[0].professor.articles[0] = {...user7.studies.exams[0].professor.articles[0]};
user7Copy.studies.exams[0].professor.articles[1] = {...user7.studies.exams[0].professor.articles[1]};
user7Copy.studies.exams[0].professor.articles[2] = {...user7.studies.exams[0].professor.articles[2]};
user7Copy.studies.exams[1].professor = {...user7.studies.exams[1].professor};
user7Copy.studies.exams[1].professor.articles = [...user7.studies.exams[1].professor.articles];
user7Copy.studies.exams[1].professor.articles[0] = {...user7.studies.exams[1].professor.articles[0]};
user7Copy.studies.exams[1].professor.articles[1] = {...user7.studies.exams[1].professor.articles[1]};
user7Copy.studies.exams[1].professor.articles[2] = {...user7.studies.exams[1].professor.articles[2]};

user7Copy.studies.exams[1].professor.articles[1].title = "Новое название";
console.log(user7);
console.log(user7Copy);
// let user7Copy = {

//      ...user7,
//     studies: {
//         ...user7.studies,
//         department: {...user7.studies.department},
//         exams: user7.studies.exams.map(exam => ({
//             ...exam,
//             professor:{
//                 ...exam.professor,
//                 articles: exam.professor.articles.map(article => ({...article}))
//             }
//         }))
//     }
// };

// ------------------------------

// 10
let store = {
    state: {
        profilePage: {
            posts: [
                {id: 1, message: 'Hi', likesCount: 12},
                {id: 2, message: 'By', likesCount: 1},
            ],
            newPostText: 'About me',
        },
        dialogsPage:{
            dialogs:[
                {id: 1, name: 'Valera'},
                {id: 2, name: 'Andrey'},
                {id: 3, name: 'Sasha'},
                {id: 4, name: 'Viktor'},
            ],
            messages:[
                {id: 1, message: 'hi'},
                {id: 2, message: 'hi hi'},
                {id: 3, message: 'hi hi hi'},
            ],
        },
        sidebar: [],
    }
}

let storeCopy = {
    state: {
        ...store.state,
        profilePage:{
            ...store.state.profilePage,
            posts: store.state.profilePage.posts.map(post => ({...post})),
        },
        dialogsPage: {
            ...store.state.dialogsPage,
            dialogs: store.state.dialogsPage.dialogs.map(dialog => ({...dialog})),
            messages: store.state.dialogsPage.messages.map(message => ({...message})),
        },
        sidebar: [...store.state.sidebar],
    },
};
console.log(storeCopy);

//----------------------------------------------
//----------------------------------------------

user5Copy.studies.department.group = 12;
user5Copy.studies.exams[1].mark = 10;
console.log(user5Copy);

user6Copy.studies.exams[0].professor.name = "Victor Adamovich";
console.log(user5Copy);

user7Copy.studies.exams[1].professor.articles[1].pagesNumber = 3;
console.log(user7Copy);

store.state.dialogsPage.messages = store.state.dialogsPage.messages.map((m) => {
    return m = {id: m.id, message: "Hello"};
})
console.log(store);