using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace CsharpPoker.Test
{
    public class HandTest
    {
        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand();
            hand.Cards.Any().Should().BeFalse();
        }
        [Fact]
        public void CanHandDrawCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Diamonds);
            var hand = new Hand();

            hand.Draw(card);

            hand.Cards.First().Should().Be(card);
        }

        [Fact]
        public void CanGetHighCard()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            hand.HighCard().Value.Should().Be(CardValue.King);
        }
        [Fact]
        public void CanScoreHighCard()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            hand.GetHandRank().Should().Be(HandRank.HighCard);
        }
        [Fact]
        public void CanScoreFlush()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Three, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Six, CardSuit.Spades));

            hand.GetHandRank().Should().Be(HandRank.Flush);

        }
        [Fact]
        public void CanScoreStraight()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));

            hand.GetHandRank().Should().Be(HandRank.Straight);

        }
        [Fact]
        public void CanScoreStraightFlush()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));

            hand.GetHandRank().Should().Be(HandRank.StraightFlush);
        }
        [Fact]
        public void CanScoreRoyalFlush()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Ten,CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

            hand.GetHandRank().Should().Be(HandRank.RoyalFlush);

        }
    }
}
