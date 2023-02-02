using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CardGenandShuffle
{
    internal class enumWithCard
    {
        public class Card
        {
            public Suit Suit { get; set; }
            public CardValue CardValue { get; set; }
        }

        public enum CardValue
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13
        }

        public enum Suit
        {
            Clubs,
            Hearts,
            Spades,
            Dimonds
        }

        public class PlayersHand
        {
            public List<Card> Cards { get; set; }
        }
    }
}
