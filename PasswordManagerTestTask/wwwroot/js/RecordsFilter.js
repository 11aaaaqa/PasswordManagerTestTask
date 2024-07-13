function searchRecord() {
    const searchInput = document.getElementById("searchInput");
    const recordsTable = document.getElementById("recordsTable");
    const tr = recordsTable.getElementsByTagName("tr");

    for (let i = 1; i < tr.length; i++) {
        const td = tr[i].getElementsByTagName('td')[0];
        if (td) {
            const tdValue = td.textContent;
            if (tdValue.toLowerCase().indexOf(searchInput.value.toLowerCase()) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}