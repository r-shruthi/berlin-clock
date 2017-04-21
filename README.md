# berlin-clock
Implementation of Berlin Clock

Run the file BerlinClock.exe

The following instructions appear on the terminal:
  Please input choice:
  1 = Basic Berlin Clock
  2 = Custom Berlin Clock

Enter 1 for a Basic Berlin Clock takes input time in 24 hour format and displays the time according to Berlin clock
Enter 2 for a Custom Berlin Clock implementation takes input time in any valid DateTime format and displays output Berlin Clock time 
based on user customizations like Show Seconds, Change Color Scheme, Display in 12 hour format

If you chose 1 for Basic Berlin Clock,
  Please input time in hh:mm:ss format

  Enter time in 24 hour format. E.g. 17:10:56

  Berlin Clock Time displayed as: Y RRRO RROO YYOOOOOOOOO OOOO

If you chose 2 for Custom Berlin Clock,
  Enter time. E.g. 4:35PM, 23:12:34, 12/12/2017 1:10AM
  
  Enter the time in any valid DateTime format E.g 4/21/2017 4:10PM

  Input the Menu number of the changes you want to make E.g. 2,3
  1 Change Color Scheme
  2 Show seconds in lamp
  3 Show in 12h format
  
  If you choose 1 as one of your choices,
    Enter Colour Scheme. E.g. G,B,O
    
    Enter the color scheme you want to use instead of default Y,R,O. In this example, G replaces Y; B replaces R; and O replaces O
    
  If you choose 2 as one of your choices,
    The berlin clock output explicitly displaying seconds shows the same number of lamps as the original berlin clock plus two rows at       the end for seconds. The last-but-one row has 11 lamps, each denoting 5 seconds. The last row has 4 lamps, each denoting 4 seconds
    
  If you choose 3 as one of your choices,
    The berlin clock output for 12 hour format has same number of lamps as the original plus a last row to denote AM/PM. Based on your       input color scheme, O indicates AM and Y indicates PM
