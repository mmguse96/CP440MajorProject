using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGenandShuffle
{
    class Card
    {
        public int value { get; set; }
        public int suite { get; set; }
    }

    abstract class Deck
    {
        public Card[] cards { get; set; }

        public void ShuffleCards(int timesToShuffle)
        {
            Card temp;
            Random random = new Random();
            // this is going to be a random shuffle
            int cardToShuffle1, cardToShuffle2;

            for (int x = 0; x < timesToShuffle; x++)
            {
                cardToShuffle1 = random.Next(this.cards.Length);
                cardToShuffle2 = random.Next(this.cards.Length);
                temp = this.cards[cardToShuffle1];

                this.cards[cardToShuffle1] = this.cards[cardToShuffle2];
                this.cards[cardToShuffle2] = temp;
            }
        }
    }

}
