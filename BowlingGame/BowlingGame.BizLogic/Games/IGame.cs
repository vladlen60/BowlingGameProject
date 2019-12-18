using BowlingGame.BizLogic.Data;
using System.Collections.Generic;

namespace BowlingGame.BizLogic.Games
{
    interface IGame
    {
        void ProcessGameData(string gameInput, List<Frame> framesList, int maxFrameNumber,
            int startingPinsNumber);

         int ShowScore(string gameInput);
    }
}
