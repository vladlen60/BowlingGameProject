using System;
using BowlingGame.BizLogic.Data;
using BowlingGame.BizLogic.Games;
using BowlingGame.BizLogic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.BizLogicTest.IntegrationTests
{
    [TestClass]
    public class TenPinsGameTest
    {

        #region Possitive Tests

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests Strike on the Final frame and 2 Bonuses.")]
        public void TestsGameWithStrikeOnTheFinalFrameAndTwoBonusThrows()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X||81";
            int expectedScore = 167;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests Spare on the Final frame and 1 Bonus.")]
        public void TestsGameWithSpareOnTheFinalFrameAndOneBonusThrows()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|2/||8";
            int expectedScore = 150;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests regular game without any Bonuses.")]
        public void TestsGameWithoutAnyBonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|2-||";
            int expectedScore = 126;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests game when every Frame has one miss.")]
        public void TestsGameWhenEveryFrameHasOneMiss()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||";
            int expectedScore = 90;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests game when every throw is a Strike.")]
        public void TestsGameWhenEveryThrowIsStrike()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|X|x|x|x|x|x|x|X|X||xx";
            int expectedScore = 300;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests game when every frame has a Spare.")]
        public void TestsGameWhenEveryFrameHasSpare()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5";
            int expectedScore = 150;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests game when every Frame is a miss.")]
        public void TestsGameWhenEveryFrameIsAMiss()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "--|--|--|--|--|--|--|--|--|--||";
            int expectedScore = 0;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests game with Zero instead of Miss char.")]
        public void TestsGameZeroInsteadOfMissChar()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "90|9-|9-|9-|9-|9-|9-|9-|9-|90||";
            int expectedScore = 90;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests Game input with leading and trailing white spaces.")]
        public void TestsGameInputWithLeadingAndTrailingWhiteSpaces()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = " X|7/|9-|x|-8|8/|-6|x|X|X||81 ";
            int expectedScore = 167;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
        

        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests Game input with white spaces before the Bonus.")]
        public void TestsGameInputWithWhiteSpaceBeforeBonus()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X|| 81";
            int expectedScore = 167;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        [TestMethod]
        [Priority(1)]
        [TestCategory("PositiveCases")]
        [Description("Tests Game input with white spaces before the Final-Frame Divider ('||').")]
        public void TestsGameInputWithWhiteSpaceBeforeFinalFrameDivider()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X ||81";
            int expectedScore = 167;

            //-- Act
            int actualScore = game.ShowScore(gameInput);

            //-- Assert
            Assert.AreEqual(expectedScore, actualScore);
        }


        #endregion


        #region Negative Tests

        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with Strike on the Final frame and Number of Bonuses Over allowed.")]
        public void TestsFailedOnGameWithStrikeOnTheFinalFrameAndNumberOfBonusesOverAllowed()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X||8x1";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The number of bonus throws 3, is over allowed for the Last Strike. Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }

        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with Spare on the Final frame and 2 Bonuses.")]
        public void TestsFailedWithSpareOnTheFinalFrameAndTwoBonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|9/||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The number of bonus throws 2, is over allowed for the Last Spare. Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with Strike on the Final frame and No Bonuses.")]
        public void TestsFailedWithStrikeOnTheFinalFrameAndNoBonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|x||";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("You're missing the bonus points. Pls check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with Spare on the Final frame and No Bonuses.")]
        public void TestsFailedWithSpareOnTheFinalFrameAndNoBonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|9/||";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("You're missing the bonus points. Pls check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game without Strike or Spare on the Final frame but with Bonuses.")]
        public void TestsFailedWithoutStrikeOrSpareOnTheFinalFrameButWithBonuses()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|9-||8";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("You're trying to add a Bonus, while it's not allowed based on your last throw. Pls. check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the InvalidOperationException");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with 2 Strikes on the Same frame.")]
        public void TestsFailedOnGameWithTwoStrikesOnTheSameFrame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "Xx|7/|9-|x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Your Knocked down Pins count of 20 is out of range for StartingPinsNumber of '10'. Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with a Spare on the First Throw of the frame.")]
        public void TestsFailedOnGameWithSpareOnTheFirstThrowOfTheFrame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|//|9-|x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the ArgumentOutOfRangeException");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with letter character ('O') for the throw.")]
        public void TestsFailedOnGameWithLetterCharForTheThrow()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9O|x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid character 'O' was detected in the provided input, please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with a white space for the throw.")]
        public void TestsFailedOnGameWithWhiteSpaceForTheThrow()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-| x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid character ' ' was detected in the provided input, please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with special character for the throw.")]
        public void TestsFailedOnGameWithSpecialCharForTheThrow()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X||8!";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid character '!' was detected in the provided input, please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with more than 2 throws for the frame.")]
        public void TestsFailedOnGameWithTooManyThrowsForTheFrame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|713|9-|x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("You have too many throws (3) for one (non-final) Frame. Pls check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with too little throws on the frame.")]
        public void TestsFailedOnGameWithTooLittleTrowsOnTheFrame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9|18|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("It looks you're missing a throw for the frame.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with too little throws on the frame, and followed by the Strike.")]
        public void TestsFailedOnGameWithTooLittleTrowsOnTheFrameAndFollowedByStrike()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9|x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("It looks you're missing a throw for the frame.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with too many frames for a single game.")]
        public void TestsFailedOnGameWithTooManyFrames()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|71|3-|9-|x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("You specified 11 frames, which is more than allowed # of 10. Please check your input.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with too little frames for a single game (missing '|').")]
        public void TestsFailedOnGameWithTooLittleFrames()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|xX|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("You played 9 turns, which is less than required # of 10. Please check your input.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with Knocked-down pins count more than StartingPinsNumber.")]
        public void TestsFailedOnGameWithKnowckedDownPinsHigherThanStartingPins()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|92|x|-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Your Knocked down Pins count of 11 is out of range for StartingPinsNumber of '10'. Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with missing Final-Frame Divider ('||').")]
        public void TestsFailedOnGameWithMissingFinalFrameDivider()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|9-";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The frames data has to end with '||' (divider between frames and bonus throws). Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with Frames Divider ('|') instead of Final-Frame Divider ('||').")]
        public void TestsFailedOnGameWithFrameDividerInstaedOfFinalFrameDivider()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|9-|";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The frames data has to end with '||' (divider between frames and bonus throws). Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with Frames Divider ('|') instead of Final-Frame Divider ('||'), while with Bonus.")]
        public void TestsFailedOnGameWithFrameDividerInsteadOfFinalFrameDividerWithBonus()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X|81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The frames data has to end with '||' (divider between frames and bonus throws). Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with an Empty frame.")]
        public void TestsFailedOnGameWithAnEmptyFrame()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-||-8|8/|-6|x|X|X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The '||' divider can be only one per the input. Please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on CalculateScore method when StartingPinsNumber is 0.")]
        public void TestsFailedToCalculateWhenStartingPinsNumberIsZero()
        {
            //-- Arrange
            Calculate _calculate = new Calculate();
            int startingPinsNumber = 0;
            CommonGameData data = new CommonGameData(10, 10);

            try
            {
                _calculate.CalculateScore(data.Frames, startingPinsNumber);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The number of starting pins 0 is out of range.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }



        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on ShowScore method when input is Null.")]
        public void TestsFailedToShowScoreWhenInputIsNull()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = null;

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on ShowScore method when input is Empty.")]
        public void TestsFailedToShowScoreWhenInputIsEmpty()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = string.Empty;

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game with No Frames Dividers at all ('|').")]
        public void TestsFailedOnGameWithNoFrameDividersAtAll()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X;7/;9-;x;-8;8/;-6;x;X;X||81";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Your input does not have any frames devider '|'. Pls check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game when Spare set on Bonus throw.")]
        public void TestsFailedOnGameWhenSpareSetOnBonusThrow()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X||8/";

            try
            {
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The 'Spare' cannot be set on the Bonus Throws, please check.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game when MaxFramesNumber is Zero.")]
        public void TestsFailedWhenMaxFramesNumberIsZero()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X||81";
            CommonGameData data;

            try
            {
                data = new CommonGameData(0, 10);
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("MaxFrameNumber and StartingPinsNumber has to be higher than 0.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }


        [TestMethod]
        [Priority(2)]
        [TestCategory("NegativeCases")]
        [Description("Tests Failed on game when StartingPinsNumber is Zero.")]
        public void TestsFailedWhenStartingPinsNumberIsZero()
        {
            //-- Arrange
            TenPinsGame game = new TenPinsGame();
            string gameInput = "X|7/|9-|x|-8|8/|-6|x|X|X||81";
            CommonGameData data;

            try
            {
                data = new CommonGameData(10, 0);
                game.ShowScore(gameInput);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("MaxFrameNumber and StartingPinsNumber has to be higher than 0.", ex.Message);
                return;
            }
            Assert.Fail("Call did NOT throw the Argument Exception");
        }







        #endregion


        #region DataDrivenTest
        public TestContext TestContext { get; set; }

        [TestMethod]
        [Ignore()]
        [DataSource("System.Data.SqlClient",
            "Server=(localdb)\\MSSQLLocalDB;Database=DevEvaluation;Integrated Security=true",
            "tests.BowlingGameTest",
            DataAccessMethod.Sequential)]
        public void GamesFromDB_Test()
        {
            string gameInput;
            int expectedValue;
            bool causesException;

            gameInput = TestContext.DataRow["GameInput"].ToString();
            expectedValue = Convert.ToInt32(TestContext.DataRow["ExpectedValue"]);
            causesException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);

            TenPinsGame game = new TenPinsGame();


            try
            {
                var actualValue = game.ShowScore(gameInput);
                Assert.AreEqual(expectedValue, actualValue,
                    $"The Game: '{gameInput}', has following Actual Score: {actualValue}");
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(causesException);
            }
        }

        #endregion


    }
}
