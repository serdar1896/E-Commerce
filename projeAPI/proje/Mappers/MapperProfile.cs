using AutoMapper;
using proje.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static proje.Data.DatabaseContext;

namespace proje.Mappers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Urunler, Urundto>().ForMember(des => des.urunid, opt => opt.MapFrom(src => src.UrunId))
                .ForMember(des => des.markaid, opt => opt.MapFrom(src => src.MarkaId))
                .ForMember(des => des.satisfiyati, opt => opt.MapFrom(src => src.SatisFiyati))
                .ForMember(des => des.kategoriid, opt => opt.MapFrom(src => src.AltKategori.Kategoriler.KategoriId))
                .ForMember(des => des.altkategoriid, opt => opt.MapFrom(src => src.AltKategoriId))
                .ForMember(des => des.urunadi, opt => opt.MapFrom(src => src.UrunAdi))
                .ForMember(des => des.urunkodu, opt => opt.MapFrom(src => src.UrunKodu))
               /* .ForMember(des => des.urunresim, opt => opt.MapFrom(src => src.UrunResims.Select(y => y.ResimYol).ToString()))*/ ;

            //CreateMap<Urundto, Urunler>().ForMember(des => des.UrunId, opt => opt.MapFrom(src => src.urunid))
            //  .ForMember(des => des.MarkaId, opt => opt.MapFrom(src => src.markaid))
            //  .ForMember(des => des.SatisFiyati, opt => opt.MapFrom(src => src.satisfiyati))
            //  .ForMember(des => des.AltKategori.Kategoriler.KategoriId, opt => opt.MapFrom(src => src.kategoriid))
            //  .ForMember(des => des.AltKategoriId, opt => opt.MapFrom(src => src.altkategoriid))
            //  .ForMember(des => des.UrunAdi, opt => opt.MapFrom(src => src.urunadi))
            //  .ForMember(des => des.UrunKodu, opt => opt.MapFrom(src => src.urunkodu))
            //  .ForMember(des => des.UrunResims.Select(y => y.ResimYol), opt => opt.MapFrom(src => src.urunresim));



            CreateMap<Kategoriler, KategoriDto>().ForMember(des => des.kategoriid, opt =>opt.MapFrom(src => src.KategoriId))
                .ForMember(des => des.kategoriad, opt => opt.MapFrom(src => src.KategoriAd));
            CreateMap<KategoriDto, Kategoriler>().ForMember(des => des.KategoriId, opt => opt.MapFrom(src => src.kategoriid))
                .ForMember(des => des.KategoriAd, opt => opt.MapFrom(src => src.kategoriad));


            CreateMap<UyeAdres, AdresDto>().ForMember(des => des.adresId, opt => opt.MapFrom(src => src.AdresId))
                .ForMember(des => des.adresTanim, opt => opt.MapFrom(src => src.AdresTanim))
                .ForMember(des => des.adresTuru, opt => opt.MapFrom(src => src.AdresTuru))
                .ForMember(des => des.ilceId, opt => opt.MapFrom(src => src.IlceId))
                .ForMember(des => des.ilId, opt => opt.MapFrom(src => src.Ilce.Il.Id))
                .ForMember(des => des.ulkeId, opt => opt.MapFrom(src => src.Ilce.Il.Ulke.Id))
                .ForMember(des => des.uyeId, opt => opt.MapFrom(src => src.UyeId));
            //CreateMap<AdresDto, UyeAdres>().ForMember(des => des.AdresId, opt => opt.MapFrom(src => src.adresId))
            //    .ForMember(des => des.AdresTanim, opt => opt.MapFrom(src => src.adresTanim))
            //    .ForMember(des => des.AdresTuru, opt => opt.MapFrom(src => src.adresTuru))
            //    .ForMember(des => des.IlceId, opt => opt.MapFrom(src => src.ilceId))
            //    .ForMember(des => des.Ilce.Il.Id, opt => opt.MapFrom(src => src.ilId))
            //    .ForMember(des => des.Ilce.Il.Ulke.Id, opt => opt.MapFrom(src => src.ulkeId))
            //    .ForMember(des => des.UyeId, opt => opt.MapFrom(src => src.uyeId));
        }

    }
}
