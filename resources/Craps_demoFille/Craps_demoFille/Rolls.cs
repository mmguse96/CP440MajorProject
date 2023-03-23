using System;

namespace Craps_demoFille
{
    internal class Rolls
    {
        private Random rand;

        public Rolls()
        {
            rand = new Random();
        }

        public int die1 { get; set; }
        public int die2 { get; set; }

        public int RollDiec()
        {
            die1 = rand.Next(1, 7);
            die2 = rand.Next(1, 7);

            return die1 + die2;
        }
    }
}

