using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required, StringLength(120)]
        public string Name { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}