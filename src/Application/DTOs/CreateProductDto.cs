namespace Application.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
