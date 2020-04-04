using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proje.DTOs;
using static proje.Data.DatabaseContext;
using static proje.Repository.BusinessRepository;

namespace proje.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        RepKategori _repKategori;
        IMapper _mapper;
        public KategoriController(RepKategori repKategori, IMapper mapper)
        {
            _mapper = mapper;
            _repKategori = repKategori;
        }
        [HttpGet("GetCategory")]
        public ICollection<KategoriDto> GetCategory()
        {
            return _repKategori.Doldur();

        }
        [HttpGet("GetCategory/{id}")]
        public async Task<Kategoriler> GetCategory(int id)
        {
            return await _repKategori.Find(id);
        }
        [HttpPut("UpdateCategory")]

        public async Task<KategoriDto> UpdateCategory([FromBody] KategoriDto kategoriDto)
        {
            Kategoriler secUrun = await _repKategori.Find(kategoriDto.kategoriid);

            secUrun = _mapper.Map(kategoriDto, secUrun);
            _repKategori.Update(secUrun);
            await _repKategori.Commit();
            return kategoriDto;

        }
        [HttpPost("EntryCategory")]

        public async Task<KategoriDto> EntryCategory([FromBody] KategoriDto kategoriDto)
        {

            Kategoriler yeniKategori = new Kategoriler();

            yeniKategori = _mapper.Map(kategoriDto, yeniKategori);
            yeniKategori.KategoriId = 0;
            _repKategori.Entry(yeniKategori);
            await _repKategori.Commit();
            return kategoriDto;

        }
        [HttpDelete("DeleteCategory/{id}")]

        public async Task<Kategoriler> DeleteCategory(int id)
        {
            Kategoriler silinenUrun = await _repKategori.Find(id);
            _repKategori.Delete(silinenUrun);
            await _repKategori.Commit();
            return silinenUrun;

        }
    }
}