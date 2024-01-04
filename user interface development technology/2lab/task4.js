let string = "He5llo лWorа?ld";
alert(updateString(string));

function updateString(str){
    str = str.split("").reverse().join("");
    let english = /^[A-Za-z]*$/;
    for(let i = 0; i < str.length; i++){
        if(!str[i].match(english)){
            str = str.replace(str[i], '');
            i--;
        }
    }
    return str;
}