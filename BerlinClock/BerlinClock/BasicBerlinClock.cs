/// <summary>
/// This class calculates the time according to the original Berlin Clock 
/// for an input time in HH:ss:mm format (24 hout format)
/// Input time should be between 00:00:00 to 23:59:59
/// Y= Yellow; R= Red; O= Off
/// <example>Input:20:12:38 Output:Y RRRR OOOO YYOOOOOOOOO YYOO</example>
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    class BasicBerlinClock
    {
        StringBuilder sbTotalTime = new StringBuilder();
        protected TimeSpan tsTime;
        protected int secRowSize = 4;
        protected int secRowWeight = 5;

        protected int thirdRowSize = 4;
        protected int thirdRowWeight = 1;

        protected int fourthRowSize = 11;
        protected int fourthRowWeight = 5;

        protected int fifthRowSize = 4;
        protected int fifthRowWeight = 1;

        //color used for seconds depiction
        protected char chMainColor = 'Y';

        //color used for hours depiction
        protected char chSecColor = 'R';

        //color used for Off depiction
        protected char chOff = 'O';

        public BasicBerlinClock()
        {
            
        }
        public BasicBerlinClock(TimeSpan time)
        {
            tsTime = time;
        }

        /// <summary>
        /// This method calculates the time according to the original Berlin Clock 
        /// for an input time in HH:ss:mm format (24 hout format)
        /// </summary>
        /// <returns>Berlin clock time in string</returns>
        public virtual string GenerateBerlinClock()
        {
            try
            {
                //top row calculation
                //check if seconds value is odd or even
                if (tsTime.Seconds % 2 == 0)
                {
                    sbTotalTime.Append(chMainColor);
                }
                else
                {
                    sbTotalTime.Append(chOff);
                }
                sbTotalTime.Append(" ");

                //second and third row calc
                int secRowOnCount = tsTime.Hours / secRowWeight;
                int thirdRowOnCount = tsTime.Hours % secRowWeight;
                sbTotalTime.Append(chSecColor, secRowOnCount);
                sbTotalTime.Append(chOff, secRowSize - secRowOnCount);
                sbTotalTime.Append(" ");

                sbTotalTime.Append(chSecColor, thirdRowOnCount);
                sbTotalTime.Append(chOff, thirdRowSize - thirdRowOnCount);
                sbTotalTime.Append(" ");

                //fourth and fifth row calculation
                int fourthRowOnCount = tsTime.Minutes / fourthRowWeight;
                int fifthRowOnCount = tsTime.Minutes % fourthRowWeight;
                char[] fourthRowPattern = { chMainColor, chMainColor, chSecColor, chMainColor, chMainColor, chSecColor, chMainColor, chMainColor, chSecColor,chMainColor, chMainColor};
                sbTotalTime.Append(fourthRowPattern, 0, fourthRowOnCount);
                sbTotalTime.Append(chOff, fourthRowSize - fourthRowOnCount);
                sbTotalTime.Append(" ");

                sbTotalTime.Append(chMainColor, fifthRowOnCount);
                sbTotalTime.Append(chOff, fifthRowSize - fifthRowOnCount);
            }
            catch (Exception)
            {
            }
            return sbTotalTime.ToString();
        }

    }
}
