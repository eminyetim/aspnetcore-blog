# 📝 BlogApp (ASP.NET Core MVC - .NET 8)

Bu proje, kullanıcı kimlik doğrulama, blog ve kategori yönetimi, kategoriye göre filtreleme, hata loglama ve SOLID prensiplerine uygun servis katmanları gibi modern yazılım mimarisi örneklerini barındıran bir ASP.NET Core MVC uygulamasıdır.

---

## 📌 Projenin Amacı

Bu blog platformu, **Doğuş Teknoloji Bootcamp** kapsamında geliştirilen bir eğitim projesidir. Proje boyunca .NET mimarisi, temiz kod ilkeleri, hata yönetimi, kullanıcı işlemleri ve loglama gibi konular birebir uygulanmıştır.

---

## 🚀 Uygulanan Özellikler

### ✅ Kullanıcı Sistemi (Authentication & Authorization)
- ASP.NET Core Identity ile kullanıcı kaydı, giriş ve çıkış işlemleri
- GUID tabanlı kullanıcı ID’si ile güçlü veri bütünlüğü
- Cookie tabanlı kimlik doğrulama
- `[Authorize]` kullanımı ile güvenli sayfa erişimi

### ✅ Blog Yönetimi
- Blog oluşturma, düzenleme, silme işlemleri (CRUD)
- Yalnızca giriş yapan kullanıcılar kendi bloglarını görebilir ve yönetebilir
- Her blog için başlık, içerik, kategori, yayın tarihi ve yazar bilgisi tutulur

### ✅ Kategori Sistemi
- Kategori oluşturma ve listeleme
- Blog oluştururken kategori seçme
- Ana sayfada kategoriye göre filtreleme butonları
- ViewBag yerine servis üzerinden `SelectList` üretimi (refactor)

### ✅ Global Exception Handling & Loglama
- Tüm uygulamayı saran `ExceptionMiddleware` yazıldı
- Hatalar hem `ILogger` ile loglandı hem de `Logs/error-log.txt` dosyasına yazıldı
- Yardımcı `LogHelper` sınıfı ile hata detayları sistematik olarak kaydedildi

### ✅ Mimari Yapı ve Kod Kalitesi
- Katmanlı yapı:
  - `Controller → Service → Repository → EntityFramework`
- SOLID prensiplerine uygun yapı:
  - Tek sorumluluk (SRP)
  - Bağımlılıkların soyutlanması (DI)
- AutoMapper ile DTO - Entity dönüşümü
- DTO'lar sayesinde View ve veri modeli ayrımı
- `IUserService` ile kullanıcı ID’si erişimi controller’dan alındı

### ✅ Arayüz (UI)
- Razor View Engine + Bootstrap 5 kullanıldı
- Navbar, sticky footer, responsive layout
- Validation uyarıları, anti-forgery token, validation summary

---

## 📋 Yapılan Commit'lere Göre Geliştirme Adımları

| Adım | Açıklama |
|------|----------|
| ✅ Proje başlatıldı, MVC yapısı kuruldu | .NET 8 ile `BlogApp` isimli MVC projesi oluşturuldu |
| ✅ Entity'ler oluşturuldu (`Blog`, `Category`, `User`) | Database modeli hazırlandı, ilişkiler kuruldu |
| ✅ Identity eklendi ve `User` sınıfı `IdentityUser<Guid>` olarak ayarlandı | GUID bazlı kullanıcı yönetimi sağlandı |
| ✅ `CategoryService`, `BlogService`, `IUserService` yazıldı | Service ve Repository desenleri uygulandı |
| ✅ AutoMapper entegre edildi | DTO dönüşümleri için kullanıldı |
| ✅ Blog ve kategori CRUD işlemleri yapıldı | Formlar oluşturuldu, validasyonlar yazıldı |
| ✅ Kategori filtreleme butonları ile bloglar listelendi | HomeController üzerinden ViewBag ile kategori filtreleme eklendi |
| ✅ Global `ExceptionMiddleware` yazıldı | Tüm hatalar yakalanıp kullanıcı dostu hale getirildi |
| ✅ Hatalar `Logs/error-log.txt` dosyasına yazıldı | `LogHelper` sınıfı ile hata logları oluşturuldu |
| ✅ Layout düzenlendi, sticky footer sorunu çözüldü | Flexbox yapısı kullanılarak footer sorunsuz hale getirildi |
| ✅ Kullanıcı sadece kendi bloglarını görebiliyor | `[Authorize]` ve UserId kontrolü ile güvenlik sağlandı |
| ✅ Servis katmanları sadeleştirildi, kodlar refactor edildi | `GetUserId`, `GetCategorySelectListAsync` gibi yardımcı metodlar eklendi |
| ✅ Gelişmiş `README.md` eklendi | Tüm proje adımları ve açıklamaları bu dosyada yazıldı |

---

## 🔧 Projeyi Çalıştırma

1. Bu repoyu klonlayın:
```bash
git clone https://github.com/kullaniciadi/BlogApp.git
cd BlogApp
