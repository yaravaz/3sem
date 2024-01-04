let students = [
    {name: "Илья", age: 21, groupId: 4},
    {name: "Ксения", age: 16, groupId: 3},
    {name: "Ульяна", age: 19, groupId: 1},
    {name: "Кирилл", age: 19, groupId: 1},
    {name: "Геннадий", age: 19, groupId: 4},
    {name: "Яна", age: 18, groupId: 3},
]

function filterStudents(students){
    let result = {};
    students.forEach(student => {
        let {name, age, groupId} = student;
        if (age > 17) {
            if(!result[groupId]){
                result[groupId] = [];
            }
            result[groupId].push({name, age});
        }
    });
    return result;
}

console.log(filterStudents(students));