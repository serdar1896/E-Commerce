using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proje.DTOs
{
    public class AdresDto
    {
        public int adresId { get; set; }
        public int uyeId { get; set; }
        public int ilceId { get; set; }
        public int ilId { get; set; }
        public int ulkeId { get; set; }
        public string adresTanim { get; set; }    
        public string adresTuru { get; set; }
    }
}
