using System;
using System.Collections;

namespace RockPaperScissors
{
    class Program
    {
        static int PlayerScore = 0;
        static int ComputerScore = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors");
            Console.WriteLine();
            Console.WriteLine("You'll be facing off against the computer. First to 3 wins!");
            Console.WriteLine();
            Console.WriteLine("Press 'Enter' when you are ready to begin");
            string userInput = Console.ReadLine();
            if (userInput == "")
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("Please press 'Enter' to begin");
            }
        }

        public static string NamePrompt(string prompt)
        {
            Console.Write(prompt);
            string name = Console.ReadLine();
            return name;
        }

        static void StartGame()
        {
            string playerName = NamePrompt("What is your name?");

            while (PlayerScore < 3 && ComputerScore < 3)
            {
                Console.WriteLine($@"
  /$$$$$$                                                /$$$$$$$                                      /$$
 /$$__  $$                                              | $$__  $$                                    | $$
| $$  \__/  /$$$$$$$  /$$$$$$   /$$$$$$   /$$$$$$       | $$  \ $$  /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$$
|  $$$$$$  /$$_____/ /$$__  $$ /$$__  $$ /$$__  $$      | $$$$$$$  /$$__  $$ |____  $$ /$$__  $$ /$$__  $$
 \____  $$| $$      | $$  \ $$| $$  \__/| $$$$$$$$      | $$__  $$| $$  \ $$  /$$$$$$$| $$  \__/| $$  | $$
 /$$  \ $$| $$      | $$  | $$| $$      | $$_____/      | $$  \ $$| $$  | $$ /$$__  $$| $$      | $$  | $$
|  $$$$$$/|  $$$$$$$|  $$$$$$/| $$      |  $$$$$$$      | $$$$$$$/|  $$$$$$/|  $$$$$$$| $$      |  $$$$$$$
 \______/  \_______/ \______/ |__/       \_______/      |_______/  \______/  \_______/|__/       \_______/

[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]

| {playerName.Trim()} : {PlayerScore} | Computer: {ComputerScore} |

            ");

                Console.WriteLine("What would you like to throw?");
                Console.WriteLine("1) Rock");
                Console.WriteLine("2) Paper");
                Console.WriteLine("3) Scissors");
                int throwNum = 0;
                try
                {
                    string throwThis = Console.ReadLine();
                    throwNum = int.Parse(throwThis);
                    if (throwNum < 1 || throwNum > 3)
                    {
                        Console.WriteLine("Invalid selection. Please enter a number between 1 and 3.");
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine($"{playerName} throws: ");
                    Console.WriteLine(DisplaySelection(throwNum));
                    UpdateScores(throwNum);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }
            }

            if (PlayerScore == 3)
            {
                Console.WriteLine("Congratulations on your victory!");
                Console.WriteLine("The final score is: " + PlayerScore + " - " + ComputerScore);
            }
            else
            {
                Console.WriteLine("Better luck next time.");
                Console.WriteLine("The final score is: " + PlayerScore + " - " + ComputerScore);
            }
        }

        static void UpdateScores(int playerThrow)
        {
            int computerThrow = GetComputerThrow();
            Console.WriteLine("Computer throws:");
            Console.WriteLine(DisplaySelection(computerThrow));
            if (playerThrow == computerThrow)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((playerThrow == 1 && computerThrow == 3) ||
                     (playerThrow == 2 && computerThrow == 1) ||
                     (playerThrow == 3 && computerThrow == 2))
            {
                Console.WriteLine("You win this round!");
                PlayerScore++;
            }
            else
            {
                Console.WriteLine("Computer wins this round!");
                ComputerScore++;
            }

            Console.WriteLine();
            Console.WriteLine("Press 'Enter' to continue.");
            Console.ReadLine();
        }

        static int GetComputerThrow()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }

        static string DisplaySelection(int selection)
        {
            var throwOptions = new ArrayList();
            throwOptions.Add(@"
                _______
            ---'   ____)
                  (_____)
                  (_____)
                  (____)
            ---.__(___)
            ");
            throwOptions.Add(@"
                 _______
            ---'    ____)____
                       ______)
                      _______)
                     _______)
            ---.__________)            
            ");
            throwOptions.Add(@"
                _______
            ---'   ____)____
                      ______)
                   __________)
                  (____)
            ---.__(___)
            ");
            string selected = (string)throwOptions[selection - 1];
            return selected;
        }
    }
}