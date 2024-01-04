let a = 7;
let b = 7;

// Function Declaration
function params1(a,b){
    if(a == b)
        return 2 * (a+b);
    else
        return a*b;
}

// Function Expression
let params2 = function(a, b){
    if(a == b)
        return 2 * (a+b);
    else
        return a*b;
}

// Стрелочная функция
let params3 = (a, b) => a == b ? alert(2 * (a+b)) : alert(a*b);


alert(params1(a, b));
alert(params2(a, b));
params3(a, b);