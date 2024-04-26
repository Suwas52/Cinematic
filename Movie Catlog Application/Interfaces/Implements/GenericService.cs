using Microsoft.EntityFrameworkCore;
using Movie_Catlog_Application.Context;
using Movie_Catlog_Application.Interfaces.Abstract;

namespace Movie_Catlog_Application.Interfaces.Implements
{
    public class GenericService : IGenericService
    {
        private readonly ApplicationDbContext context;
        public GenericService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            _ = await context.SaveChangesAsync();
        }

        public Task DeleteAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class
        {
            return await context.Set<T>().ToListAsync();
        }

        public Task UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
