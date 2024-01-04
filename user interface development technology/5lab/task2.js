function curry(f){
    return function(a){
        return function(b){
            return function(c){
                return a*b*c;
            }
        }
    }
}

function Volume(a, b, c){
    return a*b*c;
}

let curriedVolume = curry(Volume);

alert( curriedVolume(3)(5)(2) );

// --------------------------------

function FindVolume(same){
    return function(a){
        return function(b){
            return same*a*b;
        }
    }
}

let volume = FindVolume(3);

alert(volume(5)(2));