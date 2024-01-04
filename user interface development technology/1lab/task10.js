let second = "cvbn";
let third = prompt("Введите параметр", "param");

function concatFunction(y, z, x = 42){
    return x + y + z;
}

console.log(concatFunction(second, third));

// 42cvbnparam