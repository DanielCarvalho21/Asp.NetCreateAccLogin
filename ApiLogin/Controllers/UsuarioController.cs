using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ApiLogin.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace ApiLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuario : ControllerBase
    {

        private readonly ApiLoginDbContext _context;

        public Usuario(ApiLoginDbContext context)
        {
            _context = context;
        }

        private List<UsuarioModel> _usuarios = new List<UsuarioModel>();

        [HttpPost("Adicionar")]
        public ActionResult AdicionarUsuario(UsuarioModel novoUsuario)
        {
            if (novoUsuario == null)
            {
                return BadRequest("Dados Invalidos!!");
            }
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            Console.WriteLine(_usuarios.Count());
            _usuarios.Add(novoUsuario);
            Console.WriteLine(_usuarios.Count());

            return CreatedAtAction(nameof(GetUser), new { email = novoUsuario.Email }, novoUsuario);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> GetUser()
        {
            var usuarios = _context.Usuarios.ToList();

            if (usuarios.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(usuarios);
            }
        }
    }
}