🧩 EBookApi – Modular Backend-Only E-Book Management API

EBookApi, modüler bir yapıda geliştirilmiş, sadece arka uç (backend) tarafını içeren bir .NET 8 Web API projesidir.

Herhangi bir kullanıcı arayüzü (web/mobil) içermez. Amaç; e-kitap verilerinin merkezi olarak yönetilmesini sağlamak için temiz, genişletilebilir ve katmanlı bir servis mimarisi sunmaktır.

🏗 Kullanılan Teknolojiler

.NET 8 / ASP.NET Core Web API – Modern REST mimarisi

Entity Framework Core – ORM ve veritabanı işlemleri

AutoMapper – DTO ↔ Entity dönüşümleri

FluentValidation – Giriş doğrulama işlemleri

MediatR – CQRS desen desteği ile handler bazlı işlem mimarisi

Swagger / Swashbuckle – Otomatik API dokümantasyonu ve test arayüzü

JWT Authentication – Token tabanlı yetkilendirme (opsiyonel)

Serilog – Gelişmiş ve yapılandırılabilir loglama altyapısı (isteğe bağlı)

📁 Proje Klasör Yapısı
/src
  /EBookApi.WebAPI         --> API Controller’lar ve giriş noktası

  /EBookApi.Application    --> UseCase’ler, DTO’lar, Handler’lar, Validation

  /EBookApi.Domain         --> Entity’ler ve Domain kuralları

  /EBookApi.Persistence    --> DbContext, Repository, EF konfigürasyonları

/shared

  /Mappings                --> AutoMapper profilleri

  /Validation              --> FluentValidation sınıfları

  /DTOs                    --> Taşıma nesneleri

🔄 Geliştirme Akışı

HTTP İstekleri API Controller üzerinden MediatR’a iletilir

FluentValidation doğrulama kuralları çalışır

EF Core ile veritabanı işlemleri gerçekleştirilir

AutoMapper, Entity ↔ DTO dönüşümlerini yapar

Swagger UI, endpoint testleri için sunulur

JWT Authentication (varsa) ile endpoint erişimi sınırlandırılabilir

Serilog, uygulama loglarını yapılandırılmış şekilde yönetir

🚀 Kurulum ve Çalıştırma
Projeyi Klonlayın
git clone https://github.com/megfb/EBookApi.git
cd EBookApi

Bağımlılıkları Yükleyin
dotnet restore

Veritabanı Oluştur / Güncelle (EF Core)
dotnet ef database update --project src/EBookApi.Persistence


💡 Not: appsettings.json içindeki veritabanı bağlantı bilgisini güncellediğinizden emin olun.

Uygulamayı Başlat
dotnet run --project src/EBookApi.WebAPI

Swagger UI

API dokümantasyonuna aşağıdaki URL üzerinden erişebilirsiniz:

https://localhost:<port>/swagger/index.html

🧪 Örnek Endpoint’ler
GET    /api/books
POST   /api/books
PUT    /api/books/{id}
DELETE /api/books/{id}
