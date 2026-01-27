document.addEventListener("DOMContentLoaded", () => {
        const citySelect = document.getElementById("citySelect");
        const hospitalSelect = document.getElementById("hospitalSelect");
        const departmentSelect = document.getElementById("departmentSelect");
        const doctorSelect = document.getElementById("doctorSelect");
        const dateSelect = document.getElementById("dateSelect");
        const timeSlotsDiv = document.getElementById("timeSlots");
        const selectedTimeInput = document.getElementById("selectedTime");

        citySelect.addEventListener("change", () => {
            // Ajax ile hastaneleri getir
            fetch(`/api/hospitals?city=${citySelect.value}`)
                .then(r => r.json())
                .then(data => {
                    hospitalSelect.innerHTML = `<option value="">Hastane Seçiniz</option>`;
                    data.forEach(h => {
                        const opt = document.createElement("option");
                        opt.value = h.id;
                        opt.innerText = h.name;
                        hospitalSelect.appendChild(opt);
                    });
                });
        });

        hospitalSelect.addEventListener("change", () => {
            // Ajax ile bölümleri getir
            fetch(`/api/departments?hospitalId=${hospitalSelect.value}`)
                .then(r => r.json())
                .then(data => {
                    departmentSelect.innerHTML = `<option value="">Bölüm Seçiniz</option>`;
                    data.forEach(d => {
                        const opt = document.createElement("option");
                        opt.value = d.id;
                        opt.innerText = d.name;
                        departmentSelect.appendChild(opt);
                    });
                });
        });

        departmentSelect.addEventListener("change", () => {
            // Ajax ile doktorları getir
            fetch(`/api/doctors?departmentId=${departmentSelect.value}`)
                .then(r => r.json())
                .then(data => {
                    doctorSelect.innerHTML = `<option value="">Doktor Seçiniz</option>`;
                    data.forEach(d => {
                        const opt = document.createElement("option");
                        opt.value = d.id;
                        opt.innerText = d.name;
                        doctorSelect.appendChild(opt);
                    });
                });
        });

        function loadTimeSlots() {
            if(!doctorSelect.value || !dateSelect.value) return;
            fetch(`/Appointment/GetAvailableTimes?doctorId=${doctorSelect.value}&date=${dateSelect.value}`)
                .then(r => r.json())
                .then(slots => {
                    timeSlotsDiv.innerHTML = "";
                    slots.forEach(s => {
                        const btn = document.createElement("button");
                        btn.type = "button";
                        btn.classList.add("time-slot", s.isAvailable ? "available" : "unavailable");
                        btn.textContent = s.time;
                        btn.disabled = !s.isAvailable;
                        btn.dataset.time = s.time;

                        btn.addEventListener("click", () => {
                            document.querySelectorAll(".time-slot").forEach(b => b.classList.remove("selected"));
                            btn.classList.add("selected");
                            selectedTimeInput.value = s.time;
                        });

                        timeSlotsDiv.appendChild(btn);
                    });
                });
        }

        doctorSelect.addEventListener("change", loadTimeSlots);
        dateSelect.addEventListener("change", loadTimeSlots);
    });