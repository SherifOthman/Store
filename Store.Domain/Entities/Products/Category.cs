using Store.Domain.Common;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Store.Domain.Entities.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
    public Guid? RootCategoryId { get; set; }

    public HashSet<Category> _subCategories;
    public IReadOnlyCollection<Category> SubCategories => _subCategories;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Category()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        _subCategories = new HashSet<Category>();
    }


    public static Category Create(string name, Guid? RootCategoryId = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (RootCategoryId != null && RootCategoryId == Guid.Empty)
            throw new ArgumentException("Parent category Id should be either null or a valid Id");

        return new Category
        {
            Name = name,
            RootCategoryId = RootCategoryId,
            IsActive = true,
        };

    }

    public void AddChild(Category category)
    {
        category.RootCategoryId = this.Id;
        _subCategories.Add(category);
    }

    public void RemoveChild(Category category)
    {
        _subCategories.Remove(category);
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void UpdateName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }


    // Override
    public override bool Equals(object? obj)
    {
        var other = obj as Category;
        if (other is null)
            return false;

        return (other.Id == this.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.Name, IsActive);
    }

}


