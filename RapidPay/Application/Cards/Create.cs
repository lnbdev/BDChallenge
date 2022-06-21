using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Cards
{
    public class Create
    {
        public class Command : IRequest 
        {
            public Card Card { get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler (DataContext context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(request.Card.Number.Length != 15)
                {
                    throw new Exception("Card number is too long");
                }
                _context.Cards.Add(request.Card);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}