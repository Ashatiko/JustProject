let offset = 0;
let step = 433;
const sliderLine = document.querySelector('.slider-line');
const sliders = sliderLine.childElementCount;

document.querySelector('.slider-next').addEventListener('click', function () {
    if (((sliders * step) - (step * 3)) <= (offset * -1)) {
        sliderLine.style.left = (offset - 250) + 'px';
        setTimeout(() => {
            sliderLine.style.left = offset + 'px';
        }, 700);        
    }
    else {
        offset = offset - step;
        sliderLine.style.left = offset + 'px';
    }    
})

document.querySelector('.slider-prev').addEventListener('click', function () {
    if ((offset * -1) <= 0) {
        sliderLine.style.left = (offset + 250) + 'px';
        setTimeout(() => {
            sliderLine.style.left = offset + 'px';
        }, 700);
    }
    else {
        offset = offset + step;   
        sliderLine.style.left = offset + 'px';
    }
})