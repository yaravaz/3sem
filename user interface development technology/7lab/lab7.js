// 1 ЗАДАНИЕ

// создать объект по параметрам
let products = {
    Shoes:{
        Boots:[
            {id: 11, size: 35, color: 'red', price: 34 },
            {id: 22, size: 37, color: 'blue', price: 35 },
            {id: 33, size: 38, color: 'red', price: 65 },
            {id: 44, size: 39, color: 'green', price: 24 },
            {id: 55, size: 40, color: 'white', price: 56 }
        ], 
        Sneakers:[
            {id: 21, size: 32, color: 'black', price: 12 },
            {id: 22, size: 33, color: 'yellow', price: 14 },
            {id: 23, size: 34, color: 'orange', price: 21 },
            {id: 24, size: 35, color: 'red', price: 24 },
            {id: 25, size: 36, color: 'white', price: 34 }
        ],
        Sandals:[
            {id: 31, size: 35, color: 'red', price: 56 },
            {id: 32, size: 34, color: 'blue', price: 76 },
            {id: 33, size: 34, color: 'grey', price: 87 },
            {id: 34, size: 45, color: 'white', price: 45 },
            {id: 35, size: 41, color: 'white', price: 67 }
        ],
    }
}
console.log(products);

// 2 ЗАДАНИЕ

// создать функцию для фильтрации по цене, размеру, цвету

function FilterGoods(products, min, max, size, color){
    let filtered = [];

    for(let item in products.Shoes){
        let shoes = products.Shoes[item];

        shoes.forEach(shoe => {
            if (shoe.price >= min && shoe.price <= max && 
                shoe.size == size && shoe.color == color){
                    filtered.push(shoe.id);
                }
        });
    }

    return filtered;
}

console.log(FilterGoods(products, 20, 60, 35, "red"))

// 3-4 ЗАДАНИЕ

// создать новый объект

let newProducts = {
    Shoes:{
        Boots:[
            {id: 11, size: 35, color: 'red', price: 34, discount: 10 },
            {id: 12, size: 37, color: 'blue', price: 35, discount: 15 },
            {id: 13, size: 38, color: 'red', price: 65, discount: 14 },
            {id: 14, size: 39, color: 'green', price: 24, discount: 10 },
            {id: 15, size: 40, color: 'white', price: 56, discount: 11 }
        ], 
        Sneakers:[
            {id: 21, size: 32, color: 'black', price: 12, discount: 20 },
            {id: 22, size: 33, color: 'yellow', price: 14, discount: 100 },
            {id: 23, size: 34, color: 'orange', price: 21, discount: 25 },
            {id: 24, size: 35, color: 'red', price: 24, discount: 75 },
            {id: 25, size: 36, color: 'white', price: 34, discount: 35 }
        ],
        Sandals:[
            {id: 31, size: 35, color: 'red', price: 56, discount: 2 },
            {id: 32, size: 34, color: 'blue', price: 76, discount: 3 },
            {id: 33, size: 34, color: 'grey', price: 87, discount: 4 },
            {id: 34, size: 45, color: 'white', price: 45, discount: 2 },
            {id: 35, size: 41, color: 'white', price: 67, discount: 5 }
        ],
    }
}
console.log(newProducts);

// свойство-аксессор

Object.keys(newProducts.Shoes).forEach(category =>{
    newProducts.Shoes[category].forEach(shoe => {
        shoe.cost = shoe.price;
        Object.defineProperty(shoe, 'id', {
            writable: false, // нельзя изменять
            enumerable: true,
            configurable: false // нельзя удалять 
        });

        Object.defineProperty(shoe, 'price', {
            get(){
                return this.cost - (this.cost * this.discount / 100);
            },
            set(newValue){
                this.cost = newValue;
            },
            enumerable: true,
            configurable: false
        });
    });
});
console.log(newProducts);
newProducts.Shoes.Boots[0].id = 2;
console.log(newProducts.Shoes.Boots[0].id) // 11
console.log(newProducts.Shoes.Boots[2].price);

// 5 ЗАДАНИЕ 

function shoesPare(id, size, color, discount, cost){
    this.size = size;
    this.color = color;
    this.discount = discount;
    this.cost = cost;
    Object.defineProperty(this, 'id', {
        value: id,
        writable: false,
        enumerable: true,
        configurable: false
    });
    Object.defineProperty(this, 'price', {
        get(){
            return this.cost * (1 - this.discount / 100)
        },
        set(newPrice){
            this.cost = newPrice
        },
        enumerable:true,
        configurable: false
    });
}

// class shoesPare{
//     constructor(id, size, color, discount, cost){
//         this.size = size;
//         this.color = color;
//         this.discount = discount;
//         this.cost = cost;
//         Object.defineProperty(this, 'id', {
//             value: id,
//             writable: false,
//             enumerable: true,
//             configurable: false
//         });
//         Object.defineProperty(this, 'price', {
//             get(){
//                 return this.cost * (1 - this.discount / 100)
//             },
//             set(newPrice){
//                 this.cost = newPrice
//             },
//             enumerable:true,
//             configurable: false
//         });
//     }
// }

// 6 ЗАДАНИЕ

let allProduct={
    Shoes:{
        Boots:[
            new shoesPare(11, 35, 'red', 34, 10),
            new shoesPare(12, 37, 'blue', 35, 15),
            new shoesPare(13, 38, 'red', 65, 14),
            new shoesPare(14, 39, 'green', 24, 10),
            new shoesPare(15, 40, 'white', 56, 11),
        ],
        Sneakers:[
            new shoesPare(21, 32, 'black', 12, 20),
            new shoesPare(22, 33, 'yellow', 14, 100),
            new shoesPare(23, 34, 'orange', 21, 25),
            new shoesPare(24, 35, 'red', 24, 75),
            new shoesPare(25, 36, 'white', 34, 35),
        ],
        Sandals:[
            new shoesPare(31, 35, 'red', 56, 2),
            new shoesPare(32, 34, 'blue', 76, 3),
            new shoesPare(33, 34, 'grey', 87, 4),
            new shoesPare(34, 45, 'white', 45, 2),
            new shoesPare(35, 41, 'white', 67, 5),
        ]
    }
}
console.log(allProduct);