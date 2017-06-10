using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Mastermind.Tests
{
    [TestFixture]
    class MastermindTests
    {
        [Test]
        public void ShouldCanaryTest()
        {
            Assert.True(true);
        }

        [Test]
        public void ShouldMatchPlayerFiveGuesses()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] selectedColors = new Colors[5] { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple };
            mastermind.SetColorSelection(selectedColors);

            Response[] response = mastermind.Guess(selectedColors);
            Response[] expected = new Response[] { Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION };

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void ShouldNotMatchAnyPlayerGuesses()
        {
            Mastermind mastermind = new Mastermind();
            
            mastermind.SetColorSelection(Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple);

            Response[] response = mastermind.Guess(Colors.Orange, Colors.Gray, Colors.White, Colors.Yellow, Colors.Black);

            Assert.False(response.All<Response>( r => r == Response.MATCH_POSITION));
        }

        [Test]
        public void MatchAllColorsWrongPositions()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] selectedColors = new Colors[5] { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple };
            mastermind.SetColorSelection(selectedColors);

            Response[] response = mastermind.Guess(Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple, Colors.Red);
            Response[] expected = new Response[] { Response.MATCH_COLOR, Response.MATCH_COLOR, Response.MATCH_COLOR, Response.MATCH_COLOR, Response.MATCH_COLOR };

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void Match2Positions2Colors()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] selectedColors = new Colors[5] { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple };
            mastermind.SetColorSelection(selectedColors);

            Response[] response = mastermind.Guess(Colors.Red, Colors.Green, Colors.Pink, Colors.Black, Colors.Purple);
            Response[] expected = new Response[] { Response.MATCH_POSITION, Response.MATCH_COLOR, Response.MATCH_COLOR, Response.NO_MATCH, Response.MATCH_POSITION };

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void SameColorTwiceOneIsCorrect()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] selectedColors = new Colors[5] { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple };
            mastermind.SetColorSelection(selectedColors);

            Response[] response = mastermind.Guess(Colors.Gray, Colors.Red, Colors.Yellow, Colors.Red, Colors.Orange);
            Response[] expected = new Response[] { Response.NO_MATCH, Response.MATCH_COLOR, Response.NO_MATCH, Response.NO_MATCH, Response.NO_MATCH };

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void SameColorTwiceOnePositionIsCorrectBothColorsCorrect()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] selectedColors = new Colors[5] { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Red };
            mastermind.SetColorSelection(selectedColors);

            Response[] response = mastermind.Guess(Colors.Gray, Colors.Red, Colors.Yellow, Colors.Orange, Colors.Red);
            Response[] expected = new Response[] { Response.NO_MATCH, Response.MATCH_COLOR, Response.NO_MATCH, Response.NO_MATCH, Response.MATCH_POSITION };

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void SameColorTwiceBothPositionsAreCorrect()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] selectedColors = new Colors[5] { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Red };
            mastermind.SetColorSelection(selectedColors);

            Response[] response = mastermind.Guess(Colors.Red, Colors.Gray, Colors.Yellow, Colors.Orange, Colors.Red);
            Response[] expected = new Response[] { Response.MATCH_POSITION, Response.NO_MATCH, Response.NO_MATCH, Response.NO_MATCH, Response.MATCH_POSITION };

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void OnlyFourGuesses()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] selectedColors = new Colors[5] { Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Red };
            mastermind.SetColorSelection(selectedColors);

            Response[] response = mastermind.Guess(Colors.Red, Colors.Gray, Colors.Yellow, Colors.Orange);
            Response[] expected = new Response[] { Response.MATCH_POSITION, Response.NO_MATCH, Response.NO_MATCH, Response.NO_MATCH, Response.NO_MATCH };

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void PlayerWinsAfter5Tries()
        {
            Mastermind mastermind = new Mastermind();

            mastermind.SetColorSelection(Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple);

            Response[] response = new Response[5];
            Response[] expected = new Response[] { Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION };

            bool gameWon = false;
            int roundCount = 0;

            for (int i = 0; i < 20 && !gameWon; i++)
            {
                roundCount = i + 1;

                if(roundCount == 5)
                {
                    response = mastermind.Guess(Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple);
                }
                else
                {
                    response = mastermind.Guess(Colors.Orange, Colors.Gray, Colors.White, Colors.Yellow, Colors.Black);
                }

                bool allMatch = true;

                for(int j = 0; j < 5 && allMatch; j++)
                {
                    if (response[j] != expected[j])
                    {
                        allMatch = false;
                    }
                }

                if(allMatch)
                {
                    gameWon = true;
                }
            }

            Assert.True(gameWon && (roundCount == 5));
        }

        [Test]
        public void PlayerLosesAfter20Tries()
        {
            Mastermind mastermind = new Mastermind();

            mastermind.SetColorSelection(Colors.Red, Colors.Blue, Colors.Green, Colors.Pink, Colors.Purple);

            Response[] response = new Response[5];
            Response[] expected = new Response[] { Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION, Response.MATCH_POSITION };

            bool gameWon = false;
            int roundCount = 0;

            for (int i = 0; i < 20 && !gameWon; i++)
            {
                roundCount = i + 1;

                response = mastermind.Guess(Colors.Orange, Colors.Gray, Colors.White, Colors.Yellow, Colors.Black);
                if(response == expected)
                {
                    gameWon = true;
                }
            }

            Assert.True(!gameWon && (roundCount == 20));
        }


        [Test]
        public void RandomSolutionIsValid()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] colorSet = mastermind.SetColorSelection();

            List<Colors> allColors = new List<Colors>();
            for(int i = 0; i < Enum.GetNames(typeof(Colors)).Length; i++)
            {
                allColors.Add((Colors)i);
            }

            bool allValidColors = true;

            for(int i = 0; i < 5 && allValidColors; i++)
            {
                if(!allColors.Contains(colorSet[i]))
                {
                    allValidColors = false;
                }
            }

            Assert.True(allValidColors);
        }

        [Test]
        public void RandomSolutionEachTimeIsDifferent()
        {
            Mastermind mastermind = new Mastermind();

            Colors[] colorSet1 = mastermind.SetColorSelection();
            Colors[] colorSet2 = mastermind.SetColorSelection();

            bool solutionIsDifferent = true;


            for (int i = 0; i < 5 && solutionIsDifferent; i++)
            {
                if (colorSet1[i] != colorSet2[i])
                {
                    solutionIsDifferent = false;
                }
            }

            Assert.True(solutionIsDifferent);
        }
    }
}
