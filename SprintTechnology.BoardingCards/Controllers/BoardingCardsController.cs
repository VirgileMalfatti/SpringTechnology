﻿using Microsoft.AspNetCore.Mvc;
using SprintTechnology.BoardingCards.Providers;
using SprintTechnology.BoardingCards.ErrorMessages;
using SprintTechnology.BoardingCards.Models;
using SprintTechnology.BoardingCards.Models.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SprintTechnology.BoardingCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardingCardsController : ControllerBase
    {
        private readonly BoardingCardsProvider boardingCardsBusiness;

        public BoardingCardsController(BoardingCardsProvider boardingCardsBusiness)
        {
            this.boardingCardsBusiness = boardingCardsBusiness;
        }

        // POST api/<BoardingCardsController>
        [HttpPost]
        public IActionResult Post([FromBody] BoardingDescription boardingDescription)
        {
            if (boardingDescription.Data != null)
            {
                try
                {
                    var orderedlist = boardingCardsBusiness.ReorderCardsRecursive(boardingDescription.Data);
                    var description = BoardingCardsProvider.CreateCardsDescription(orderedlist);
                    return Ok(new BoardingDescription { Data = orderedlist, Description = description });
                }
                catch (OrphanCardException ex)
                {
                    return UnprocessableEntity(new ErrorResponse { Message = ex.Message });
                }
            }
            return BadRequest();
        }

    }
}
