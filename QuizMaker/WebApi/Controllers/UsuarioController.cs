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
    public class UsuarioController : TipoUsuarioAPIController
    {
        #region Field
        [Dependency]
        public IUsuarioServices usuarioServices { get; set; }
        #endregion
        public UsuarioController(IUsuarioServices _usuarioServices)
        {
            this.usuarioServices = _usuarioServices;
        }

        [HttpGet]
        [ActionName("getAll")]
        public IActionResult getAll()
        {
            try
            {
                var data = usuarioServices.GetAll();
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
                var data = usuarioServices.GetbyId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }
        }


        [HttpPost]
        [ActionName("save")]
        public ActionResult save([FromBody] Usuario u)
        {
            try
            {
                var exist = usuarioServices.Exist(u.Nombre);

                if (exist) return BadRequest("Usuario ya existe");

                var data = usuarioServices.save(u);

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
        public ActionResult update([FromBody] Usuario u)
        {
            try
            {
                var exist = usuarioServices.GetbyId(u.Id);

                if (exist == null) return BadRequest("No se encontro el registro a actualizar");

                var data = usuarioServices.Update(u);

                return Ok(data);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
            }

        }
    }
}
