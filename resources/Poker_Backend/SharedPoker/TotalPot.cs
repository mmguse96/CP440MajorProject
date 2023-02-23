namespace TotalPot.SharedPoker{
    // here I am creating the Poker Pot
        public class Pot{
            public PotHash<string> Players {get; set;} = new PotHash<string>();
            public int PotTotal {get; set;}
            public string Winner {get; set;}
        }
}