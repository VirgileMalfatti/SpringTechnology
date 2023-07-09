using System.ComponentModel.DataAnnotations;

namespace SprintTechnology.BoardingCards.Models
{
    public class BoardingCardModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Departure { get; set; }
        [Required]
        public string? Destination { get; set; }
        public string? Seat { get; set; }
        public string? Gate { get; set; }
        public string? Number { get; set; }
        public bool BaggageAutoTransfer { get; set; }
        public string? BaggageTicketCounter { get; set; }

    }
}