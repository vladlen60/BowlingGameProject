using System;
using System.Collections.Generic;

namespace BowlingGame.BizLogic
{
    interface IGame
    {
        void ProcessGameData(string gameInput, List<Frame> framesList, int maxFrameNumber,
            int startingPinsNumber);

        int CalculateScore(int startingPinsNumber);

        int ShowScore(string gameInput);
    }
}
