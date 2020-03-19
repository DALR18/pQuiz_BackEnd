using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unity;
using Microsoft.AspNetCore.Http;
using Domain.Bussines;
using Services.Bussines;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class TipoUsuarioController : TipoUsuarioAPIController
    {
        #region Field
        [Dependency]
        public ITipoUsuarioServices tipoUsuarioServices { get; set; }
        #endregion

        public TipoUsuarioController(ITipoUsuarioServices _tipoUsuarioServices)
        {
            this.tipoUsuarioServices = _tipoUsuarioServices;
        }


        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = tipoUsuarioServices.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpGet]
        [ActionName("getbyid")]
        public ActionResult getbyid([FromQuery] int id)
        {
            try
            {
                var data = tipoUsuarioServices.GetbyId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] TipoUsuario tu)
        {
            try
            {
                var exist = tipoUsuarioServices.Exist(tu.Descriptor);

                if (exist) return BadRequest("Tipo de Usuario ya existe");

                var data = tipoUsuarioServices.save(tu);

                if (data) return Created("", data);
                else return Ok(data);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

            return BadRequest();
        }


        [HttpPost]
        [ActionName("update")]
        public ActionResult update([FromBody] TipoUsuario tu)
        {
            try
            {
                var exist = tipoUsuarioServices.GetbyId(tu.Id);

                if (exist == null) return BadRequest("No se encontro el registro a actualizar");

                var data = tipoUsuarioServices.Update(tu);

                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}
