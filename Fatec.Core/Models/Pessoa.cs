using System.ComponentModel.DataAnnotations;

namespace Fatec.Models
{
    public class Pessoa : Base
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Telefone { get; set; }
    }
}
