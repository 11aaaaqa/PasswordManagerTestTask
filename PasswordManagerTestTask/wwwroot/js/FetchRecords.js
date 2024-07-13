async function GetPasswords() {
    const response = await fetch("/api/passwordmanager", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const records = await response.json();
        let rows = document.querySelector("tbody");
        records.forEach(record => {
            rows.appendChild(addRow(record));
        });
    }
}

function addRow(record) {
    const tr = document.createElement("tr");

    tr.onclick = () => togglePassword(tr);

    const nameTd = document.createElement("td");
    nameTd.append(record.siteOrMailName);
    tr.append(nameTd);

    const passwordTd = document.createElement("td");
    passwordTd.append(record.password);
    passwordTd.className = "hidden-password";
    tr.append(passwordTd);

    const createdAtTd = document.createElement("td");
    createdAtTd.append(record.createdAt);
    tr.append(createdAtTd);

    return tr;
}

GetPasswords();

function togglePassword(row) {
    const passwordTd = row.getElementsByTagName("td")[1];
    passwordTd.classList.toggle("hidden-password");
}