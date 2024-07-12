const createRecordSubmit = document.getElementById("createRecordSubmit");
const radioButtons = document.querySelectorAll('input[type="radio"][name="radioBtn"]');
const siteOrMailNameInput = document.getElementById("siteOrMailNameInput");
const passwordInput = document.getElementById("passwordInput");

createRecordSubmit.addEventListener("click", () => {
    var selectedTypeName;
    for (const radioButton of radioButtons) {
        if (radioButton.checked) {
            selectedTypeName = radioButton.value;
            break;
        }
    }
    Create(siteOrMailNameInput.value, passwordInput.value, selectedTypeName);
});