using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Activities.Commands
{
    public class EditActivity
    {
        public class Query : IRequest
        {
            public required Activity Activity { get; set; }
        }
        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Query>
        {
            public async Task Handle(Query command, CancellationToken cancellationToken)
            {                
                var activity = await context.Activities.FindAsync(command.Activity.Id);
                activity.Title = command.Activity.Title;
                if (activity == null)
                {
                    throw new Exception("Faild to find activity with requsted id");
                }
                mapper.Map(command.Activity, activity);
                activity.Title = command.Activity.Title;
                await context.SaveChangesAsync();
            }
        }
    }
}
