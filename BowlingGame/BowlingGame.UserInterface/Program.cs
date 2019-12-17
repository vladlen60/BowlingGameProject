using System;
using System.Collections.Generic;

namespace BowlingGame.UserInterface
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("#===================================#");
            Console.WriteLine("# Welcome to Ten-Pins Bowling! #");
            Console.WriteLine("#-----------------------#");
            Console.WriteLine("#**** Pls note: The input is expected to be in the certain format: ");
            Console.WriteLine("          - each frame is separated with '|' char;");
            Console.WriteLine("          - last frame in the game has '||' at the end of it(and before the bonus data);");
            Console.WriteLine(
                "          - defined characters are used to indicate different throws types('X' - Strike, '/' - Spare, '-' - miss);");
            Console.WriteLine("          - no spaces are allowed inside the input string;#");
            Console.WriteLine("#====================================#");
            Console.WriteLine();

            List<string> inputList = new List<string>()
            {
                "X|7/|9-|x|-8|8/|-6|x|X|X|",
                "X|7/|9-|x|-8|8/|-6|x|X|X||",
                "X|7/|9-|x|-8|8/|-6 |x|X|X||81",
                "X|7/|9-|x|-8|8/|-6|x|X|X| ||81",
                "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||9",
                "X|//|9-|x|-8|8/|-6|x|X|X||81",
                "X|7/|9-|x|-8|8/|-6|x|X|X||/1",
                "X|7/|9-|x|-8|8/|-6|x|X|X||8/",
                "X|7/|9-|x|-8|8/|-6|x|X|X||XX",
                "",
                "X|7/|9-|x|-8|8/|-6|x|X|X||81",
                "X|X|x|x|x|x|x|x|X|X||xx",
                "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||",
                "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5"
            };
            /// For Game from provided List
            StartingCommandUserInterface.CommandLoopDBInput(inputList);

            /// For manual input of each game
            StartingCommandUserInterface.CommandLoop();

            Console.WriteLine("Thank you for playing with us!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}