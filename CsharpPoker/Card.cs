﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPoker
{
    public class Card
    {

        public CardValue Value { get;}
        public CardSuit Suit { get; }

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString() => $"{Value} of {Suit}";
    }
    public enum CardValue
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    public enum CardSuit
    {
        Spades,
        Diamonds,
        Clubs,
        Hearts
    }
}