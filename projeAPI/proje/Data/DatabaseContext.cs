using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proje.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.Entity<SiparisDetay>().HasKey(table => new {
                table.SiparisId,
                table.UrunId
            });
        }

        DbSet<Uyeler> uyeler { get; set; }  
        DbSet<Kategoriler> kategoriler { get; set; }       
        DbSet<Il> il { get; set; }
        DbSet<Ilce> ilce { get; set; }
        DbSet<Ulke> ulke { get; set; }       
        DbSet<UyeAdres> uyeAdress { get; set; }
        DbSet<Role> role { get; set; }
        DbSet<Stok> stok { get; set; }
        DbSet<UrunResim> urunResim { get; set; }       
        DbSet<SiparisDetay> siparisdetay { get; set; }
        DbSet<SiparisMaster> siparismaster { get; set; }
        DbSet<Urunler> urunler { get; set; }
        DbSet<UrunYorum> urunyorum { get; set; }  
        DbSet<Marka> marka { get; set; }
        DbSet<AltKategori> altKategori { get; set; }
        DbSet<Kargo> kargo { get; set; }

        public class Urunler
        {   [Key]
            public int UrunId { get; set; }
            public string UrunKodu { get; set; }
            public string UrunAdi { get; set; }
            public float AlisFiyati { get; set; }
            public float SatisFiyati { get; set; }
            public string UrunAciklama { get; set; }
            public DateTime UrunTarih { get; set; }
            public bool UrunDurum { get; set; }
            public int MarkaId { get; set; }
            public int AltKategoriId { get; set; }       
            public int Kampanyaid { get; set; }

            [ForeignKey("MarkaId")]
            public Marka Marka { get; set; }  
            [ForeignKey("AltKategoriId")]
            public AltKategori AltKategori { get; set; }

            public ICollection<UrunResim> UrunResims { get; set; }           
            public ICollection<Stok> Stoks { get; set; }  
            public ICollection<UrunYorum> UrunYorums { get; set; }
            public ICollection<SiparisDetay> SiparisDetays { get; set; }
        }
        public class Kategoriler
        {
            [Key]
            public int KategoriId { get; set; }
             public string KategoriAd { get; set; } 
            public DateTime KategoriTarih { get; set; }
            public ICollection<AltKategori> AltKategoris { get; set; }

        }
        public class AltKategori
        {
            [Key]
            public int AltKategoriId { get; set; }
            public int KategoriId { get; set; }
            public string AltKategoriAd { get; set; }
            public DateTime AltKategoriTarih { get; set; }

            [ForeignKey("KategoriId")]
            public Kategoriler Kategoriler { get; set; }
            public ICollection<Urunler> Urunler { get; set; }
        }
        public class UrunResim
        {
            [Key]
            public int ResimId { get; set; }
            public int UrunId { get; set; }
            public string ResimYol { get; set; }
  
            [ForeignKey("UrunId")]
            public Urunler Urunler { get; set; }
            
        }
        public class Stok
        {
            [Key]
            public int StokId { get; set; }
            public int UrunId { get; set; }
            public string UrunAdet { get; set; }
            public string DepoAdres { get; set; }
            public int Tip { get; set; }
            public DateTime Giris { get; set; }
            public DateTime Cikis { get; set; }
            [ForeignKey("UrunId")]
            public Urunler Urunler { get; set; }
        }
        public class UrunYorum
        {
            [Key]
            public int YorumId { get; set; }
            public int UrunId { get; set; }
            public int UyeId { get; set; }
            public string Yorum { get; set; }
            public bool YorumDurum { get; set; }
            public DateTime YorumTarih { get; set; }

            [ForeignKey("UrunId")]
            public Urunler Urunler { get; set; }
            [ForeignKey("UyeId")]
            public Uyeler Uyeler { get; set; }

        }
        public class Uyeler
        {
            [Key]
            public int UyeId { get; set; }
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Mail { get; set; }
            public string Sifre { get; set; }
            public string Tel { get; set; }
            public string TcNo { get; set; }
            public DateTime KayitTarihi { get; set; }
            public int RoleId { get; set; }
            public bool UyeDurum { get; set; }

            [ForeignKey("RoleId")]
            public Role Role { get; set; }
            public ICollection<UyeAdres> UyeAdress { get; set; }
            public ICollection<UrunYorum> UrunYorums { get; set; }
        }
        public class UyeAdres
        {
            [Key]
            public int AdresId { get; set; }
            public int UyeId { get; set; }
            public int IlceId { get; set; }
            public string AdresTanim { get; set; }
            public string PostaKodu { get; set; }
            public string AdresTuru { get; set; }

            [ForeignKey("IlceId")]
            public Ilce Ilce { get; set; }
            [ForeignKey("UyeId")]
            public Uyeler Uyeler { get; set; }
            public ICollection<Kargo> Kargos { get; set; }
        }
        public class Ilce
        {
            [Key]
            public int IlceId { get; set; }
            public string Ad { get; set; }
            public int Ilid { get; set; }
            [ForeignKey("Ilid")]
            public Il Il { get; set; }
            public ICollection<UyeAdres> UyeAdress { get; set; }
        }
        public class Il
        {           
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }
            public int Ulkeid { get; set; }
            [ForeignKey("Ulkeid")]
            public Ulke Ulke { get; set; }
            public ICollection<Ilce> Ilces { get; set; }
        }
        public class Ulke
        {
            [Key]
            public int Id { get; set; }
            public string Ad { get; set; }
            public ICollection<Il> Ils { get; set; }
        }
        public class Role
        {
            [Key]
            public int RoleId { get; set; }
            public string RoleAd { get; set; }
            public ICollection<Uyeler> Uyelers { get; set; }
        }
        public class Kargo
        {
            [Key]
            public int KargoId { get; set; }
            public string SirketAdi { get; set; }
            public string Telefon { get; set; }
            public int AdresId { get; set; }
            [ForeignKey("AdresId")]
            public UyeAdres UyeAdres { get; set; }
            public ICollection<SiparisMaster> SiparisMasters { get; set; }
        }
        public class SiparisMaster
        {
            [Key]
            public int SiparisId { get; set; }
            public DateTime SiparisTarih { get; set; }
            public float ToplamFiyat { get; set; }
            public bool SepetteMi { get; set; }
            public bool SiparisDurum { get; set; }
            public int KargoId { get; set; }
            [ForeignKey("KargoId")]
            //Kargo.adres.adresid oIarak cekiceksin ve uye ID
            public Kargo Kargo { get; set; }
            [ForeignKey("UyeId")]
            public Uyeler Uyeler { get; set; }
            public ICollection<SiparisDetay> SiparisDetays { get; set; }
        }
        public class SiparisDetay
        {
            [Key]        
            public int SiparisId { get; set; }
            [Key]
            public int UrunId { get; set; }
            public int Miktar { get; set; }            
            public float BirimFiyat { get; set; }
            public float Indirim { get; set; }
            public DateTime TeslimTarihi { get; set; }
            public int OdemeSecenekId { get; set; }

            [ForeignKey("SiparisId")]
            public SiparisMaster Siparisler { get; set; }
            [ForeignKey("UrunId")]
            public Urunler Urunler { get; set; }
        }           
        public class Marka
        {
            [Key]
            public int MarkaId { get; set; }
            public string MarkaAdi { get; set; }
            public string Aciklama { get; set; }
            public string ResimYol { get; set; }    
            public ICollection<Urunler> Urunler { get; set; }
           
        }

    }
}
