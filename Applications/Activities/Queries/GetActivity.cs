using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Activities.Queries
{
    public class GetActivity
    {
        public class Query : IRequest<Activity>
        {
            public required string Id {  get; set; }
        }
        public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
        {
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);
                if (activity == null)
                {
                    throw new Exception("Faild to find activity with requsted id");
                }
                return activity;
            }
        }
    }
}
