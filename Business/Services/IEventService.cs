using WebApi.Data;

namespace WebApi.EventService;

public interface IEventService
{
    Task<IEnumerable<EventEntity?>> GetAllAsync();
    Task<EventEntity?> GetAsync(string eventId);
}
