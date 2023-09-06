using Application.Activites;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        /*private readonly IMediator _mediator;

        //private readonly DataContext _context;
        //public ActivitiesController(DataContext context)
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
            //_context = context;
        }
        */

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            //return await _context.Activities.ToListAsync();
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [Authorize]
        [HttpGet("{id}")] // Activities/ids
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [Authorize(Policy= "IsActivityHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendence.Command { Id = id }));
        }

    }
}
