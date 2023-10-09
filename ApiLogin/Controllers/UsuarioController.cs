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

            var usuarioExistente = _context.usuarios.Where(u => u.email == novoUsuario.email).FirstOrDefault();

            if (usuarioExistente != null)
            {
                return BadRequest("Usuário já existe!!");
            }

            novoUsuario.HashPassword();
            _context.usuarios.Add(novoUsuario);
            _context.SaveChanges();
        
            _usuarios.Add(novoUsuario);

            return CreatedAtAction(nameof(GetUser), new { email = novoUsuario.email }, novoUsuario);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> GetUser()
        {
            var usuarios = _context.usuarios.ToList();

            if (usuarios.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(usuarios);
            }
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] UsuarioModel request)
        {
            var usuarios = _context.usuarios.FirstOrDefault(u => u.email == request.email);

            if (usuarios == null)
            {
                return NotFound("Usario não encontrado");
            }

            if (BCrypt.Net.BCrypt.Verify(request.senha, usuarios.senha))
            {
                return Ok("Usuario autenticado com sucesso");
            }

            return Unauthorized("Senha incorreta");
        }
    }
}