document.addEventListener("DOMContentLoaded", () => {

    /* =========================
       PAGE SWITCHING
    ========================= */
    let lastPage = "past";

    window.showPage = (pageId) => {
        document.querySelectorAll(".page").forEach(p => p.classList.remove("active"));
        document.getElementById(pageId)?.classList.add("active");
    };

    window.openMessagePage = (doctor, message) => {
        document.getElementById("popupDoctor").innerText = doctor + " - Doktor Mesajı";
        document.getElementById("popupMessage").innerText = message;

        document.querySelectorAll(".page").forEach(p => {
            if (p.classList.contains("active")) lastPage = p.id;
            p.classList.remove("active");
        });

        document.getElementById("messagePage")?.classList.add("active");
    };

    window.closeMessagePage = () => {
        document.getElementById("messagePage")?.classList.remove("active");
        document.getElementById(lastPage)?.classList.add("active");
    };

    /* =========================
       DEPARTMENTS
    ========================= */
    window.addDepartment = () => {
        const name = departmentName.value.trim();
        const hospital = departmentHospital.value;

        if (!name || !hospital) return alert("Alanları doldurun");

        departments.push({ name, hospital });
        renderDepartments();
        closeModal("department");
        departmentName.value = "";
    };

    function renderDepartments() {
        departmentTable.innerHTML =
            `<tr><th>Bölüm</th><th>Hastane</th><th>İşlem</th></tr>`;

        departments.forEach((d, i) => {
            const row = departmentTable.insertRow();
            row.innerHTML = `
                <td>${d.name}</td>
                <td>${d.hospital}</td>
                <td>
                    <button onclick="alert('Düzenle simülasyonu')">Düzenle</button>
                    <button onclick="deleteDepartment(${i})">Sil</button>
                </td>
            `;
        });

        populateDoctorDepartmentSelect();
    }

    window.deleteDepartment = (i) => {
        departments.splice(i, 1);
        renderDepartments();
    };

    /* =========================
       DOCTORS
    ========================= */
    window.addDoctor = () => {
        const doctor = {
            city: doctorCity.value,
            hospital: doctorHospital.value,
            department: doctorDepartment.value,
            name: doctorName.value.trim(),
            tc: doctorTC.value.trim(),
            phone: doctorPhone.value,
            email: doctorEmail.value
        };

        if (!doctor.name || !doctor.tc) return alert("Zorunlu alanlar boş");

        doctors.push(doctor);
        renderDoctors();
        closeModal("doctor");
    };

    function renderDoctors() {
        doctorTable.innerHTML =
            `<tr><th>Ad Soyad</th><th>TC</th><th>Hastane</th><th>Bölüm</th><th>İşlem</th></tr>`;

        doctors.forEach((d, i) => {
            const row = doctorTable.insertRow();
            row.innerHTML = `
                <td>${d.name}</td>
                <td>${d.tc}</td>
                <td>${d.hospital}</td>
                <td>${d.department}</td>
                <td>
                    <button onclick="alert('Düzenle simülasyonu')">Düzenle</button>
                    <button onclick="deleteDoctor(${i})">Sil</button>
                </td>
            `;
        });
    }

    window.deleteDoctor = (i) => {
        doctors.splice(i, 1);
        renderDoctors();
    };

    /* =========================
       SELECT HELPERS
    ========================= */
    function populateDepartmentHospitalSelect() {
        departmentHospital.innerHTML = hospitals.map(h =>
            `<option value="${h.name}">${h.name}</option>`
        ).join("");
    }

    function populateDoctorHospitalSelect() {
        doctorHospital.innerHTML = hospitals.map(h =>
            `<option value="${h.name}">${h.name}</option>`
        ).join("");
    }

    function populateDoctorDepartmentSelect() {
        doctorDepartment.innerHTML = departments.map(d =>
            `<option value="${d.name}">${d.name}</option>`
        ).join("");
    }

    /* =========================
       CHARTS (SAFE)
    ========================= */
    const trendChart = document.getElementById("appointmentTrendChart");
    if (trendChart) {
        new Chart(trendChart, {
            type: "line",
            data: {
                labels: ['Pzt', 'Sal', 'Çar', 'Per', 'Cum', 'Cts', 'Paz'],
                datasets: [{
                    data: [1, 2, 3, 2, 4, 3, 5],
                    borderColor: "#2563eb",
                    backgroundColor: "rgba(37,99,235,.2)",
                    fill: true,
                    tension: .4
                }]
            }
        });
    }

    const statusChart = document.getElementById("appointmentStatusChart");
    if (statusChart) {
        new Chart(statusChart, {
            type: "pie",
            data: {
                labels: ['Tamamlandı', 'Beklemede', 'İptal'],
                datasets: [{
                    data: [6, 2, 2],
                    backgroundColor: ['#10b981', '#f59e0b', '#ef4444']
                }]
            }
        });
    }
});
