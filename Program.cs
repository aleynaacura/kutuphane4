using System;
using System.Collections.Generic;
using System.Linq;

namespace KutuphaneYonetimSistemi
{
    abstract class Kitap
    {
        public int Id { get; private set; }
        public string Baslik { get; private set; }
        public string Yazar { get; private set; }
        public int YayinYili { get; private set; }
        public bool Musait { get; set; }
        public Uye OduncAlan { get; set; }

        protected Kitap(int id, string baslik, string yazar, int yayinYili)
        {
            Id = id;
            Baslik = baslik;
            Yazar = yazar;
            YayinYili = yayinYili;
            Musait = true;
        }
        public abstract void KitapBilgi();

        public virtual string TurBilgisi() => "Genel Kitap";
    }
    class Roman : Kitap
    {
        public string AltTur { get; private set; }

        public Roman(int id, string baslik, string yazar, int yayinYili, string altTur)
            : base(id, baslik, yazar, yayinYili)
        {
            AltTur = altTur;
        }

        public override void KitapBilgi()
        {
            string durum = Musait ? "MÜSAİT" : "ÖDÜNÇTE";
            Console.WriteLine($"{Id,-2}. {Baslik,-38} - {Yazar,-24} ({YayinYili}) [Roman - {AltTur}] - {durum}");
        }

        public override string TurBilgisi() => "Roman";
    }

    class TarihKitabi : Kitap
    {
        public string Donem { get; private set; }

        public TarihKitabi(int id, string baslik, string yazar, int yayinYili, string donem)
            : base(id, baslik, yazar, yayinYili)
        {
            Donem = donem;
        }

        public override void KitapBilgi()
        {
            string durum = Musait ? "MÜSAİT" : "ÖDÜNÇTE";
            Console.WriteLine($"{Id,-2}. {Baslik,-38} - {Yazar,-24} ({YayinYili}) [Tarih - {Donem}] - {durum}");
        }
    }

    class SiirKitabi : Kitap
    {
        public SiirKitabi(int id, string baslik, string yazar, int yayinYili)
            : base(id, baslik, yazar, yayinYili) { }

        public override void KitapBilgi()
        {
            string durum = Musait ? "MÜSAİT" : "ÖDÜNÇTE";
            Console.WriteLine($"{Id,-2}. {Baslik,-38} - {Yazar,-24} ({YayinYili}) [Şiir Kitabı] - {durum}");
        }
    }

    // ====================== ÜYE SINIFI ======================
    class Uye
    {
        public string Ad { get; private set; }
        public string OkulNo { get; private set; }
        public List<Kitap> OduncAlinanKitaplar { get; private set; }

        public Uye(string ad, string okulNo)
        {
            Ad = ad;
            OkulNo = okulNo;
            OduncAlinanKitaplar = new List<Kitap>();
        }

        public void KitapOduncAl(Kitap kitap)
        {
            if (kitap.Musait)
            {
                OduncAlinanKitaplar.Add(kitap);
                kitap.Musait = false;
                kitap.OduncAlan = this;
                Console.WriteLine($"\n{Ad}, '{kitap.Baslik}' kitabını ödünç aldı.");
            }
            else
            {
                Console.WriteLine("\nBu kitap şu anda başka bir üyede!");
            }
        }

        public void KitapIadeEt(Kitap kitap)
        {
            if (OduncAlinanKitaplar.Remove(kitap))
            {
                kitap.Musait = true;
                kitap.OduncAlan = null;
                Console.WriteLine($"\n'{kitap.Baslik}' kitabı iade edildi.");
            }
            else
            {
                Console.WriteLine("\nBu kitabı siz ödünç almadınız!");
            }
        }

        public void OduncListele()
        {
            Console.WriteLine($"\n    {Ad} ({OkulNo}) - Ödünç Aldığınız Kitaplar    ");
            if (OduncAlinanKitaplar.Count == 0)
                Console.WriteLine("Henüz kitap ödünç almadınız.");
            else
            {
                foreach (var k in OduncAlinanKitaplar)
                    k.KitapBilgi();
            }
        }
    }

    // ====================== KÜTÜPHANE SINIFI ======================
    class Kutuphane
    {
        public List<Kitap> Kitaplar { get; private set; }
        public List<Uye> Uyeler { get; private set; }
        private Uye girisYapanUye = null;

        public Kutuphane()
        {
            Kitaplar = new List<Kitap>();
            Uyeler = new List<Uye>();
            KitaplariOlustur();
        }

        private void KitaplariOlustur()
        {
            Kitaplar.Add(new Roman(1, "Çalıkuşu", "Reşat Nuri Güntekin", 1922, "Aşk"));
            Kitaplar.Add(new Roman(2, "Suç ve Ceza", "Fyodor Dostoyevski", 1866, "Psikolojik"));
            Kitaplar.Add(new Roman(3, "Kürk Mantolu Madonna", "Sabahattin Ali", 1943, "Psikolojik"));
            Kitaplar.Add(new TarihKitabi(4, "Nutuk", "Mustafa Kemal Atatürk", 1927, "Kurtuluş Savaşı"));
            Kitaplar.Add(new TarihKitabi(5, "Osmanlı İmparatorluğu Klasik Çağ", "Halil İnalcık", 1973, "16. Yüzyıl"));
            Kitaplar.Add(new SiirKitabi(6, "Hasretinden Prangalar Eskittim", "Ahmed Arif", 1968));
            Kitaplar.Add(new Roman(7, "Hayvan Çiftliği", "George Orwell", 1945, "Distopya"));
            Kitaplar.Add(new Roman(8, "Harry Potter ve Felsefe Taşı", "J.K. Rowling", 1997, "Fantastik"));
            Kitaplar.Add(new Roman(9, "İnce Memed", "Yaşar Kemal", 1955, "Destan"));
            Kitaplar.Add(new Roman(10, "Saatleri Ayarlama Enstitüsü", "Ahmet Hamdi Tanpınar", 1961, "Eleştirel"));
        }

        public void GirisYap()
        {
            while (true)
            {
                Console.WriteLine("\n    ÜYE GİRİŞİ    ");
                Console.Write("Ad Soyad: ");
                string ad = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(ad) || !ad.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("Ad kısmına SADECE harf girebilirsiniz!");
                    continue;
                }

                Console.Write("Okul Numarası (11 hane): ");
                string okulNo = Console.ReadLine().Trim();

                if (okulNo.Length != 11 || !okulNo.All(char.IsDigit))
                {
                    Console.WriteLine("Okul numarası tam 11 hane olmalıdır!");
                    continue;
                }

                girisYapanUye = Uyeler.FirstOrDefault(u => u.OkulNo == okulNo);

                if (girisYapanUye == null)
                {
                    girisYapanUye = new Uye(ad, okulNo);
                    Uyeler.Add(girisYapanUye);
                    Console.WriteLine(" Yeni üye oluşturuldu.");
                }
                else
                {
                    Console.WriteLine(" Hoş geldiniz.");
                }
                break;
            }
        }

        public void MenuGoster()
        {
            while (true)
            {
                Console.WriteLine("\n=== KÜTÜPHANE SİSTEMİ ===");
                Console.WriteLine("1. Tüm Kitapları Listele");
                Console.WriteLine("2. Kitap Ödünç Al");
                Console.WriteLine("3. Kitap İade Et");
                Console.WriteLine("4. Ödünç Aldığım Kitapları Göster");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": KitaplariListele(); break;
                    case "2": OduncAl(); break;
                    case "3": IadeEt(); break;
                    case "4":
                        if (girisYapanUye != null)
                            girisYapanUye.OduncListele();
                        else
                            Console.WriteLine("Önce giriş yapmalısınız!");
                        break;
                    case "5":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz Seçim!");
                        break;
                }
            }
        }

        private void KitaplariListele()
        {
            Console.WriteLine("\n    TÜM KİTAPLAR    ");
            foreach (var kitap in Kitaplar)
                kitap.KitapBilgi();
        }

        private void OduncAl()
        {
            if (girisYapanUye == null)
            {
                Console.WriteLine("Önce giriş yapmalısınız!");
                return;
            }

            KitaplariListele();
            Console.Write("\nÖdünç almak istediğiniz Kitap ID: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var kitap = Kitaplar.FirstOrDefault(k => k.Id == id);
                if (kitap != null)
                    girisYapanUye.KitapOduncAl(kitap);
                else
                    Console.WriteLine("Kitap bulunamadı!");
            }
        }

        private void IadeEt()
        {
            if (girisYapanUye == null)
            {
                Console.WriteLine("Önce giriş yapmalısınız!");
                return;
            }

            girisYapanUye.OduncListele();
            if (girisYapanUye.OduncAlinanKitaplar.Count == 0) return;

            Console.Write("\nİade etmek istediğiniz Kitap ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var kitap = girisYapanUye.OduncAlinanKitaplar.FirstOrDefault(k => k.Id == id);
                if (kitap != null)
                    girisYapanUye.KitapIadeEt(kitap);
                else
                    Console.WriteLine("Bu kitabı siz almadınız!");
            }
        }
    }

    // ====================== ANA PROGRAM ======================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("     KÜTÜPHANE YÖNETİM SİSTEMİ (OOP)   ");

            Kutuphane kutuphane = new Kutuphane();
            kutuphane.GirisYap();
            kutuphane.MenuGoster();
        }
    }
}