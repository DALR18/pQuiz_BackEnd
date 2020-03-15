using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Unity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
   
    public class RespuestaController : RespuestaAPIController
    {



        #region
        [Dependency]
        public IRespuestaServices RespuestaService { get; set; }
        #endregion

        public RespuestaController(IRespuestaServices _baseService)
        { this.RespuestaService = _baseService; }


        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = RespuestaService.GetAll();
                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error Server");

            }
        }


        [HttpGet]
        [ActionName("getbyid")]
        public ActionResult getbyid([FromQuery] int id)
        {
            try
            {
                var data = RespuestaService.GetbyId(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error Server");
            }
        }

        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Respuesta b)
        {
            try
            {
                var exist = RespuestaService.Exist(b.Texto);

                if (exist) return BadRequest("Base ya existe");
                var data = RespuestaService.Save(b);
                if (data) return Created("", data);
                else return Ok(data);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error Server");
            }

            return BadRequest();
        }



        [HttpPost]
        [ActionName("update")]

        public ActionResult update([FromBody] Respuesta b)
        {
            try
            {
                var exist = RespuestaService.GetbyId(b.Id);
                if (exist == null) return BadRequest("No de encontro el resgistro a actualizar");

                var data = RespuestaService.Update(b);
                return Ok(data);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error Server");

            }
        }
    }
}
