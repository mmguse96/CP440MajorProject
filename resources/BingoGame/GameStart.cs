using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoGame
{
    class GameStart
    {
        //creates new bingo card and caller objects
        public GameStart() 
        { 
            BCard card= new BCard();
            BingoCaller caller= new BingoCaller(card);
        }
    }
}
