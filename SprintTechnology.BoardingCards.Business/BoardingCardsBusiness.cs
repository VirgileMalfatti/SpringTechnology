using SprintTechnology.BoardingCards.Models;
using System.Security.Cryptography.X509Certificates;

namespace SprintTechnology.BoardingCards.Business
{
    public class BoardingCardsBusiness
    {
        public LinkedList<BoardingCardModel> ReorderCardsRecursive(LinkedList<BoardingCardModel> boardingCardsModelList)
        {
            var startStep = boardingCardsModelList.First();

            var previousSteps = new LinkedList<BoardingCardModel>();

            previousSteps.AddLast(GetBoardingPreviousStep(boardingCardsModelList, previousSteps, startStep));
            if(boardingCardsModelList.Count > 0)
            {
                var currentLastStep = previousSteps.Last;
                GetBoardingNextStep(boardingCardsModelList, previousSteps, startStep, currentLastStep);
            }

            return previousSteps;
        }

        private BoardingCardModel GetBoardingPreviousStep(LinkedList<BoardingCardModel> allCards, LinkedList<BoardingCardModel> resultList, BoardingCardModel currentCard)
        {
            var nextCard = allCards.Find(allCards.Where(x => x.Destination == currentCard.Departure).FirstOrDefault());
            if (nextCard != null)
            {
                allCards.Remove(nextCard);
                resultList.AddLast(GetBoardingPreviousStep(allCards, resultList, nextCard.Value));
            }
            return currentCard;
        }

        private BoardingCardModel GetBoardingNextStep(LinkedList<BoardingCardModel> allCards, LinkedList<BoardingCardModel> previousSteps, BoardingCardModel currentCard, LinkedListNode<BoardingCardModel> startingPreviousStep)
        {
            var nextCard = allCards.Find(allCards.Where(x => x.Departure == currentCard.Destination).FirstOrDefault());
            if (nextCard != null)
            {
                allCards.Remove(nextCard);
                previousSteps.AddAfter(startingPreviousStep, GetBoardingNextStep(allCards, previousSteps, nextCard.Value,startingPreviousStep));
            }
            return currentCard;
        }
    }
}