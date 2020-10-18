using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Data
{
    public class Query
    {
        [UseDbContext(typeof(BookContext))]
        public IQueryable<Author> GetAuthors([ScopedService]BookContext context) =>
            context.Authors;

        [UseDbContext(typeof(BookContext))]
        public IExecutable<Author> GetAuthorsExecutable([ScopedService] BookContext context) =>
            new MockExecutable<Author>(context.Authors);

        [UseDbContext(typeof(BookContext))]
        public async Task<Author> GetAuthor([ScopedService]BookContext context) =>
            await context.Authors.FirstOrDefaultAsync();
    }

    public class InvalidQuery
    {
        [UseDbContext(typeof(object))]
        public IQueryable<Author> GetAuthors([ScopedService]BookContext context) =>
            context.Authors;

        [UseDbContext(typeof(object))]
        public async Task<Author> GetAuthor([ScopedService]BookContext context) =>
            await context.Authors.FirstOrDefaultAsync();
    }
}
