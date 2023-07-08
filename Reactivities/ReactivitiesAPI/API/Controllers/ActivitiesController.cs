using Application.Activites;
using Domain;
using MediatR;
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
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] // Activities/ids
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            // return await _context.Activities.FindAsync(id);
            //return Ok();
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}
