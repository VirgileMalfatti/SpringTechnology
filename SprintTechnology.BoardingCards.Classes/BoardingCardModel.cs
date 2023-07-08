using System.ComponentModel.DataAnnotations;

namespace SprintTechnology.BoardingCards.Classes
{
    public class BoardingCardModel
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? Departure { get; set; }
        [Required]
        public string? Destination { get; set; }
        public string? LinkedTo { get; set; }
        public string? Seat { get; set; }
        public string? Gate { get; set; }
        public bool BaggageAutoTransfer { get; set; }
        public bool BaggageTicketCounter { get; set; }

    }
}