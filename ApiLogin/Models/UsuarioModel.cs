using ApiLogin.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;
using Microsoft.OpenApi.Validations;

namespace ApiLogin.Models
{
    [Table("usuarios")]
    public class UsuarioModel
    {
        [Key]

        [Required(ErrorMessage = "O campo Email é obrigatório!")]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(8)]
        public string senha { get; set; }

        public UsuarioModel() { }

        public UsuarioModel(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }

        public void HashPassword()
        {
            this.senha = BCrypt.Net.BCrypt.HashPassword(this.senha, BCrypt.Net.BCrypt.GenerateSalt(10));
        }
    }
}
