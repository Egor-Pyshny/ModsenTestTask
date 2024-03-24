using Aplication.UseCases.Users.GetAllUserEvents;
using Aplication.UseCases.Users.LogIn;
using Aplication.UseCases.Users.Registration;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using WebApplication3.DTO.User;

namespace WebApplication3.Controllers
{
    [Route("api/v1.0/user")]
    [ApiController]
    public class UserController(IMediator _mediator, IMapper _mapper) : ControllerBase
    {
        /// <summary>
        /// Log in user
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] UserLogInDTO data)
        {
            var createCmd = new LogInCommand(data.Email, data.Password);
            var result = await _mediator.Send(createCmd);
            return StatusCode(200, result);
        }

        /// <summary>
        /// Register user
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Registration([FromBody] UserAddDTO data)
        {
            var registrationCmd = _mapper.Map<RegistrationCommand>(data);
            var result = await _mediator.Send(registrationCmd);
            return StatusCode(201, result);
        }

        /// <summary>
        /// Get all events in which the user participates
        /// </summary>
        [HttpGet("{userId}/events")]
        public async Task<IActionResult> GetAllUserEventsCommand(Guid userId)
        {
            var geteventsCmd = new GetAllUserEventsCommand(userId);
            var result = await _mediator.Send(geteventsCmd);
            return StatusCode(201, result);
        }
    }
}
