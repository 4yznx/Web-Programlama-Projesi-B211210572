using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adı alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Adı 50 karakterden fazla olamaz.")]
        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Soyadı alanı zorunludur.")]
        [StringLength(50, ErrorMessage = "Soyadı 50 karakterden fazla olamaz.")]
        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "Uzmanlık alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Uzmanlık 100 karakterden fazla olamaz.")]
        [Display(Name = "Uzmanlıklar")]
        public string Uzmanliklar { get; set; }

        [Required(ErrorMessage = "Uygunluk durumu zorunludur.")]
        [Display(Name = "Uygunluk")]
        public string Uygunluk { get; set; }
    }
}
