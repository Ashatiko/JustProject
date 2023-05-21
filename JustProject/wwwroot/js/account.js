
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