using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activites
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //throw new NotImplementedException();

                var actvity = await _context.Activities.FindAsync(request.Activity.Id);

                //actvity.Title = request.Activity.Title ?? actvity.Title;
                _mapper.Map(request.Activity, actvity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
