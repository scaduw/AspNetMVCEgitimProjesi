﻿using AspNetMVCEgitimProjesi.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVCEgitimProjesi.NetCore.Controllers
{
    public class MVC10ModelBindingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Kullanici()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };

            return View(kullanici); // yukardaki kullanici nesnesinin view da model olarak kullanılabilmesi için bu şekilde view a göndermemiz gerekir.
        }
        [HttpPost]
        public IActionResult Kullanici(Kullanici kullanici) // Burada belirttiğimiz kullanici nesnesi view sayfasındaki model kullanan form içerisindeki verileri model binding yöntemiyle yakalıyor.
        {
            return View(kullanici); // Post işleminden sonra metoda parametreyle gelen kullanici nesnesini tekrar ekrana gönder
        }
        public IActionResult Adres()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adres(Adres adres)
        {
            // Projelerde bu noktada yakaladığımız adres nesnesini veritabanına kaydederiz.
            return View(adres);
        }
        public IActionResult UyeSayfasi()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            //kullanici.Sifre = "112365";
            UyeSayfasiViewModel model = new UyeSayfasiViewModel()
            {
                Kullanici = kullanici,
                Adres = new Adres { Ilce = "Ataşehir", Sehir = "İstanbul", AcikAdres = "Menekşe Sokak No:18" }
            };
            //model.Adres = new Adres { Ilce = "Ataşehir", Sehir = "İstanbul", AcikAdres = "Menekşe Sokak No:18" };
            return View(model);
        }
    }
}
