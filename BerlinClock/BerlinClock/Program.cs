///<summary>
///This application generates the time according to the Berlin Clock
///there is  basic Berlin Clock implementation and a custom Berlin Clock implementation
///Basic Berlin Clock takes input time in 24 hour format and displays the time according to Berlin clock
///Custom Berlin Clock implementation takes input time in any valid DateTime format and displays output Berlin Clock time 
///based on user customizations like Show Seconds, Change Color Scheme, Display in 12 hour format
/// </summary>
/// <see cref="https://en.wikipedia.org/wiki/Mengenlehreuhr"/>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BerlinClock
{
    class Program
    {
        //first hour's row size
        const int ROW2_SIZE = 4;

        //first minutes row size
        const int ROW4_SIZE = 11;
        static void Main(string[] args)
        {
            TimeSpan tsInputTime;
            Console.WriteLine(Resources.strInput);
            string strChoice = Console.ReadLine();
            bool isBasicSelected = false;

            //regular expression to check if time is in 24 hour format
            string regexTime = "\\b([01]\\d|2[0-3])(\\:)([012345]\\d)(\\:)([012345]\\d)\\b";

            //check if basic clock selected or custom clock selected
            switch (strChoice)
            {
                case "1":
                    isBasicSelected = true;
                    break;
                case "2":
                    isBasicSelected = false;
                    break;
                default:
                    Console.WriteLine(Resources.strInvalidChoice);
                    Console.ReadKey();
                    return;
            }

            //basic berlin clock
            if (isBasicSelected)
            {
                //get input time
                Console.WriteLine(Resources.strBasicBerlinInput);                
                string strTime = Console.ReadLine();
                try
                {
                    bool isValidTime = Regex.IsMatch(strTime, regexTime);
                    //if valid time in 24 hour format
                    if (isValidTime && TimeSpan.TryParse(strTime, out tsInputTime))
                    {
                        isValidTime = TimeSpan.TryParse(strTime, out tsInputTime);
                        BasicBerlinClock objBerlinClock = new BasicBerlinClock(tsInputTime);
                        string strBerlinTime = objBerlinClock.GenerateBerlinClock();
                        Console.WriteLine(Resources.strBasicOutput + strBerlinTime);
                    }
                    else
                    {
                        Console.WriteLine(Resources.strInvalidBasicInput);
                    }                    
                }
                catch (Exception)
                {
                    Console.WriteLine(Resources.strError);
                }
            }
            //custom Berlin Clock
            else
            {
                DateTime dtInputTime= new DateTime();
                try
                {
                    //get input time
                    Console.WriteLine(Resources.strInputCustomTime);
                    string strInputTime = Console.ReadLine();

                    //validate input time as DateTime
                    while (!DateTime.TryParse(strInputTime, out dtInputTime))
                    {
                        Console.WriteLine(Resources.strInvalidCustomTime);
                        strInputTime = Console.ReadLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(Resources.strError);
                }

                //get the user to choose the customization 
                //any combination of customizations can be chosen
                StringBuilder sbMenu = new StringBuilder("\nInput the Menu number of the changes you want to make E.g. 2,3\n");
                sbMenu.Append("1 Change Color Scheme\n");
                sbMenu.Append("2 Show seconds in lamp\n");
                sbMenu.Append("3 Show in 12h format");

                bool blNewColorScheme = false;
                bool blShowSeconds = false;
                bool blShow12Hour = false;
                bool isChoiceValid = false;
                string[] strColors = { "Y", "R", "O" };
                while (!isChoiceValid)
                {
                    //get menu choices
                    Console.WriteLine(sbMenu.ToString());
                    string strMenuChoice = Console.ReadLine();
                    char[] chDelimiter = { ',' };
                    string[] strChoices = strMenuChoice.Split(chDelimiter, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strChoices)
                    {
                        switch (str)
                        {
                            //customize the color scheme
                            case "1":
                                {                                   
                                    blNewColorScheme = true;
                                    Console.WriteLine(Resources.strInputColors);
                                    isChoiceValid = true;
                                    string strColorScheme = Console.ReadLine();
                                    strColors = strColorScheme.Split(chDelimiter, StringSplitOptions.RemoveEmptyEntries);
                                    if (strColors.Length != 3)
                                    {
                                        isChoiceValid = false;
                                        Console.WriteLine(Resources.strInvalidColor);
                                    }
                                    break;
                                }
                            
                            //include full seconds depiction in clock
                            case "2":
                                {
                                    blShowSeconds = true;
                                    isChoiceValid = true;
                                    break;
                                }

                            //show time in 12 hour format
                            case "3":
                                {
                                    blShow12Hour = true;
                                    isChoiceValid = true;
                                    break;
                                }
                            default:
                                Console.WriteLine(Resources.strInvalidChoice);
                                isChoiceValid = false;
                                break;
                        }
                        if (!isChoiceValid)
                            break;
                    }
                }

                //generate berlin clock time
                CustomBerlinClock customClock = new CustomBerlinClock(dtInputTime, blNewColorScheme, blShowSeconds, blShow12Hour, strColors);
                string strCustomOutput = customClock.GenerateBerlinClock();
                if (blShow12Hour)
                    Console.WriteLine(Resources.str12HourDesc);
                if(blShowSeconds)
                {
                    Console.WriteLine(Resources.str24HourDesc);
                }
                Console.WriteLine("\nTime: " + strCustomOutput);
            }
            Console.ReadKey();
        }
    }
}
