using CardGame.Application.Interfaces;
using CardGame.Domain.Entities;
using CardGame.Infrastructure.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Tests
{
    public class DeckTests
    {
        [Fact]
        public void Deck_Should_Contain_52_Cards_On_Initialization()
        {
            var mockShuffler = new Mock<IShuffler>();
            var deck = new Deck(mockShuffler.Object);

            deck.Cards.Should().HaveCount(52);
        }

        [Fact]
        public void Constructor_Should_Throw_If_Shuffler_Is_Null()
        {
            Action act = () => new Deck(null);
            act.Should().Throw<ArgumentNullException>().WithParameterName("shuffler");
        }

        [Fact]
        public void Shuffle_Should_Use_IShuffler_To_Shuffle_Cards()
        {
            // Arrange
            var mockShuffler = new Mock<IShuffler>();

            // Capture the input passed to Shuffle and return a reversed list
            mockShuffler
                .Setup(s => s.Shuffle(It.IsAny<List<Card>>()))
                .Returns((List<Card> input) => input.AsEnumerable().Reverse().ToList());

            var deck = new Deck(mockShuffler.Object);
            var originalCards = deck.Cards.Select(c => c.ToString()).ToList();

            // Act
            deck.Shuffle();

            // Assert
            var shuffledCards = deck.Cards.Select(c => c.ToString()).ToList();
            shuffledCards.Should().NotEqual(originalCards); // confirms shuffle
            mockShuffler.Verify(s => s.Shuffle(It.IsAny<List<Card>>()), Times.Once);
        }

    }
}
