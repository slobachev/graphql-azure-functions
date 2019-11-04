using GraphQL;

namespace Function {
  public class Mutation
  {
    [GraphQLMetadata("addBook")]
    public Book AddBook(Book  input) 
    {
      return BooksDB.AddBook(input);
    }

    [GraphQLMetadata("updateBook")]
    public Book UpdateBook(Book input)
    {
      return BooksDB.UpdateBook(input);
    }

    [GraphQLMetadata("removeBook")]
    public string RemoveBook(int id)
    {
      return BooksDB.RemoveBook(id);
    }
  }
}