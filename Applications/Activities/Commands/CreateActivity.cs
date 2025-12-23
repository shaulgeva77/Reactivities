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
    public class CreateActivity
    {
        public class Query : IRequest<string>
        {
            public required Activity Activity { get; set; }
        }
        public class Handler(AppDbContext context) : IRequestHandler<Query, string>
        {
            public async Task<string> Handle(Query command, CancellationToken cancellationToken)
            {
                var activity = command.Activity;
                
                context.Activities.Add(activity);
                await context.SaveChangesAsync();
                return activity.Id;
            }
        }
    }
}
