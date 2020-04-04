﻿using proje.Data;
using proje.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static proje.Data.DatabaseContext;

namespace proje.Repository
{
    public class BusinessRepository
    {
        public class RepUrun : BaseRepository<Urunler>
        {
            public RepUrun(DatabaseContext db) : base(db)
            {

            }
            public ICollection<Urundto> Doldur()
            {
                return Set().Select(x => new Urundto
                {
                     urunid= x.UrunId,
                     markaid = x.MarkaId,
                    kategoriid = x.AltKategori.Kategoriler.KategoriId,
                    altkategoriid = x.AltKategoriId,
                     urunkodu = x.UrunKodu,
                     urunadi = x.UrunAdi,
                     satisfiyati = x.SatisFiyati,
                    // Composit key olan tablodan cekmek ıcın
                    //klist = (ICollection<UrunKategori>)x.urunKategoris.Select(y => y.kategoriler.KategoriAd).ToList(),
                    urunresim = x.UrunResims.Select(y=> y.ResimYol).ToList()
                }).ToList();
            }

        }
        public class RepKategori : BaseRepository<Kategoriler>
        {
            public RepKategori(DatabaseContext db) : base(db)
            {
            }
            public ICollection<KategoriDto> Doldur()
            {
                return Set().Select(x => new KategoriDto
                {
                    kategoriid = x.KategoriId,
                    kategoriad = x.KategoriAd
               
                }).ToList();
            }
        }
      
    }
    }

