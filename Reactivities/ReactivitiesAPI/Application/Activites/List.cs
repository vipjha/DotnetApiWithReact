﻿using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activites
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            private readonly IMapper _mapper;

            public Handler(DataContext context, ILogger<List> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;  
                _mapper = mapper;
            }
            public async Task<Result<List<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                //throw new NotImplementedException();
                /*
                try
                {
                    for (var i = 0; i < 10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation($"Task was cancelled");
                    //throw;
                }
                */

                /* List<Activity> activities = await _context.Activities
                     .Include(a=>a.Attendees)
                     .ThenInclude(u=>u.AppUser)
                     .ToListAsync(cancellationToken);

                 var activitiesToReturn = _mapper.Map<List<ActivityDto>>(activities);

                 return Result<List<ActivityDto>>.Success(activitiesToReturn);*/

                var activities = await _context.Activities
                    .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
               
                return Result<List<ActivityDto>>.Success(activities);
            }
        }
    }
}
