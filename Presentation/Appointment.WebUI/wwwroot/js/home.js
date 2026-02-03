// home.js

// Global değişken (Modal için)
let rescheduleModalObj = null;

document.addEventListener("DOMContentLoaded", () => {
    
    // ==========================================
    // BÖLÜM 1: RANDEVU ALMA EKRANI (Index.cshtml)
    // ==========================================
    
    // Önce elementin sayfada olup olmadığını kontrol et!
    const citySelectElement = document.getElementById("citySelect");

    if (citySelectElement) { 
        // Eğer bu element varsa, demek ki Randevu Alma sayfasındayız.
        // Dropdown kodlarını buraya alıyoruz.
        
        const selects = {
            city: citySelectElement,
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
            if(selects.timeSlots) selects.timeSlots.innerHTML = "";
            if(selects.timeDrawer) selects.timeDrawer.style.display = "none";
            if(selects.selectedTime) selects.selectedTime.value = "";
        };

        const fillDropdown = async (url, targetKey, defaultText) => {
            try {
                const response = await fetch(url);
                const data = await response.json();
                const target = selects[targetKey];
                
                // Varsa seçili ID'yi al
                const selectedId = target.getAttribute("data-selected-id");

                target.innerHTML = `<option value="">${defaultText}</option>`;

                let items = Array.isArray(data) ? data : (data.$values || data.items || []);

                if (items.length > 0) {
                    items.forEach(item => {
                        const opt = document.createElement("option");
                        opt.value = item.id || item.Id; 
                        
                        let displayText = "";
                        if (item.Name || item.name) {
                            displayText = item.Name || item.name;
                        } else if (item.FirstName || item.firstName) {
                            displayText = `${item.FirstName || item.firstName} ${item.LastName || item.lastName}`.trim();
                        }
                        opt.innerText = displayText || "Bilinmiyor";

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

        // Event Listeners (Sadece elementler varsa eklenir)
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
        
        // Slot Yükleme
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
                    btn.innerText = slot.time.substring(0, 5);
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

        if(selects.selectedTime){
             selects.selectedTime.addEventListener("click", () => {
                if (selects.timeSlots.innerHTML !== "") {
                    selects.timeDrawer.style.display = selects.timeDrawer.style.display === "block" ? "none" : "block";
                }
            });
        }

        if(selects.doctor) selects.doctor.addEventListener("change", loadSlots);
        if(selects.date) selects.date.addEventListener("change", loadSlots);

        // Sayfa açılışında şehirleri doldur
        fillDropdown('/Home/GetCities', 'city', 'Şehir Seçiniz');
    }

    // ==========================================
    // BÖLÜM 2: AKTİF RANDEVULAR (Active.cshtml)
    // ==========================================

    // Modalın varlığını kontrol et
    const modalElement = document.getElementById('rescheduleModal');
    if (modalElement) {
        // Bootstrap Modalı başlat
        rescheduleModalObj = new bootstrap.Modal(modalElement);

        // Modal içindeki tarih değişince slotları yükle
        const modalDateInput = document.getElementById("modalDate");
        if(modalDateInput){
            modalDateInput.addEventListener("change", loadModalSlots);
        }
    }
});

// ==========================================
// FONKSİYONLAR (Global Scope - Onclick için)
// ==========================================

const modalElement = document.getElementById('rescheduleModal');

// ==========================================
// 1. MODALI AÇAN FONKSİYON (GÜNCELLENDİ)
// ==========================================
function openRescheduleModal(appointmentId, doctorId) {
    if (!modalElement) {
        console.error("Modal elementi bulunamadı!");
        return;
    }

    // Inputları Doldur
    document.getElementById("modalAppointmentId").value = appointmentId;
    document.getElementById("modalDoctorId").value = doctorId;
    
    // Temizlik
    document.getElementById("modalDate").value = "";
    document.getElementById("modalSelectedTime").value = "";
    document.getElementById("modalTimeSlots").innerHTML = '<span style="color:#666; font-size:0.8rem;">Tarih seçiniz.</span>';
    
    // Drawer'ı gizle (Tarih seçilince açılacak)
    const drawer = document.getElementById("modalTimeDrawer");
    if(drawer) drawer.style.display = "none";

    // CSS: display: none -> display: flex yapıyoruz
    modalElement.style.display = "flex"; 
}

// ==========================================
// 2. MODALI KAPATAN FONKSİYON (YENİ)
// ==========================================
function closeCustomModal() {
    if (modalElement) {
        modalElement.style.display = "none";
    }
}

// Modalın dışına (siyah alana) tıklayınca kapanması için
window.onclick = function(event) {
    if (event.target == modalElement) {
        closeCustomModal();
    }
}

// ==========================================
// 3. SLOTLARI YÜKLEME (GÜNCELLENDİ - Drawer Ayarı)
// ==========================================
async function loadModalSlots() {
    const doctorId = document.getElementById("modalDoctorId").value;
    const date = document.getElementById("modalDate").value;
    const container = document.getElementById("modalTimeSlots");
    const drawer = document.getElementById("modalTimeDrawer"); // Drawer elementi
    const timeInput = document.getElementById("modalSelectedTime");

    if (!date || !doctorId) return;

    // Drawer'ı görünür yap
    if(drawer) drawer.style.display = "block";
    
    container.innerHTML = "Yükleniyor...";
    timeInput.value = ""; 

    try {
        const response = await fetch(`/Home/GetSlots?doctorId=${doctorId}&date=${date}`);
        const slots = await response.json();

        container.innerHTML = ""; 

        if (slots.length === 0) {
            container.innerHTML = '<span style="color:red; font-size:0.8rem;">Uygun saat yok.</span>';
            return;
        }

        slots.forEach(slot => {
            const btn = document.createElement("div"); // Button yerine div kullandım, CSS ile daha uyumlu olsun diye
            btn.className = `slot-btn ${slot.isAvailable ? 'available' : 'unavailable'}`;
            btn.innerText = slot.time.substring(0, 5); 
            
            if (slot.isAvailable) {
                btn.onclick = () => {
                    // Seçim stili
                    document.querySelectorAll("#modalTimeSlots .slot-btn").forEach(b => {
                        b.classList.remove("selected");
                    });
                    btn.classList.add("selected");
                    timeInput.value = slot.time;
                };
            }
            container.appendChild(btn);
        });

    } catch (err) {
        console.error(err);
        container.innerHTML = 'Hata oluştu.';
    }
}

// 3. Modal Formunu Gönderen Fonksiyon
function submitReschedule() {
    const timeVal = document.getElementById("modalSelectedTime").value;
    const dateVal = document.getElementById("modalDate").value;

    if (!dateVal || !timeVal) {
        alert("Lütfen yeni bir tarih ve saat seçiniz!");
        return;
    }
    document.getElementById("rescheduleForm").submit();
}