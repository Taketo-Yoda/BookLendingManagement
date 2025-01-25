using WebApi.Domain.Entity;

namespace WebApi.Test.Domain.Entity.AuthorTest;

public class Initialize
{
    [Fact]
    public void TestEmptyName()
    {
        var exception = Assert.Throws<InvalidDataException>(() => new Author(""));
        Assert.Equal("Required name.", exception.Message);
    }

    [Fact]
    public void TestLessThanLimitByName()
    {
        Author result = new Author("Author Name at 49 Length 123456789012345678901234");
        Assert.Equal("Author Name at 49 Length 123456789012345678901234", result.Name);
    }

    [Fact]
    public void TestLimitByName()
    {
        Author result = new Author("Author Name at 49 Length 1234567890123456789012345");
        Assert.Equal("Author Name at 49 Length 1234567890123456789012345", result.Name);
    }

    [Fact]
    public void TestOverLimitByName()
    {
        var exception = Assert.Throws<InvalidDataException>(() => new Author("Author Name at 49 Length 12345678901234567890123456"));
        Assert.Equal("Name is too long.", exception.Message);
    }
}