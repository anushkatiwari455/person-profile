using CardGame.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Domain.Entities
{
    public class Deck
    {
        private readonly IShuffler _shuffler;
        public List<Card> Cards { get; private set; }

        public Deck(IShuffler shuffler)
        {
            _shuffler = shuffler ?? throw new ArgumentNullException(nameof(shuffler));
            Cards = GenerateDeck();
        }

        private List<Card> GenerateDeck()
        {
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            return suits.SelectMany(s => ranks.Select(r => new Card(s, r))).ToList();
        }

        public void Shuffle()
        {
            Cards = _shuffler.Shuffle(Cards);
        }
    }
}
