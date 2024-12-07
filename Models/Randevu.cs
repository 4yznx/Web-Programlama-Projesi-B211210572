using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{

    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "İşlem seçimi zorunludur.")]
        [ForeignKey("Islem")] // Foreign Key
        [Display(Name = "İşlem")]
        public int IslemId { get; set; }

        public Islem Islem { get; set; }

        [Required(ErrorMessage = "Çalışan seçimi zorunludur.")]
        [ForeignKey("Calisan")] // Foreign Key
        [Display(Name = "Çalışan")]
        public int CalisanId { get; set; }

        public Calisan Calisan { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kullanıcı adı 100 karakterden fazla olamaz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Randevu saati zorunludur.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Randevu Saati")]
        public DateTime RandevuSaati { get; set; }
    }
}
