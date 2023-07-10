using FluentAssertions;
using SprintTechnology.BoardingCards.Providers;
using SprintTechnology.BoardingCards.Models;
using SprintTechnology.BoardingCards.Models.Exceptions;
using System.Linq;

namespace SprintTechnology.BoardingCards.Tests
{
    [TestClass]
    public class BoardingCardsProviderTests
    {
        private BoardingCardsProvider provider;

        [TestInitialize]
        public void Init()
        {
            provider = new BoardingCardsProvider();
        }

        [TestMethod]
        public void ReorderCardsRecursive_Should_Reorder_CardsList()
        {
            //Arrange
            var unorderedCardList = BuildCardList();
            var expected = new LinkedList<BoardingCardModel>();
            
            expected.AddLast(new BoardingCardModel()
            {
                Name = "Mad-Bar",
                Type = "train",
                Departure = "Madrid",
                Destination = "Barcelona",
                Number = "78A",
                Seat = "45B"
            });
            expected.AddLast(new BoardingCardModel()
            {
                Name = "Bar-Ger",
                Type = "airport bus",
                Departure = "Barcelona",
                Destination = "Gerona Airport"
            });
            expected.AddLast(new BoardingCardModel()
            {
                Name = "Ger-Sto",
                Type = "flight",
                Departure = "Gerona Airport",
                Destination = "Stockolm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                BaggageTicketCounter = "344"
            });
            expected.AddLast(new BoardingCardModel()
            {
                Name = "Sto-New",
                Type = "flight",
                Departure = "Stockolm",
                Destination = "New-York JFK",
                Number = "SK22",
                Gate = "22",
                Seat = "7B",
                BaggageAutoTransfer = true
            });

            //Act
            var actual = provider.ReorderCardsRecursive(unorderedCardList);

            //Assert
            expected.Should().BeEquivalentTo(actual);
        }

        [TestMethod]
        public void ReorderCardsRecursive_Should_Throw_OrphanException()
        {
            //Arrange
            var unorderedCardList = BuildCardList();
            unorderedCardList.Last.Value.Departure = "NotValid";

            //Act&&Assert
            Assert.ThrowsException<OrphanCardException>(()=>provider.ReorderCardsRecursive(unorderedCardList));
        }

        private LinkedList<BoardingCardModel> BuildCardList()
        {
            var boardingCards = new LinkedList<BoardingCardModel>();
            boardingCards.AddLast(new BoardingCardModel()
            {
                Name = "Ger-Sto",
                Type = "flight",
                Departure = "Gerona Airport",
                Destination = "Stockolm",
                Number = "SK455",
                Gate = "45B",
                Seat = "3A",
                BaggageTicketCounter = "344"
            });
            boardingCards.AddLast(new BoardingCardModel()
            {
                Name= "Mad-Bar",
                Type= "train",
                Departure="Madrid",
                Destination="Barcelona",
                Number="78A",
                Seat="45B"
            });
            boardingCards.AddLast(new BoardingCardModel()
            {
                Name= "Sto-New",
                Type= "flight",
                Departure="Stockolm",
                Destination="New-York JFK",
                Number= "SK22",
                Gate="22",
                Seat="7B",
                BaggageAutoTransfer=true
            });
            boardingCards.AddLast(new BoardingCardModel()
            {
                Name= "Bar-Ger",
                Type= "airport bus",
                Departure="Barcelona",
                Destination="Gerona Airport"
            });
            return boardingCards;
        }
    }
}