using BowlingGame.BizLogic.Games;
using System;
using System.Collections.Generic;

namespace BowlingGame.BizLogic
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("#===================================#");
            Console.WriteLine("# Welcome to Ten-Pins Bowling! #");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("#**** Pls note: the end of last frame (or between last frame and bonuses) needs to be indicated with '||'.#");
            Console.WriteLine("#====================================#");
            Console.WriteLine();

            List<string> inputList = new List<string>()
            {
                //"X|7/|9-|x|-8|8/|-6|x|X|X|",
                //"X|7/|9-|x|-8|8/|-6|x|X|X||",
                //"X|7/|9-|x|-8|8/|-6 |x|X|X||81",
                //"X|7/|9-|x|-8|8/|-6|x|X|X| ||81",
                //"9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||9",
                //"X|//|9-|x|-8|8/|-6|x|X|X||/1",
                "55|7/|9-|x|-8|8/|-6|x|X|X||XX ",
                " X|7/|9-|x|-8|8/|-6|x|X|X||XX ",
                //"xX|7/|9-|x|-8|8/|-6|x|X|X||XX",
                "X|7/|9-|x|-8|8/|-6|x|X|X||XX",
                //"X|7/|9-|x|-8|8/|-6|x|X|X||8/",
                "X|7/|9-|x|-8|8/|-6|x|X|X||81",
                "X|X|x|x|x|x|x|x|X|X||xx",
                "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||",
                "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5"
            };

            foreach (var input in inputList)
            {
                TenPinsGame game = new TenPinsGame();
                Console.WriteLine("Game{1}: {0}", input, inputList.IndexOf(input));
                Console.WriteLine("Score: " + game.ShowScore(input));
                Console.WriteLine("#=====#");
            }


            Console.WriteLine("Thank you for playing with us!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}
