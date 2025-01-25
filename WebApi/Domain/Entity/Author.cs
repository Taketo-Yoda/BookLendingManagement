namespace WebApi.Domain.Entity;

/*
 * 著者エンティティ.
 */
public class Author
{
    public string Name { get; init; }

    public Author(string name)
    {
        if (name.Length > 50)
        {
            throw new InvalidDataException("Name is too long.");
        }
        if ("".Equals(name))
        {
            throw new InvalidDataException("Required name.");
        }
        Name = name;
    }
}