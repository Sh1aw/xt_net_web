let pagesArray = ['page1.html','page2.html','page3.html','page4.html','page5.html'];
let nowPage = window.location.pathname.split('/');
let nP = nowPage[nowPage.length-1];
let currentIndex = getIndex();

function getIndex(){
    let index = pagesArray.indexOf(nP);
    if (index == pagesArray.length-1){
        return -1;
    }
    return index;
}

function switchButtons(){
    let container = document.getElementById('bts');
    container.innerHTML = '<div class="last_page_info">It was last page!<h2><a href="'+pagesArray[0]+'">' +
        'Start at the beginning</a></h2>' +
        '<a onclick="window.close()" style="cursor: pointer">Close window(not working)</a></div>';
}

let Clock = {
    startValue: 10,
    container: document.getElementById('tm1'),
    timerIdd: null,
    UpdateClock(value){
        if (value>0)
            this.container.innerText = value;
        else {
            clearInterval(this.timerIdd);
            this.timerIdd = null;
            if (currentIndex!=-1)
                document.location.href = pagesArray[currentIndex+1];
            else {
                switchButtons();
            }
        }
    },
    startClocking(){
        if (!this.timerIdd)
            this.timerIdd = setInterval(()=>(Clock.UpdateClock(this.startValue--)),1000);
        else {
            alert('Timer is already working now');
        }
    },
    forceStop(){
        if (this.timerIdd!=null)
        {
            clearInterval(this.timerIdd);
            this.timerIdd = null;
        }
        else {
            alert('Timer is already not working now!');
        }
    },
};

Clock.startClocking();
document.getElementById("sB").addEventListener('click',Clock.forceStop.bind(Clock));
document.getElementById("sG").addEventListener('click',Clock.startClocking.bind(Clock));