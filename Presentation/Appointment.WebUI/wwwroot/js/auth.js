// Login Sayfası için Rol Seçimi ve Form Kontrolü
document.addEventListener("DOMContentLoaded", () => {
    const loginForm = document.getElementById('loginForm');
    const roleButtons = document.querySelectorAll('.roles button');
    const selectedRoleInput = document.getElementById('selectedRoleInput');
    const roleText = document.getElementById('roleText');
    
    let selectedRole = null;

    // Rol butonlarına tıklanınca
    roleButtons.forEach(btn => {
        btn.addEventListener('click', function() {
            // Önceki seçimi kaldır
            roleButtons.forEach(b => b.classList.remove('active'));
            
            // Yeni seçimi ekle
            this.classList.add('active');
            selectedRole = this.dataset.role;
            
            // Gizli inputu güncelle
            selectedRoleInput.value = selectedRole;
            
            // Rol metni güncelle
            roleText.textContent = selectedRole + ' rolü ile giriş yapacaksınız.';
        });
    });

    // Form gönderilince
    if (loginForm) {
        loginForm.addEventListener('submit', function(e) {
            if (!selectedRole) {
                e.preventDefault();
                alert('Lütfen bir rol seçiniz!');
            }
        });
    }
});
