using System;

namespace Craps_demoFille
{
    class Craps
    {
        //Declare and Define
        private enum dieSum { snakeEyes = 2, three = 3, seven = 7, eleven = 11, twelve = 12 }
        private enum GameStatus { win, lose, playAging }
        private enum Line { Pass, DontPass }

        private Rolls rolls;
        private Line line;
        private GameStatus gameStatus;
        private int numRolls;

        public int Sum { get; set; }
        public int Point { get; set; }

        public int Bet { get; set; }
        public int Bet2 { get; set; }

        public int allMon;
        public int betmon { get; set; }
        public string reset { get; set; }
        public string linebet { get; set; }




        public Craps()
        {
            rolls = new Rolls();
            gameStatus = GameStatus.playAging;
            numRolls = 1;


        }

        //run game  
        public void PlayGame()
        {


            while (gameStatus == GameStatus.playAging)
            {

                while (gameStatus == GameStatus.playAging)
                {
                    setBet();

                    Sum = rolls.RollDiec();

                    PassLine();
                    displayMess();




                    while (gameStatus == GameStatus.playAging)
                    {
                        ComeBet();
                        displayMess();

                        if (gameStatus == GameStatus.playAging)
                        {
                            moreBet();
                        }
                        else { }
                    }

                    moreGaming();
                }

            }
        }

        // win condition for first roll
        private void PassLine()
        {
            if (line == Line.Pass)
            {

                switch ((dieSum)Sum)
                {
                    case dieSum.seven:
                    case dieSum.eleven:
                        gameStatus = GameStatus.win;
                        Point = 0;
                        break;

                    case dieSum.snakeEyes:
                    case dieSum.three:
                    case dieSum.twelve:
                        gameStatus = GameStatus.lose;
                        Point = 0;
                        break;

                    default:
                        gameStatus = GameStatus.playAging;
                        Point = Sum;
                        break;

                }
            }
            else
            {
                switch ((dieSum)Sum)
                {
                    case dieSum.seven:
                    case dieSum.eleven:
                        gameStatus = GameStatus.lose;
                        Point = 0;
                        break;

                    case dieSum.snakeEyes:
                    case dieSum.three:
                    case dieSum.twelve:
                        gameStatus = GameStatus.win;
                        Point = 0;
                        break;

                    default:
                        gameStatus = GameStatus.playAging;
                        Point = Sum;
                        break;


                }
            }
        }

        //win condishon for all rolls after the first one 
        private void ComeBet()
        {
            Sum = rolls.RollDiec();
            if (Sum == Point)
            {
                gameStatus = GameStatus.win;
            }
            else if (Sum == 7)
            {
                gameStatus = GameStatus.lose;
            }
            else
            {

            }

        }

        // display outcome of roll
        private void displayMess()
        {
            switch (gameStatus)
            {
                case GameStatus.win:
                    Console.WriteLine("you rolled a {0}. you win", Sum);

                    allMon = allMon * 2;
                    Console.WriteLine("your Winings are {0}", allMon);


                    break;
                case GameStatus.lose:
                    Console.WriteLine("you rolled a {0}. you lose", Sum);
                    Console.WriteLine("you lost $ {0}", allMon);


                    break;
                default:
                    if (numRolls == 1)
                        Console.WriteLine("you rolled a {0} your point is {1}. ", Sum, Point);
                    else
                    {

                    }
                    break;
            }


        }

        // betting
        public void setBet()
        {
            Console.WriteLine("is this a Pass line[yes/no]");
            linebet = Console.ReadLine();
            Console.WriteLine("How much would you like your starter bet");
            Bet = Convert.ToInt32(Console.ReadLine());
            allMon = Bet;


            switch (linebet)
            {
                case "yes":
                    line = Line.Pass;

                    break;

            }

        }

        // betting for second loop
        public void moreBet()
        {
            Console.WriteLine(" how much do you want to rase ");
            Bet2 = Convert.ToInt32(Console.ReadLine());
            betmon = betmon + Bet2;
            allMon = betmon + Bet;

            Console.WriteLine(allMon);


        }
        //loop
        public void moreGaming()
        {
            Console.WriteLine("Play aging [yes/no]");
            reset = Console.ReadLine();

            switch (reset)
            {
                case "yes":
                    gameStatus = GameStatus.playAging;
                    betmon = 0;

                    break;

            }




        }
    }

}

