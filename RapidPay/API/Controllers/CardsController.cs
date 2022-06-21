using Application.Cards;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CardsController : BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<List<Card>>> GetActivities()
        {
            return await Mediator.Send(new List.Query());
        }

        [Authorize]
        [HttpGet("{id}")] // cards/id
        public async Task<ActionResult<Card>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCard(Card card)
        {
           return Ok(await Mediator.Send(new Create.Command { Card = card }));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCard(Guid id, Card card)
        {
            card.Id = id;
            return Ok(await Mediator.Send(new Edit.Command { Card = card }));
        }
    }
}