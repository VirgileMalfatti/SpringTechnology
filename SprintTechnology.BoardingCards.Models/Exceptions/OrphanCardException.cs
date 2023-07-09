using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTechnology.BoardingCards.Models.Exceptions
{
    public class OrphanCardException: Exception
    {
        public OrphanCardException(string? message):base(message) { }
    }
}
