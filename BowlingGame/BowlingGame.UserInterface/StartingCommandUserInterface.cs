using System;
using System.Collections.Generic;
using BowlingGame.BizLogic.Games;

namespace BowlingGame.UserInterface
{
    public static class StartingCommandUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do ('help' for Help)?");
                var command = Console.ReadLine().ToLowerInvariant();
                CommandRoute(command);
            }
        }


        public static void CommandLoopDBInput(List<string> inputList)
        {
            if (inputList == null || inputList.Count == 0)
            {
                Console.WriteLine("The game list provided is Empty.");
                CommandLoop();
            }
            else
            {
                foreach (var input in inputList)
                {
                    ScoreCommand(input);
                }

                CommandLoop();
            }
        }


        public static void CommandRoute(string command)
        {
            if (command.StartsWith("score"))
            {
                Console.WriteLine(">> Please enter your full game data: ");
                var gameInput = Console.ReadLine();

                ScoreCommand(gameInput);
            }
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }


        public static void ScoreCommand(string gameInput)
        {
            try
            {
                TenPinsGame game = new TenPinsGame();
                Console.WriteLine("Game: {0}", gameInput);
                Console.WriteLine("Score: " + game.ShowScore(gameInput));
                Console.WriteLine("#=====#");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }


        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine("The Game accepts the following commands:");
            Console.WriteLine();
            Console.WriteLine("Score - The score will required the input in the following format:");
            Console.WriteLine("   - each frame should be separated with single '|'");
            Console.WriteLine("   - the last frame should be ended with '||' (if there are any bonuses it should come between last frame and the bonus number)");
            Console.WriteLine("   - Strike is represented with 'X'");
            Console.WriteLine("   - Spare is represented with '/'");
            Console.WriteLine("   - miss is represented with '-|'");
            Console.WriteLine("   - no spaces is allowed");
            Console.WriteLine();
            Console.WriteLine("Help - Displays all accepted commands.");
            Console.WriteLine();
            Console.WriteLine("Quit - Exits the application");
        }

    }
}
