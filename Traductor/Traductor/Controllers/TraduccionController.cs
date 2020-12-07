using System;

using System.Web.Http;
using System.Web.Http.Cors;
using Traductor.Datos;
using Traductor.Models;

namespace Traductor.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TraduccionController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Obtener(String FraseEspanol, String Idioma, int Tipo)
        {
            Frase f = new Frase(FraseEspanol, Idioma);
            switch (Tipo)
            {
                case 1:
                    f.Traduccion = Traduccion.Traducir(f);
                    return Ok(f);
                case 2:
                    byte[] bAudio = Traduccion.ObtenerAudio(f);
                    return Ok(bAudio);
                default:
                    return BadRequest("Debe enviar un tipo de consulta válido");
            }
        }


    }
}
