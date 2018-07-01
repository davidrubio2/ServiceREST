using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicioREST.Models;

namespace ServicioREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        DataAccessEmisor objEmisor = new DataAccessEmisor();

         [HttpPost]
        public String Post(Emisor emisor)
        {
           String sRespuesta;
           sRespuesta  = objEmisor.AddEmisor(emisor);
           if(sRespuesta == "1")
           {
                 sRespuesta  = objEmisor.GetEmisor(emisor);
           }
            return sRespuesta;
        }
    }
}
