let n = 5;
let s = "Hello";
alert(copyString(n, s));

function copyString(n, s){
    s = s.repeat(n);
    return s;
}