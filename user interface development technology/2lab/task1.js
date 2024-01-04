function basicOperation(operation, value1, value2) {
    let result = 0;
    switch(operation){
        case '+': result = value1 + value2; break;
        case '-': result = value1 - value2; break;
        case '*': result = value1 * value2; break;
        case '/': result = value1 / value2; break;
    }
    return result;
}

let result = basicOperation('+', 5, 10); 
alert(result); // result 15