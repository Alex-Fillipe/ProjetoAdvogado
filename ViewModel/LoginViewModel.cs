using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O usuário não pode ter mais de 50 caracteres.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "A senha não pode ter mais de 50 caracteres.")]
        public string Senha { get; set; }
    }
}
