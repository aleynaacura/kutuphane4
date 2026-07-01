#  Kütüphane Yönetim Sistemi (OOP)

Bu proje, Mersin Üniversitesi Yönetim Bilişim Sistemleri bölümünde aldığım **Nesne Tabanlı Programlama** dersi kapsamında geliştirilmiştir.

C# ve Nesne Tabanlı Programlama (OOP) prensipleri kullanılarak oluşturulan bu konsol uygulaması, temel bir kütüphane otomasyon sistemini simüle etmektedir.

---

##  Projenin Amacı

Kullanıcıların sisteme giriş yaparak kitapları görüntüleyebilmesi, kitap ödünç alabilmesi ve iade edebilmesini sağlayan basit bir kütüphane yönetim sistemi geliştirmek.

Bu proje ile;

- Nesne Tabanlı Programlama (OOP)
- C# programlama dili
- Sınıf yapıları
- Koleksiyonlar (List)
- Menü tabanlı konsol uygulamaları

konularında uygulamalı deneyim kazanılmıştır.

---

##  Kullanılan Teknolojiler

- C#
- .NET Console Application
- Visual Studio
- Object Oriented Programming (OOP)

---

## Proje Özellikleri

-  Üye oluşturma ve giriş işlemi
-  Kitapları listeleme
-  Kitap ödünç alma
-  Kitap iade etme
-  Ödünç alınan kitapları görüntüleme
-  Kitap müsaitlik durumu kontrolü
-  Giriş bilgilerinin doğrulanması

---

## Kullanılan OOP Prensipleri

###  Abstraction (Soyutlama)

- `abstract Kitap` sınıfı kullanıldı.
- Ortak özellikler tek sınıfta toplandı.

###  Inheritance (Kalıtım)

- `Roman`
- `TarihKitabi`
- `SiirKitabi`

sınıfları `Kitap` sınıfından türetildi.

### Polymorphism (Çok Biçimlilik)

Her kitap türü kendi `KitapBilgi()` metodunu `override` ederek farklı davranış sergilemektedir.

### Encapsulation (Kapsülleme)

Sınıf özelliklerinde `private set` kullanılarak verilerin kontrollü şekilde değiştirilmesi sağlandı.

---

##  Proje Yapısı

```text
KutuphaneYonetimSistemi
│
├── Kitap (Abstract)
│ ├── Roman
│ ├── TarihKitabi
│ └── SiirKitabi
│
├── Uye
├── Kutuphane
└── Program
```

---

##  Program Akışı

1. Üye sisteme giriş yapar.
2. Ana menü görüntülenir.
3. Kitaplar listelenir.
4. Kullanıcı kitap seçer.
5. Kitap ödünç alınır veya iade edilir.
6. Kullanıcının ödünç aldığı kitaplar görüntülenebilir.

---

## Öğrenim Kazanımları

Bu proje sayesinde;

- Nesne Tabanlı Programlama mantığını uygulamalı olarak öğrendim.
- Kalıtım, kapsülleme, soyutlama ve çok biçimlilik kavramlarını gerçek bir proje üzerinde kullandım.
- C# dilinde koleksiyonlar, sınıflar ve metotlar üzerinde çalışma deneyimi kazandım.
- Konsol tabanlı bir otomasyon sistemi geliştirerek problem çözme becerilerimi geliştirdim.

---

## Geliştirici

**Aleyna Cura**

Mersin Üniversitesi

Yönetim Bilişim Sistemleri (3. Sınıf)

---

Bu projeyi inceleyebilir, geri bildirimlerinizi paylaşabilirsiniz.
