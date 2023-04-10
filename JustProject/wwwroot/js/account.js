
const txtElement = document.querySelector('.txt-edit'); 
const btnElement = document.querySelector('.btn-changes-end');
const inputElements = document.querySelectorAll('#userData');

inputElements.forEach((inputElement) => {
     inputElement.addEventListener('input', (event) => {
         txtElement.style.color = "red";
         btnElement.style.visibility = "visible";   
     });
});

btnElement.addEventListener('click', () => {
    txtElement.style.color = "white";
    btnElement.style.visibility = "hidden";
});

window.addEventListener('beforeunload', function () {
    sessionStorage.setItem('scrollPosPage1', window.scrollY);
});

window.addEventListener('DOMContentLoaded', function () {
    var scrollPos = sessionStorage.getItem('scrollPosPage1');
    if (scrollPos) {
        setTimeout(function () {
            window.scrollTo(0, scrollPos);
        }, 100);
        sessionStorage.removeItem('scrollPosPage1');
    }
});
