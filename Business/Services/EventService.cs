using Business.Models;
using WebApi.Data;
using WebApi.Repositories;

namespace WebApi.EventService;
public class EventService(IEventRepository repository) : IEventService
{

    private readonly IEventRepository _repository = repository;

    public async Task<EventResult<IEnumerable<Event>>> GetAllAsync()
    {
        try
        {
            var result = await _repository.GetAllAsync();
            var events = result.Result?.Select(x => new Event
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Date = x.Date,
                Price = x.Price,
                Location = x.Location,
                Category = x.Category,
            });
            return new EventResult<IEnumerable<Event>> { Success = true, Result = events};
        }
        catch (Exception ex)
        {
            return new EventResult<IEnumerable<Event>>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public async Task<EventResult<Event?>> GetAsync(string eventId)
    {
        try
        {
            var result = await _repository.GetAsync(eventId);
            if (result.Success && result.Result != null)
            {
                var currentEvent = new Event
                {
                    Id = result.Result.Id,
                    Name = result.Result.Name,
                    Description = result.Result.Description,
                    Date = result.Result.Date,
                    Price = result.Result.Price,
                    Location = result.Result.Location,
                    Category = result.Result.Category,

                };
                return new EventResult<Event?> { Success = true, Result = currentEvent };
            }
            return new EventResult<Event?>
            {
                Success = false,
                Error = result.Message ?? "Event not found"
            };
        }
        catch (Exception ex)
        {
            return new EventResult<Event?> {Success = false, Error = ex.Message};
        }
    }

    public async Task<EventResult<string>> CreateAsync(CreateEventDTO eventDTO)
    {
        try
        {
            var eventEntity = new EventEntity
            {
                Id = Guid.NewGuid().ToString(),
                Name = eventDTO.Name,
                Description = eventDTO.Description,
                Date = eventDTO.Date,
                Price = eventDTO.Price,
                Location = eventDTO.Location,
                Category = eventDTO.Category,

            };

                var result = await _repository.CreateAsync(eventEntity);
            return result.Success
               ? new EventResult<string> { Success = true, Result = eventEntity.Id }
               : new EventResult<string> { Success = false, Error = result.Message };



        }
        catch (Exception ex)
        {
            return new EventResult<string> { Success = false, Error = ex.Message };
        }
    }
}
