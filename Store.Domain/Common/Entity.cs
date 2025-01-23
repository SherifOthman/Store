namespace Store.Domain.Common;
public abstract class Entity
{
    public Guid Id { get; private set; }
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Entity(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException(message: "Id must be a valid GUID", nameof(id));

        Id = id;
    }


}
