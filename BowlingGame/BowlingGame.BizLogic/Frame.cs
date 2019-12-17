using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.BizLogic
{
    public class Frame
    {
        public List<int> ThrowsList = new List<int>();
        public int KnockedDownPinsCount { get; set; }
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }
        public bool IsFinalFrame { get; set; }
        public bool IsBonusAllowed { get; set; }
        public bool IsFrameOver { get; set; }
        public int StartingPinsNumber { get; set; }


        public Frame(bool isFinalFrame, int startingPinsNumber = 0)
        {
            this.IsFinalFrame = isFinalFrame;
            this.StartingPinsNumber = startingPinsNumber;
        }         
    }
}
