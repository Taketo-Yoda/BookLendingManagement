using Microsoft.AspNetCore.Components.Web;

namespace WebApi.Domain.Entity;

/*
 * 書籍エンティティ.
 */
public class Book
{
    public string Title { get; init; }

    public string? Subtitle { get; init; }

    public List<Author> Authors { get; init; }

    public Book(string title, string? subtitle, List<Author> authors)
    {
        if (title.Length > 100)
        {
            throw new InvalidDataException("title is too long.");
        }
        if (subtitle != null && subtitle.Length > 100)
        {
            throw new InvalidDataException("subtitle is too long.");
        }
        Title = title;
        Subtitle = subtitle;
        Authors = authors;
    }
}