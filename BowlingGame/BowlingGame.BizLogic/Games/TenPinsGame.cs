using System;
using System.Collections.Generic;
using BowlingGame.BizLogic.Utilities;
using BowlingGame.BizLogic.Repositories;
using BowlingGame.BizLogic.Data;
using BowlingGame.BizLogic.Types;

namespace BowlingGame.BizLogic.Games
{
    public class TenPinsGame : IGame
    {
        private const int MaxFramesNumber = 10;
        private const int StartingPinsNumber = 10;
        private readonly CommonGameData _data;

        public TenPinsGame()
        {
            _data = new CommonGameData(MaxFramesNumber, StartingPinsNumber);
        }


        /// <summary>
        /// Process all data from the game: 
        /// Call required parsing methods to process given data;
        /// Then call method to build the Frames List and set all the properties values accordingly.
        /// </summary>
        /// <param name="gameInput"></param>
        /// <param name="framesList"></param>
        /// <param name="maxFrameNumber"></param>
        /// <param name="startingPinsNumber"></param>
        public void ProcessGameData(string gameInput, List<Frame> framesList, int maxFrameNumber, int startingPinsNumber)
        {
            gameInput = gameInput.Trim();
            GameInputParser parser = new GameInputParser();
            string framesSubstring = parser.SplitGameInputString(gameInput).NormalFramesPart;
            string bonusSubsctring = parser.SplitGameInputString(gameInput).BonusThrowsPart;
            List<string> framesStringsList = parser.SplitFramesString(framesSubstring);

            ValidateGame(framesStringsList, maxFrameNumber);

            GameRepository gamerepo = new GameRepository();
            gamerepo.BuildAllFramesForTheGame(framesStringsList, framesList, maxFrameNumber, startingPinsNumber, bonusSubsctring);
        }


        /// <summary>
        /// Validate generated Frames string-array.
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="maxFramesNumber"></param>
        private static void ValidateGame(List<string> frames, int maxFramesNumber)
        {
            if (frames == null)
            {
                throw new ArgumentNullException("The frames list has not been defined.");
            }
            else if (frames.Count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frames));
            }
            else if (frames.Count < maxFramesNumber)
            {
                throw new ArgumentException($"You played {frames.Count} turns, which is less than required # of {maxFramesNumber}. Please check your input.");
            }
            else if (frames.Count > maxFramesNumber)
            {
                throw new ArgumentException($"You specified {frames.Count} frames, which is more than allowed # of {maxFramesNumber}. Please check your input.");
            }
        }


        /// <summary>
        /// Gets game input string, call Calculation method and then return the total game score.
        /// </summary>
        /// <param name="gameInput"></param>
        /// <returns>Returns value from the CalculateScore method</returns>
        public int ShowScore(string gameInput)
        {
            if (string.IsNullOrWhiteSpace(gameInput)) throw new ArgumentNullException("The input is Null or Empty.");
            if (_data.Frames == null) throw new ArgumentNullException("The List of Frames is Null.");

            ProcessGameData(gameInput, _data.Frames, _data.MaxFramesNumber, _data.StartingPinsNumber);

            return CalculateScore(_data.StartingPinsNumber); 
        }


        /// <summary>
        /// Calculates the Total score for the whole game/line.
        /// </summary>
        /// <param name="startingPinsCount"></param>
        /// <returns>Total score value for the whole game.</returns>
        public int CalculateScore(int startingPinsCount)
        {
            if (startingPinsCount <= 0)
            {
                throw new ArgumentException($"The number of starting pins {startingPinsCount} is out of range.");
            }

            int score = 0;
            foreach (var frame in _data.Frames)
            {
                int frameIndex = _data.Frames.IndexOf(frame);
                if (!frame.IsFinalFrame && frame.IsStrike)
                {
                    if (_data.Frames[frameIndex + 1].ThrowsList.Count == 1)
                        score += startingPinsCount + _data.Frames[frameIndex + 1].ThrowsList[0] + _data.Frames[frameIndex + 2].ThrowsList[0];
                    else if (_data.Frames[frameIndex + 1].ThrowsList.Count == 2 || _data.Frames[frameIndex + 1].ThrowsList.Count == 3)
                        score += startingPinsCount + _data.Frames[frameIndex + 1].ThrowsList[0] + _data.Frames[frameIndex + 1].ThrowsList[1];
                }
                else if (!frame.IsFinalFrame && frame.IsSpare)
                {
                    score += startingPinsCount + _data.Frames[frameIndex + 1].ThrowsList[0];
                }
                else if (frame.IsFinalFrame && (frame.IsStrike || frame.IsSpare))
                {
                    score += CalculateBonusScore(startingPinsCount, frame);
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
        /// <param name="startingPinsCount"></param>
        /// <param name="lastFrame"></param>
        /// <returns>Score for the bonus part of the game</returns>
        internal int CalculateBonusScore(int startingPinsCount, Frame lastFrame)
        {
            int score = 0;
            if (lastFrame.IsFinalFrame && lastFrame.IsStrike)
            {
                score += startingPinsCount + lastFrame.ThrowsList[1] +
                         lastFrame.ThrowsList[2];
            }
            else if (lastFrame.IsFinalFrame && lastFrame.IsSpare)
            {
                score += startingPinsCount + lastFrame.ThrowsList[1];
            }

            return score;
        }

    }
}
