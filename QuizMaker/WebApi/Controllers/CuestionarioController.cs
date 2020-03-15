using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Dominio.Business;
using Microsoft.AspNetCore.Http;
using Unity;
using System.Net.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class CuestionarioController : CuestionarioAPIController
    {

        #region
        [Dependency]
        public ICuestionarioServices CuestionarioService { get; set; }
        #endregion

        public CuestionarioController(ICuestionarioServices _baseService)
        { this.CuestionarioService = _baseService; }


        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = CuestionarioService.GetAll();
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
                var data = CuestionarioService.GetbyId(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error Server");
            }
        }

        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Cuestionario b)
        {
            try
            {
                var exist = CuestionarioService.Exist(b.Nombe);

                if (exist) return BadRequest("Base ya existe");
                var data = CuestionarioService.Save(b);
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

        public ActionResult update([FromBody] Cuestionario b)
        {
            try
            {
                var exist = CuestionarioService.GetbyId(b.Id);
                if (exist == null) return BadRequest("No de encontro el resgistro a actualizar");

                var data = CuestionarioService.Update(b);
                return Ok(data);
            }
            catch (Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error Server");

            }
        }
    }
}
