using BowlingGame.BizLogic.Types;
using System.Collections.Generic;

namespace BowlingGame.BizLogic.Data

{
    public class CommonGameData
    {
        public int MaxFramesNumber { get;}
        public int StartingPinsNumber { get; }
        public List<Frame> Frames { get; }
        public GameType Type { get; set; }

        public CommonGameData(int maxFramesNumber, int startingPinsNumber)
        {
            MaxFramesNumber = maxFramesNumber;
            StartingPinsNumber = startingPinsNumber;
            Frames = new List<Frame>();
        }
    }
}
