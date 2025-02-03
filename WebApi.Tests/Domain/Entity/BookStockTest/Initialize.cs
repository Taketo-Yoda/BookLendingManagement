using WebApi.Domain.Entity;
using WebApi.Domain.Value;

namespace WebApi.Test.Domain.Entity.BookStockTest;

public class Initialize
{

    [Fact]
    public void TestInitialize()
    {
        List<Author> authors = new (){new Author("author name")};
        Book book = new("Title", "Sub-Title", new Isbn10("ISBN123456"), authors);
        UnitOfAmount uom = new(10);
        BookStock result = new(book, uom);

        Assert.Equal("Title", result.Book.Title);
        Assert.Equal("Sub-Title", result.Book.Subtitle);
        Assert.Equal("ISBN123456", result.Book.Isbn10.Value);
        Assert.Equal(10, result.Stock.Value);
    }

}