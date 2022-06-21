using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Cards
{
    public class Details
    {
        public class Query : IRequest<Card>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Card>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Card> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Cards.FindAsync(request.Id);
            }
        }
    }
}