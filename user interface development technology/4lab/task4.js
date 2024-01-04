// кеширование результатов
let weakMap = new WeakMap();

function Sum(arr){
    if(weakMap.has(arr)){
        console.log("взято из кэша")
        return weakMap.get(arr)
    }

    let sum = 0;
    for(let i = 0; i < arr.length; i++){
        sum += arr[i];
    }

    weakMap.set(arr, sum)

    return sum
}

let array = [2, 4, 6]
let array2 = [3, 6, 9]

console.log(Sum(array))
console.log(Sum(array2))
console.log(Sum(array))
console.log(weakMap)
