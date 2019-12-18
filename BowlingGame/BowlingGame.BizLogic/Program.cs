using BowlingGame.BizLogic.Games;
using System;
using System.Collections.Generic;

namespace BowlingGame.BizLogic
{
    public static class Program
    {
        private static IGame Game { get; set; }

        private static void SetGame(string gameType)
        {
            gameType = gameType.Trim().ToLower();
            switch (gameType)
            {
                case "tenpins":
                    Game = new TenPinsGame();
                    break;
                case "fivepins":
                    Game = new FivePinsGame();
                    break;
                default:
                    throw new ArgumentException("Sorry, no such game supported.");
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Please specify game you want to play (FivePins, TenPins): ");
            string gameType = Console.ReadLine();

            Console.WriteLine("#===================================#");
            Console.WriteLine("# Welcome to Ten-Pins Bowling! #");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("#**** Pls note: the end of last frame (or between last frame and bonuses) needs to be indicated with '||'.#");
            Console.WriteLine("#====================================#");
            Console.WriteLine();

            List<string> inputList = new List<string>()
            {
                "55|7/|9-|x|-8|8/|-6|x|X|X||XX ",
                "X|7/|9-|x|-8|8/|-6|x|X|X||81",
                "X|X|x|x|x|x|x|x|X|X||xx",
                "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||",
                "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5"
            };

            foreach (var input in inputList)
            {
                SetGame(gameType);
                //TenPinsGame game = new TenPinsGame();
                Console.WriteLine("Game{1}: {0}", input, inputList.IndexOf(input));
                Console.WriteLine("Score: " + Game.ShowScore(input));
                Console.WriteLine("#=====#");
            }

            Console.WriteLine("Thank you for playing with us!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}
