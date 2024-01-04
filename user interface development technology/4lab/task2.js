// список студентов
let students = new Set()

function AddStud(cardNum, groupNum, FIO){
    let student = {
        card: cardNum,
        group: groupNum,
        name: FIO
    }
    students.add(student)
}

function DeleteByNumber(number){
    students.forEach(student => { if(student.card == number){ students.delete(student)}})
    console.log('был отчислен студент')
}

function Filter(group){
    return [...students].filter(student => student.group == group)
}

function Sort(){
    return [...students].sort((a, b) => a.card - b.card)
}

AddStud(3, 5, "Ципинё Антон Богданович");
AddStud(5, 5, "Стасеня Артемий Александрович");
AddStud(2, 3, "Ловенеч Илья Евгеньевич");
AddStud(1, 4, "Литвинов Кирилл Валерьянович");
AddStud(6, 3, "Дормат Дмитрий Дмитриевич");

DeleteByNumber(1)

console.log(students)

console.log(Filter(5))

console.log(Sort())