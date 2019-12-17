using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.BizLogic.Repositories
{
    public class GameRepository
    {
        /// <summary>
        /// Processes the data for the whole game. Adds new frame to the list as needed. 
        /// Call corresponding methods to: parse frame-string, set frame flags and add bonus value.
        /// </summary>
        /// <param name="framesStringsList"></param>
        /// <param name="framesList"></param>
        /// <param name="maxFramesNumber"></param>
        /// <param name="startingPinsNumber"></param>
        /// <param name="bonusString"></param>
        public void BuildAllFramesForTheGame(List<string> framesStringsList, List<Frame> framesList, int maxFramesNumber, int startingPinsNumber, string bonusString = null)
        {
            ValidateGameParameters(framesStringsList, framesList, maxFramesNumber, startingPinsNumber);

            foreach (var frame in framesStringsList)
            {
                if (!framesList.Any() || framesList.Last().IsFrameOver)
                {
                    var isFinalFrame = framesList.Count == maxFramesNumber - 1;
                    framesList.Add(new Frame(isFinalFrame, startingPinsNumber));
                }
                FrameRepository _framerepo = new FrameRepository();
                _framerepo.ProcessFrameStringIntoFrameProperties(frame, framesList, maxFramesNumber, startingPinsNumber);
            }

            if (framesList.Last().IsFinalFrame && (framesList.Last().IsStrike || framesList.Last().IsSpare))
                framesList.Last().IsBonusAllowed = true;

            AddBonusToTheLastFrame(framesList.Last(), startingPinsNumber, bonusString);
        }


        /// <summary>
        /// Process and add Bonus points to the Last Frame, if applicable.
        /// </summary>
        /// <param name="lastFrame"></param>
        /// <param name="startingPinsNumber"></param>
        /// <param name="bonusString"></param>
        private void AddBonusToTheLastFrame(Frame lastFrame, int startingPinsNumber, string bonusString = null)
        {
            if (string.IsNullOrWhiteSpace(bonusString) && lastFrame.IsBonusAllowed)
            {
                throw new ArgumentException("You're missing the bonus points. Pls check.");
            }
            else if (!string.IsNullOrWhiteSpace(bonusString) && !lastFrame.IsBonusAllowed)
            {
                throw new InvalidOperationException("You're trying to add a Bonus, while it's not allowed based on your last throw. Pls. check.");
            }
            else if (!string.IsNullOrWhiteSpace(bonusString) && lastFrame.IsBonusAllowed)
            {
                FrameRepository _framerepo = new FrameRepository();
                _framerepo.ProcessBonusStringToLastFrame(bonusString, lastFrame, startingPinsNumber);
            }                
        }


        /// <summary>
        /// Validate parameters of the game before processing.
        /// </summary>
        /// <param name="framesStringsList"></param>
        /// <param name="framesList"></param>
        /// <param name="maxFramesNumber"></param>
        /// <param name="startingPinsNumber"></param>
        private static void ValidateGameParameters(List<string> framesStringsList, List<Frame> framesList, int maxFramesNumber, int startingPinsNumber)
        {
            if (framesStringsList == null)
                throw new ArgumentNullException("framesStringsList cannot be Null.");
            if (framesList == null)
                throw new ArgumentNullException("framesList cannot be Null.");
            if (maxFramesNumber <= 0)
                throw new ArgumentException("MaxFramesNumber has to be higher than 0.");
            if (startingPinsNumber <= 0)
                throw new ArgumentException("StartingPinsNumber has to be higher than 0.");
        }
    }
}
