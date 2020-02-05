function calculateString(string){
    let generalRegex = /^(((( )?(-)?( )?((\d+)((\.\d+)?))){1})(( )?([+*\/\-])( )?(\d+)((\.\d+)?))*( )?(=){1}( )?)$/g;
    let minorRegex = /(([+\-*/])|((\d+)((\.\d+)?)+))/g;

    if (!generalRegex.test(string)){
        return false;
    }

    let matches = string.match(minorRegex);
    let res = 0;

    for (let i = 0; i <matches.length-1 ; i++) {
        switch (matches[i]) {
            case '-':
            {
                res = res - (+matches[i+1]);
                break;
            }
            case '+':{
                res = res + (+matches[i+1]);
                break;
            }
            case '/':{
                res = res / (+matches[i+1]);
                break;
            }
            case '*':{
                res = res* (+matches[i+1]);
                break;
            }
            default:{
                if (i===0){
                    res = +matches[i];
                }
                break;
            }
        }
    }
    return res.toFixed(2);
}

function mathCalculator(string) {
    let result = calculateString(string);
    if (result){
        console.log('Result: '+result)
    }
    else {
        console.log('Expression has issues! Check you`r expression!');
    }
}

mathCalculator('3.5 +4*10-5.3 /5 =');