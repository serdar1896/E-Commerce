using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using proje.DTOs;
using static proje.Data.DatabaseContext;
using static proje.Repository.BusinessRepository;

namespace proje.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
    
        RepUrun _repUrun;
        IMapper _mapper;
        public UrunController(RepUrun repUrun, IMapper mapper)
        {
            _mapper = mapper;
            _repUrun = repUrun;
        }
        [HttpGet("GetUrunler")]
        public ICollection<Urundto> GetUrunler()
        {
            return _repUrun.Doldur();

        }
        [HttpGet("GetUrunler/{id}")]
        public async Task<Urunler> GetUrun(int id)
        {
            return await _repUrun.Find(id);
        }
        [HttpPut("UpdateUrun")]

        public async Task<Urundto> UpdateUrun([FromBody] Urundto urunDTO)
        {
            Urunler secUrun = await _repUrun.Find(urunDTO.urunid);

            secUrun = _mapper.Map(urunDTO, secUrun);
            _repUrun.Update(secUrun);
            await _repUrun.Commit();
            return urunDTO;

        }
        [HttpPost("EntryUrun")]

        public async Task<Urundto> EntryUrun([FromBody] Urundto urunDTO)
        {

            Urunler yeniUrun = new Urunler();

            yeniUrun = _mapper.Map(urunDTO, yeniUrun);
            yeniUrun.UrunId = 0;
            _repUrun.Entry(yeniUrun);
            await _repUrun.Commit();
            return urunDTO;

        }
        [HttpDelete("DeleteUrun/{id}")]

        public async Task<Urunler> DeleteUrun(int id)
        {
            Urunler silinenUrun = await _repUrun.Find(id);
            _repUrun.Delete(silinenUrun);
            await _repUrun.Commit();
            return silinenUrun;

        }
    }
}