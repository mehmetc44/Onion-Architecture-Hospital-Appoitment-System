document.addEventListener("DOMContentLoaded", () => {
    // =========================
    // Sayfa Geçişi (Dashboard vs User Pages)
    // =========================
    window.showPage = (pageId) => {
        document.querySelectorAll(".page").forEach(p => p.classList.remove("active"));
        document.getElementById(pageId).classList.add("active");
    }

    let lastPage = "past"; // Mesaj popup için

    window.openMessagePage = (doctor, message) => {
        document.getElementById("popupDoctor").innerText = doctor + " - Doktor Mesajı";
        document.getElementById("popupMessage").innerText = message;
        document.querySelectorAll(".page").forEach(p => {
            if (p.classList.contains("active")) lastPage = p.id;
            p.classList.remove("active");
        });
        document.getElementById("messagePage").classList.add("active");
    }

    window.closeMessagePage = () => {
        document.getElementById("messagePage").classList.remove("active");
        document.getElementById(lastPage).classList.add("active");
    }

    // =========================
    // CRUD: Hastane, Bölüm, Doktor
    // =========================
    let hospitals = [];
    let departments = [];
    let doctors = [];

    const hospitalModal = document.getElementById('hospitalModal');
    const departmentModal = document.getElementById('departmentModal');
    const doctorModal = document.getElementById('doctorModal');

    window.openHospitalModal = () => hospitalModal.style.display = 'flex';
    window.closeHospitalModal = () => hospitalModal.style.display = 'none';

    window.openDepartmentModal = () => {
        populateDepartmentHospitalSelect();
        departmentModal.style.display = 'flex';
    }
    window.closeDepartmentModal = () => departmentModal.style.display = 'none';

    window.openDoctorModal = () => doctorModal.style.display = 'flex';
    window.closeDoctorModal = () => doctorModal.style.display = 'none';

    // ====== Hastane ======
    window.addHospital = () => {
        const name = document.getElementById('hospitalName').value.trim();
        const address = document.getElementById('hospitalAddress').value.trim();
        const city = document.getElementById('hospitalCity').value.trim();
        if (!name || !address || !city) { alert("Alanları doldurun!"); return; }
        hospitals.push({ name, address, city });
        renderHospitals();
        closeHospitalModal();
        document.getElementById('hospitalName').value = '';
        document.getElementById('hospitalAddress').value = '';
        document.getElementById('hospitalCity').value = '';
    }

    function renderHospitals() {
        const table = document.getElementById('hospitalTable');
        table.innerHTML = '<tr><th>İsim</th><th>Adres</th><th>Şehir</th><th>İşlem</th></tr>';
        hospitals.forEach((h, i) => {
            const row = table.insertRow();
            row.insertCell(0).innerText = h.name;
            row.insertCell(1).innerText = h.address;
            row.insertCell(2).innerText = h.city;
            const cell = row.insertCell(3);
            const btnEdit = document.createElement('button'); btnEdit.innerText = 'Düzenle'; btnEdit.onclick = () => alert("Düzenle simülasyonu");
            const btnDel = document.createElement('button'); btnDel.innerText = 'Sil'; btnDel.onclick = () => { hospitals.splice(i, 1); renderHospitals(); };
            cell.appendChild(btnEdit); cell.appendChild(btnDel);
        });
        populateDepartmentHospitalSelect();
        populateDoctorHospitalSelect();
    }

    // ====== Bölümler ======
    window.addDepartment = () => {
        const name = document.getElementById('departmentName').value.trim();
        const hospital = document.getElementById('departmentHospital').value;
        if (!name || !hospital) { alert("Alanları doldurun!"); return; }
        departments.push({ name, hospital });
        renderDepartments();
        closeDepartmentModal();
        document.getElementById('departmentName').value = '';
    }

    function renderDepartments() {
        const table = document.getElementById('departmentTable');
        table.innerHTML = '<tr><th>Bölüm Adı</th><th>Hastane</th><th>İşlem</th></tr>';
        departments.forEach((d, i) => {
            const row = table.insertRow();
            row.insertCell(0).innerText = d.name;
            row.insertCell(1).innerText = d.hospital;
            const cell = row.insertCell(2);
            const btnEdit = document.createElement('button'); btnEdit.innerText = 'Düzenle'; btnEdit.onclick = () => alert("Düzenle simülasyonu");
            const btnDel = document.createElement('button'); btnDel.innerText = 'Sil'; btnDel.onclick = () => { departments.splice(i, 1); renderDepartments(); };
            cell.appendChild(btnEdit); cell.appendChild(btnDel);
        });
        populateDoctorDepartmentSelect();
    }

    // ====== Doktorlar ======
    window.addDoctor = () => {
        const city = document.getElementById('doctorCity').value.trim();
        const hospital = document.getElementById('doctorHospital').value;
        const department = document.getElementById('doctorDepartment').value;
        const name = document.getElementById('doctorName').value.trim();
        const tc = document.getElementById('doctorTC').value.trim();
        const phone = document.getElementById('doctorPhone').value.trim();
        const email = document.getElementById('doctorEmail').value.trim();
        if (!city || !hospital || !department || !name || !tc) { alert("Alanları doldurun!"); return; }
        doctors.push({ city, hospital, department, name, tc, phone, email });
        renderDoctors();
        closeDoctorModal();
        document.getElementById('doctorCity').value = '';
        document.getElementById('doctorHospital').innerHTML = '';
        document.getElementById('doctorDepartment').innerHTML = '';
        document.getElementById('doctorName').value = '';
        document.getElementById('doctorTC').value = '';
        document.getElementById('doctorPhone').value = '';
        document.getElementById('doctorEmail').value = '';
    }

    function renderDoctors() {
        const table = document.getElementById('doctorTable');
        table.innerHTML = '<tr><th>Ad Soyad</th><th>TC</th><th>Hastane</th><th>Bölüm</th><th>Telefon</th><th>Email</th><th>İşlem</th></tr>';
        doctors.forEach((d, i) => {
            const row = table.insertRow();
            row.insertCell(0).innerText = d.name;
            row.insertCell(1).innerText = d.tc;
            row.insertCell(2).innerText = d.hospital;
            row.insertCell(3).innerText = d.department;
            row.insertCell(4).innerText = d.phone;
            row.insertCell(5).innerText = d.email;
            const cell = row.insertCell(6);
            const btnEdit = document.createElement('button'); btnEdit.innerText = 'Düzenle'; btnEdit.onclick = () => alert("Düzenle simülasyonu");
            const btnDel = document.createElement('button'); btnDel.innerText = 'Sil'; btnDel.onclick = () => { doctors.splice(i, 1); renderDoctors(); };
            cell.appendChild(btnEdit); cell.appendChild(btnDel);
        });
    }

    // ====== Select Popülasyon ======
    window.filterHospitalsByCity = () => {
        const city = document.getElementById('doctorCity').value;
        const hospitalSelect = document.getElementById('doctorHospital');
        hospitalSelect.innerHTML = '';
        hospitals.filter(h => h.city === city).forEach(h => {
            const opt = document.createElement('option'); opt.value = h.name; opt.innerText = h.name;
            hospitalSelect.appendChild(opt);
        });
        filterDepartmentsByHospital();
    }

    window.filterDepartmentsByHospital = () => {
        const hospital = document.getElementById('doctorHospital').value;
        const deptSelect = document.getElementById('doctorDepartment');
        deptSelect.innerHTML = '';
        departments.filter(d => d.hospital === hospital).forEach(d => {
            const opt = document.createElement('option'); opt.value = d.name; opt.innerText = d.name;
            deptSelect.appendChild(opt);
        });
    }

    function populateDepartmentHospitalSelect() {
        const select = document.getElementById('departmentHospital');
        select.innerHTML = '';
        hospitals.forEach(h => { const opt = document.createElement('option'); opt.value = h.name; opt.innerText = h.name; select.appendChild(opt); });
    }

    function populateDoctorHospitalSelect() {
        const city = document.getElementById('doctorCity').value;
        const select = document.getElementById('doctorHospital');
        select.innerHTML = '';
        hospitals.filter(h => h.city === city).forEach(h => { const opt = document.createElement('option'); opt.value = h.name; opt.innerText = h.name; select.appendChild(opt); });
    }

    function populateDoctorDepartmentSelect() {
        const hospital = document.getElementById('doctorHospital').value;
        const select = document.getElementById('doctorDepartment');
        select.innerHTML = '';
        departments.filter(d => d.hospital === hospital).forEach(d => { const opt = document.createElement('option'); opt.value = d.name; opt.innerText = d.name; select.appendChild(opt); });
    }

    // =========================
    // Dashboard Grafikleri
    // =========================
    if (document.getElementById('dashboardChart')) {
        const ctx1 = document.getElementById('dashboardChart').getContext('2d');
        new Chart(ctx1, {
            type: 'bar',
            data: { labels: ['Pzt','Sal','Çar','Per','Cum','Cmt','Paz'], datasets:[{label:'Haftalık Randevu',data:[10,8,12,5,15,6,9],backgroundColor:'#10b981'}] },
            options: { responsive:true, plugins:{ legend:{ display:false } }, scales:{ y:{ beginAtZero:true, stepSize:1 } } }
        });
    }

    if (document.getElementById('patientChart')) {
        const ctx2 = document.getElementById('patientChart').getContext('2d');
        new Chart(ctx2, {
            type: 'bar',
            data: { labels: ['Pzt','Sal','Çar','Per','Cum','Cmt','Paz'], datasets:[{label:'Hasta Sayısı', data:[8,5,7,6,9,4,3], backgroundColor:'#065f46'}] },
            options: { responsive:true, plugins:{ legend:{ display:false } }, scales:{ y:{ beginAtZero:true, stepSize:1 } } }
        });
    }

    // =========================
    // Takvim (Doktor / Kullanıcı)
    // =========================
    if (document.getElementById('calendarGrid')) {
        let today = new Date();
        let currentMonth = today.getMonth();
        let currentYear = today.getFullYear();

        const calendarMonthYear = document.getElementById('calendarMonthYear');
        const calendarGrid = document.getElementById('calendarGrid');
        const prevMonthBtn = document.getElementById('prevMonth');
        const nextMonthBtn = document.getElementById('nextMonth');
        const selectedDateSpan = document.getElementById('selectedDate');
        const totalAppointmentsSpan = document.getElementById('totalAppointments');
        const completedAppointmentsSpan = document.getElementById('completedAppointments');
        const cancelledAppointmentsSpan = document.getElementById('cancelledAppointments');

        const appointmentsData = [
            {day:15, month:0, year:2026, status:"Bekliyor"},
            {day:16, month:0, year:2026, status:"Tamamlandı"},
            {day:16, month:0, year:2026, status:"İptal"},
            {day:18, month:0, year:2026, status:"Bekliyor"}
        ];

        function renderCalendar(month, year){
            calendarGrid.innerHTML = "";
            calendarMonthYear.textContent = new Intl.DateTimeFormat('tr-TR',{month:'long', year:'numeric'}).format(new Date(year, month));

            const firstDay = new Date(year, month, 1).getDay();
            const daysInMonth = new Date(year, month+1, 0).getDate();

            for(let i=0;i<firstDay;i++){
                calendarGrid.appendChild(document.createElement('div'));
            }

            for(let d=1; d<=daysInMonth; d++){
                const dayDiv = document.createElement('div');
                dayDiv.classList.add('calendar-day');
                dayDiv.textContent = d;
                dayDiv.addEventListener('click', ()=>{
                    document.querySelectorAll('.calendar-day').forEach(dd=>dd.classList.remove('active'));
                    dayDiv.classList.add('active');
                    updateDayStats(d, month, year);
                });
                calendarGrid.appendChild(dayDiv);
            }
        }

        function updateDayStats(day, month, year){
            selectedDateSpan.textContent = `${day}.${month+1}.${year}`;
            const dayAppointments = appointmentsData.filter(a=>a.day===day && a.month===month && a.year===year);
            totalAppointmentsSpan.textContent = dayAppointments.length;
            completedAppointmentsSpan.textContent = dayAppointments.filter(a=>a.status==="Tamamlandı").length;
            cancelledAppointmentsSpan.textContent = dayAppointments.filter(a=>a.status==="İptal").length;
        }

        prevMonthBtn.addEventListener('click', ()=>{
            currentMonth--; if(currentMonth<0){ currentMonth=11; currentYear--; }
            renderCalendar(currentMonth, currentYear);
        });

        nextMonthBtn.addEventListener('click', ()=>{
            currentMonth++; if(currentMonth>11){ currentMonth=0; currentYear++; }
            renderCalendar(currentMonth, currentYear);
        });

        renderCalendar(currentMonth, currentYear);
    }

    // =========================
    // Profil Güncelleme
    // =========================
    if (document.getElementById('profileForm')) {
        document.getElementById('profileForm').addEventListener('submit', e => {
            e.preventDefault();
            const name = document.getElementById('doctorName')?.value || "";
            const tc = document.getElementById('doctorTC')?.value || "";
            const dept = document.getElementById('doctorDepartment')?.value || "";
            const phone = document.getElementById('doctorPhone')?.value || "";
            const email = document.getElementById('doctorEmail')?.value || "";

            alert(`Profil güncellendi!\nAd Soyad: ${name}\nTC: ${tc}\nBölüm: ${dept}\nTelefon: ${phone}\nEmail: ${email}`);
        });
    }

});
