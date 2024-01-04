function makeCounter(){
    let currentCount = 1;

    return function(){
        return currentCount++;
    }
}

let counter = makeCounter();

alert( counter() ); // 1
alert( counter() ); // 2
alert( counter() ); // 3

let counter2 = makeCounter();
alert( counter2() ); // 1

// -----------------------------

let currentCount = 1;

function makeCounter2(){
    return function(){
        return currentCount++;
    };
}

let counter1_1 = makeCounter2();
let counter1_2 = makeCounter2();

alert( counter1_1() ); // 1
alert( counter1_1() ); // 2

alert( counter1_2() ); // 3
alert( counter1_2() ); // 4