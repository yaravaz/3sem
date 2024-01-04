let array = [];
for(let i = 1; i <= 10; i++){
    if(i % 2 != 0)
        array[i-1] = i + "мм";
    else
        array[i-1] = i + 2;
}

console.log(array);
// ['1мм', 4, '3мм', 6, '5мм', 8, '7мм', 10, '9мм', 12]