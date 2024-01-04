let n = 5
let sumCubes = (n) => {
    let result = 0;
    for(let i = 1; i <= n; i++)
        result += Math.pow(i, 3);
    alert(result);
};

sumCubes(n);

// function sumCubes(n){
//     let result = 0;
//     for(let i = 1; i <= n; i++)
//         result += Math.pow(i, 3);
//     return result;
// }