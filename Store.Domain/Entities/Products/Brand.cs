using Store.Domain.Common;

namespace Store.Domain.Entities.Products;

public class Brand : Entity
{
    public string Name { get; private set; }
    public string? LogoPath { get; private set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Brand()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {

    }

    public Brand(string name, string? logoPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name);
        Name = name;
        LogoPath = LogoPath;
    }

    public void UpdateLogo(string logoPath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(logoPath);
        LogoPath = logoPath;
    }

}



