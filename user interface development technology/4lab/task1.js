// список товаров 
let goods = new Set(['smartphone', 'watch', 'fridge'])

function AddElem(elem){
    goods.add(elem)
    console.log('добавлен элемент ' + elem)
}

function DeleteElem(elem){
    goods.delete(elem)
    console.log('элемент удалён ' + elem)
}

function HasElem(elem){
    if(goods.has(elem)){
        console.log('такое элемент есть')
    }
    else{
        console.log('к сожалению я не нашёл такой элемент ಥ_ಥ')
    }
}

alert(goods.size)

AddElem('vacuum cleaner')
AddElem('vacuum cleaner')
AddElem('washing machine')

DeleteElem('watch');

HasElem('watch')

alert(goods.size)

console.log(goods)