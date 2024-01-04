let total1 = 'ABC';
let total2 = '';
for(let i = 0; i < total1.length; i++){
    total2 = total2 + total1[i].charCodeAt(0);
}
// let total2 = '1774927'
for(let i = 0; i < total2.length; i++){
    if(total2[i] == '7'){
        total2 = total2.replace(total2[i], '1');
    }
}
alert(total2);