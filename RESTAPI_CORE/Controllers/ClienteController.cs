using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

using RESTAPI_CORE.Modelos;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using RESTAPI_CORE.servicios;

namespace RESTAPI_CORE.Controllers
{
    public class ClienteController : ControllerBase
    {
        private readonly string cadenaSQL;
        public ClienteController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }
        [HttpGet]
        [Route("Lista2")]
        public IActionResult Lista()
        {
            
            return StatusCode(StatusCodes.Status200OK, JsonConvert.SerializeObject(Service.Listar(cadenaSQL)));
        }


    }
}
