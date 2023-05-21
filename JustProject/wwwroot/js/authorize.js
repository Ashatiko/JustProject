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

