using BowlingGame.BizLogic.Data;
using System;
using System.Collections.Generic;

namespace BowlingGame.BizLogic.Repositories
{
    public class Calculate
    {

        /// <summary>
        /// Calculates the Total score for the whole game/line.
        /// </summary>
        /// <param name="framesList"></param>
        /// <param name="startingPinsNumber"></param>
        /// <returns>Total score value for the whole game.</returns>
        public int CalculateScore(List<Frame> framesList, int startingPinsNumber)
        {
            if (startingPinsNumber <= 0)
            {
                throw new ArgumentException($"The number of starting pins {startingPinsNumber} is out of range.");
            }

            int score = 0;
            foreach (var frame in framesList)
            {
                int frameIndex = framesList.IndexOf(frame);
                if (!frame.IsFinalFrame && frame.IsStrike)
                {
                    if (framesList[frameIndex + 1].ThrowsList.Count == 1)
                        score += startingPinsNumber + framesList[frameIndex + 1].ThrowsList[0] + framesList[frameIndex + 2].ThrowsList[0];
                    else if (framesList[frameIndex + 1].ThrowsList.Count == 2 || framesList[frameIndex + 1].ThrowsList.Count == 3)
                        score += startingPinsNumber + framesList[frameIndex + 1].ThrowsList[0] + framesList[frameIndex + 1].ThrowsList[1];
                }
                else if (!frame.IsFinalFrame && frame.IsSpare)
                {
                    score += startingPinsNumber + framesList[frameIndex + 1].ThrowsList[0];
                }
                else if (frame.IsFinalFrame && (frame.IsStrike || frame.IsSpare))
                {
                    score += CalculateBonusScore(startingPinsNumber, frame);
                }
                else
                {
                    score += frame.ThrowsList[0] + frame.ThrowsList[1];
                }
            }

            return score;
        }


        /// <summary>
        /// Calculates the score for the bonus part
        /// </summary>
        /// <param name="startingPinsNumber"></param>
        /// <param name="lastFrame"></param>
        /// <returns>Score for the bonus part of the game</returns>
        internal int CalculateBonusScore(int startingPinsNumber, Frame lastFrame)
        {
            int score = 0;
            if (lastFrame.IsFinalFrame && lastFrame.IsStrike)
            {
                score += startingPinsNumber + lastFrame.ThrowsList[1] +
                         lastFrame.ThrowsList[2];
            }
            else if (lastFrame.IsFinalFrame && lastFrame.IsSpare)
            {
                score += startingPinsNumber + lastFrame.ThrowsList[1];
            }

            return score;
        }

    }
}
