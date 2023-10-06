using ApiLogin.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}
