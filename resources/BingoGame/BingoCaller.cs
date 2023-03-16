using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        //List<int> calledBalls = new List<int>(); //holds all the already called numbers; prevents dupes
        int cBalls;
        bool bingo;

        public BingoCaller(BCard card)
        {

            CallBalls(card, balls,bingo);
        }

        public int GetCalledBalls()
        {
            //allows the called ball to be passed to other classes
            return cBalls;
        }

        public void CallBalls(BCard card, int[] balls, bool bingo)
        {
            int counter = 0;
            balls = ShuffleBalls(balls);
            while (!bingo)
            {
                cBalls = balls[counter] ;
                Console.WriteLine(cBalls);
                Console.WriteLine(" ");

                card.CheckForNumber(this);
                counter++;
            }
        }

        public int[] ShuffleBalls(int[] balls)
        {
            int lastIndex = balls.Length - 1;
            int randIndex;
            Random r = new Random();
            int temp;
            while (lastIndex > 0)
            {
                randIndex = r.Next(0, lastIndex - 1);
                temp = balls[lastIndex];
                balls[lastIndex] = balls[randIndex];
                balls[randIndex] = temp;
                lastIndex--;
            }
            return balls;
        }

        public void CallBingo(bool bingo)
        {
            //if bing is true, will call the end game class
            new GameEnd();
        }


    }
        
}
    
