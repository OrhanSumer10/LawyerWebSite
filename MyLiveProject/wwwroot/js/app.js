

let mybutton = document.getElementById("go-up");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    $("html, body").animate({ scrollTop: "0" }, 1000);

}

var close = document.getElementsByClassName("closebtn");
var i;

// Loop through all close buttons
for (i = 0; i < close.length; i++) {
    // When someone clicks on a close button
    close[i].onclick = function () {

        // Get the parent of <span class="closebtn"> (<div class="alert">)
        var div = this.parentElement;

        // Set the opacity of div to 0 (transparent)
        div.style.opacity = "0";

        // Hide the div after 600ms (the same amount of milliseconds it takes to fade out)
        setTimeout(function () { div.style.display = "none"; }, 600);
    }
}

let toastBox = document.getElementById("toastBox");
let successMsg =
    '<i class="fa-solid fa-circle-check"></i> Successfully submited';
let errorMsg = '<i class="fa-solid fa-circle-xmark"></i> Please fix the error';
let InvalidMsg =
    '<i class="fa-solid fa-circle-info"></i> Invalid input, check again';
function showToast(msg) {
    let toast = document.createElement("div");
    toast.classList.add("toast");
    toast.innerHTML = msg;
    toastBox.appendChild(toast);

    if (msg.includes("error")) {
        toast.classList.add("error");
    }

    if (msg.includes("Invalid")) {
        toast.classList.add("invalid");
    }
    setTimeout(() => {
        toast.remove();
    }, 5000);
}



function googleTranslateElementInit() {
    new google.translate.TranslateElement(
        {
            pageLanguage: "en"
        },
        'google_translate_element'
    )
}


