using Microsoft.AspNetCore.Components.Web;
using WebApi.Domain.Value;

namespace WebApi.Domain.Entity;

/*
 * 書籍在庫エンティティ.
 */
public class BookStock
{
    public Book Book { get; init; }

    private UnitOfAmount _stock;
    public UnitOfAmount Stock
    {
        get { return _stock; }
    }


    public BookStock(Book book, UnitOfAmount stock)
    {
        Book = book;
        _stock = stock;
    }

    public void AddStock()
    {
        _stock = _stock.Add(1);
    }

    public void MinusStock()
    {
        if (_stock <= 0)
        {
            throw new InvalidDataException("Not exists stock.");
        }
        _stock = _stock.Minus(1);
    }
}