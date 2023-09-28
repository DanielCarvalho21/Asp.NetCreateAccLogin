using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ApiLogin.Models;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario : ControllerBase
    {

        private List<UsuarioModel> _usuarios = new List<UsuarioModel>();
        [HttpPost("Adicionar")]

        public ActionResult AdicionarUsuario([FromBody] UsuarioModel novoUsuario)
        {
            if(novoUsuario == null)
            {
                return BadRequest("Dados Invalidos!!");
            }

            _usuarios.Add(novoUsuario);

            return CreatedAtAction(nameof(Get), new { email = novoUsuario.Email }, novoUsuario);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
