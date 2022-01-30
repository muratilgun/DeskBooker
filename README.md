# **Test Driven Development**
TDD’de öncelikle Gereksimler(requirements) belirlenir ve küçük parçalar halinde ayrılır.

<img src="https://i.ibb.co/QNPMGBn/1.png" alt="1" border="0"  width="359" height="300"><img src="https://i.ibb.co/KzFdFP0/2.png" alt="2" border="0"  width="359" height="300">

Daha sonra, implementasyondan önce bir test yazılır, Business kurallarını tam olarak belirlemediğimiz için bu test başarısız olur. Ancak test, kodunuzun gereksinimi karşılamak için ne yapması gerektiğini zaten açıklar. Bir sonraki adım testi geçmek için gerekli olan kodları yazmak olur. Başarılı olan testten sonra kodlarda iyileştirme yapılarak tekrar düzenlenir.

<img src="https://i.ibb.co/gz4Hgsp/3.png" alt="3">

Bu döngü bu şekilde tamamlandıktan sonra bir sonraki gereksinime geçilir. Ve döngü tekrar eder.

<img src="https://i.ibb.co/Jk3gf6t/4.png" alt="4" border="0" width="359" height="300">

<img src="https://i.ibb.co/QjGGkjJ/5.png" alt="5" border="0" width="394" height="300"><img src="https://i.ibb.co/mhKx0y8/6.png" alt="6" border="0" width="220" height="300">

kısacası; TDD bu kırmızı,yeşil ve refactor döngü içerisinde yenilenen gereksinimlere göre implementasyon gerçekleştirilen yaklaşımdır.
## TDD’nin avantajları nelerdir ?
-   TDD en baştan sona kadar geliştirilen apiler hakkında çok iyi düşünmeye zorlar. Hangi metodlar, classlar, propertyler kullanılacağını vs.  
    Bu genellikle iyi bir API tasarımının yaratılmasına yol açan bir avantajdır.
    
-   TDD'nin en büyük avantajı, kodun nasıl yapacağını düşünmek zorunda kalmadan kodun ne yapacağını düşünebilmenizdir. Çünkü test yaparak başlıyorsunuz. Bunun haricinden kodların nasıl implemenete edileceğiyle ilgili ayrıca bir zaman ayırmaya gerek yoktur.
    
-   Diğer güzel bir avantajı gereksinimleri implemente ederken hızlı bir şekilde feedback alınır. Daha sonra yeni bir özelliği görmek için uygulamayı başlatmak yeterli olacaktır. TDD bir uygulama oluştururken örnek bir business logic üzerinden ilerlemeyi sağlar. Uygulamayı başlatmadan business logic tamamen oluşur. Çünkü testlerden gerekli feedbackler alınmış olur.

<img src="https://i.ibb.co/LxXFc5b/7.png" alt="7" border="0">

-   TDD yaklaşımında, kodumuz sınıfı otomatik olarak test edecek modül oluşturacaktır. bağımlılıkları anlamak ve ayırmak gerekir ve TDD sizi bunu yapmaya en baştan zorlar. Bu kodlarımızı ve modellerimizi modellemeye yol açar. Yani tüm bağımlılıklara sahip olmadan tek başına bir gereksinim üzerinde çalışmaya olanak sağlar. Bu yüzden database tamamen hazır değil, Web API tamamen hazır değil diye düşünmeye gerek yoktur vb.. Bu modüler yapı diğer tüm bileşenler için çalışır.
    
-   TDD ile bakım yapılabilir bir kod yapısına sahip olunur. Mevcut işlevleri bozmadan büyük kod değişiklikleri yapılabilinir. Değişikliklerden sonra unit testler tekrar çalıştırılır tüm testler yeşil ise logic’in eskisi gibi çalıştığını biliyorsunuzdur.
    
-   Testler kodlarla ilgili iyi bir dökümantasyon oluşturur.
## TDD’nin dezavantajı nelerdir ?
TDD yaklaşımına yeni başlayanlar için test süreçlerine alışmak o kadar kolay değildir.

<img src="https://i.ibb.co/pPy5Ffp/8.png" alt="8" border="0"  width="390" height="216">

## The Wired Brain Coffee Scenario
<img src="https://i.ibb.co/zSfBQ7D/9.png" alt="9" border="0">

Dünya çapında birçok birçok kahve dükkanı işleten bir şirkettir.
Zürih'teki dükkanlarında müşteriler için masaları var.
Müşterilerin tam gün masa rezervasyonu yapabileceği bir web uygulaması istiyorlar.
Şimdiye kadar henüz hiçbir şey implemente edilmedi.
Web uygulamasının iş mantığını ve bölümlerini oluşturmanızı istiyorlar.

<img src="https://i.ibb.co/7zrJQDg/10.png" alt="10" border="0">

Kullanıcı olarak web sitesi üzerinden kafede tam gün masa rezervasyonu yapabilirsiniz. Bunun için ad,soyad,email ve tarih bilgileri vermeniz ve masa ayırtın düğmesine tıklamanız gerekiyor. Aşağıdaki mockup da görüldüğü gibi

<img src="https://i.ibb.co/db4Y7my/11.png" alt="11" border="0"  width="407" height="392">

Bu web sitesi `DeskBooker.Web` (ASP.NET Core/Razor Pages) adlı bir projenin parçası
olacaktır. Bu planlanan `DeskBooker` Solution’ın bir parçasıdır. Planlanan mimaride, ayrıca solution’ında `DeskBooker.Core`(.Net Core class library) yani business logiclerin yazıldığı katman olacaktır. Bu logiclerin merkezinde ise `DeskBookingRequestProcessor` sınıfı yer alacaktır. İlgili sınıf masa ayırma isteklerinin işleneceği bir sınıf olacak temel masa ayırma logic’ini içerecektir. Örneğin: seçili tarihte masanın detaylı bilgilerine bakıldığı zaman rezervasyon yapmaya uygun mu ? Bunun için `DeskBooker.DataAccesss`(Entity Framework Core) katmanına bağlanacaktır.

<img src="https://i.ibb.co/qBN16nL/12.png" alt="12" border="0" >

Oluşturulan Test katmanlarında test işlemleri gerçekleştirilir.

<img src="https://i.ibb.co/gwmPwzR/13.png" alt="13" border="0">
<img src="https://i.ibb.co/hZT6Y88/14.png" alt="14" border="0">

## İlk Gereksinimi anlamak

Sınıfımızı sırasıyla Mockup’tan bir örneğe işliyorum. Bu sınıf genel masa ayırma taleplerini işleyecek temel business logiclerini içerecek, Müşteri ad, soyad, email, ve bir tarih girebilir.  
Bu DeskBookingRequestProcessor sınıfının giriş(input) verileridir. **İlk aşamada gerekliliğimiz DeskBookingRequestProcessor sınıfının bu verileri alıp tekrar geri vermesidir.**
Bu testi yazmadan önce API dizaynını düşünmemiz gerekir. Diyelim ki bu aşamada BookDesk adından bir metodumuz var ve bu metod masa ayırma işlemini gerçekleştiriyor. Gelen istekleri karşılayan ad,soyad,email ve tarih propertylerini içeren DeskBookingRequest sınıfımız var. Bunun üzerinden bilgiler metodumuza geliyor ve aynı şekilde DeskBookingResult adında bir sınıfımız var buda veriyi geri dönüyor.
### İLK GEREKSİNİMİN TDD İLE İMPLEMENTASYONU
    -   Red Unit Test oluşturulur.
    -   Testi yeşil yapmak için kod yazılır
    -   Kodlar refactor edilir

### [FACT] NEDİR ?
[Fact] attribute’ü, ilgili fonksiyonun bir test metodu olduğunu belirtmek üzere kullanılır.

### [Theory] NEDİR ?
Parametre alan metotları ise ‘Theory’ attribute’u ile işaretliyor

### [InlineData] NEDİR ?
Metodun parametrelerini ‘InlineData’ attribute’u ile opsiyonel olarak veriyoruz.

> İYİ BİRİ UNİT TEST 3 AŞAMADAN OLUŞUR ARRANGE ACT VE ASSERT
> 
> 1.  **Arrange :** test yapacağımız metodun nesneleri yaratılır bunlar hard code yazılan ya da oluşturulan mock nesneler olabilir.
> 2.  **Act :** Bu aşamada ilgili nesneden hangi metodu test edeceksek arrange bölümünden oluşturulan nesneler ve inputlarla bu metod
> tetiklenir, harekete geçirilir.
> 3. **Assert :** istediğimiz sonuca ulaşılıp ulaşılmadığı kontrol edilir.

## **RED-GREEN-REFACTOR OLUŞTURMA AŞAMALARI**
-   Testin amacını belirten void bir metod yazıldı.
    
-   Fact attribute ile test metodu olduğu belirtildi.
    
-   Masa ayırma talepleri için business kodlarının olduğu bir processor sınıfının ihtiyacı tespit edildi. `DeskBookingRequestProcessor()` sınıfı oluşturuldu ve instance’ı alındı.
    
-   Daha sonra ilgili processor sınıfında `BookDesk` adında metodun ihtiyacı tespit edildi ve ilgili method oluşturuldu.
    
-   `BookDesk` metodunun input bilgilerini alması gerektiği tespit edildi. `DeskBookingRequest` adında Ad-Soyad-Email-Tarih propertyleri olan bir sınıf oluşturuldu. Bu model `BookDesk’e` parametre olarak verildi.
    
-   `BookDesk` metodunun bir sonuç döndürmesi gerekliliği tespit edildi. `DeskBookingResult` adında Ad-Soyad-Email-Tarih propertyleri olan bir sınıf oluşturuldu. BookDesk’in metodunda geri dönüş değeri bu sınıfı ile değiştirildi.
    
-   assert ile geri dönen modelin boş olup olmadığının kontrol yapıldı.
    
-   requestin result ile aynı olup olmadığının kontrolü yapıldı.
    
-   View → Test Explorer üzerinden test başlatıldı. ve başarısız sonuç döndü.
    
-   TDD döngüsünde, bir sonraki aşama olan Green test yani başarılı test sonucu için, ihtiyaçlar tespit edildi. DeskBookingRequestProcessor sınıfı içerisinde bulunan `BookDesk` metodunun içerisine `DeskBookingRequest` ile gelen değerleri `DeskBookingResult’a` mapleyip return edebileceği kodlar implemente edildi.
    
-   Test Explorer üzerinden tekrar test başlatıldı. Başarılı sonuç dönünce TDD döngüsünün diğer aşaması yani Refactor aşamasına geçildi.
    
-   Testi yazarken oluşturduğumuz sınıflar separation of concerns yapısına göre ayrıldı. → `DeskBooker.Core` adından bir class library oluşturuldu. `Processor` ve `Domain` adında 2 ayrı klasör oluşturuldu. Sınıflar ilgili klasörlere taşınarak proje düzenlendi.

## **SONRAKİ GEREKSİNİM**

<img src="https://i.ibb.co/3Y6x9p4/15.png" alt="15" border="0">

Eğer request `null` gelirse `ArgumentNullException` hatasının gönderilmesi gereksinim olarak belirlendi.

-   Null gelmesi durumunda hangi hata gönderiliyor
    
-   `ArgumentNullException` fırlatılması
    
-   Kodların refactor edilmesi

#### **TEST AŞAMASI**

-   Processor sınıfının instance’ı alındı.
    
-   Assert yazılarak, `null` model gelirse(Invalid model olarakta tanımlanabilir) `ArgumentNullException` hatasının gönderilmesi test edildi.
    
-   `NullReferenceException` gönderildi. Test sonucu başarısız oldu. TDD döngüsündeki bir sonraki aşamaya geçildi.
    
-   Daha sonra `BookDesk` metodunun içerisine bir if statement’ı yazılarak eğer parametre `null` olursa `ArgumentNullException` göndermesi ile ilgili logic implemente edildi.
    
-   Test Explorer üzerinden tekrar test edildi. Test başarılı oldu Refactor aşamasına geldi
    
-   2 test metodu da `DeskBookingRequestProcessor()` sınıfını instance alıyor. Processor sınıfını her test metoduna implemente edilebilecek şekilde setup oluşturmak daha iyi bunun için `DeskBookinRequestProcessorTests()` sınıfının constructor’ına `DeskBookingRequestProcessor` sınıfını inject ederek sınıf çağrıldığında nesnenin oluşması sağlandı. Bu her metoda implemente edilerek, tekrar tekrar instance almaya gerek kalmadı.
    
-   En son yapılan değişikliklerden sonra testler tekrar denendi başarılı dönüş alındığı için diğer gereksinime geçilir.


### **SONRAKİ GEREKSİNİMLER**

<img src="https://i.ibb.co/Hz9qF2B/16.png" alt="16" border="0">

**Mock Object**

<img src="https://i.ibb.co/zfmmdjr/17.png" alt="17" border="0">
<img src="https://i.ibb.co/cNpVq90/18.png" alt="18" border="0">
<img src="https://i.ibb.co/bBzbY94/19.png" alt="19" border="0">

**Data Driven Test**

<img src="https://i.ibb.co/GcyQs9S/20.png" alt="20" border="0">

<img src="https://i.ibb.co/7kx9R3s/21.png" alt="21" border="0">


[KAYNAK](https://app.pluralsight.com/library/courses/csharp-test-driven-development/table-of-contents)
