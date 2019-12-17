using BowlingGame.BizLogic.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.BizLogic.Utilities
{
    internal class GameInputParser
    {
        /// <summary>
        /// Splits game-input string into 2 parts, based on the '||' divider char.
        /// </summary>
        /// <param name="gameInput"></param>
        /// <returns>Output that contains 2 parts (strings): Frames and Bonus-throws.</returns>
        internal GameParserType SplitGameInputString(string gameInput)
        {
            var output = new GameParserType();
            if (gameInput.Contains("||"))
            {
                var parts = gameInput.Split(new string[] { "||" }, StringSplitOptions.None);
                if (parts.Length > 2)
                    throw new ArgumentException($"The '||' divider can be only one per the input. Please check.");

                output.NormalFramesPart = parts[0].Trim();

                if (parts.Length == 2)
                    output.BonusThrowsPart = parts[1].Trim();
            }
            else
            {
                throw new ArgumentException($"The frames data has to end with '||' (divider between frames and bonus throws). Please check.");
            }
            return output;
        }

        /// <summary>
        /// Splits each frame in the string, based on the '|' divider char.
        /// </summary>
        /// <param name="framesString"></param>
        /// <returns>List of strings that represents the frames (not converted chars values).</returns>
        internal List<string> SplitFramesString(string framesString)
        {
            if (!framesString.Contains("|")) throw new ArgumentException("Your input does not have any frames devider '|'. Pls check.");

            List<string> framesStringsList = framesString.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return framesStringsList;
        }
    }
}
