using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Function {
  public class Server 
  {
    private ISchema schema { get; set; }
    public Server() 
    {
      this.schema = Schema.For(@"
          type Book {
            id: ID
            name: String,
            genre: String
          }

          input BookInput {
            name: String
            genre: String
            id: ID
          }

          type Mutation {
            addBook(input: BookInput): Book
            updateBook(input: BookInput ): Book
            removeBook(id: ID): String
          }

          type Query {
              books: [Book]
              book(id: ID): Book
          }
      ", _ =>
      {
        _.Types.Include<Query>();
        _.Types.Include<Mutation>();
      });

    }

    public async Task<string> QueryAsync(string query) 
    {
      var result = await new DocumentExecuter().ExecuteAsync(_ =>
      {
        _.Schema = schema;
        _.Query = query;
      });

      if(result.Errors != null) {
        return result.Errors[0].Message;
      } else {
        return JsonConvert.SerializeObject(result.Data);
      }
    }
  }
}