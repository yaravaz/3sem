let array = prompt("Предметы сдал(р, м, а)").split(", ");
let math = false;
let rus = false;
let eng = false;

if(array.indexOf("р") != -1)
    rus = true;
if(array.indexOf("м") != -1)
    math = true;
if(array.indexOf("а") != -1)
    eng = true;

if(!rus && !math && !eng)
    alert("Вы отчислены");
else if(rus && math && eng)
    alert("Поздравляем!! Вы остаётесь");
else
    alert("На пересачу");

