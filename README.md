
# berlin-clock
Implementation of Berlin Clock

This application generates the time according to the Berlin Clock. There is  basic Berlin Clock implementation and a custom Berlin Clock implementation. Basic Berlin Clock takes input time in 24 hour format and displays the time according to Berlin clock. Custom Berlin Clock implementation takes input time in any valid DateTime format and displays output Berlin Clock time based on user customizations requests like Show Seconds, Change Color Scheme, Display in 12 hour format

**To execute**
Run the file BerlinClock.exe

The following instructions appear on the terminal:

  _Please input choice:_
  
  _1 = Basic Berlin Clock_
   
  _2 = Custom Berlin Clock_

Enter 1 for a Basic Berlin Clock takes input time in 24 hour format and displays the time according to Berlin clock.

Enter 2 for a Custom Berlin Clock implementation

**If you chose 1 for Basic Berlin Clock**

_Please input time in hh:mm:ss format_

Enter time in 24 hour format. E.g. 17:10:56

Berlin Clock Time displayed as: Y RRRO RROO YYOOOOOOOOO OOOO


**If you chose 2 for Custom Berlin Clock**

_Enter time. E.g. 4:35PM, 23:12:34, 12/12/2017 1:10AM_
  
Enter the time in any valid DateTime format E.g 4/21/2017 4:10PM


_Input the Menu number of the changes you want to make E.g. 2,3_

_1 Change Color Scheme_

_2 Show seconds in lamp_

_3 Show in 12h format_
  

**If you choose 1 as one of your choices,**
_Enter Colour Scheme. E.g. G,B,O_
    
Enter the color scheme you want to use instead of default Y,R,O. In this example, G replaces Y; B replaces R; and O replaces O
    

**If you choose 2 as one of your choices,**
    
The berlin clock output explicitly displaying seconds shows the same number of lamps as the original berlin clock plus two rows at       the end for seconds. The last-but-one row has 11 lamps, each denoting 5 seconds. The last row has 4 lamps, each denoting 4 seconds
    

**If you choose 3 as one of your choices,**

The berlin clock output for 12 hour format has same number of lamps as the original plus a last row to denote AM/PM. Based on your       input color scheme, O indicates AM and Y indicates PM
