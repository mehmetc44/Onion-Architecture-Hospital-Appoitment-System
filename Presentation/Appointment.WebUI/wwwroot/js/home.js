document.addEventListener("DOMContentLoaded", () => {
    const selects = {
        city: document.getElementById("citySelect"),
        hospital: document.getElementById("hospitalSelect"),
        department: document.getElementById("departmentSelect"),
        doctor: document.getElementById("doctorSelect"),
        date: document.getElementById("dateSelect"),
        timeSlots: document.getElementById("timeSlots"),
        timeDrawer: document.getElementById("timeDrawer"),
        selectedTime: document.getElementById("selectedTime")
    };

    const resetSelectors = (list) => {
        list.forEach(key => {
            const el = selects[key];
            if (el) {
                el.innerHTML = `<option value="">Bekleyiniz...</option>`;
                el.disabled = true;
            }
        });
        selects.timeSlots.innerHTML = "";
        selects.timeDrawer.style.display = "none";
        selects.selectedTime.value = "";
    };
const fillDropdown = async (url, targetKey, defaultText) => {
    try {
        const response = await fetch(url);
        const data = await response.json();
        const target = selects[targetKey];
        
        const selectedId = target.getAttribute("data-selected-id");

        target.innerHTML = `<option value="">${defaultText}</option>`;

        let items = Array.isArray(data) ? data : (data.$values || data.items || []);

        if (items.length > 0) {
            items.forEach(item => {
                const opt = document.createElement("option");
                
                // ID Ataması (Değişmedi)
                opt.value = item.id || item.Id; 

                // --- DÜZELTME BURADA ---
                let displayText = "";

                // 1. Durum: Eğer nesnenin bir 'Name' veya 'name' özelliği varsa (Şehir, Hastane, Bölüm için)
                if (item.Name || item.name) {
                    displayText = item.Name || item.name;
                } 
                // 2. Durum: Eğer nesnenin İsim/Soyisim özelliği varsa (Doktorlar için)
                else if (item.FirstName || item.firstName) {
                    displayText = `${item.FirstName || item.firstName} ${item.LastName || item.lastName}`.trim();
                }

                // Hiçbiri yoksa fallback
                opt.innerText = displayText || "İsimsiz Kayıt"; 
                // -----------------------

                if (selectedId && opt.value == selectedId) {
                    opt.selected = true;
                }

                target.appendChild(opt);
            });
            target.disabled = false;

            if (targetKey === 'city' && target.value) {
                target.dispatchEvent(new Event('change'));
            }
        }
    } catch (error) {
        console.error(`${targetKey} yükleme hatası:`, error);
    }
};

    // --- EVENT LISTENERS ---

    selects.city.addEventListener("change", () => {
        if (!selects.city.value) return;
        resetSelectors(['hospital', 'department', 'doctor']);
        fillDropdown(`/Home/GetHospitals?cityId=${selects.city.value}`, 'hospital', 'Hastane Seçiniz');
    });

    selects.hospital.addEventListener("change", () => {
        if (!selects.hospital.value) return;
        resetSelectors(['department', 'doctor']);
        fillDropdown(`/Home/GetDepartments?hospitalId=${selects.hospital.value}`, 'department', 'Bölüm Seçiniz');
    });

    selects.department.addEventListener("change", () => {
        if (!selects.department.value) return;
        resetSelectors(['doctor']);
        fillDropdown(`/Home/GetDoctors?departmentId=${selects.department.value}`, 'doctor', 'Doktor Seçiniz');
    });

    selects.selectedTime.addEventListener("click", () => {
        if (selects.timeSlots.innerHTML !== "") {
            selects.timeDrawer.style.display = selects.timeDrawer.style.display === "block" ? "none" : "block";
        }
    });

    const loadSlots = async () => {
        const doctorId = selects.doctor.value;
        const date = selects.date.value;
        if (!doctorId || !date) return;

        selects.timeSlots.innerHTML = "Saatler yükleniyor...";
        selects.timeDrawer.style.display = "block";

        try {
            const r = await fetch(`/Home/GetSlots?doctorId=${doctorId}&date=${date}`);
            const slots = await r.json();
            selects.timeSlots.innerHTML = "";
            slots.forEach(slot => {
                const btn = document.createElement("button");
                btn.type = "button";
                btn.className = `slot-btn ${slot.isAvailable ? 'available' : 'unavailable'}`;
                btn.innerText = slot.time;
                if (slot.isAvailable) {
                    btn.onclick = () => {
                        document.querySelectorAll(".slot-btn").forEach(b => b.classList.remove("selected"));
                        btn.classList.add("selected");
                        selects.selectedTime.value = slot.time;
                        selects.timeDrawer.style.display = "none";
                    };
                } else {
                    btn.disabled = true;
                }
                selects.timeSlots.appendChild(btn);
            });
        } catch (err) {
            selects.timeSlots.innerHTML = "Saatler alınamadı.";
        }
    };

    selects.doctor.addEventListener("change", loadSlots);
    selects.date.addEventListener("change", loadSlots);
    fillDropdown('/Home/GetCities', 'city', 'Şehir Seçiniz');
});