﻿using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activites
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                //throw new NotImplementedException();
               var activity = await _context.Activities.FindAsync(request.Id);
                if (activity == null) throw new Exception("Activity not found");
                return Result<Activity>.Success(activity);
            }
        }
    }
}
