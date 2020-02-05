function charRemover(string) {
    let clear="";
    let stuff = [' ','\t','.',',','!','?'];

    for (let i=0;i<string.length;i++){
        if (stuff.includes(string[i])){
            clear+=' ';
        }
        else {
            clear+=string[i];
        }
    }

    let array = clear.split(' ');
    let notNeededChars = [];

    for (let i = 0; i <array.length; i++) {
        if (searchDoubles(array[i]).length>0){
            notNeededChars = searchDoubles(array[i]);
            for (let j = 0; j <notNeededChars.length ; j++) {
                string = string.split(notNeededChars[j]).join('');
            }
        }
    }

    return string;
}

function searchDoubles(str) {
    let doubles = [];
    for (let i = 0; i <str.length; i++) {
        for (let j = 0; j <str.length ; j++) {
            if (str[i]===str[j] && i!=j){
                if (!doubles.includes(str[i]))
                    doubles.push(str[i]);
            }
        }
    }
    return doubles;
}

console.log(charRemover('У попа была собака'));