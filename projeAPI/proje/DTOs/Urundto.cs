using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static proje.Data.DatabaseContext;

namespace proje.DTOs
{
    public class Urundto    {

        public int urunid { get; set; }
        public int kategoriid { get; set; }
        public int altkategoriid { get; set; }
        public int markaid { get; set; }
        public string urunadi { get; set; }
        public float satisfiyati { get; set; }
        public string urunkodu { get; set; }
        //public string urunresim { get; set; }
        public ICollection<string> urunresim { get; set; }
    }
    
}
