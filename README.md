# Clean Architecture (.NET 9)

Bu proje, **Clean Architecture** prensiplerine göre oluşturulmuş örnek bir .NET 9 projesidir. Amacı, katmanlı mimari yaklaşımıyla sürdürülebilir, test edilebilir ve genişletilebilir bir yapı sunmaktır.

## 🧱 Katmanlar

Proje aşağıdaki gibi yapılandırılmıştır:

- **CleanArchitecture.Domain**  
  Uygulamanın iş kurallarını barındırır. Entity ve temel interface’ler burada yer alır.

- **CleanArchitecture.Application**  
  Use case'leri, DTO'ları, servis arayüzlerini ve CQRS (Command & Query) yapısını içerir.

- **CleanArchitecture.Infrastructure**  
  Dış servis entegrasyonları, veri erişimi (Entity Framework), dışa bağımlı yapıların uygulamaları burada bulunur.

- **CleanArchitecture.Persistance**  
  Veri tabanı işlemleri (DbContext, EF Core) burada yapılandırılır.

- **CleanArchitecture.Presentation**  
  ASP.NET Core MVC ya da Razor Pages yapılarını içerebilir. UI katmanıdır.

- **CleanArchitecture.WebApi**  
  HTTP üzerinden çalışan API uçlarını içerir. Swagger, JWT, Middleware'ler burada tanımlanır.

- **CleanArchitecture.Test**  
  Unit ve integration testlerin yazıldığı katmandır.

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core 9
- Entity Framework Core
- AutoMapper
- MediatR (CQRS)
- FluentValidation
- JWT Authentication
- Swagger UI
- SQL Server
- Serilog

## 🔧 Kurulum


1. Repozitoriyi klonlayın:

```bash
   git clone https://github.com/Kaanr21/Clean_Architecture.git
   cd Clean_Architecture
````

2. `appsettings.json` dosyasını uygun şekilde yapılandırın.

3. Veritabanı migrasyonlarını uygulayın:

   ```bash
   dotnet ef database update --project CleanArchitecture.Persistance
   ```

4. Uygulamayı çalıştırın:

   ```bash
   dotnet run --project CleanArchitecture.WebApi
   ```

5. `https://localhost:7020/swagger` adresinden Swagger UI’a erişebilirsiniz.

## 📁 Proje Yapısı

```
├── CleanArchitecture.Domain
├── CleanArchitecture.Application
├── CleanArchitecture.Infrastructure
├── CleanArchitecture.Persistance
├── CleanArchitecture.Presentation
├── CleanArchitecture.WebApi
├── CleanArchitecture.Test
```

## 🎯 Hedefler

* SOLID prensiplerine uygun yapı
* Bağımlılıkların dış katmanlara yönlendirilmesi
* Genişletilebilir, test edilebilir ve okunabilir kod yapısı
* Gerçek dünya projelerine kolay entegrasyon

## ✍️ Katkı Sağlama

Pull request’ler ve katkılar memnuniyetle karşılanır. Lütfen önce bir issue açarak ne eklemek istediğinizi belirtin.

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
