let arrayOfNumbers = [1, 3, 5, 7, 2, 8, 9]
alert(findAverage(arrayOfNumbers)); // result 5

function findAverage(array){
    let result = 0;
    for(let i = 0; i < array.length; i++)
        result += array[i];
    return result / array.length;
}
