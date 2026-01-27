document.addEventListener("DOMContentLoaded", () => {

    /* =========================
       MODALS
    ========================= */
    const modals = {
        hospital: document.getElementById("hospitalModal"),
        updateHospital: document.getElementById("updateHospitalModal"),
        department: document.getElementById("departmentModal"),
        doctor: document.getElementById("doctorModal")
    };

    window.openModal = (type) => modals[type] && (modals[type].style.display = "flex");
    window.closeModal = (type) => modals[type] && (modals[type].style.display = "none");

    /* =========================
       HOSPITAL CRUD
    ========================= */
    const hospitalTable = document.getElementById("hospitalTable");
    let hospitals = []; // Başlangıçta boş veya DB’den çekilebilir

    function renderHospitals() {
        hospitalTable.innerHTML = `<tr>
            <th>İsim</th>
            <th>Adres</th>
            <th>Şehir</th>
            <th>İşlem</th>
        </tr>`;

        hospitals.forEach((h, i) => {
            const row = hospitalTable.insertRow();
            row.innerHTML = `
                <td>${h.name}</td>
                <td>${h.address}</td>
                <td>${h.city}</td>
                <td>
                    <button onclick="openUpdateHospitalModal(${i})">Düzenle</button>
                    <button onclick="deleteHospital(${i})">Sil</button>
                </td>
            `;
        });

        populateDepartmentHospitalSelect();
        populateDoctorHospitalSelect();
    }

    window.addHospital = () => {
        const name = document.getElementById("hospitalName").value.trim();
        const address = document.getElementById("hospitalAddress").value.trim();
        const city = document.getElementById("hospitalCity").value;

        if (!name || !address || !city) { alert("Alanları doldurun!"); return; }

        hospitals.push({ name, address, city });
        renderHospitals();
        closeModal("hospital");

        // Inputları temizle
        document.getElementById("hospitalName").value = "";
        document.getElementById("hospitalAddress").value = "";
        document.getElementById("hospitalCity").value = "";
    };

    window.deleteHospital = (i) => {
        if (confirm("Silmek istediğinize emin misiniz?")) {
            hospitals.splice(i, 1);
            renderHospitals();
        }
    };

    window.openUpdateHospitalModal = (i) => {
        const h = hospitals[i];
        const modal = modals.updateHospital;
        modal.style.display = "flex";

        document.getElementById("updateHospitalIndex").value = i;
        document.getElementById("updateHospitalName").value = h.name;
        document.getElementById("updateHospitalAddress").value = h.address;
        document.getElementById("updateHospitalCity").value = h.city;
    };

    window.updateHospital = () => {
        const i = document.getElementById("updateHospitalIndex").value;
        const name = document.getElementById("updateHospitalName").value.trim();
        const address = document.getElementById("updateHospitalAddress").value.trim();
        const city = document.getElementById("updateHospitalCity").value;

        if (!name || !address || !city) { alert("Alanları doldurun!"); return; }

        hospitals[i] = { name, address, city };
        renderHospitals();
        closeModal("updateHospital");
    };

    /* =========================
       SELECT POPULATION
    ========================= */
    window.populateDepartmentHospitalSelect = () => {
        const select = document.getElementById("departmentHospital");
        if (!select) return;
        select.innerHTML = "";
        hospitals.forEach(h => {
            const opt = document.createElement("option");
            opt.value = h.name;
            opt.innerText = h.name;
            select.appendChild(opt);
        });
    };

    window.populateDoctorHospitalSelect = () => {
        const select = document.getElementById("doctorHospital");
        if (!select) return;
        const city = document.getElementById("doctorCity")?.value;
        select.innerHTML = "";
        hospitals
            .filter(h => !city || h.city === city)
            .forEach(h => {
                const opt = document.createElement("option");
                opt.value = h.name;
                opt.innerText = h.name;
                select.appendChild(opt);
            });
    };

});
