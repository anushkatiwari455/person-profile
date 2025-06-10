using CardGame.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Tests
{
    public class CardTests
    {
        [Fact]
        public void ToString_Should_Return_Correct_Format()
        {
            var card = new Card("Hearts", "Ace");
            card.ToString().Should().Be("Ace of Hearts");
        }
    }
}
