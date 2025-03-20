Proje Açıklaması
Fatura yönetimi ve e-posta gönderimi gibi işlemleri içeren bir web uygulamasıdır. Proje, .NET Core 8 ile geliştirilmiştir.

Teknolojiler
ASP.NET Core Web API
Entity Framework Core (EF Core)
FluentValidation
AutoMapper (DTO ile Model dönüşümleri için)
MailKit (SMTP e-posta gönderimi için)
Serilog (Loglama için)

Proje Yapısı
Proje, Clean Architecture ve mimarisine uygun olarak aşağıdaki katmanlardan oluşur:

SovosProject.Core: Domain modelleri ve iş kurallarını barındırır.
SovosProject.Application: Uygulama iş mantığını içerir. Servisler, CQRS işlemleri burada bulunur.
SovosProject.Infrastructure: Veritabanı erişimi, repository yapıları, dış servis entegrasyonları gibi altyapısal işlemleri içerir.
WebAPI: Kullanıcıya API hizmetleri sağlayan katmandır.
SovosProject.Tests: Birim testler ve entegrasyon testlerini içerir.
