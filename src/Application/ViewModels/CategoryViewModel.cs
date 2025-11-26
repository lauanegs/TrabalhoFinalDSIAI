using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(80, ErrorMessage = "O nome pode ter no máximo 80 caracteres.")]
        public string Name { get; set; } = null!;
    }
}
