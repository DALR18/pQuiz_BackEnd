using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Business;
using Microsoft.AspNetCore.Mvc;
using Services.Business;
using Unity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/ [action]/{id?}")]
    public class CuestionarioRegistroController : CuestionarioAPIController
    {
        #region Field
        [Dependency]
        public ICuestionarioRegistroServices cuestionarioregistroServices { get; set; }
        #endregion

        public IEnumerable<CuestionarioRegistro> getAll()
        {
            try
            {
                var data = cuestionarioregistroServices.GetAll();
                return data;
            }
            catch  (System.Exception ex)
            {
                return null;
                throw;
            }  
        }

    }
}

