namespace Movie_Catlog_Application.Interfaces.Abstract
{
    public interface IGenericService
    {
        Task<List<T>> GetAllAsync<T>() where T : class;
        
        Task CreateAsync<T>(T entity) where T : class;

        Task UpdateAsync<T>(T entity) where T : class;

        Task<T> GetByIdAsync<T>(int id) where T : class;

        Task DeleteAsync<T>(T entity) where T : class;
    }
}
