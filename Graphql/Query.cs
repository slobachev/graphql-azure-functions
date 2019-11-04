using System.Collections.Generic;
using GraphQL;
using System.Linq;

namespace Function
{
  public class Query
  {
    [GraphQLMetadata("books")]
    public IEnumerable<Book> GetJedis()
    {
      return BooksDB.GetBooks();
    }

    [GraphQLMetadata("book")]
    public Book GetJedi(int id)
    {
      return BooksDB.GetBooks().SingleOrDefault(j => j.Id == id);
    }

    [GraphQLMetadata("hello")]
    public string GetHello()
    {
      return "World";
    }
  }

}