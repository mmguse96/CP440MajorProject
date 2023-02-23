using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BingoGame
{
    class BingoCaller
    {
        //all the possible numbers that can be called
        int[] balls = new int[]
        {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
        31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45,
        46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
        61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75};

        List<int> calledBalls = new List<int>(); //holds all the already called numbers; prevents dupes
        int bNum, cBalls;
        bool bingo;

        public BingoCaller(BCard card)
        {

            CallBalls(calledBalls, card, balls,bingo);
        }

        public int getCalledBalls()
        {
            //allows the called ball to be passed to other classes
            return cBalls;
        }

        public void CallBalls(List<int> calledBalls, BCard card, int[] balls, bool bingo)
        {
            //calls the balls.
            //gens a number between 0 and 74, the ball is whatever array index it is of int[]balls
            Random random = new Random();
            bNum = random.Next(75);

            //checks to see if that number has already been called, if so calls a new one
            while (bingo != true)
            {

                while (calledBalls.Contains(balls[bNum]))
                {
                    bNum = random.Next(75);
                }
                cBalls = balls[bNum];

                //adds called ball to list then passes it to the card for checking
                calledBalls.Add(cBalls);
                Console.WriteLine(cBalls);
                Console.WriteLine(" ");

                card.CheckForNumber(this);

            }
        }

        public void callBingo(bool bingo)
        {
            //if bing is true, will call the end game class
            GameEnd end = new GameEnd();
        }


    }
        
}
    
