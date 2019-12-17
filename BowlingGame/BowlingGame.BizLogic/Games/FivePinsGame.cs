using System;
using System.Collections.Generic;
using BowlingGame.BizLogic.Data;
using BowlingGame.BizLogic.Repositories;
using BowlingGame.BizLogic.Utilities;

namespace BowlingGame.BizLogic.Games
{
    public class FivePinsGame : IGame
    {
        private new const int MaxFramesNumber = 5;
        private new const int StartingPinsNumber = 5;
        private CommonGameData _data;

        public FivePinsGame()
        {
            _data = new CommonGameData(MaxFramesNumber, StartingPinsNumber);
        }

        // TODO: Some code to calculate FivePins Game


        public int ShowScore(string gameInput)
        {
            // TODO: Do some coding here
            return 0;
            //ProcessGameData(gameInput, _data.Frames, _data.MaxFramesNumber, _data.StartingPinsNumber);
            //return CalculateScore(_data.StartingPinsNumber);
        }


        public void ProcessGameData(string gameInput, List<Frame> framesList, int maxFrameNumber, int startingPinsNumber)
        {
            // TODO: Do some codding here
        }

        public int CalculateScore(int startingPinsNumber)
        {
            int score = 0;
            return score;
        }
    }
}
