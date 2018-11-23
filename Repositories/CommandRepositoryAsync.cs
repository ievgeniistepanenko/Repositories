using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repositories
{
    public class CommandRepositoryAsync<TContext> : CommandRepository<TContext> where TContext : DbContext
    {
        public CommandRepositoryAsync(TContext context) : base(context)
        {
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}