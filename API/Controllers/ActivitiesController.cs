using Applications.Activities.Commands;
using Applications.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    
    public class ActivitiesController : BaseApiController
    {        

        // GET: api/<ActivitiesController>
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await Mediator.Send(new GetActivityList.Query());
        }

        // GET api/<ActivitiesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await Mediator.Send(new GetActivity.Query() { Id = id});           
        }

        // POST api/<ActivitiesController>
        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            return await Mediator.Send(new CreateActivity.Query() { Activity = activity });            
        }

        // PUT api/<ActivitiesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditActivity(string id, Activity activity)
        {
            await Mediator.Send(new EditActivity.Query() { Activity  = activity});
            return NoContent();
        }

        // DELETE api/<ActivitiesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteActivity.Query() { Id = id });
            return NoContent();
        }
    }
}
