///<summary>
///This class generates a customized Berlin Clock Time for an input time in any valid DateTime format
///
///If 12-hour output format is specified, then Lamp structure is similar to 
///original Berlin clock except for the addition of an extra row with one lamp to denote AM/PM.
///<example>Input:23:10:10 Output:Y RROO ROOO YYOOOOOOOOO OOOO Y </example>
///
///If colour scheme is chosen as G, B, R in the above example, 
///G replaces Y; B replaces R; and R replaces O
///<example>Input:23:10:10 Output:G BBRR BRRR GGRRRRRRRRR RRRR G</example>
///
///If show seconds is chosen then two rows depicting seconds in added after the minutes rows
///The last-but-one row has 11 lamps each denoting 5 seconds and last row has 4 lamps each denoting 1 second
///<example>Input:23:10:10 Output: Y RRRR RRRO YYOOOOOOOOO OOOO YYOOOOOOOOO OOOO</example>
///</summary>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock
{
    class CustomBerlinClock:BasicBerlinClock
    {
        DateTime dtInputTime;
        bool isNewColorScheme;
        bool isNewClock;
        bool isShowSeconds;
        string[] strColors;
        string amRow;
        public CustomBerlinClock(DateTime dtInputTime,bool isNewColorScheme, bool isShowSeconds, bool isNewClock, string[] strColors)
        {
            this.dtInputTime = dtInputTime;
            this.isNewColorScheme = isNewColorScheme;
            this.isNewClock = isNewClock;
            this.isShowSeconds = isShowSeconds;
            this.strColors = strColors;            
        }

        /// <summary>
        /// Generate the Berlin Clock Time based on the customizations specified by the user  
        /// </summary>
        /// <returns>Berlin Clock time in string</returns>
        public override string GenerateBerlinClock()
        {
            StringBuilder sbBerlinTime = new StringBuilder();
            try
            {
                //set the color according user input color scheme
                this.chMainColor = strColors[0].ToCharArray()[0];
                this.chSecColor = strColors[1].ToCharArray()[0];
                this.chOff = strColors[2].ToCharArray()[0];

                bool isValid;
                TimeSpan tsFormattedTime = new TimeSpan();

                //if 12-hour format is chosen for Berlin clock output
                //Lamp structure is similar to original Berlin clock except for the addition of an extra row
                //with one lamp to denote AM/PM.
                //However the time output is always between 12:00:00 AM to 11:59:59 PM
                if (isNewClock)
                {
                    string str12hour = dtInputTime.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
                    char[] chDelimiter = { ' ' };
                    string[] strChoices = str12hour.Split(chDelimiter, StringSplitOptions.RemoveEmptyEntries);
                    isValid = TimeSpan.TryParse(strChoices[0], out tsFormattedTime);

                    //if time is in AM, then output the Off color in last row
                    //else output the main color (yellow in original format) to last row
                    if (strChoices[1].ToLower() == "am")
                        amRow = chOff.ToString();
                    else
                        amRow = chMainColor.ToString();
                }
                else
                {
                    //format input time to 24 hour format
                    string str24hour = dtInputTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                    isValid = TimeSpan.TryParse(str24hour, out tsFormattedTime);
                }

                //call parent's GenerateBerlinClock()
                this.tsTime = tsFormattedTime;
                string strBerlinTime = base.GenerateBerlinClock();
                sbBerlinTime = new StringBuilder(strBerlinTime);

                //if seconds are to be displayed by Berlin Clock
                //Lamp structure is similar to original Berlin clock except for the addition of 2 extra rows
                //at bottom to denote seconds, similar to minutes calculation
                //The last but one row has 11 lamps each denoting 5 seconds and last row has 4 lamps each denoting 1 second
                if (isShowSeconds)
                {
                    sbBerlinTime.Append(" ");
                    int fourthRowOnCount = tsTime.Seconds / fourthRowWeight;
                    int fifthRowOnCount = tsTime.Seconds % fourthRowWeight;
                    char[] fourthRowPattern = { chMainColor, chMainColor, chSecColor, chMainColor, chMainColor, chSecColor, chMainColor, chMainColor, chSecColor, chMainColor, chMainColor };
                    sbBerlinTime.Append(fourthRowPattern, 0, fourthRowOnCount);
                    sbBerlinTime.Append(chOff, fourthRowSize - fourthRowOnCount);
                    sbBerlinTime.Append(" ");

                    sbBerlinTime.Append(chMainColor, fifthRowOnCount);
                    sbBerlinTime.Append(chOff, fifthRowSize - fifthRowOnCount);
                }

                if (isNewClock)
                {
                    sbBerlinTime.Append(" ");
                    sbBerlinTime.Append(amRow);
                }
            }
            catch (Exception)
            {

            }
            return sbBerlinTime.ToString();
        } 
    }
}
