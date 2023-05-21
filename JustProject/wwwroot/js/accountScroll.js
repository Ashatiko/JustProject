//window.addEventListener('beforeunload', function () {
//    sessionStorage.setItem('scrollPosPage1', window.scrollY);
//});

//window.addEventListener('DOMContentLoaded', function () {
//    var scrollPos = sessionStorage.getItem('scrollPosPage1');
//    if (scrollPos) {
//        setTimeout(function () {
//            window.scrollTo(0, scrollPos);
//        }, 0);
//        sessionStorage.removeItem('scrollPosPage1');
//    }
//});

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