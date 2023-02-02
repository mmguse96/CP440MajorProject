using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoGame
{
    class BingoCaller
    {
        string[] balls = new String[]
            {"B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11", "B12", "B13", "B14", "B15",
        "I16", "I17", "I18", "I19", "I20", "I21", "I22", "I23", "I24", "I25", "I26", "I27", "I28", "I29", "I30",
        "N31", "N32", "N33", "N34", "N35", "N36", "N37", "N38", "N39", "N40", "N41", "N42", "N43", "N44", "N45",
        "G46", "G47", "G48", "G49", "G50", "G51", "G52", "G53", "G54", "G55", "G56", "G57", "G58", "G59", "G60",
        "O61", "O62", "O63", "O64", "O65", "O66", "O67", "O68", "O69", "O70", "O71", "O72", "O73", "O74", "O75"};

        List<string> calledBalls = new List<string>();
        bool results = false;
        int num;

        public BingoCaller()
        {
            CallBalls(balls,results,calledBalls, num);
        }

        public void CallBalls(string[] balls,bool results, List<string> calledBalls, int num)
        {
            Random random= new Random();
            int counter = 0;
            num = random.Next(75);
            
            while(results != true || counter < 75)
            {

                while (calledBalls.Contains(balls[num]))
                {
                    num = random.Next(75);

                }
                
                calledBalls.Add(balls[num]);
                Console.WriteLine(calledBalls[counter]);
                
                counter++;
                
            }
        }

        public Boolean CheckforWin(bool results)
        {
            
            return results;
        }
    }
}
