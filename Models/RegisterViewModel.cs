using System.ComponentModel.DataAnnotations;
namespace BarberShop.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Adı alanı zorunludur.")]
    [StringLength(50, ErrorMessage = "Adı 50 karakterden fazla olamaz.")]
    [Display(Name = "Adı")]
    public string Adi { get; set; }

    [Required(ErrorMessage = "Soyadı alanı zorunludur.")]
    [StringLength(50, ErrorMessage = "Soyadı 50 karakterden fazla olamaz.")]
    [Display(Name = "Soyadı")]
    public string Soyadi { get; set; }

    [Required(ErrorMessage = "E-posta alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    [StringLength(100, ErrorMessage = "E-posta adresi 100 karakterden fazla olamaz.")]
    [Display(Name = "E-posta")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Şifre alanı zorunludur.")]
    [StringLength(100, ErrorMessage = "Şifre 8-100 karakter arasında olmalıdır.", MinimumLength = 8)]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre")]
    public string Sifre { get; set; }
}
