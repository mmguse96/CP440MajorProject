using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BingoCard card = new BingoCard();
            card.Display();
            BingoCaller caller = new BingoCaller();

        }
    }
}
