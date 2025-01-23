using Store.Domain.Common;

namespace Store.Domain.Entities.Users;

public sealed class Role : Entity
{
    public string Name { get; }

    public Role(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        Name = name;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != this.GetType())
        {
            return false;
        }

        var other = (Role)obj;
        return this.Id == other.Id && this.Name == other.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}
