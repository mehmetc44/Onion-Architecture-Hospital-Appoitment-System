document.addEventListener("DOMContentLoaded", () => {
    // =========================
    // Rol Seçimi ve Login/Register
    // =========================
    const roleButtons = document.querySelectorAll('.roles button');
    let selectedRole = ""; // Global olarak rol

    // Fonksiyon: Rol seçimi
    function selectRole(role) {
        selectedRole = role;
        document.getElementById("roleText").innerText = role + " Girişi";

        // Butonu seçili yap, diğerlerinden kaldır
        roleButtons.forEach(b => b.classList.remove('active'));
        const btn = Array.from(roleButtons).find(b => b.getAttribute('data-role') === role);
        if (btn) btn.classList.add('active');
    }

    // Butonlara tıklama olayı
    roleButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            const role = btn.getAttribute('data-role');
            selectRole(role);
        });
    });

    // Sayfa açıldığında otomatik Kullanıcı rolünü seç
    selectRole("Kullanıcı");

    // Form gösterme fonksiyonu
    window.showForm = (formId) => {
        document.querySelectorAll(".form").forEach(f => f.classList.remove("active"));
        document.getElementById(formId).classList.add("active");
    }

    // Form submit olayı
    document.querySelectorAll("form").forEach(form => {
        form.addEventListener("submit", e => {
            e.preventDefault();
            if (selectedRole === "") {
                alert("Lütfen bir rol seçiniz.");
                return;
            }
            alert("İşlem başarılı (Statik Demo)\nRol: " + selectedRole);
        });
    });
});
