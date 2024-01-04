let week = ['пн', 'вт', 'ср', 'чт', 'пт', 'сб', 'вс'];
let number = prompt("Введите номер дня недели", 1);
alert(week[number-1]);

let weekObject = {
    "1": "пн",
    "2": "вт",
    "3": "ср",
    "4": "чт",
    "5": "пт",
    "6": "сб",
    "7": "вс"
}
alert(weekObject[number]);