let x = 9;
var y = 8;
for (let prop in window){
    console.log(prop, '=', window[prop]);
}
// переопределение через глобальный объект
window.y = 33;
console.log(y);