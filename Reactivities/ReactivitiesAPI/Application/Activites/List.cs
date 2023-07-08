using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activites
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;  
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
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

                return await _context.Activities.ToListAsync(cancellationToken);
            }
        }
    }
}
