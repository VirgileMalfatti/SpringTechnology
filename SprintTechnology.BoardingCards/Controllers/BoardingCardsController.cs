﻿using Microsoft.AspNetCore.Mvc;
using SprintTechnology.BoardingCards.Business;
using SprintTechnology.BoardingCards.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SprintTechnology.BoardingCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardingCardsController : ControllerBase
    {
        // GET: api/<BoardingCardsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BoardingCardsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoardingCardsController>
        [HttpPost]
        public IActionResult Post([FromBody] BoardingDescription boardingDescription)
        {
            if(boardingDescription.Data != null)
            {
                var orderedlist = BoardingCardsBusiness.ReorderCards(boardingDescription.Data);
                return Ok(new BoardingDescription { Data = orderedlist });
            }
            return BadRequest();
        }

        // PUT api/<BoardingCardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoardingCardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}