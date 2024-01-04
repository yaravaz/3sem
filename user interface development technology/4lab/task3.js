// хранилище товаров 
let map = new Map();

function AddElem(id, nameOfGood, countOfGood, priceOfGood){
    let good = {
        name: nameOfGood,
        count: countOfGood,
        price: priceOfGood
    }

    map.set(id, good);
}

function DeleteElem(id){
    if(map.delete(id)){
        console.log('Такой элемент был, но теперь его нет')
    }
    else{
        console.log('Нечего удалять')
    }
}

function DeleteByName(name){
    for(let [id, good] of map){
        if(good.name == name){
            map.delete(id)
            console.log('Нашёлся и был выброшен')
        }
    }
}

function ChangeCount(count){
    for(let good of map.values()){
        good.count += count
    }
    console.log('количество всех товаров было увеличено на ' + count)
}

function ChangePrice(idOfGood, price){
    for(let [id, good] of map){
        if(id == idOfGood){
            good.price += price
            console.log('Цена ' + good.name + ' была увеличена на ' + price)
        }
    }
}

AddElem(1234, 'что-то', 4, 230)
AddElem(4321, 'что-нибудь', 10, 2000)
AddElem(1324, 'ещё', 2, 150)
AddElem(2413, 'дополнительно', 23, 123)

DeleteElem(1324);
DeleteByName('дополнительно')

ChangeCount(2);
ChangePrice(1234, 100)

console.log(map);

// статистика: количество и общая цена
console.log('Количество позиций ' + map.size)
let totalPrice = 0;

for(let good of map.values()){
    totalPrice += good.count * good.price
}
console.log(totalPrice)
