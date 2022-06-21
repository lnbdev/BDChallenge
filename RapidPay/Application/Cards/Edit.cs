using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Cards
{
    public class Edit
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
                var card = await _context.Cards.FindAsync(request.Card.Id);
                if (card == null)
                {
                    throw new Exception("Could not find card");
                }
                var newBalance = card.Balance - request.Card.Balance;
                if (newBalance < 0)
                {
                    throw new Exception("Balance cannot be negative");
                }
                card.Balance = newBalance;
                await _context.SaveChangesAsync();
                return Unit.Value;        

            }
        }
    }
}