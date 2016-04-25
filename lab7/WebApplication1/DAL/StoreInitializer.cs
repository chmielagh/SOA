using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var books = new List<Book>
            {
                new Book() { Id=1, ISBN="sksz", Title="Smętarz zwierząt" },
                new Book() { Id=2, ISBN="skc", Title="Cujo" },
                new Book() { Id=3, ISBN="slm", Title="Millenium" }

            };
            context.Books.AddRange(books);
            context.SaveChanges();

            var authors = new List<Author>()
            {
                new Author() { Id=1, Name="Stephan", Surname="King" },
                new Author() { Id=2, Name="Stieg", Surname="Larssen" }
            };
            context.Authors.AddRange(authors);
            context.SaveChanges();

        }
    }
}