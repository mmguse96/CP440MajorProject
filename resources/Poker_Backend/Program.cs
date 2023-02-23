//using System;

namespace pokerGame{
    class NewPokerInstance{
        static void Main(string[] args) {
            
            // creating poker table
    
        }

        public class PokerTable{
            public int Id{get; set;}
            public string Name{get; set;}
            public int MaxPlayers {get; set;}
            public int SmallBlind{get; set;}
        }

        // here I am creating a 
        public class Pot{
            public PotHash<string> Players {get; set;} = new PotHash<string>();
            public PotTotal {get; set;}
        }
    }
}