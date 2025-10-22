using Dominio.Enums;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AdvogadoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senioridade é obrigatória")]
        public SenioridadeEnum Senioridade { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public EstadoEnum Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 00000-000")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Digite um número válido")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O Complemento é obrigatório")]
        public string Complemento { get; set; }
    }
}
