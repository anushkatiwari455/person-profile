using CardGame.Application.Interfaces;
using CardGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Infrastructure.Services
{
    public class RandomShuffler : IShuffler
    {
        public List<Card> Shuffle(List<Card> cards)
        {
            if (cards == null || cards.Count == 0)
                throw new ArgumentException("Deck is empty or null");

            var rng = new Random();
            return cards.OrderBy(_ => rng.Next()).ToList();
        }
    }
}
