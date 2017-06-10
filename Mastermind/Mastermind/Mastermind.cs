using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public enum Colors { Red, Blue, Yellow, Green, Purple, Orange, Pink, Black, White, Gray }
    public enum Response { MATCH_POSITION, MATCH_COLOR, NO_MATCH };

    public class Mastermind
    {
        public Colors[] solution;
        public static Random rnd1;
        public static int roundCount;
        public static int MaxColors = 5;

        public Mastermind()
        {
            solution = new Colors[5];
            rnd1 = new Random();
            roundCount = 0;
        }

        public Colors[] SetColorSelection()
        {
            for (int i = 0; i < MaxColors; i++)
            {
                solution[i] = (Colors)rnd1.Next(Enum.GetNames(typeof(Colors)).Length);
            }

            return (solution);
        }

        public Colors[] SetColorSelection(params Colors[] colors)
        {
            for( int i = 0; i < solution.Length; i++)
            {
                solution[i] = colors[i];
            }

            return (solution);
        }

        public Response[] Guess(params Colors[] selectedColors)
        {
            Response[] guessResults = new Response[MaxColors];

            List<Colors> colorsAvailable = new List<Colors>(solution).GetRange(0, MaxColors);
            List<int> guessesLeft = new List<int>();

            int colorsToCheck = selectedColors.Length < MaxColors ? selectedColors.Length : MaxColors;

            for (int i = 0; i < colorsToCheck; i++)
            {
                if (solution[i] == selectedColors[i])
                {
                    guessResults[i] = Response.MATCH_POSITION;
                    colorsAvailable.Remove(solution[i]);
                }
                else
                {
                    guessesLeft.Add(i);
                }
            }

            foreach(int n in guessesLeft)
            {
                if (colorsAvailable.Contains(selectedColors[n]))
                {
                    guessResults[n] = Response.MATCH_COLOR;
                    colorsAvailable.Remove(selectedColors[n]);
                }
                else
                {
                    guessResults[n] = Response.NO_MATCH;
                }

            }
                
            for (int i = colorsToCheck; i < MaxColors; i++)
            {
                guessResults[i] = Response.NO_MATCH;
            }
            return guessResults;
        }

    }
}
