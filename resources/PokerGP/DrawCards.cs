using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGP
{
    //this is where I would be able to the multiplayer stuff also change this when we import to Unity
    //this is for testing in console 
    internal class DrawCards
    {
        //draw the outlines
        public static void DrawCardOutline (int xcoord, int ycoord)
        {
            //Console.
            int x = xcoord * 12;
            int y = ycoord;

            Console.SetCursorPosition(x, y);
            Console.Write(" __________\n"); //the top edge of the card

            //again just hard coding this this whole part can be scrapped in unity
            for(int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);

                if (i != 9)
                    Console.WriteLine("|          |"); // left and right edges
                else
                    Console.WriteLine("|__________|"); // the bottom
                
            }
        }
        // will display the suit and value of the card
        public static void DrawCardSuitValue(Card card, int xcoord, int ycoord)
        {
            char cardSuit = ' ';
            int x = xcoord * 12;
            int y = ycoord;

            //### Okay I gave up on hard encoding I just draw the outline for now, I don't know how to modernise this approach I was looking at some older .net 2 code for help
            
            //I will encode each of the suits using the official microshaft characters from CodePage437
            // hearts and diamonds are red, and spades and clubs are black
            //switch(card.MySuits)
            //{
            //    case Card.SUIT.HEARTS:
            //        cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 3 })[0];
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        break;
            //    case Card.SUIT.DIAMONDS:
            //        cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 4 })[0];
            //        Console.ForegroundColor = ConsoleColor.Red;
            //        break;
            //    case Card.SUIT.SPADES:
            //        cardSuit = Encoding.GetEncoding(U + 2664).GetChars(new byte[] { 5 })[0];
            //        Console.ForegroundColor = ConsoleColor.White;
            //        break;
            //    case Card.SUIT.CLUBS:
            //        cardSuit = Encoding.GetEncoding(437).GetChars(new byte[] { 6 })[0];
            //        Console.ForegroundColor = ConsoleColor.White;
            //        break;
            //}


            //display the character and value of the card
            Console.SetCursorPosition(x,y);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.MyValue);
        }
    }
}
