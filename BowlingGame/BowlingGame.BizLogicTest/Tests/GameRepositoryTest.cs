using System;
using System.Collections.Generic;
using BowlingGame.BizLogic.Data;
using BowlingGame.BizLogic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.BizLogicTest.Tests
{
    [TestClass]
    public class GameRepositoryTest
    {
        [TestMethod]
        [Description("Test should be successful while all values are correct.")]
        public void BuildAllFramesForTheGame_AllCorrectValues()
        {
            List<string> inputFrames = new List<string> { "X", "7/", "9-", "x", "-8", "8/", "-6", "x", "X", "X" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            int startingPinsNumber = 10;
            string bonusString = "81";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Description("Test should Not be successful if the input data is not defined.")]
        public void BuildAllFramesForTheGame_InputDataIsNotDefined()
        {
            List<string> inputFrames = null;
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            int startingPinsNumber = 10;
            string bonusString = "81";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);

            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the NullReference Exception");
        }

        [TestMethod]
        [Description("Test should Not be successful if the input data is Null.")]
        public void BuildAllFramesForTheGame_InputDataIsNull()
        {
            List<string> inputFrames = new List<string>();
            List<Frame> framesList = new List<Frame>();
            inputFrames = null;
            int maxFrameNumber = 10;
            int startingPinsNumber = 10;
            string bonusString = "81";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);

            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the NullReferenceException");
        }


        [TestMethod]
        [Description("Test should Not be successful if Frames List is Null")]
        public void BuildAllFramesForTheGame_FramesListIsNull()
        {
            List<string> inputFrames = new List<string> { "X", "7/", "9-", "x", "-8", "8/", "-6", "x", "X", "X" };
            List<Frame> framesList = null;
            int maxFrameNumber = 10;
            int startingPinsNumber = 10;
            string bonusString = "81";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);

            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the ArgumentNullException");
        }


        [TestMethod]
        [Description("Test should be successful when passing MaxFramesNumber as 0.")]
        public void BuildAllFramesForTheGame_MaxFrameNumberIsZero()
        {
            List<string> inputFrames = new List<string> { "X", "7/", "9-", "x", "-8", "8/", "-6", "x", "X", "X" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 0;
            int startingPinsNumber = 10;
            string bonusString = "81";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);
            }
            catch (Exception ex)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the Exception");

        }

        [TestMethod]
        [Description("Test should be successful if BonusString is Null")]
        public void BuildAllFramesForTheGame_BonusIsNull()
        {            
            List<string> inputFrames = new List<string> { "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            int startingPinsNumber = 10;
            string bonusString = null;

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Description("Test should be successful if BonusString is Empty")]
        public void BuildAllFramesForTheGame_BonusIsEmpty()
        {
            List<string> inputFrames = new List<string> { "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            int startingPinsNumber = 10;
            string bonusString = string.Empty;

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Description("Test should be successful if BonusString is WhiteSpace")]
        public void BuildAllFramesForTheGame_BonusIsWhiteSpace()
        {
            List<string> inputFrames = new List<string> { "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-", "9-" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            int startingPinsNumber = 10;
            string bonusString = " ";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [Description("Test should Not be successful when StartingPinsNumber is 0, and KnockedDownPinsNumber is not 0. It should thrown Argument Exception.")]
        public void BuildAllFramesForTheGame_StartingPinsNumberIsZero_ThrowArgumentException()
        {
            List<string> inputFrames = new List<string> { "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            int startingPinsNumber = 0;
            string bonusString = "5";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);

            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        [Description("Test should Not be successful when StartingPinsNumber is Negative value. It should thrown Argument Exception.")]
        public void BuildAllFramesForTheGame_StartingPinsNumberIsNegative__ThrowArgumentException()
        {
            List<string> inputFrames = new List<string> { "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            int startingPinsNumber = -1;
            string bonusString = "5";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, startingPinsNumber, bonusString);

            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        [Description("Test should Not be successful when StartingPinsNumber is of a String value. It should thrown the Format Exception.")]
        public void BuildAllFramesForTheGame_StartingPinsNumberIsString__ThrowArgumentException()
        {
            List<string> inputFrames = new List<string> { "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/", "5/" };
            List<Frame> framesList = new List<Frame>();
            int maxFrameNumber = 10;
            string bonusString = "5";

            try
            {
                GameRepository repo = new GameRepository();
                repo.BuildAllFramesForTheGame(inputFrames, framesList, maxFrameNumber, Convert.ToInt32("ten"), bonusString);

            }
            catch (FormatException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the Format Exception");
        }











    }
}
