using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CsharpPoker
{
    public class Hand
    {
        private bool handWasSorted = false;

        private readonly List<Card> cards = new List<Card>();

        public IEnumerable<Card> Cards => cards;
       
        public void Draw(Card card)
        {
            handWasSorted = false;
            cards.Add(card);
            
        }
        public Card HighCard()
        {
            if (!handWasSorted)
            {
                SortCards();
            }
            return cards.Last();

        }   
        public HandRank GetHandRank()
        {
            if (!handWasSorted)
            {
                SortCards();
            }
            
            if (HasRoyalFlush()) return HandRank.RoyalFlush;
            if (HasStrightFlush()) return HandRank.StraightFlush;
            if (HasFlush()) return HandRank.Flush;
            if (HasStright()) return HandRank.Straight;
            return HandRank.HighCard;
        }
        private bool HasStright()
        {
            return cards[0].Value == cards[1].Value - 1 && cards[1].Value == cards[2].Value - 1 && cards[2].Value == cards[3].Value - 1 && cards[3].Value == cards[4].Value - 1;
        }
        private bool HasFlush() => cards.All(c => cards.First().Suit == c.Suit);

        private bool HasStrightFlush() => HasFlush() && HasStright();  
       
        private bool HasRoyalFlush() => HasFlush() && cards.All(c => c.Value > CardValue.Nine);
        
        private void SortCards()
        {
            cards.Sort((a, b) => a.Value.CompareTo(b.Value));
            handWasSorted = true;
        }

    }
}
