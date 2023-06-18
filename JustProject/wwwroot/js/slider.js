let offset = 0;
let step = 433;
const sliderLine = document.querySelector('.slider-line');
const sliders = sliderLine.childElementCount;
var mediaQuery = window.matchMedia('(max-width: 600px)');


function handleSliderClick() {
    if (((sliders * 250) - 250) <= (offset * -1)) {
        sliderLine.style.left = (offset - 30) + 'px';
        setTimeout(() => {
            sliderLine.style.left = offset + 'px';
        }, 700);
    } else {
        offset = offset - 270;
        sliderLine.style.left = offset + 'px';
    }
}

function handleSliderPrevClick() {    
    if ((offset * -1) <= 0) {
        sliderLine.style.left = (offset + 30) + 'px';
        setTimeout(() => {
            sliderLine.style.left = offset + 'px';
        }, 700);
    } else {
        offset = offset + 270;
        sliderLine.style.left = offset + 'px';
    }
}

if (mediaQuery.matches) {
    document.querySelector('.slider-next').addEventListener('click', handleSliderClick);
    document.querySelector('.slider-prev').addEventListener('click', handleSliderPrevClick);
} else {
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
}