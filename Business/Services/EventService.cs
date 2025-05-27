using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.EventService;
public class EventService(DataContext context) : IEventService
{

    private readonly DataContext _Context = context;

    public async Task<IEnumerable<EventEntity?>> GetAllAsync()
    {
        var entities = await _Context.Events.ToListAsync();
        return entities;
    }

    public async Task<EventEntity?> GetAsync(string eventId)
    {
        var entity = await _Context.Events.FirstOrDefaultAsync(x => x.Id == eventId);
        return entity;
    }
}
