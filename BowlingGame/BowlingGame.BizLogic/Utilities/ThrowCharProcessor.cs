using System;

namespace BowlingGame.BizLogic.Utilities
{
    internal class ThrowCharProcessor
    {
        /// <summary>
        /// Processes given character (from the frame-string) into a corresponding digital value
        /// and adds the value to the throws list for the given frame.
        /// </summary>
        /// <param name="characterInString"></param>
        /// <param name="lastFrame"></param>
        /// <param name="startingPinsNumber"></param>
        internal void ConvertCharIntoDigitalValueForThrow(char characterInString, Frame lastFrame, int startingPinsNumber)
        {
            if (char.IsDigit(characterInString))
            {
                lastFrame.ThrowsList.Add((int)char.GetNumericValue(characterInString));
                var pinsCount = int.Parse(characterInString.ToString());
                return;
            }

            switch (char.ToUpperInvariant(characterInString))
            {
                case 'X':
                    lastFrame.ThrowsList.Add(10);
                    return;
                case '-':
                    lastFrame.ThrowsList.Add(0);
                    return;
                case '/':
                    if (lastFrame.IsFinalFrame && lastFrame.IsBonusAllowed)
                        throw new ArgumentException("The 'Spare' cannot be set on the Bonus Throws, please check.");

                    lastFrame.ThrowsList.Add(startingPinsNumber - lastFrame.ThrowsList[0]);
                    return;
                default:
                    throw new ArgumentException($"Invalid character '{characterInString}' was detected in the provided input, please check.");
            }
        }


        /// <summary>
        /// Process given character (from the frame-string) and set the throw type accordingly
        /// </summary>
        /// <param name="characterInString"></param>
        /// <param name="lastFrame"></param>
        internal void SetThrowTypeBasedOnThrowChar(char characterInString, Frame lastFrame)
        {
            if (char.ToUpperInvariant(characterInString) == 'X')
                lastFrame.IsStrike = true;
            else if (char.ToUpperInvariant(characterInString) == '/')
                lastFrame.IsSpare = true;
        }


        /// <summary>
        /// Process given character (from the frame-string) and set the throw type accordingly
        /// </summary>
        /// <param name="characterInString"></param>
        /// <param name="lastFrame"></param>
        internal void SetFrameClosedFlagBasedOnThrowChar(char characterInString, Frame lastFrame)
        {
            if (char.ToUpperInvariant(characterInString).Equals('X'))
                lastFrame.IsFrameOver = true;
            else if (char.ToUpperInvariant(characterInString).Equals('/'))
                lastFrame.IsFrameOver = true;
        }

    }
}
