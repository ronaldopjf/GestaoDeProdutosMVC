using Cadastro.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        public decimal Value { get; set; }

        [Display(Name = "Disponível")]
        public bool Active { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int IdClient { get; set; }

        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        [Display(Name = "Nome")]
        public string ClientName { get; set; }
    }
}
