using Data.Data;
using WebApi.Data;

namespace WebApi.Repositories
{
    public interface IEventRepository
    {
        Task<RepositoryResult<EventEntity>> CreateAsync(EventEntity entity);
        Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync();
        Task<RepositoryResult<EventEntity>> GetAsync(string id);
    }
}