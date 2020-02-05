function shiftMultiply(cur, tur){
    let elem = document.getElementById(cur);
    let targetEllem = document.getElementById(tur);
    let idOption = elem.selectedOptions;
    if (idOption.length==0){
        alert("Empty select!");
    }
    for (let i = 0; i <idOption.length; i++) {
        let temp = idOption[i];
        temp.selected = false;
        targetEllem.append(temp);
        i--;
    }
}

function shiftAll(cur,tur) {
    let elem = document.getElementById(cur);
    let targetEllem = document.getElementById(tur);
    if (elem.length===0){
        alert("Empty select!");
    }
    for (let i = 0; i <elem.length; i++) {
        let temp = elem[i];
        temp.selected = false;
        targetEllem.append(elem[i]);
        i--;
    }
}

document.getElementById('shiftLeft').addEventListener('click',()=>{shiftMultiply('sl1','sl2')});
document.getElementById('shiftAllLeft').addEventListener('click',()=>{shiftAll('sl1','sl2')});
document.getElementById('shiftRight').addEventListener('click',()=>{shiftMultiply('sl2','sl1')});
document.getElementById('shiftAllRight').addEventListener('click',()=>{shiftAll('sl2','sl1')});


