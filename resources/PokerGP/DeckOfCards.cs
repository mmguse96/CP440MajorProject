using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGP
{
    internal class DeckOfCards : Card
    {
        const int NUM_OF_Cards = 52; //total number of cards
        private Card[] deck; //this is the array of all playing cards

        public DeckOfCards() 
        {
            deck = new Card[NUM_OF_Cards];
        }

        public Card[] getDeck { get { return deck; } } // this gets the current deck

        //here I am creating a deck of 52 cards: with 13 values each, and 4 suits
        public void setUpDeck()
        {
            int i = 0;
            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { MySuits = s, MyValue = v };
                    i++;
                }
            }
            ShuffleCards();
        }
        //shuffle the deck
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;

            //I am going to run the shuffle 1000 times to randomize as much as possible
            for (int shuffleAmount = 0; shuffleAmount < 1000; shuffleAmount++)
            {
                for (int i = 0; i < NUM_OF_Cards; i++)
                {
                    //I am going to swap the cards around using num of cards per suit
                    int cardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[cardIndex];
                    deck[cardIndex] = temp;
                }
            }
        }
    }
}
