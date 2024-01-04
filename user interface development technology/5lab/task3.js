function* Generator(){
    let x = 0;
    let y = 0;

    while(true){
        let coordinates = yield {x, y};

        switch(coordinates){
            case 'up':
                y += 10;
                break;
            case 'down':
                y -= 10;
                break;
            case 'left':
                x -= 10;
                break;
            case 'right':
                x += 10;
                break;
        }
    }
}

let generator = Generator();
generator.next();

function Input(){
    input = prompt('Введите команду');
    if(['up', 'down', 'left', 'right'].includes(input)){
        let result = generator.next(input).value;
        alert(`(${result.x}, ${result.y})`);
        Input();
    }
}

Input();