using WebApi.Domain.Entity;
using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Entity.BookTest;

public class Initialize
{
    private List<Author> authors = new (){new Author("author name")};

    private Isbn10 isbn10 = new Isbn10("ISBN123456");

    [Fact]
    public void TestEmptyTitle()
    {
        var exception = Assert.Throws<InvalidDataException>(() => new Book("", "sub-title", isbn10, authors));
        Assert.Equal("Title is required.", exception.Message);
    }

    [Fact]
    public void TestLessThanLimitByTitle()
    {
        string title = "Title at 99 Length 12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        string subtitle = "sub-title";
        Book result = new Book(title, subtitle, isbn10, authors);
        Assert.Equal(title, result.Title);
        Assert.Equal(subtitle, result.Subtitle);
        Assert.Equal(isbn10, result.Isbn10);
        Assert.Single(result.Authors);
        Assert.Equal(authors[0], result.Authors[0]);
    }

    [Fact]
    public void TestLimitByTitle()
    {
        string title = "Title at 100 Length 12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        string subtitle = "sub-title";
        Book result = new Book(title, subtitle, isbn10, authors);
        Assert.Equal(title, result.Title);
    }

    [Fact]
    public void TestOverLimitByTitle()
    {
        string title = "Title at 101 Length 12345678901234567890123456789012345678901234567890123456789012345678901234567890X";
        string subtitle = "sub-title";
        var exception = Assert.Throws<InvalidDataException>(() => new Book(title, subtitle, isbn10, authors));
        Assert.Equal("Title is too long.", exception.Message);
    }

    [Fact]
    public void TestNullSubtitle()
    {
        Book result = new Book("title", null, isbn10, authors);
        Assert.Equal("title", result.Title);
        Assert.Null(result.Subtitle);
        Assert.Equal(isbn10, result.Isbn10);
        Assert.Single(result.Authors);
        Assert.Equal(authors[0], result.Authors[0]);
    }

    [Fact]
    public void TestEmptySubtitle()
    {
        Book result = new Book("title", "", isbn10, authors);
        Assert.Equal("", result.Subtitle);
    }

    [Fact]
    public void TestLessThanLimitBySubtitle()
    {
        string subtitle = "Title at 99 Length 12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        Book result = new Book("title", subtitle, isbn10, authors);
        Assert.Equal(subtitle, result.Subtitle);
    }

    [Fact]
    public void TestLimitBySubtitle()
    {
        string subtitle = "Title at 100 Length 12345678901234567890123456789012345678901234567890123456789012345678901234567890";
        Book result = new Book("title", subtitle, isbn10, authors);
        Assert.Equal(subtitle, result.Subtitle);
    }

    [Fact]
    public void TestOverLimitBySubtitle()
    {
        string subtitle = "Title at 101 Length 12345678901234567890123456789012345678901234567890123456789012345678901234567890X";
        var exception = Assert.Throws<InvalidDataException>(() => new Book("title", subtitle, isbn10, authors));
        Assert.Equal("Subtitle is too long.", exception.Message);
    }
}