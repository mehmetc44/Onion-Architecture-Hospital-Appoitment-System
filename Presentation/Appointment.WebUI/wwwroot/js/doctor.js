document.addEventListener("DOMContentLoaded", ()=>{

    // Sayfa geçişi
    window.showPage = function(pageId){
        document.querySelectorAll(".page").forEach(p=>p.classList.remove("active"));
        document.getElementById(pageId).classList.add("active");
    }

    // Randevu Onay / İptal
    document.querySelectorAll(".confirm-btn").forEach((btn)=>{
        btn.addEventListener("click", ()=>{
            const row = btn.closest("tr");
            const status = row.querySelector(".status-select").value;
            const desc = row.querySelector(".desc-input").value;
            alert("Randevu güncellendi!\nDurum: "+status+"\nAçıklama: "+desc);
        });
    });

    document.querySelectorAll(".cancel-btn").forEach(btn=>{
        btn.addEventListener("click", ()=>{
            if(confirm("Bu randevuyu iptal etmek istediğinize emin misiniz?")){
                alert("Randevu iptal edildi!");
            }
        });
    });

    // Grafik
    const ctx = document.getElementById('patientChart').getContext('2d');
    const chart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Pzt','Sal','Çar','Per','Cum','Cmt','Paz'],
            datasets: [{
                label: 'Hasta Sayısı',
                data: [8,5,7,6,9,4,3],
                backgroundColor: '#1e40af'
            }]
        },
        options: {responsive:true,plugins:{ legend:{ display:false } },scales: { y:{ beginAtZero:true, stepSize:1 }}}
    });

    // Takvim
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
            const empty = document.createElement('div');
            calendarGrid.appendChild(empty);
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
        currentMonth--;
        if(currentMonth<0){ currentMonth=11; currentYear--; }
        renderCalendar(currentMonth, currentYear);
    });

    nextMonthBtn.addEventListener('click', ()=>{
        currentMonth++;
        if(currentMonth>11){ currentMonth=0; currentYear++; }
        renderCalendar(currentMonth, currentYear);
    });

    renderCalendar(currentMonth, currentYear);

    // =========================
    // Profil güncelleme
    // =========================
    document.getElementById('profileForm').addEventListener('submit', e=>{
        e.preventDefault();
        const name = document.getElementById('doctorName').value;
        const tc = document.getElementById('doctorTC').value;
        const dept = document.getElementById('doctorDepartment').value;
        const phone = document.getElementById('doctorPhone').value;
        const email = document.getElementById('doctorEmail').value;

        alert(`Profil güncellendi!\nAd Soyad: ${name}\nTC: ${tc}\nBölüm: ${dept}\nTelefon: ${phone}\nEmail: ${email}`);
    });

});