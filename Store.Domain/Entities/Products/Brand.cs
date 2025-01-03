namespace Store.Domain.Entities.Products;

public class Brand
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? LogoPath { get; set; }
}


