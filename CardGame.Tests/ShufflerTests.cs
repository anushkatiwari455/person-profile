using CardGame.Domain.Entities;
using CardGame.Infrastructure.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Tests
{
    public class ShufflerTests
    {
        [Fact]
        public void Shuffle_Should_Throw_If_Null_Is_Passed()
        {
            var shuffler = new RandomShuffler();
            Action act = () => shuffler.Shuffle(null);

            act.Should().Throw<ArgumentException>().WithMessage("Deck is empty or null");
        }
        [Fact]
        public void Shuffle_Should_Return_Same_Cards_In_Different_Order()
        {
            var originalCards = new List<Card>
            {
                new Card("Hearts", "Ace"),
                new Card("Spades", "King"),
                new Card("Diamonds", "Queen")
            };

            var shuffler = new RandomShuffler();
            var shuffled = shuffler.Shuffle(originalCards);

            shuffled.Should().HaveCount(originalCards.Count);
            shuffled.Select(c => c.ToString()).Should().BeEquivalentTo(originalCards.Select(c => c.ToString()));
            shuffled.Should().NotEqual(originalCards); // very likely to be different due to randomness
        }
    }

}
