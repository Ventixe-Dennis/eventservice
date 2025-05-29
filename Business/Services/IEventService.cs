using Business.Models;
using WebApi.Data;

namespace WebApi.EventService
{
    public interface IEventService
    {
        Task<EventResult<string>> CreateAsync(CreateEventDTO eventDTO);
        Task<EventResult<IEnumerable<Event>>> GetAllAsync();
        Task<EventResult<Event?>> GetAsync(string eventId);
    }
}