namespace Store.Domain.Entities.Products;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Category> ChildCategories { get; set; } = null!;

    public Category()
    {
        IsActive = true;
    }
}


