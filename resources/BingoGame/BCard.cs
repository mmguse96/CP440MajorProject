using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoGame
{
    class BCard
    {
        List<int> bingoNumbers = new List<int>();//holds the already generated card numbers to prevent duplicates
        Cell[,] card = new Cell[5, 5]; //array for card
        bool bingo;
        
        
        public BCard()
        {
            //calls these methods when a new bingo card object is created
            genCard(card);
            Display();

        }

        //allows me to pass the generated card to other classes
        public Cell[,] getCard() { return card; }
       
        public void genCard(Cell[,] card)
        {
            //generates a random bingo card

            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 5; j++)
                {

                    //Assign the free space. 
                    if (i == 2 && j == 2)
                    {
                        card[i, j].cNumber = 0;
                        card[i, j].dabbed = true;
                    }

                    //Bs
                    else if (j == 0)
                    {
                        int num = genNumbers(1, 16);

                        while (bingoNumbers.Contains(num))
                        {

                            num = genNumbers(1, 16);

                        }

                        card[i, j].cNumber = num;
                        bingoNumbers.Add(num);
                    }

                    //I
                    else if (j == 1)
                    {
                        int num = genNumbers(16, 31);

                        while (bingoNumbers.Contains(num))
                        {

                            num = genNumbers(16, 31);

                        }

                        card[i, j].cNumber = num;
                        bingoNumbers.Add(num);
                    }

                    //N
                    else if (j == 2)
                    {
                        int num = genNumbers(31, 45);

                        while (bingoNumbers.Contains(num))
                        {

                            num = genNumbers(31, 46);

                        }

                        card[i, j].cNumber = num;
                        bingoNumbers.Add(num);
                    }

                    //G
                    else if (j == 3)
                    {
                        int num = genNumbers(46, 61);

                        while (bingoNumbers.Contains(num))
                        {

                            num = genNumbers(46, 61);

                        }

                        card[i, j].cNumber = num;
                        bingoNumbers.Add(num);
                    }

                    //O
                    else if (j == 4)
                    {
                        int num = genNumbers(61, 76);

                        while (bingoNumbers.Contains(num))
                        {

                            num = genNumbers(61, 76);

                        }

                        card[i, j].cNumber = num;
                        bingoNumbers.Add(num);

                    }
                }
            }
        }
       
        public void Display()
        {
            //displays the generated bingo card

            Console.WriteLine(card[0, 0].cNumber + " " + card[0, 1].cNumber + " " + card[0, 2].cNumber + " " + card[0, 3].cNumber + " " + card[0, 4].cNumber);
            Console.WriteLine(card[1, 0].cNumber + " " + card[1, 1].cNumber + " " + card[1, 2].cNumber + " " + card[1, 3].cNumber + " " + card[1, 4].cNumber);
            Console.WriteLine(card[2, 0].cNumber + " " + card[2, 1].cNumber + " " + card[2, 2].cNumber + " " + card[2, 3].cNumber + " " + card[2, 4].cNumber);
            Console.WriteLine(card[3, 0].cNumber + " " + card[3, 1].cNumber + " " + card[3, 2].cNumber + " " + card[3, 3].cNumber + " " + card[3, 4].cNumber);
            Console.WriteLine(card[4, 0].cNumber + " " + card[4, 1].cNumber + " " + card[4, 2].cNumber + " " + card[4, 3].cNumber + " " + card[4, 4].cNumber);

        }

        public int genNumbers(int num1, int num2)
        {
            //generates a random number for each bingo card cell
            Random ranNumber = new Random();
            int num = ranNumber.Next(num1, num2);
            return num;
        }

        public void CheckForNumber(BingoCaller cBalls)
        {
            
            //loops through the bingo card to see if the called number is on the card; 
            //turns the bool of Cell into true
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (card[i, j].cNumber == cBalls.GetCalledBalls())
                    {
                        Console.WriteLine("true");
                        card[i, j].dabbed = true;
                        Display();
                    }
                    
                }
            }

            CheckforWin(card);

            if (bingo == true )
            {
                cBalls.CallBingo(bingo);
            }

        }

        public Boolean CheckforWin(Cell[,] card)
        {
            //checks the bingo card cells for either Horizontal, vertical or diaganals of true booleans
            //horizontal check
            for (int i = 0; i < 5; i++)
            {
                bingo = true;
                for (int j = 0; j < 5; j++)
                {
                    
                    //if (card[i,j].dabbed == true) { Console.WriteLine("spot dabbed hCheck: " + card[i, j].cNumber); }
                    if (card[i,j].dabbed == false)
                    {
                        
                        bingo = false;
                        //Console.WriteLine("false");
                        break;
                    }
                }
                if (bingo == true)
                {
                    return true;
                }
            }

            if (!bingo)
            {
                //vertical check
                for (int i = 0; i < 5; i++)
                {
                    bingo = true;

                    for (int j = 0; j < 5; j++)
                    {
                        
                        //if (card[j,i].dabbed == true) { Console.WriteLine("spot dabbedvCheck: " + card[j, i].cNumber); }

                        if (card[j,i].dabbed == false)
                        {
                            
                            bingo = false;
                            //Console.WriteLine("false");
                            break;
                        }
                    }

                    if (bingo == true)
                    {
                        Console.WriteLine("True");
                        return true;
                    }
                }
            }
            if (!bingo)
            {
                //left diagonal
                for (int i = 0; i < 5; i++)
                {
                    bingo = true;
                  
                    //if (card[i, i].dabbed == true) { Console.WriteLine("spot dabbed lDiag:" + card[i, i].cNumber); }

                    if (card[i, i].dabbed == false)
                    {
                        
                        bingo = false;
                        //Console.WriteLine("false");
                        break;
                    }
                }

                if (bingo == true)
                {
                    Console.WriteLine("True");
                    return true;
                }
            }

            if (!bingo)
            {
                //right diagonal
                for (int i = 4; i >= 0; i--)
                {
                    bingo = true;
                    
                    //if (card[i, i].dabbed == true) { Console.WriteLine("spot dabbedrDia: " + card[i, i].cNumber); }

                    if (card[i,i].dabbed == false)
                    {
                        
                        bingo = false;
                        //Console.WriteLine("false");
                        break;
                    }

                }
                if (bingo == true)
                {
                    Console.WriteLine("True");
                    return true;
                }
            }
            return false;
        }
    
    }

    
    public struct Cell
        {
        //allows me to make a "3D" array of type int and bool
            public int cNumber;
            public bool dabbed;
        }
    }



