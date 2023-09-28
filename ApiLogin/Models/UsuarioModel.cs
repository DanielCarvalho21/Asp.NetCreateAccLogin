using ApiLogin.Controllers;
using System.ComponentModel.DataAnnotations;

namespace ApiLogin.Models
{
    public class UsuarioModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Senha { get; set; }
        
    }
}
