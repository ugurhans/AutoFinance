<h5>AutoFinance</h5>
<div>
  <h3>Proje Hakkında</h3>
  <p>
    N-Katmanlı Solid mimari yapısı ile hazırlanan, EntityFramework kullanılarak
    CRUD işlemlerinin yapıldığı, kayıt olma giriş yapabilme Jwt teknikleri ile
    token alarak güvenliği sağlanan, Caching, Validation,
    Transaction,Performance işlemlerini Autofac paketi ile oluşturulan
    Aspectleri kullanarak gerçekleştiren, Wpf arayüzü ile çalışan,Proje
    içerisinde data kaynakları kolayca değiştirilebilir, yeni nesneler
    eklenebilir, bütün iş istekleri değiştirilebilir.Yapılacak olanlar eski
    kodları bozmadan sürekli ekleme ile yapılabilir.Proje sürdürülebilirlik
    prensibini yerine getirmektedir.
  </p>

  <h4>Backend Tecnologies</h4>
  <p>
    MsSql, Asp.Net Core for Restful api,EntityFramework
    Core,Autofac,FluentValidation MsSql, Asp.Net Core for Restful api,
    EntityFramework, Core, Autofac, FluentValidation
  </p>

  <h4>Layered Architecture Design Pattern</h4>
  <p>IOC,AOP,Aspects,JWT IOC, AOP, Aspects, JWT</p>

  <h2>Katmanlar</h2>
  <h3>Entities Katmanı</h3>
  <p>
    Entities Katmanı'nda Dtos ve Concrete olmak üzere iki adet klasör
    bulunmaktadır.Concrete klasörü veri tabanından gelen somut nesnelerin
    özelliklerini tutmak için oluşturulmuştur.Dtos klasörü ise veri tabanında
    birbiri ile ilişkili olan nesnelerin ilişkili özelliklerini birlikte
    kullanabilmek için oluşturulmuştur.
  </p>

  <h3>Core Katmanı</h3>
  <p>
    Core Katmanı projeden bağımsız bir katmandır. Geliştirilecek her projede
    kullanılabilir, isimlendirme kuralları ve oluşturulma düzeni sebebi ile
    oldukça kullanışlıdır. Core Katmanı'nda DataAccess, Entities, Utilities,
    Aspects, CrossCuttingConcerns, DependencyResolvers ve Extensions klasörleri
    bulunmaktadır. Aspects kasörü Caching, Validation, Transaction,Performance
    işlemlerinin Autofac attribute altyapısını hazırlar.CrossCuttingConcerns
    klasöründe Validation ve Cache yönetimi proje içerisinde, dikey katmanda
    dinamik çalışabilmesi için generics genelleştirildi.DependencyResolvers
    klasöründe servis konfigrasyonları yapıldı.DataAccess klasöründe bütün CRUD
    operasyonları ve DataBaseler generic olarak yapılandırıldı.Extensions
    içerisinde Jwt için yönetimi kolaylaştıran genişlemeler yapıldı.Utilities
    içerisinde iş metodu kurallarının yönetimi kolaylaştırıldı, belge ekleme
    işlemleri kodlandı,Aspectlerin araya girebilmesi için alt yapı hazırlandı ve
    ezilmeyi bekliyor, Results yapısı kurularak hata yönetimi yapılandırıldı,
    Jwt ve hashing teknikleriyle şifreler ile projede ve veritabanında güvenlik
    yapılandırıldı.
  </p>

  <h3>Data Access Katmanı</h3>
  <p>
    Data Access Katmanı'nda Abstract interfaceleri barındıran ve Concrete
    classları barındıran klasörler bulunmaktadır.Crud operasyonlarını core
    katmanından miras alarak gerçekleştirmektedir.Gelebilecek iş kodları için
    altyapı burada hazırlanır.Objelerin data transferleri için kullanacağı data
    baseler ve varlıkların bağlantıları Data Access Katmanı'nda yapılandırıldı.
  </p>

  <h3>Business Katmanı</h3>
  <p>
    Business Katmanı'nda altyapısı hazır olan bütün serviserin yönetimleri
    yazıldı.Sürekli değişebilen iş kodlarımızı altyapıyı değiştirmeden
    ekleyebildiğimiz katmandır.Sürekliliğin korunduğu projemde birçok
    değişikliğin sadece burada yapılıyor olması yönetimi, sürekli gelişimi çok
    kolaylaştırmaktadır.
  </p>
</div>
