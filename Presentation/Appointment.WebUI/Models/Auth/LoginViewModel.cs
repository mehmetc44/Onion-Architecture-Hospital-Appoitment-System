namespace Appointment.WebUI.Models;

using System.ComponentModel.DataAnnotations;
using global::Appointment.Domain.Enums;

public class LoginViewModel
{
    [Required(ErrorMessage = "Kullanıcı adı veya email zorunludur.")]
    public string UserNameOrEmail { get; set; } = null!;

    [Required(ErrorMessage = "Şifre zorunludur.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Lütfen bir rol seçiniz.")]
    public UserRole? SelectedRole { get; set; }
}

