console.log("Котик" > "котик"); // false
console.log("Котик" > "китик"); // false
console.log("Кот" > "Котик"); // false
console.log("Привет" > "Пока"); // true
console.log(73 > "53"); // true
console.log(false == 0); // true
console.log(54 < true); // false
console.log(123 > false); // true
console.log(true > "3"); // false
console.log(3 > "5мм"); // false
console.log(8 > "-2"); // true
console.log(34 == "34"); // true
console.log(null == undefined); // true

document.querySelector('.napoleon').onclick = () =>{
    let a = document.querySelector('.i-1').value;
    (a == "Napoleon") ? alert("*music started playing* There's nothing we can do...") : alert(a);
}