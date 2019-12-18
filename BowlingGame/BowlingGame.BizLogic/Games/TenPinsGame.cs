using System;
using System.Collections.Generic;
using BowlingGame.BizLogic.Utilities;
using BowlingGame.BizLogic.Repositories;
using BowlingGame.BizLogic.Data;

namespace BowlingGame.BizLogic.Games
{
    public class TenPinsGame : IGame
    {
        private const int MaxFramesNumber = 10;
        private const int StartingPinsNumber = 10;
        private readonly CommonGameData _data;
        private Calculate _calculate;

        public TenPinsGame()
        {
            _data = new CommonGameData(MaxFramesNumber, StartingPinsNumber);
            _calculate = new Calculate();
        }


        /// <summary>
        /// Gets game input string, call Calculation method and then return the total game score.
        /// </summary>
        /// <param name="gameInput"></param>
        /// <returns>Returns value from the CalculateScore method</returns>
        public int ShowScore(string gameInput)
        {
            if (string.IsNullOrWhiteSpace(gameInput)) throw new ArgumentNullException("The input is Null or Empty.");

            ProcessGameData(gameInput, _data.Frames, _data.MaxFramesNumber, _data.StartingPinsNumber);

            return _calculate.CalculateScore(_data.Frames, _data.StartingPinsNumber);
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
            GameInputParser _parser = new GameInputParser();
            string framesSubstring = _parser.SplitGameInputString(gameInput).NormalFramesPart;
            string bonusSubsctring = _parser.SplitGameInputString(gameInput).BonusThrowsPart;
            List<string> framesStringsList = _parser.SplitFramesString(framesSubstring);

            ValidateGame(framesStringsList, maxFrameNumber);

            GameRepository _gamerepo = new GameRepository();
            _gamerepo.BuildAllFramesForTheGame(framesStringsList, framesList, maxFrameNumber, startingPinsNumber, bonusSubsctring);
        }


        /// <summary>
        /// Validate generated Frames string-array.
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="maxFramesNumber"></param>
        private static void ValidateGame(List<string> frames, int maxFramesNumber)
        {
            if (frames.Count < maxFramesNumber)
            {
                throw new ArgumentException($"You played {frames.Count} turns, which is less than required # of {maxFramesNumber}. Please check your input.");
            }
            else if (frames.Count > maxFramesNumber)
            {
                throw new ArgumentException($"You specified {frames.Count} frames, which is more than allowed # of {maxFramesNumber}. Please check your input.");
            }
        }
    }
}
