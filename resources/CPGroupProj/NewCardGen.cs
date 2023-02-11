using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DeckOfCards
{
    class NewCardGen
    {
        static void Main(string[] args)
        {
            // here we are getting the number of users
            Console.WriteLine("Enter the number of players: ");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            // creating the deck using our deck class
            Deck deck = new Deck();

            // this is just the shuffle feature
            deck.Shuffle();

            // here we are listing the cards by hand number for the amount of players we selected
            List<Card>[] hands = deck.Deal(numberOfPlayers);
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Console.WriteLine("Hand " + (i + 1) + ":");
                foreach (Card card in hands[i])
                {
                    Console.WriteLine(card.Face + " of " + card.Suit);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        /* this code can be use to just set it to 6 players, we can use this to connect our lobby */
        //static void Main(string[] args)
        //{
        //    Deck deck = new Deck();
        //    deck.Shuffle();
        //    List<Card>[] hands = deck.Deal(6);
        //    for (int i = 0; i < 6; i++)
        //    {
        //        Console.WriteLine("Hand " + (i + 1) + ":");
        //        foreach (Card card in hands[i])
        //        {
        //            Console.WriteLine(card.Face + " of " + card.Suit);
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.ReadLine();
        //}
    }

    // I am enumerating the face values to use in the deck 
    public enum Face
    {
        Ace = 1,
        Two,
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
        King
    }

    // I am enumerating the suits as well
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    // here we are creating the cards, and their values using the enum from earlier
    public class Card
    {
        public Face Face { get; set; }
        public Suit Suit { get; set; }

        // this lets us use Ace as 11 and 1
        public int Value
        {
            get
            {
                if (Face == Face.Ace)
                {
                    return 11;
                }
                else if (Face >= Face.Ten)
                {
                    return 10;
                }
                else
                {
                    return (int)Face;
                }
            }
        }

        public Card(Face face, Suit suit)
        {
            Face = face;
            Suit = suit;
        }
    }

    // this is the deck class this will take our cards we created and add them in the "deck" 
    public class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    _cards.Add(new Card(face, suit));
                }
            }
        }

        // here we are shuffling our deck so that it can be dealed out randombly
        public void Shuffle()
        {
            Random rng = new Random();
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        // and finally a deal function to deal out to the selected amount of players
        public List<Card>[] Deal(int numberOfHands)
        {
            List<Card>[] hands = new List<Card>[numberOfHands];
            for (int i = 0; i < numberOfHands; i++)
            {
                hands[i] = new List<Card>();
            }
            for (int i = 0; i < _cards.Count; i++)
            {
                hands[i % numberOfHands].Add(_cards[i]);
            }
            return hands;
        }
    }
}
