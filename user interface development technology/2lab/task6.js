let arr1 = ["cat", "dog", "snake", "dinosaur", "bird"];
let arr2 = ["cat", "otter", "bug", "snake"];
alert(checkForUniqueness(arr1, arr2));

function checkForUniqueness(arr1, arr2){
    let arr3 = [];
    for(let i = 0; i < arr1.length; i++)
        if(arr2.indexOf(arr1[i]) == -1)
            arr3.push(arr1[i]);
    return arr3;
}