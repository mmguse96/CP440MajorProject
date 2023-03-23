using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BingoGame
{
    internal class GameEnd
    {
        public GameEnd() {
            bingo(); 
        }

        public void bingo ()
        {
            Console.WriteLine("bingo");
            
            //asks user if they want to continue to play
            string answer;
            Console.WriteLine("press y to play again n to close");
            answer = Console.ReadLine();

            if (answer.Equals("y"))
            {
               new GameStart();  
            }
            else if(answer.Equals("n")) { Environment.Exit(0); }

        }
    }
}
