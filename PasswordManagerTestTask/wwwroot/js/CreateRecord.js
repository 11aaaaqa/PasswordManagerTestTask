async function Create() {
    const response = await fetch("api/PasswordManager",
        {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                
            })
        });
    if (response.ok === true) {
        const record = await response.JSON();
        resetForm();
        document.querySelector("tbody").append(addRow(record));
    }
}

function resetForm() {

}