function scrollToAboutUs() {    
    window.location.href = "/Home/Index" + "#AboutUs";
}

function scrollToContact() {
    window.location.href = "/Home/Index" + "#contact";
}

function scrollToTests() {
    window.location.href = "/Home/Index" + "#tests";
}

function scrollToInfo() {
    const targetElement = document.getElementById("info");
    targetElement.scrollIntoView({ behavior: "smooth" });
}

function scrollToReviews() {
    window.location.href = "/Home/Index" + "#reviews";
}

function scrollToAdvantages() {
    window.location.href = "/Home/Index" + "#advantages";
}

const toggleBtn = document.getElementById('toggleBtn');
const sidebar = document.querySelector('.personal-cart');
const container = document.querySelector('.container');

toggleBtn.addEventListener('click', () => {
    sidebar.classList.toggle('active');
});

container.addEventListener('click', (event) => {
    if (sidebar.classList.contains('active') && !event.target.matches('#toggleBtn')) {
        sidebar.classList.remove('active');
    }
});

sidebar.addEventListener('click', (event) => {
    event.stopPropagation();
});