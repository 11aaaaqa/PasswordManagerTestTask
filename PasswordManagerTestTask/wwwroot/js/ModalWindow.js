const btn = document.getElementById("addRecord");

const modal = document.getElementById("modalWindow");

const close = document.getElementById("close");

btn.onclick = function() {
    modal.style.display = "block";
}

close.onclick = function() {
    modal.style.display = "none";
}