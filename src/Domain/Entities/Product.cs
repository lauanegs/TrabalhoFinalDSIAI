using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(120)]
        public string Name { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}