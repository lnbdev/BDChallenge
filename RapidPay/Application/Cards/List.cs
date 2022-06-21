using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Cards
{
    public class List
    {
        public class Query : IRequest<List<Card>> {}

        public class Handler : IRequestHandler<Query, List<Card>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Card>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Cards.ToListAsync();
            }
        }
    }
}