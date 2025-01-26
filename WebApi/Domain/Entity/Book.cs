using Microsoft.AspNetCore.Components.Web;
using WebApi.Domain.Value;

namespace WebApi.Domain.Entity;

/*
 * 書籍エンティティ.
 */
public class Book
{
    public string Title { get; init; }

    public string? Subtitle { get; init; }

    public Isbn10 Isbn10 { get; init; }

    public List<Author> Authors { get; init; }

    public Book(string title, string? subtitle, Isbn10 isbn10, List<Author> authors)
    {
        if ("".Equals(title))
        {
            throw new InvalidDataException("Title is required.");
        }
        if (title.Length > 100)
        {
            throw new InvalidDataException("Title is too long.");
        }
        if (subtitle != null && subtitle.Length > 100)
        {
            throw new InvalidDataException("Subtitle is too long.");
        }
        // TODO Authorsの上限検査

        Title = title;
        Subtitle = subtitle;
        Isbn10 = isbn10;
        Authors = authors;
    }
}