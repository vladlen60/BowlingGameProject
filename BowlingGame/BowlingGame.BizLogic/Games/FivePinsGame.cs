using System;
using System.Collections.Generic;
using BowlingGame.BizLogic.Data;
using BowlingGame.BizLogic.Types;

namespace BowlingGame.BizLogic.Games
{
    public class FivePinsGame : IGame
    {
        private new const int MaxFramesNumber = 5;
        private new const int StartingPinsNumber = 5;
        private CommonGameData _data;
        private GameType Type;

        public FivePinsGame()
        {
            _data = new CommonGameData(MaxFramesNumber, StartingPinsNumber);
            Type = GameType.FivePins;
        }

        // TODO: Some code to calculate FivePins Game

        public void ProcessGameData(string gameInput, List<Frame> framesList, int maxFrameNumber, int startingPinsNumber)
        {
            // TODO: Do Something
        }

        public int CalculateScore(int startingPinsNumber)
        {
            int score = 0;
            return score;
        }

        public int ShowScore(string gameInput)
        {
            int score = 0;
            ProcessGameData(gameInput, _data.Frames, _data.MaxFramesNumber, _data.StartingPinsNumber);
            return score;
        }
    }
}
