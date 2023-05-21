
var hidden = false;
function tests() {
    document.getElementById("moreTests").classList.toggle("show");
    hidden = !hidden;
    if (hidden) {
        document.getElementById('btnTests').innerText = "Скрыть";
    } else {
        document.getElementById('btnTests').innerText = "Показать eщe";
    }
}