using EgitimSistemi.BusinessLayer.Abstract;
using EgitimSistemi.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgitimSistemi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrenciController : ControllerBase
    {
        private readonly IOgrenciService _ogrenciService;

        public OgrenciController(IOgrenciService ogrenciService)
        {
            _ogrenciService = ogrenciService;
        }

        [HttpGet]
        public ActionResult OgrenciList()
        {
            var values = _ogrenciService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public ActionResult OgrenciAdd(Ogrenci ogrenci)
        {
            _ogrenciService.TInsert(ogrenci);

            return Ok();
        }
        [HttpDelete]
        public ActionResult OgrenciDelete(Ogrenci ogrenci)
        {
            _ogrenciService.TDelete(ogrenci);
            return Ok();
        }
        [HttpPut]
        public ActionResult OgrenciUpdate(Ogrenci ogrenci)
        {
            _ogrenciService.TUpdate(ogrenci);

            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult OgrenciGetID(int id)
        {
            var values = _ogrenciService.TGetByID(id);
            return Ok(values);
        }
      
    }
}
