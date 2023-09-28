/input block/
document.getElementById("Data").textContent = "Михаил Лахметкин";

document.getElementById("print").addEventListener("click", function() {
    var firstname = document.getElementById("key").value;
    var secondname = document.getElementById("key2").value;
    document.getElementById("Data").textContent = firstname+" "+secondname; 
});

/button for random change background/
var BackGNum = 0;  
window.onload = function() {
    var button = document.getElementById('input_button_bg_change');
    var body = document.getElementsByTagName('body')[0];
    var colors = ['white', '#c85845', '#a84c4d', '#884055', '#7e5a63', '#757571', '#6e7e59', '#688842', ,'#919a3f', '#b9ac3c', '#bd8f30', '#c07223', '#c46534'];
    button.onclick = function() {
        var a = Math.floor(Math.random() * colors.length);
        if(a == BackGNum){
          BackGNum = a + 1;
          if(BackGNum >= colors.length){
            BackGNum = 0;
          }
        }
        else{
          BackGNum = a;
        }
        body.style.backgroundColor = colors[BackGNum];
    };
};

/data transmitted by the machine/
var work = 0;  
var i = 0;

function sleep(ms) {
  return new Promise((resolve) => setTimeout(resolve, ms));
}
 
document.getElementById("TextBt").textContent = "Включить"
function Start() {
  if(work <= 2){
    document.getElementById("TextBt").textContent = "Выключить"
    work += 1;
    autoRefresh();
  } 
  else{
    document.getElementById("TextBt").textContent = "Включить"
    work = 0;
  }
}

function autoRefresh() {
  if(work == 2){
    ReadSt();
    setTimeout(autoRefresh, 5000);
  }
}

function ReadSt() {
  (async () => {
    let response = await fetch("https://kav-api.kovalev.team/servodrive/lastActualData?servoDriveId=1");
    let el = document.getElementById("DataOSt");
    el.innerHTML = "";
    let text = await response.text();
    for (const [key, value] of Object.entries(JSON.parse(text)[0])) {
      const newEl = document.createElement("li");
      newEl.appendChild(document.createTextNode(`${key}: ${value}`));
      el.appendChild(newEl);
      await sleep(100);
    }
})();
}

document.getElementById("btn").addEventListener("click", function() {
    Start();
});