using System.ComponentModel.DataAnnotations;

namespace SprintTechnology.BoardingCards.Models
{
    public class BoardingDescription
    {
        public List<string>? Description { get; set; }
        [Required]
        public LinkedList<BoardingCardModel>? Data { get; set; }
    }
}
