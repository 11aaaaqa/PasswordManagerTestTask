async function GetPasswords() {
    const response = await fetch("/api/passwordmanager", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const records = response.json();
        let rows = document.querySelector("tbody");
        records.forEach(record => {
            rows.append(addRow(record));
        });
    }
}

function addRow(record) {
    const tr = document.createElement("tr");

    const nameTd = document.createElement("td");
    nameTd.append(record.SiteOrMailName);
    tr.append(nameTd);

    const passwordTd = document.createElement("td");
    passwordTd.append(record.Password);
    tr.append(passwordTd);

    const createdAtTd = document.createElement("td");
    createdAtTd.append(record.CreatedAt);
    tr.append(createdAtTd);

    //return tr;
}

GetPasswords();