﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoGame
{
    class BingoCard
    {
        string[,] bingoCard =
                {
                {" "," "," "," "," " },
                {" "," "," "," "," " },
                {" "," "," "," "," " },
                {" "," "," "," "," " },
                {" "," "," "," "," " },

        };

        public BingoCard()
        {
            //disabled to gen static cards
            GenCard(bingoCard);

        }

        public string[,] getBingoCard()
        {
            return bingoCard;
        }

        public static void GenCard(string[,] bingoCard)
        {
            HashSet<int> bingoNumbers = new HashSet<int>();

            //create random object
            Random ranNumber = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {


                    if (i == 2 && j == 2)
                    {
                        bingoCard[i, j] = "X";
                    }

                    //B
                    else if (j == 0)
                    {
                        int num = ranNumber.Next(1, 16);

                        while (bingoNumbers.Contains(num))
                        {

                            num = ranNumber.Next(1, 16);

                        }
                        string b = "B" + num;
                        bingoCard[i, j] = b;
                        bingoNumbers.Add(num);
                    }

                    //I
                    else if (j == 1)
                    {
                        int num = ranNumber.Next(16, 31);

                        while (bingoNumbers.Contains(num))
                        {

                            num = ranNumber.Next(16, 31);

                        }
                        string I = "I" + num;
                        bingoCard[i, j] = I;
                        bingoNumbers.Add(num);
                    }

                    //N
                    else if (j == 2)
                    {
                        int num = ranNumber.Next(31, 45);

                        while (bingoNumbers.Contains(num))
                        {

                            num = ranNumber.Next(31, 46);

                        }
                        string N = "N" + num;
                        bingoCard[i, j] = N;
                        bingoNumbers.Add(num);
                    }

                    //G
                    else if (j == 3)
                    {
                        int num = ranNumber.Next(46, 61);

                        while (bingoNumbers.Contains(num))
                        {

                            num = ranNumber.Next(46, 61);

                        }
                        string g = "G" + num;
                        bingoCard[i, j] = g;
                        bingoNumbers.Add(num);
                    }

                    //O
                    else if (j == 4)
                    {
                        int num = ranNumber.Next(61, 76);

                        while (bingoNumbers.Contains(num))
                        {

                            num = ranNumber.Next(61, 76);

                        }
                        string o = "O" + num;
                        bingoCard[i, j] = o;
                        bingoNumbers.Add(num);

                    }
                }
            }
            return;
        }

        public void Display()
        {
            Console.WriteLine(bingoCard[0, 0] + " " + bingoCard[0, 1] + " " + bingoCard[0, 2] + " " + bingoCard[0, 3] + " " + bingoCard[0, 4]);
            Console.WriteLine(bingoCard[1, 0] + " " + bingoCard[1, 1] + " " + bingoCard[1, 2] + " " + bingoCard[1, 3] + " " + bingoCard[1, 4]);
            Console.WriteLine(bingoCard[2, 0] + " " + bingoCard[2, 1] + " " + bingoCard[2, 2] + " " + bingoCard[2, 3] + " " + bingoCard[2, 4]);
            Console.WriteLine(bingoCard[3, 0] + " " + bingoCard[3, 1] + " " + bingoCard[3, 2] + " " + bingoCard[3, 3] + " " + bingoCard[3, 4]);
            Console.WriteLine(bingoCard[4, 0] + " " + bingoCard[4, 1] + " " + bingoCard[4, 2] + " " + bingoCard[4, 3] + " " + bingoCard[4, 4]);
            //Console.Read();
        }

        //test cases 
        //Horizontal seems to work
        string[,] bingoCardHozLine1 =
                {
                {" X "," X "," X "," X "," X " },
                {" X "," O "," O "," X "," O " },
                {" O "," X "," X "," O "," X "  },
                {" O "," O "," O "," O "," O "  },
                {" X ", " O ", "X ", " O ", " O "},

        };
        string[,] bingoCardHozLine2 =
                {
                {" X "," O "," O "," O "," X "  },
                {" X "," X "," X "," X "," X " },
                {" O "," X "," X "," O "," O "  },
                {" O "," O "," O "," O "," O "  },
                {" X "," O "," O "," X "," O "  },

        };
        string[,] bingoCardHozLine3 =
                {
                {" X ", " X ", " O ", " X ", " O "},
                {" O "," O "," O "," O "," O "},
                {" X "," X "," X "," X "," X "},
                {" O ", " O ", " O ", " O ", " O "},
                {" O ", " O ", " X ", " O ", " X "},

        };
        string[,] bingoCardHozLine4 =
                {
                {" X ", " O ", " O ", " X ", " O "},
                {" O ", " O ", " O ", " X ", " O "},
                {" O ", " X ", " O ", " O ", " O "},
                {" X "," X "," X "," X "," X "},
                {"X ", " O ", " O ", " X ", " O "},

        };
        string[,] bingoCardHozLine5 =
                {
                {" X ", " O ", " X ", " O ", " O "},
                {" O ", " O ", " O ", " O ", " X "},
                {" O ", " X ", " O ", " O ", " O "},
                {" O ", " X ", " X ", " O ", " X "},
                {" X "," X "," X "," X "," X "  },

        };
        //works
        string[,] bingoCardVertLine1 =
                {
                {" X ", " O ", " X ", " O ", " O "},
                {" X ", " O ", " O ", " O ", " X "},
                {" X ", " X ", " O ", " O ", " O "},
                {" X ", " X ", " X ", " O ", " X "},
                {" X "," X "," X "," X "," O "  },

        };
        //works
        string[,] bingoCardVertLine2 =
                {
                {" O", " X ", " X ", " O ", " O "},
                {" X ", " X ", " O ", " O ", " X "},
                {" X ", " X ", " O ", " O ", " O "},
                {" O ", " X ", " X ", " O ", " X "},
                {" X "," X "," X "," O "," X "  },

        };
        //doesnt work when in actual game so sometimes
        string[,] bingoCardVertLine3 =
                {
                {" X ", " O ", " X ", " O ", " O "},
                {" O ", " O ", " X ", " O ", " X "},
                {" X ", " X ", " X ", " O ", " O "},
                {" X ", " X ", " X ", " O ", " X "},
                {" X "," O "," X "," X "," X "  },

        };
        //works
        string[,] bingoCardVertLine4 =
                {
                {" X ", " O ", " X ", " X ", " O "},
                {" X ", " O ", " O ", " X ", " X "},
                {" O ", " X ", " O ", " X ", " O "},
                {" X ", " X ", " X ", " X ", " X "},
                {" X "," X "," O "," X "," X "  },

        };
        //works
        string[,] bingoCardVertLine5 =
                {
                {" X ", " O ", " X ", " O ", " X "},
                {" X ", " O ", " O ", " O ", " X "},
                {" X ", " X ", " O ", " X ", " X "},
                {" O ", " X ", " X ", " O ", " X "},
                {" X "," O "," X "," X "," X " },

        };

        string[,] bingoCardDia1 =
                {
                {" X ", " O ", " X ", " O ", " X "},
                {" X ", " O ", " O ", " X ", " X "},
                {" X ", " X ", " X ", " X ", " X "},
                {" O ", " X ", " X ", " O ", " X "},
                {" X "," O "," X "," X "," O " },

        };
        //doesnt work in game
        string[,] bingoCardDia2 =
                {
                {" X ", " O ", " X ", " O ", " X "},
                {" X ", " X ", " O ", " O ", " X "},
                {" X ", " X ", " X ", " X ", " X "},
                {" O ", " X ", " X ", " X ", " O "},
                {" X "," O "," X "," X "," X " },

        };

    }
}
