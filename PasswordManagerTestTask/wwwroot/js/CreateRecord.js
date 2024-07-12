const radioButtons = document.querySelectorAll('input[type="radio"][name="radioBtn"]');
document.forms["newRecordForm"].addEventListener("submit",
    e => {
    e.preventDefault();
    const form = document.forms["newRecordForm"];
    const siteOrMailName = form.elements["siteOrMailNameInput"].value;
    const password = form.elements["passwordInput"].value;
    var selectedTypeName;
    for (const radioButton of radioButtons) {
        if (radioButton.checked) {
            selectedTypeName = radioButton.value;
            break;
        }
    }
    Create(siteOrMailName, password, selectedTypeName);
});

async function Create(name, password, recordType) {
    const response = await fetch("api/passwordmanager",
        {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                siteOrMailName: name,
                password: password,
                recordType: recordType
            })
        });
    if (response.ok === true) {
        closeForm();
        resetForm();
        clearTbody();
        GetPasswords();
    }
    if (response.statusCode === 409) {
        alert("Запись об этом сайте/почте уже существует");
    }
}

function closeForm() {
    const modal = document.getElementById("modalWindow");
    modal.style.display = "none";
}

function resetForm() {
    const form = document.forms["newRecordForm"];
    form.reset();
}

function clearTbody() {
    let tbody = document.querySelector("tbody");
    while (tbody.firstChild != null) {
        tbody.removeChild(tbody.firstChild);
    }
}