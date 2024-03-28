using Aplication.Interfaces;
using Aplication.UseCases.Events.AddPhoto;
using Aplication.UseCases.Events.Create;
using Aplication.UseCases.Events.Delete;
using Aplication.UseCases.Events.FilteredList;
using Aplication.UseCases.Events.Get;
using Aplication.UseCases.Events.GetAllEventUsers;
using Aplication.UseCases.Events.List;
using Aplication.UseCases.Events.RegisterForEvent;
using Aplication.UseCases.Events.UnregisterForEvent;
using Aplication.UseCases.Events.Update;
using AutoMapper;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTO.Catalog;
using WebApplication3.DTO.Event;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication3.Controllers
{
    [Route("api/v1.0/event")]
    [ApiController]
    public class EventController(IMediator _mediator, IMapper _mapper, IFileSystemAccessor _file) : ControllerBase
    {
        /// <summary>
        /// Create new event
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> CreateEvent([FromForm]EventAddDTO data)
        {            
            var createCmd = _mapper.Map<CreateEventCommand>(data);
            var result = await _mediator.Send(createCmd);
            return StatusCode(201, result);
        }

        /// <summary>
        /// Subscribe user to event
        /// </summary>
        [HttpPut("{eventId}/addUser")]
        public async Task<IActionResult> RegisterUserForEvent(Guid eventId, [FromBody] Guid userId)
        {
            var registerCmd = new RegistrationForEventCommand(userId, eventId);
            await _mediator.Send(registerCmd);
            return StatusCode(200);
        }

        /// <summary>
        /// Add photo to event
        /// </summary>
        [HttpPut("{eventId}/addPhoto")]
        public async Task<IActionResult> AddPhoto(Guid eventId, IFormFile uploads)
        {
            var addPhotoCmd = new AddPhotoCommand(eventId, uploads);
            var res = await _mediator.Send(addPhotoCmd);
            return StatusCode(201, res);
        }

        /// <summary>
        /// Delete photo to event
        /// </summary>
        [HttpDelete("{eventId}/deltePhoto/{photoId}")]
        public async Task<IActionResult> DeltePhoto(Guid eventId, Guid photoId)
        {
            return StatusCode(200);
        }

        /// <summary>
        /// Delete event
        /// </summary>
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteEvent(Guid eventId)
        {
            var deleteCmd = new DeleteEventCommand(eventId);
            await _mediator.Send(deleteCmd);
            return StatusCode(204);
        }

        /// <summary>
        /// Unsubscribe user to event
        /// </summary>
        [HttpPost("{eventId}/delteUser")]
        public async Task<IActionResult> UnegisterUserForEvent(Guid eventId, [FromBody] Guid userId)
        {
            var registerCmd = new UnegistrationForEventCommand(userId, eventId);
            await _mediator.Send(registerCmd);
            return StatusCode(200);
        }

        /// <summary>
        /// Get full information about specified event
        /// </summary>
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEvent(Guid eventId)
        {
            var getCmd = new GetByIdEventCommand(eventId);
            var result = await _mediator.Send(getCmd);
            List<string> images = [];
            foreach (string path in result.images) {
                images.Add(_file.GetFile(path));
            }
            result.images = images;
            return StatusCode(200, result);
        }

        /// <summary>
        /// Get all users of specified event
        /// </summary>
        [HttpGet("{eventId}/users")]
        public async Task<IActionResult> GetAllUsers(Guid eventId)
        {
            var usersCmd = new GetAllEventUsersCommand(eventId);
            var res = await _mediator.Send(usersCmd);
            return StatusCode(200, res);
        }

        /// <summary>
        /// Get all events with only essantial info
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var listCmd = new ListEventCommand();
            var result = await _mediator.Send(listCmd);
            var catalog = result.Select(c => _mapper.Map<EventCatalogDTO>(c)).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                catalog[i].MainImage = _file.GetFile(result[i].images[0]);
            }
            return StatusCode(200, catalog);
        }

        /// <summary>
        /// Get filtered events with only essantial info
        /// </summary>
        [HttpGet("filtered")]
        public async Task<IActionResult> GetFilteredEvents([FromBody] EventFilterDTO filterDTO)
        {
            var filterlistCmd = _mapper.Map<FilterListCommand>(filterDTO);
            var result = await _mediator.Send(filterlistCmd);
            var catalog = result.Select(c => _mapper.Map<EventCatalogDTO>(c)).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                catalog[i].MainImage = _file.GetFile(result[i].images[0]);
            }
            return StatusCode(200, catalog);
        }

        /// <summary>
        /// Update event
        /// </summary>
        [HttpPatch]
        public async Task<IActionResult> UpdateEvent([FromBody] EventUpdateDTO data)
        {
            var updateCmd = _mapper.Map<UpdateEventCommand>(data);
            var result = await _mediator.Send(updateCmd);
            return StatusCode(200, result);
        }
    }
}
