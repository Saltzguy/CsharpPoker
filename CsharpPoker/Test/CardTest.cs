using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CsharpPoker.Test
{
    public class CardTest
    {

        [Fact]
        public void CanCreateCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Clubs);

            Assert.NotNull(card);

        }
        [Fact]
        public void CanCreateCardWithValue()
        {
            var card = new Card(CardValue.Ace, CardSuit.Clubs);

            Assert.Equal(CardSuit.Clubs, card.Suit);
            Assert.Equal(CardValue.Ace, card.Value);
        }
        

        [Fact]
        public void CanDescribeCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            Assert.Equal("Ace of Spades", card.ToString());
        }



    }
}
