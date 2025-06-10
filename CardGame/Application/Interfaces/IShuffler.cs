using CardGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Application.Interfaces
{
    public interface IShuffler
    {
        List<Card> Shuffle(List<Card> cards);
    }
}
