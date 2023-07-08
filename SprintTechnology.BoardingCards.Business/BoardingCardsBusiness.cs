using SprintTechnology.BoardingCards.Models;
using System.Security.Cryptography.X509Certificates;

namespace SprintTechnology.BoardingCards.Business
{
    public class BoardingCardsBusiness
    {
        public static LinkedList<BoardingCardModel> ReorderCards(LinkedList<BoardingCardModel> boardingCardsModelList)
        {
            // Getting the last step
            var current = boardingCardsModelList.Find(boardingCardsModelList.Where(x => x.Destination == null).First());

            do
            {
                var previousStep = boardingCardsModelList.Find(boardingCardsModelList.Where(x => x.Destination == current.Value.Departure).FirstOrDefault());

                //if no previous step is found : starting point found
                if(previousStep == null)
                    break;
                boardingCardsModelList.Remove(previousStep);
                boardingCardsModelList.AddBefore(current, previousStep);
                current = previousStep;
            }
            while (current != null);

            return boardingCardsModelList;
        }
    }
}