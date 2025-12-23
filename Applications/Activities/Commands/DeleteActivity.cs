using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Activities.Commands
{
    public class DeleteActivity
    {
        public class Query : IRequest        {
            public required string Id { get; set; }
        }
        public class Handler(AppDbContext context) : IRequestHandler<Query>
        {
            public async Task Handle(Query command, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(command.Id,cancellationToken);
                if (activity == null)
                {
                    throw new Exception("Faild to find activity with requsted id");
                }
                context.Activities.Remove(activity);
                await context.SaveChangesAsync();               
            }
        }
    }
}
