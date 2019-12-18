using System;
using System.Collections.Generic;
using System.Linq;
using BowlingGame.BizLogic.Data;
using BowlingGame.BizLogic.Utilities;

namespace BowlingGame.BizLogic.Repositories
{
    internal class FrameRepository
    {
        /// <summary>
        /// Processes each frame-string in the frames string-array, to determine the pins count for each frame
        /// and adds those values to the corresponding Frame (in the Frames List)
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="framesList"></param>
        /// <param name="maxFramesNumber"></param>
        /// <param name="startingPinsNumber"></param>
        internal void ProcessFrameStringIntoFrameProperties(string frame, List<Frame> framesList, int maxFramesNumber, int startingPinsNumber)
        {
            char[] frameCharArr = frame.ToCharArray();
            foreach (char c in frameCharArr)
            {
                ThrowCharProcessor _throwProcessor = new ThrowCharProcessor();
                _throwProcessor.ConvertCharIntoDigitalValueForThrow(c, framesList.Last(), startingPinsNumber);
                _throwProcessor.SetThrowTypeBasedOnThrowChar(c, framesList.Last());
                _throwProcessor.SetFrameClosedFlagBasedOnThrowChar(c, framesList.Last());
                SetIsOverFlagForTheFrame(framesList.Last());
                SetIsFinalFlagForTheFrame(framesList, maxFramesNumber);
                CalculateKnockedDownPins(framesList.Last(), startingPinsNumber);
            }

            ValidateFrame(framesList.Last());
        }


        /// <summary>
        /// Processes each char in the Bonus string, 
        /// and adds those values to the corresponding Throws (to the Last Frame)
        /// </summary>
        /// <param name="bonusString"></param>
        /// <param name="lastFrame"></param>
        /// <param name="startingPinsNumber"></param>
        internal void ProcessBonusStringToLastFrame(string bonusString, Frame lastFrame, int startingPinsNumber)
        {            
            if (!lastFrame.IsFinalFrame)
                throw new ArgumentException("It seems that you're trying to process Bonus while not on the Last Frame. Please check.");

            char[] bonusCharArr = bonusString.ToCharArray();
            ThrowCharProcessor _throwProcessor = new ThrowCharProcessor();
            if (lastFrame.IsStrike)
            {
                if (bonusCharArr.Length > 2)
                    throw new ArgumentException($"The number of bonus throws {bonusCharArr.Length}, is over allowed for the Last Strike. Please check.");

                foreach (char c in bonusCharArr)
                {
                    _throwProcessor.ConvertCharIntoDigitalValueForThrow(c, lastFrame, startingPinsNumber);
                }
            }
            else if (lastFrame.IsSpare)
            {
                if (bonusCharArr.Length != 1)
                    throw new ArgumentException($"The number of bonus throws {bonusCharArr.Length}, is over allowed for the Last Spare. Please check.");

                _throwProcessor.ConvertCharIntoDigitalValueForThrow(bonusCharArr[0], lastFrame, startingPinsNumber);
            }
        }

        /// <summary>
        /// Sets IsFinalFrame and IsFrameOver flags for a frame in the List
        /// </summary>
        /// <param name="lastFrame"></param>
        private void SetIsOverFlagForTheFrame(Frame lastFrame)
        {
            if (!lastFrame.IsFinalFrame)
            {
                if (lastFrame.ThrowsList.Count == 2)
                    lastFrame.IsFrameOver = true;
            }
        }

        /// <summary>
        /// Sets IsFinalFrame and IsFrameOver flags for a frame in the List
        /// </summary>
        /// <param name="framesList"></param>
        /// <param name="maxFrameNumber"></param>
        private void SetIsFinalFlagForTheFrame(List<Frame> framesList, int maxFrameNumber)
        {
            if (framesList.Count == maxFrameNumber)
                framesList.Last().IsFinalFrame = true;
        }


        /// <summary>
        /// Calculates all knocked down pins for the frame.
        /// </summary>
        /// <param name="lastFrame"></param>
        /// <param name="startingPinsNumber"></param>
        private static void CalculateKnockedDownPins(Frame lastFrame, int startingPinsNumber)
        {
            if (lastFrame.IsFrameOver)
            {
                if (lastFrame.ThrowsList.Count == 1) 
                    lastFrame.KnockedDownPinsCount = lastFrame.ThrowsList[0];
                else if (lastFrame.ThrowsList.Count == 2) 
                    lastFrame.KnockedDownPinsCount = lastFrame.ThrowsList[0] + lastFrame.ThrowsList[1];
                else throw new ArgumentException($"You have too many throws ({lastFrame.ThrowsList.Count}) for one (non-final) Frame. Pls check.");

                if (!lastFrame.IsFinalFrame && (lastFrame.KnockedDownPinsCount < 0 || lastFrame.KnockedDownPinsCount > startingPinsNumber))
                    throw new ArgumentException($"Your Knocked down Pins count of {lastFrame.KnockedDownPinsCount} " +
                                                $"is out of range for StartingPinsNumber of '{startingPinsNumber}'. Please check.");
            }
        }


        // NOTE: This one probably will not be necessary as it will capture the issue and throw an error in another parts of the code.
        /// <summary>
        /// Validates a frame for the adequate number of throws
        /// </summary>
        /// <param name="lastFrame"></param>
        private static void ValidateFrame(Frame lastFrame)
        {
            if (!lastFrame.IsFinalFrame && lastFrame.ThrowsList.Count <= 2)
                if (!lastFrame.IsStrike && !lastFrame.IsFrameOver)
                    throw new ArgumentException("It looks you're missing a throw for the frame.");
        }
    }
}
