using System;
using BowlingGame.BizLogic.Types;
using System.Collections.Generic;

namespace BowlingGame.BizLogic.Data

{
    public class CommonGameData
    {
        public int MaxFramesNumber { get;}
        public int StartingPinsNumber { get; }
        public List<Frame> Frames { get; }

        public CommonGameData(int maxFramesNumber, int startingPinsNumber)
        {
            if (maxFramesNumber <= 0 || startingPinsNumber <= 0) throw new ArgumentException("MaxFrameNumber and StartingPinsNumber has to be higher than 0.");
            MaxFramesNumber = maxFramesNumber;
            StartingPinsNumber = startingPinsNumber;
            Frames = new List<Frame>();
        }
    }
}
