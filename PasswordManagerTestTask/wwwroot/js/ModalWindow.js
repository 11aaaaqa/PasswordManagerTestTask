let btn = document.getElementById("addRecord");

let modal = document.getElementById("modalWindow");

let close = document.getElementById("close");

btn.onclick = function() {
    modal.style.display = "block";
}

close.onclick = function() {
    modal.style.display = "none";
}