namespace WebApi.Domain.Entity;

public class People
{
    public string FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string LastName { get; set; }

    public People(string firstName, string middleName, string lastName) : this(firstName, lastName)
    {
        if (middleName.Length > 50)
        {
            throw new InvalidDataException("Middle name is too long.");
        }
        MiddleName = middleName;
    }

    public People(string firstName, string lastName)
    {
        // TODO セッターで値を上書きする場合にもチェックする必要あり
        if (firstName.Length > 50)
        {
            throw new InvalidDataException("First name is too long.");
        }
        if (firstName.Equals(""))
        {
            throw new InvalidDataException("Required first name.");
        }
        FirstName = firstName;

        if (lastName.Length > 50)
        {
            throw new InvalidDataException("Last name is too long.");
        }
        if (lastName.Equals(""))
        {
            throw new InvalidDataException("Required last name.");
        }
        LastName = lastName;
    }

    public string GetFullName()
    {
        if (MiddleName != null && !MiddleName.Equals(""))
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }
        return FirstName + " " + LastName;
    }
}