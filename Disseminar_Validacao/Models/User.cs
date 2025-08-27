using System.ComponentModel.DataAnnotations;

namespace Disseminar_Validacao.Models
{
    public class User
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres.")]
        public string Nome { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "O e-mail fornecido não é válido.")]
        public string Email { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 digitos.")]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha", ErrorMessage = "As senhas devem ser iguais.")]
        public string ConfirmarSenha { get; set; }
    }
}
