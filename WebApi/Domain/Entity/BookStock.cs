using Microsoft.AspNetCore.Components.Web;
using WebApi.Domain.Value;

namespace WebApi.Domain.Entity;

/*
 * 書籍在庫エンティティ.
 */
public class BookStock
{
    public Book Book { get; init; }

    public UnitOfAmount Stock { get; init; }

    public BookStock(Book book, UnitOfAmount stock)
    {
        Book = book;
        Stock = stock;
    }
}