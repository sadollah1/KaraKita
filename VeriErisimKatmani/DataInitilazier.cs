using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace VeriErisimKatmani
{
    public  class DataInitilazier : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Proje> projeler = new List<Proje> {
            new Proje{ Id="prj-1",Aciklama="Afrika'da yaşayan müslümanlar namazlarının tamamını mescidde kılmakta, cuma nazazı, bayram namazı ve teravih namazları ise genel itibarle kaçırılmamaktadır. Ayrıca tüm cami ve mescidler bulundukları bölgenin (mahalle, köy, kasaba vs) merkezi durumundadırlar. Tüm etkinlikler cami veya mescid etrafında gerçekleşmektedir. Afrika'da cami veya mescid inşaası veya tamir-tadilat ihtiyacı olan mesciddlerde tamir işlerini gerçekleştirmekteyiz.",Ad="Cami Mescit Projesi",EklemeZamanı=DateTime.Now,ResimYolu="proje/proje01_b.jpg"},
            new Proje{ Id="prj-2",Aciklama="1,2 milyar insanın yaşadığı Afrika kıtasında 10 milyon katarakt hastası olduğu bilinmektedir. Beslenme yetersizliği, kısıtlı su nedeniyle sanitasyon yetersizliği, kum fırtınaları gibi nedenler kataraktın ortaya çıkması ya da ilerlemesine etken rol oynamaktadır. Uzman doktorlarla belirlenen noktalarda katarakt ameliyatı operasyonları ile gözlere ışık, kalplere umut saçmaya devam ediyoruz.",Ad="Katarakt Projesi",EklemeZamanı=DateTime.Now,ResimYolu="proje/proje02_b.jpg"},
            new Proje{ Id="prj-3",Aciklama="Ramazan ve kurban bayramları arefesinde Afrika’daki çocukların sevindirmek, tebessümlerine ortak olmak, dualarını almak amacıyla onlara elbise, ayakkabı, terlik, oyuncak, balon, şeker ve çikolata gibi ürünlerden müteşekkil bayramlık paketleri dağıtabilmekteyiz. Yetimhanelerde, okullarda, köylerde veya camilerde yaptığımız program ile partner kuruluşlarımız adına bu bölgelerdeki çocukları aynı noktada toplayarak bayram ve şenlik havasında, tatlı bir serenomi eşliğinde tek tek çocuklara bayramlıkları dağıtılmakta, fotoğraf ve videoları alınmaktadır.",Ad="Bayramlık Dağıtımları",EklemeZamanı=DateTime.Now,ResimYolu="proje/proje03_b.jpg"},
            new Proje{ Id="prj-4",Aciklama="Afrika'da fakirlik sınırının altında bir yaşayan ülkelerde sağlık alanında da birçok eksiklik yaşanmaktadır. Müslümanların zorlu yaşam koşulları altında hayatlarını idame ettikleri bu bölgelerde sünnet olması gereken çocuklar bulunmakta. Sünnet olamadıkları için bazı hastalıklara yakalanmışlar ve farklı hastalıklarında bulaşması yüksek ihtimal. En çok idrar yolları enfeksiyonuna yakalanmaktadırlar. Yaşları 3 ile 14 arasında değişen çocukların Peygamberler adeti, Allah emri olan sünnet yükümlülüğünü yerine getirmeleri hem de hijyen şartlarının yetersiz olduğu Afrika sünnet olarak birçok hastalıktan korunmlarını sağlıyoruz. Sünnet organizasyonlarını şölen ve bayram havasında, hediyeler dağıtarak icra etmekteyiz.",Ad="Sünnet Organizasyonu",EklemeZamanı=DateTime.Now,ResimYolu="proje/proje04_b.jpg"},
            new Proje{ Id="prj-5",Aciklama="Üçayların girişi ile başlayan planlama ve organizasyon süreci partner kuruluşlarımızın talepleri ve Kara Kıta’nın danışmanlığı doğrultusunda Ramazan ayının başlangıcı ile start verilerek gündüzünde kumanya dağıtımı, akşamları ise toplu iftar organizasyonları ile renklenmektedir. Partner kuruluş ile yapılan planlama doğrultusunda 50, 100 ve katları şeklinde günlük iftar programları düzenlenmektedir. İftar başlamadan önce tanıtım videosu çekilerek kurum adı, bağışçı adı, bölge ve ihtiyaç sahipleri hakkında bilgilendirme videosu çekilmekte, dua yapılmaktadır. Kumanya dağıtımları da istenilen sayıda, tutarlarda ve içerikte hazırlanan kumanyalar ev ev dağıtılmakta, yetim merkezlerine bırakılmakta veya köy merkezlerinde toplu olarak dağıtılmaktadır. Dağıtımlarda partner kuruluşun afişi asılmakta, bilgilendirme videosu çekilmektedir.",Ad="Ramazan Programları",EklemeZamanı=DateTime.Now,ResimYolu="proje/proje05_b.jpg"},
            new Proje{ Id="prj-6",Aciklama="En temel ihtiyacımız olan suyun kıymeti herkesçe malum. Söz konusu coğrafya Afrika olunca kıymeti kat kat artmaktadır. Yurtiçi ve yurtdışı kuruluşlarımızın talepleri doğrultusunda su şebekelerinin olmadığı, suya ulaşmanın çok zor olduğu Afrika’da ve hijyenik, temiz suya ulaşımın zor olduğu Asya ülkelerinde birçok su kuyusu açılışı yaparak bölge halkının hizmetine sunduk. STK’larımız tarafından gelen su kuyusu talepleri için ilk olarak kuyu çeşidinin belirlenmesi sonrasında ise lokasyon çalışması yapılması gerekmektedir. Bölge halkının içme suyunun, temizlik ihtiyacının ve hayvanların su ihtiyaçlarının karşılanmasını sağlayacak şekilde planlama yapılmaktadır. Su Kuyusunun dualar eşliğinde ilk kazma vurulduğu andan açılışının yapıldığı zamana kadarki süreci video ve fotoğraflarla kaydedilerek tarafınızla paylaşılmaktadır.",Ad="Su Kuyuları",EklemeZamanı=DateTime.Now,ResimYolu="proje/proje06_b.jpg"}
            };
            List<Resim> resimler = new List<Resim> { 
            new Resim{ Id="resim-1",DosyaYolu="galeri/proje01_b.jpg"},
            new Resim{ Id="resim-2",DosyaYolu="galeri/proje02_b.jpg"},
            new Resim{ Id="resim-3",DosyaYolu="galeri/proje03_b.jpg"},
            new Resim{ Id="resim-4",DosyaYolu="galeri/proje04_b.jpg"},
            new Resim{ Id="resim-5",DosyaYolu="galeri/proje05_b.jpg"},
            new Resim{ Id="resim-6",DosyaYolu="galeri/proje06_b.jpg"},
            new Resim{ Id="resim-7",DosyaYolu="galeri/proje07_b.jpg"},
            };
            Kullanici kullanici = new Kullanici() { 
            Ad="Admin Test",
            Email="test@admin.com",
            Sifre="qwerty1234"
            };
            IletisimBilgileri bilgiler = new IletisimBilgileri()
            {
                HaftaiciCalismaSaatleri = "08:30 - 17.30",
                HaftasonuCalismaSaatleri = "Kapalı",
                MailAdresi = "info@karakitaorganizasyon.com.tr",
                Telefon = " +90 544 693 8992",
                WhatsappTelefon = " +90 544 693 8992",
                Adres = "Atatürk Mh. Halit Bey Sk. No:23 / 1 Ümraniye / İSTANBUL"
            };
            context.Bilgiler.Add(bilgiler);
            context.Yoneticiler.Add(kullanici);
            context.Projeler.AddRange(projeler);
            context.Resimler.AddRange(resimler);
            context.SaveChanges();

            base.Seed(context);


        }
    }
}