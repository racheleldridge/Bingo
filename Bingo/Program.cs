using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Program
    {
        //random value variable 
        public static Random r = new Random();
        //1 array to catch the bingo called numbers
        public static int[] callednumbers = new int[100];
        //the three people playing bingo
        public static int[] player1 = new int[10];
        public static int[] player2 = new int[10];
        public static int[] player3 = new int[10];
        //counts for each person
        public static int player1C = 0, player2C = 0, player3C = 0;
        //Main Method
        static void Main(string[] args)
        {
            //generate the cards for the players 
            GenerateCard(player1);
            GenerateCard(player2);
            GenerateCard(player3);
            //Printing the cards
            Console.WriteLine("This is player 1's card");
            PrintCard(player1);
            Console.WriteLine("This is player 2's card");
            PrintCard(player2);
            Console.WriteLine("This is player 3's card");
            PrintCard(player3);
            //making the randomised values 
            GenerateCard(callednumbers);
            //play bingo
            Bingo();
        }
        //This method prints the card of the array
        static void PrintCard(int[] numbers)
        {
            int[,] card;
            card = new int[1, 10];
            bool cardspaceassigned = false;
            foreach (int number in numbers)
            {
                for (int row = 0; row < card.Length; row++)
                {
                    for (int col = 0; col < card.GetLength(1); col++)
                    {
                        if (card[row, col] == 0)
                        {
                            card[row, col] = number;
                            cardspaceassigned = true;
                            break;
                        }
                    }
                    //end of row
                    if (cardspaceassigned)
                    {
                        break;
                    }
                }
            }
            for (int row = 0; row < card.GetLength(0); row++)
            {
                for (int col = 0; col < card.GetLength(1); col++)
                {
                    Console.Write("{0}\t", (card[row, col]));
                }
                Console.WriteLine();
            }
        }
        static void GenerateCard(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Randomise:
                int newnum = r.Next(1, 101);
                if (numbers.Contains(newnum))
                {
                    goto Randomise;
                }
                numbers[i] = newnum;
            }
        }
        static void Bingo()
        {
            for (int i = 0; i < callednumbers.Length; i++)
            {
                if (player1.Contains(callednumbers[i]))
                {
                    player1C++;
                    Console.WriteLine("Player 1 crossed off {0}", callednumbers[i]);
                }
                if (player2.Contains(callednumbers[i]))
                {
                    player2C++;
                    Console.WriteLine("Player 2 crossed off {0}", callednumbers[i]);
                }
                if (player3.Contains(callednumbers[i]))
                {
                    player3C++;
                    Console.WriteLine("Player 3 crossed off {0}", callednumbers[i]);
                }
                if (((player1C == 10) || (player2C == 10) || (player3C == 10)))
                {
                    break;
                }
            }
            Console.WriteLine("\nPlayer 1 got {0} numbers ticked off", player1C);
            Console.WriteLine("Player 2 got {0} numbers ticked off", player2C);
            Console.WriteLine("Player 3 got {0} numbers ticked off", player3C);

            Console.WriteLine("\n{0} Got BINGO!\n", WhoGotBingo(player1C, player2C, player3C));
        }
        private static string WhoGotBingo(int p1, int p2, int p3)
        {
            if (p1 == 10) return "Player 1";
            if (p2 == 10) return "Player 2";
            return "Player 3";
        }
    }
}
