using WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Data.Data;


namespace WebApi.Repositories;

public class EventRepository(DataContext context) : IEventRepository
{

    private readonly DataContext _context = context;

    public async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync()
    {
        try
        {
            var events = await _context.Events.ToListAsync();
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = true,
                StatusCode = 200,
                Result = events
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<EventEntity>>
            {
                Success = false,
                StatusCode = 500,
                Message = ex.Message
            };
        }
    }

    public async Task<RepositoryResult<EventEntity>> GetAsync(string id)
    {
        try
        {
            var entity = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return new RepositoryResult<EventEntity>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = "Event not found"
                };
            }

            return new RepositoryResult<EventEntity>
            {
                Success = true,
                StatusCode = 200,
                Result = entity
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<EventEntity>
            {
                Success = false,
                StatusCode = 500,
                Message = ex.Message
            };
        }
    }

    public async Task<RepositoryResult<EventEntity>> CreateAsync(EventEntity entity)
    {
        try
        {
            _context.Events.Add(entity);
            await _context.SaveChangesAsync();

            return new RepositoryResult<EventEntity>
            {
                Success = true,
                StatusCode = 201,
                Result = entity
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<EventEntity>
            {
                Success = false,
                StatusCode = 500,
                Message = ex.Message
            };
        }
    }

}
