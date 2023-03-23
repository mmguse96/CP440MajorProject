using DeckOfCards;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace DeckOfCards
{
    class BlackjackCardGen
    {
        static void Main(string[] args)
        {
            // get num of users
            Console.Write("Enter the number of players: ");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            // add 1 to account for dealer hand
            numberOfPlayers = numberOfPlayers + 1;
            Console.WriteLine();

            // create deck using deck class
            Deck deck = new Deck();

            // shuffle the deck
            deck.Shuffle();

            // list cards by hand num for num of players entered
            List<Card>[] hands = deck.Deal(numberOfPlayers);

            int dealerRange = 1;
            int playerRange = 2;

            // deal, only two cards are shown for player
            // only one card shwon for dealer
            // dealer hand = 0, players hands = 1+
            for (int i = 0; i < numberOfPlayers; i++)
            {
                // for dealer hand
                if (hands[i] == hands[0])
                {
                    Console.WriteLine("Dealer hand: ");
                    // only shows the frist card the dealer is dealt
                    foreach (Card card in hands[i].GetRange(0, dealerRange))
                    {
                        Console.WriteLine(card.Face + " of " + card.Suit);
                    }
                    Console.WriteLine();
                }
                // for other players 
                else
                {
                    Console.WriteLine("Player " + (i) + ":");
                    // shows both cards player is dealt
                    foreach (Card card in hands[i].GetRange(0, playerRange))
                    {
                        Console.WriteLine(card.Face + " of " + card.Suit);
                    }
                    Console.WriteLine();
                }
            }

            for (int i = 1; i < numberOfPlayers; i++)
            {
                DetermineDeal dd = new DetermineDeal(hands[0], hands[i], numberOfPlayers, dealerRange, playerRange);
            }

            Console.Write("Play Again? Y for yes or N for no: ");
            string ans = Console.ReadLine().ToUpper();

            if (ans == "Y")
            {
                Console.WriteLine("Yes Selected. Click any key to restart.");
                Console.ReadKey();
                RestartApp reapp = new RestartApp();
                reapp.Restart = true;
            }
            else if (ans == "N")
            {
                Console.WriteLine("No Selected");
                Console.ReadKey();
                //save point to player profile
                RestartApp reapp = new RestartApp();
                reapp.Restart = false;
            }

            //PlayAgain pa = new PlayAgain(restart);

            //for (int i = 0; i < numberOfPlayers; i++)
            //{
            //    Console.Write("Enter player " + i + " bet: ");
            //    int bet = int.Parse(Console.ReadLine());
            //    if (bet < playerPoints)
            //    {
            //        PlaceBet pb = new PlaceBet(hands[i], playerPoints, bet);
            //    }
            //    while (bet > playerPoints)
            //    {
            //        Console.WriteLine("Player " + i + " has " + playerPoints + " points.");
            //        Console.Write("Enter another bet that is less than or eqaual to your total points: ");
            //        bet = int.Parse(Console.ReadLine());
            //    } 
            //}

            // last line
            Console.Write("Click any button to exit");
            Console.ReadLine();
        } // end of main 
    } // end of blackjackcardgen class


    // enumerating face values to use in deck 
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

    // enumerating suits to use in deck
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    // create cards and their values using enum from above
    public class Card
    {
        public Face Face { get; set; }
        public Suit Suit { get; set; }

        // to use Ace as 11 and 1
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
    } // end of card class

    // deck class - take cards created, add them to the deck
    // includes shuffle and deal functions
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

        // shuffle deck function
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

        // deal function - deals cards based on num of players
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
    } // end of deck class

    //public class PlaceBet
    //{
    //    public PlaceBet(List <Card> playerHand, int points, int bet, string winLoss) 
    //    {
    //        points -= bet;
    //    }

    //    public void WinLossBet(List<Card> playerHand, int points, int bet, string winLoss, int numPlayers)
    //    {
    //        for (int i = 0; i < numPlayers; i++)
    //        {
    //            if (winLoss == "win")
    //            {
    //                points += (bet * 2);
    //                Console.WriteLine("Player " + i + " points: " + points);
    //            }
    //            else if (winLoss == "push")
    //            {
    //                points += bet;
    //                Console.WriteLine("Player " + i + " points: " + points);
    //            }
    //            else if (winLoss == "loss")
    //            {
    //                Console.WriteLine("Player " + i + " points: " + points);
    //            }
    //        }
    //    } // end of winloss
    //} // end of placebet class


    public class DetermineDeal
    {
        public DetermineDeal(List<Card> dealerHand, List<Card> playerHand, int numPlayers, int dealerRange, int playerRange)
        {
            Console.WriteLine("Determine Deal");

            int sumOfPlayerHand = 0;

            //assign card to player hand
            for (int i = 1; i < numPlayers; i++)
            {
                // only shows the first card the dealer is dealt
                foreach (Card card in playerHand.GetRange(0, playerRange))
                {
                    sumOfPlayerHand += card.Value;
                }
                Console.WriteLine("Value of player " + i + " cards: " + sumOfPlayerHand);
                Console.WriteLine();
            }

            //see what to do based on player card values after hit
            if (sumOfPlayerHand == 21)
            {
                RevealDealerCards rdc = new RevealDealerCards(dealerHand, playerHand, numPlayers, sumOfPlayerHand, dealerRange, playerRange);
            }
            else if (sumOfPlayerHand > 21)
            {
                Console.WriteLine("Error: Value of cards is greater than 21. Determine Deal error");
                // EXIT GAME
            }
            else if (sumOfPlayerHand < 21)
            {
                PlayerOptions options = new PlayerOptions(dealerHand, playerHand, numPlayers, dealerRange, playerRange);
            }
            else
            {
                Console.WriteLine("Error: Unexpected error. Determine Deal error");
            }
        }
    } // end of determinedeal class

    public class PlayerOptions
    {
        public PlayerOptions(List <Card> dealerHand, List<Card> playerHand, int numPlayers, int dealerRange, int playerRange)
        {
            // show options for player (hit, stand, doubledown, split
            Console.WriteLine("Player Options");
            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("Type one of the following: H, S, D, P or ? for help");

            // takes input and makes upper case
            // ensures if loop works even if user inputs lowercase
            string option = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (option == "H")
            {
                Hit(dealerHand, playerHand, numPlayers, dealerRange, playerRange, false);
            }
            else if (option == "S")
            {
                Stand(dealerHand, playerHand, numPlayers, dealerRange, playerRange);
            }
            else if (option == "D")
            {
                Doubledown(dealerHand, playerHand, numPlayers, dealerRange, playerRange);
            }
            else if (option == "P")
            {
                Split();
            }
            else if (option == "?")
            {
                Console.WriteLine("- H for hit");
                Console.WriteLine("- S for stand");
                Console.WriteLine("- D for double down");
                Console.WriteLine("- P for split");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        // player option Hit
        // add card to hand 
        public void Hit(List <Card> dealerHand, List<Card> playerHand, int numPlayers, int dealerRange, int playerRange, bool dd)
        {
            int sumOfPlayerHand = 0;
            playerRange++;
            
            Console.WriteLine("Hit selected");

            foreach (Card card in playerHand.GetRange(0, playerRange))
            {
                sumOfPlayerHand += card.Value;
            }
            
            //assign card to player hand
            for (int i = 1; i < numPlayers; i++)
            { 
                Console.WriteLine("Player " + (i) + " cards:");
                // only shows the first card the dealer is dealt
                foreach (Card card in playerHand.GetRange(0, playerRange))
                {
                    Console.WriteLine(card.Face + " of " + card.Suit);
                }
                Console.WriteLine("Value of player hand: " + sumOfPlayerHand);
                Console.WriteLine();
            }

            //see what to do based on player card values after hit
            if (sumOfPlayerHand == 21)
            {
                RevealDealerCards rdc = new RevealDealerCards(dealerHand, playerHand, numPlayers, sumOfPlayerHand, dealerRange, playerRange);
            }
            else if (sumOfPlayerHand > 21)
            {
                WinLoss wl = new WinLoss("loss");
            }
            else if (sumOfPlayerHand < 21 && dd == false)
            {
                PlayerOptions options = new PlayerOptions(dealerHand, playerHand, numPlayers, dealerRange, playerRange);
            }
            else if (sumOfPlayerHand < 21 && dd == true)
            {
                // nothing
            }
            else
            {
                Console.WriteLine("Error: Hit else error");
            }
        } // end of hit
        public void Stand(List<Card> dealerHand, List<Card> playerHand, int numPlayers, int dealerRange, int playerRange)
        {
            Console.WriteLine("Stand Function");

            int sumOfPlayerHand = 0;

            foreach (Card card in playerHand.GetRange(0, playerRange))
            {
                sumOfPlayerHand += card.Value;
            }
            Console.WriteLine("Value of player hand: " + sumOfPlayerHand);
            Console.WriteLine();

            RevealDealerCards rdc = new RevealDealerCards(dealerHand, playerHand, numPlayers, sumOfPlayerHand, dealerRange, playerRange);
        }
        public void Doubledown(List<Card> dealerHand, List<Card> playerHand, int numPlayers, int dealerRange, int playerRange)
        {
            bool ddtrue = true;

            Console.WriteLine("Double down Function");

            // call doublebet() ***

            //call HIDEOPTIONS()

            Hit(dealerHand, playerHand, numPlayers, dealerRange, playerRange, ddtrue);

            Stand(dealerHand, playerHand, numPlayers, dealerRange, playerRange);
        }
        public void Split()
        {
            Console.WriteLine("Split Function");

            //call DOUBLEWAGER()

            //hand1.card1 = card1

            //hand1.card2 = hidden

            //hand2.card1 = card2

            //hand2.card2 = hidden

            //call SHOWOPTIONS() for hand1

            //call SHOWOPTIONS() for hand2

            //hide SPLIT button
        }
    } // end of playeroptions class

    public class RevealDealerCards
    {
        public RevealDealerCards(List<Card> dealerHand, List<Card> playerHand, int numPlayers, int sumOfPlayerHand, int dealerRange, int playerRange)
        {
            Console.WriteLine("Revealing dealer cards...");

            // determine dealer hand value
            int sumOfDealerHand = 0;

            // show remaining cards needed
            // deal, only two cards are shown
            // dealer hand = 0, players hands = 1+
            if (dealerRange == 1)
            {
                dealerRange = 2;
            }

            Console.WriteLine("Dealer hand: ");
            // shows first two dealer cards
            foreach (Card card in dealerHand.GetRange(0, dealerRange))
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
                sumOfDealerHand += card.Value;
            }
            Console.WriteLine("Dealer value: " + sumOfDealerHand);
            Console.WriteLine();

            while (sumOfDealerHand < 17)
            {
                DealerHit(dealerHand, playerHand, numPlayers, dealerRange, playerRange);
            }

            if (sumOfDealerHand >= 17)
            {
                //see what to do based on dealer card count
                if (sumOfDealerHand > 21)
                {
                    WinLoss wl = new WinLoss("win");
                }
                else if (sumOfDealerHand == sumOfPlayerHand)
                {
                    WinLoss wl = new WinLoss("tie");
                }
                else if (sumOfDealerHand > sumOfPlayerHand)
                {
                    WinLoss wl = new WinLoss("loss");
                }
                else if (sumOfDealerHand < sumOfPlayerHand)
                {
                    WinLoss wl = new WinLoss("win");
                }
                else
                {
                    Console.WriteLine("Error: sumOfDealer cards else if statements 1");
                }
            }
            else
            {
                Console.WriteLine("Error: sumOfDealer cards else if statements 2");
            }
        } // end of reveal dealer cards

        public void DealerHit(List<Card> dealerHand, List<Card> playerHand, int numPlayers, int dealerRange, int playerRange)
        {
            int sumOfDealerHand = 0;
            dealerRange++;

            Console.WriteLine("Dealer hit");

            foreach (Card card in dealerHand.GetRange(0, dealerRange))
            {
                sumOfDealerHand += card.Value;
            }

            //assign card to player hand
            for (int i = 1; i < numPlayers; i++)
            {
                Console.WriteLine("Dealer cards:");
                foreach (Card card in dealerHand.GetRange(0, dealerRange))
                {
                    Console.WriteLine(card.Face + " of " + card.Suit);
                }
                Console.WriteLine("Value of dealer hand: " + sumOfDealerHand);
                Console.WriteLine();
            }
        } // end of dealerhit
    } // end of revealdealercards class

    public class WinLoss
    {
        public WinLoss(string playerWin)
        {
            if (playerWin == "win")
            {
                Console.WriteLine("Player wins!");
                //playerPoints = playerpoints + (playerBet * 2)
                //call ASKTOEXIT()
            }
            else if (playerWin == "loss")
            {
                Console.WriteLine("Player loses.");
                //call ASKTOEXIT()
            }
            else if (playerWin == "tie")
            {
                Console.WriteLine("Player pushes.");
                //playerPoints = playerpoints + (playerBet)
                //call ASKTOEXIT()
            }
            else
            {
                Console.WriteLine("Error: playerWin not set to true or false");
            }
            // PlayAgain pa = new PlayAgain();
        }
    } // end of winloss class

    class RestartApp
    {
        private bool restart = false;
        public bool Restart
        {
            get { return restart; }
            set { restart = value; }
        }
    }
    public class PlayAgain
    {
        public PlayAgain(bool restart)
        {
            Console.Write("Play Again? Y for yes or N for no: ");
            string ans = Console.ReadLine().ToUpper();

            if (ans == "Y")
            {
                Console.WriteLine("Yes Selected. Click any key to restart.");
                Console.ReadKey();
                restart = true;
            }
            else if (ans == "N")
            {
                Console.WriteLine("No Selected");
                Console.ReadKey();
                //save point to player profile
                restart = false;
            }
        }
 
    } // end of playagain class
} // end of namespace