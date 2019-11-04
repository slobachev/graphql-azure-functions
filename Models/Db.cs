using System.Collections.Generic;
using System.Linq;

namespace Function
{
  public class BooksDB
  {
    private static List<Book> books = new List<Book>() {
      new Book() { Id = 1, Name ="Lord of the rings", Genre="Fantasy"},
      new Book() { Id = 2, Name ="Republic", Genre="Philosophy"},
      new Book() { Id = 3, Name ="The Moonstone", Genre="Mystery"}
    };
    public static IEnumerable<Book> GetBooks()
    {
      return books;
    }

    public static Book AddBook(Book book)
    {
      book.Id = books.Count + 1;
      books.Add(book);
      return book;
    }

    public static Book UpdateBook(Book book)
    {
      var toUpdate = books.SingleOrDefault(b => b.Id == book.Id);
      toUpdate.Name = book.Name;
      toUpdate.Genre = book.Genre;
      return toUpdate;
    }

    public static string RemoveBook(int id)
    {
      var toRemove = books.SingleOrDefault(b => b.Id == id);
      books.Remove(toRemove);
      return "success";
    }
  }

  public class Book
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
  }
}