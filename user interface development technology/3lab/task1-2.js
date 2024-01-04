let arrayA = [1, [1, 2, [3, 4]], [2, [3, [4, 8]]]];
let arrayB = [6, [8, 2], [2, 9]];

function mergedArr(arr){
    return arr.reduce(function(result, item){ 
        return Array.isArray(item) ? result.concat(mergedArr(item)) : result.concat(item)
    }, [])
}

let newArray = mergedArr(arrayA).concat(mergedArr(arrayB))

console.log(newArray)

const sum = newArray.reduce((partialSum, a) => partialSum + a, 0)

alert(sum)