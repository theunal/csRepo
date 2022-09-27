using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebUI.Entity.Context
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){CategoryName="Kamera",Description="Kamera Ürünleri"},
                 new Category(){CategoryName="Bilgisayar",Description="Bilgisayar Ürünleri"},
                  new Category(){CategoryName="Elektronik",Description="Elektronik Ürünleri"},
                 new Category(){CategoryName="Telefon",Description="Telefon Ürünleri"},
                  new Category(){CategoryName="Beyaz Eşya",Description="Beyaz Eşya Ürünleri"},

            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();


            List<Product> products = new List<Product>()
            {
                new Product(){Name="Canon EOS 90D + 18-135 mm Lens Dijital SLR Fotoğraf Makinesi",Description="32,5 megapiksellik olağanüstü fotoğraflar yakalayabilen, ayrıntılara daha da yakınlaşmanıza ve daha hızlı çekim yapmanıza imkan tanıyan tam özellikli DSLR. - 32,5 MP APS-C CMOS Sensör - Wi-Fi & NFC Bağlantı - 4K Video Çekimi - Saniyede 10 Kare Çekim Hızı - 45 Adet Netleme Noktası (45 Adet Çapraz Tipte) Canon EOS 90D + EF-S 18-135mm f/3.5-5.6 IS Nano USM Fotoğraf Makinesi (Canon Eurasia Garantili) Özellikleri Ekran Boyutu    3 inç Hafıza Kartı Tipi   SD Hafıza Kartı    SDHC/SDXC Kamera Formatı  APS-C (1.6x Crop Factor) Maksimum ISO    51200 Paket İçeriği   Canon EOS 90D DSLR Fotoğraf Makinesi (Sadece Gövde) Canon EF-S 18-135mm IS USM Lens Canon LP-E6N Lityum-İyon Pil Takımı (7.2V, 1865mAh) Canon LC-E6 Şarj Cihazı Canon Eyecup Eb Canon EOS Kameralar için Canon RF-3 Gövde Kapağı EC2 Geniş Kamera Askısı Kullanım Kılavuzu Garanti Belgesi Sensör Boyutu   CMOS, 22.3 x 14.9 mm Tipi    Kit (Objektifli) Video Çözünürlüğü   4K 60i/30p Diğer Garanti Süresi (Ay) 24 Yurt Dışı Satış Yok Stok Kodu   HBV00000NPZRB",Price=25309,Stock=208,IsApproved=true,CategoryId=1,IsHome=true,image="1.jpg"},
                new Product(){Name="Canon EOS 90D Fotoğraf Makinesi",Description="32,5 megapiksellik olağanüstü fotoğraflar yakalayabilen, ayrıntılara daha da yakınlaşmanıza ve daha hızlı çekim yapmanıza imkan tanıyan tam özellikli DSLR. - 32,5 MP APS-C CMOS Sensör - Wi-Fi & NFC Bağlantı - 4K Video Çekimi - Saniyede 10 Kare Çekim Hızı - 45 Adet Netleme Noktası (45 Adet Çapraz Tipte) Canon EOS 90D + EF-S 18-135mm f/3.5-5.6 IS Nano USM Fotoğraf Makinesi (Canon Eurasia Garantili) Özellikleri Ekran Boyutu    3 inç Hafıza Kartı Tipi   SD Hafıza Kartı    SDHC/SDXC Kamera Formatı  APS-C (1.6x Crop Factor) Maksimum ISO    51200 Paket İçeriği   Canon EOS 90D DSLR Fotoğraf Makinesi (Sadece Gövde) Canon EF-S 18-135mm IS USM Lens Canon LP-E6N Lityum-İyon Pil Takımı (7.2V, 1865mAh) Canon LC-E6 Şarj Cihazı Canon Eyecup Eb Canon EOS Kameralar için Canon RF-3 Gövde Kapağı EC2 Geniş Kamera Askısı Kullanım Kılavuzu Garanti Belgesi Sensör Boyutu   CMOS, 22.3 x 14.9 mm Tipi    Kit (Objektifli) Video Çözünürlüğü   4K 60i/30p Diğer Garanti Süresi (Ay) 24 Yurt Dışı Satış Yok Stok Kodu   HBV00000NPZRB",Price=25309,Stock=208,IsApproved=true,CategoryId=1,IsHome=true,image="2.jpg"}

            };

            foreach(var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();


            base.Seed(context);
        }
    }
}