using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly BarberDbContext _context;

        public AccountController(BarberDbContext context)
        {
            _context = context;
        }

        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                var existingUser = await _context.Kullanicilar.FirstOrDefaultAsync(k => k.Email == kullanici.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Bu e-posta zaten kayıtlı.");
                    return View(kullanici);
                }

                // Add user to the database
                _context.Kullanicilar.Add(kullanici);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(kullanici);
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Check if admin
            if (email == "b211210572@sakarya.edu.tr" && password == "sau")
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToAction("Index", "Home");
            }

            // Check regular user
            var user = await _context.Kullanicilar.FirstOrDefaultAsync(k => k.Email == email && k.Sifre == password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserRole", "User");
                HttpContext.Session.SetString("UserName", user.Adi);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Geçersiz giriş bilgileri.");
            return View();
        }

        // POST: Logout
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
