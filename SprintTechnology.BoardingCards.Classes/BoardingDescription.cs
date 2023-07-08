using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTechnology.BoardingCards.Classes
{
    public class BoardingDescription
    {
        public string? Description { get; set; }
        public LinkedList<BoardingCardModel>? Data { get; set; }
    }
}
