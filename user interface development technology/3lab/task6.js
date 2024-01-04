let floors = 10;

function tower(num){
    let tower = [];
    let count = num;
    let stars = 1;
    for(let i = 1; i <= num; i++){
        tower[i-1] = " ".repeat(count)+"*".repeat(stars);
        count--;
        stars += 2;
    }
    return tower;
}

console.log(tower(floors));