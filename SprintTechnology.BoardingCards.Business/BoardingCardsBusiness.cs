using SprintTechnology.BoardingCards.Models;
using SprintTechnology.BoardingCards.Models.Exceptions;
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

            // if no remaining boarding cards, it means that all steps are previous steps of the first item, no need to iterate
            if(boardingCardsModelList.Count > 0)
            {
                var currentLastStep = previousSteps.Last;
                GetBoardingNextStep(boardingCardsModelList, previousSteps, startStep, currentLastStep);
            }
            if (boardingCardsModelList.Count > 1)
                throw new OrphanCardException($"{boardingCardsModelList.Count} cards are not linked. Cannot finish process.");
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

        public static List<string> CreateCardsDescription(LinkedList<BoardingCardModel> boardingCardsModelList) 
        {
            var descriptionList = new List<string>();
            foreach(var card in boardingCardsModelList)
            {
                var cardDescription = string.Empty;
                if (card.Type == "flight")
                    cardDescription += $"From {card.Departure}, take flight {card.Number} to {card.Destination}. Gate {card.Gate}, seat {card.Seat}.";
                else
                {
                    cardDescription += $"Take {card.Type} {card.Number} from {card.Departure} to {card.Destination}.";
                    if (card.Seat != null)
                        cardDescription += $"Sit in seat {card.Seat}.";
                    else
                        cardDescription += "No seat assigned.";

                }
                if (card.BaggageTicketCounter != null)
                    cardDescription += $"Bagage drop at ticket counter {card.BaggageTicketCounter}.";
                if (card.BaggageAutoTransfer)
                    cardDescription += "Baggage will be automatically transferred from your last leg.";
                descriptionList.Add(cardDescription);
            }
            descriptionList.Add("You have arrived at your final destination");
            return descriptionList;
        }
    }
}