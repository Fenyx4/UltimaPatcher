Congrats! You have Aradindae Dragon's Ultima 4 music patch V2.02.

Intstallation
This patch has three steps.
        1) unzip `U4SOUND.ZIP' into your ultima 4 directory.  
        2) run the program `SETUP.BAT'.  
        3) run `U4.BAT' and enjoy the tunes.

If you later want to change what music driver is used, then go through the
        installation starting with step 2.
If you never ever want to change the music drivers, run 'REMOVE.BAT'

Compatablity
My patch has been tested on
P120 w/DOS 5.00 -Worked perfectly.  --Aradindae Dragon
P120 w/WIN 3.1  -Worked somewhat.  I had to run Ultima 4 in exclusive and
        full screen mode.  I also had to set moslo up to 80%.  Want
        frustration? try running ultima4 with moslo at 1%.  All in all, I
        suggest exiting all the way to DOS to run U4, if you are running
        WIN 3.XX.  --Aradindae Dragon
486/33 w/WIN95  -Has same situation as trying to run it in Win 3.1, works
        patchily as long as you are in Windoze(music doesn't always play).
        Works perfectly in an exclusive DOS boot.  --Richard Kenan

My patch has not been tested on any other operating system not listed in the
previous section.

So if you use an OS that is not one of these, please report whether or not it worked, and
include your CPU type, your OS type, and any other notes, like "it worked
after I did such and such" or "It didn't work, and this is what I tried. . ."  


Reporting Bugs/Commenting/Suggestions/Questions
Did you find a bug? do like/hate what I did? is there something I can do to
improve it? do you want to tell me anything at all?
--A common bug should be playing music at the wrong time.  I did NOT
        extensively (aka play the entire game from start to finish, asking
        everyone everything) test it.  Should you encounter this bug, please
        tell me, and be as specific as possible.  eg: "I was speaking with
        Joe Shmuckatelli, in the town of Whereveriam, when it started playing 
        Sumtoon, after I asked him about doolahitchies."
Send me an email: draug@u.washington.edu


Known bugs/differences/quirks
        1) The music will end if you don't press a key.  (This should not be
           a problem if you are actively playing, but if you leave it running,
           then the music will eventually stop until you press a key)
        2) Death is NOT handled properly.  (actually, it doesn't even detect
           death, yet)
        3) This patch uses some the more advanced OpCodes.  (this means that
           it won't (or shouldn't) run on old machines like the 8088 or 8086)
           If this is really a problem, complain to me and maybe I'll make a
           more compatible version.
        4) The music sounds sort of...well...wrong in some places.  Some
           notes are to quiet when compared to the rest of the notes. (at
           least, it does on my system) this is most notable while shopping.
           If anyone reading this just happens to know how to program the
           midpak.ad file (I believe that it is a midi instrument patch map
           of some sort), please make one!

Features
I also added a few more keys :)
Alt-X:  quit to DOS
Alt-R:  reload saved game
Alt-Q:  Return to title screen
Alt-V:  Toggles music, off or on
Alt-'+':increase volume (this is not the numeric keypad '+')
Alt-'-':decrease volume (this is not the numeric keypad '-')

Do you like them?


Future Ideas/projects
Fixing bugs
Adding music to U3 and U5


Developement
V1.0    The first actual working version, lots of bugs
V1.01   Fixed a few bugs
V2.0    Fixed more bugs, (like the 'what the hell is LB saying' bug)
                for those interested, it was because I was pushed BP when I
                meant to push SP
        Added support for Combat, Shopping, and LB music
        Added Alt-V, Alt-'-', and Alt-'+'
V2.01   Plays correct music upon returning to the main screen
        Fixed bug-sound now stays off if you have turned it off
V2.02   Now plays town music when you enter Magincia

Acknowlegdments
KUDOS to SpiritWind, for info on the Atari version, some music, and
        encouragement,
     and Minstrel, for more and better music,
     and Wiltshire, for the nifty graphics and giving me the idea of adding
        music,
     and Blackmage, for just plain being interested,
     and The Audio Solution, inc; for their wonderful music interface,
     and anyone else that I just happend to forget!


Copyright/disclaimer stuff
First, this software is "Freeware."  This means that this software may be
distributed to anyone, anytime, with no restrictions.  Please feel free to
make copies and give them to your friends, or add it to your webpage, or
whatever.  Also, MIDPAK.COM and its associated files, is not "Freeware" like
mine.  If you intend to use it with a commercial product (not "Freeware" or
"Shareware") you must register it with The Audio Solution.  For more
information on MIDPAK or The Audio Solution, visit their Web Page.

As usual, I am not responsible for anything this does to you or your computer.


Technical junk
I programmed this entirely in Assembly Language, using Eric Isaacson's
assembler ver 3.22.  And yes, I am a little bit crazy.


Last words
For anyone so inclined, I will accept donations.
Make checks payable to "Ryan Wiener"
my address is
                McMahon Hall, Box 623
                Seattle, WA 98195

PS: Candy is dandy, but sex won't rot your teeth.  :)
