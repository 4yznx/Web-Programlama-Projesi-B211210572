using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class BarberDbContext : DbContext
    { 

        public BarberDbContext(DbContextOptions<BarberDbContext> options) : base(options) { }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Islem> Islemler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
    }
}
