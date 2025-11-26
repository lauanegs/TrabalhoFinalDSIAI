using System;
using System.ComponentModel.DataAnnotations;
using Application.Common.Validations;

namespace Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(120, ErrorMessage = "O nome deve ter no máximo 120 caracteres.")]
        [NameCannotContainNumbers]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        public int Quantity { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [PriceGreaterThanZero]
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new();

    }
}
