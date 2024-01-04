let object1 = {a:1, b:2};
let object2 = {c:1, h:2};

let object3 = {a:5, b:3};
let object4 = {b:4, h:2};

function extend(obj1, obj2){
    return Object.assign(obj1, obj2);
}

let result = extend(object1, object2);
console.log(result); // {a: 1, b: 2, c: 1, h: 2}

console.log(extend(object3, object4)); // {a: 5, b: 4, h: 2}