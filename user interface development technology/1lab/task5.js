let nameTeacher = "марина";

let str = prompt("Введите данные", "name").toLowerCase();
let array = str.split(" ");
if (str.indexOf(nameTeacher) != -1){
    if ((array.length == 3 && array[1] == nameTeacher) || 
        (array.length == 2 && array[0] == nameTeacher) || 
        (array.length == 1 && array[0] == nameTeacher)){
            alert("Верные данные");
    }
    else
        alert("Данные неверны");
}
else
    alert("Данные неверны");

// Имя                   -- str[0] length = 1
// Имя Отчество          -- str[0] length = 2
// Фамилия Имя Отчеств   -- str[1] length = 3