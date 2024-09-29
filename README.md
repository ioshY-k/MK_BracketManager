### Mario Kart Bracket Manager

This application serves as a simple manager for running a Mario Kart tournament bracket. features include:

- Tournaments for 8 to 32 contestants
- Automated Track selection for MKDD and MK8
- Option to use custom Track selection (therefore suitable for all kinds of racing games)
- Automated distribution of contestants from octalfinals to finals
- Automated adaption for number of races, allowing for tournaments of equal length (ca 1:30h) at every playercount
- Overview of upcoming races and current bracket at all times

## Installation

To install the bracket manager, just download the MK_BracketManager.exe file found in the MK_Bracketmanager directory

## Tournament setup

When opening the file, you will be asked several questions like contestant numbers, -names, track selection etc. These are self explainatory for the most. Just know that when selecting the game (MKDD or MK8) it only affects the offered default track selection. if you play with a custom selection or a non-Mario Kart racer, this choice doesn't matter. Also the number of tracks can not be altered, since the tournament always aims at 1:30h length and adapts it to the number of contestants,

## Games

The main menu starts up with a summary of the chosen tournament settings followed by a depiction of every upcoming game. A game will look as follows:

Game ID: 13 (Semifinals)
Courses: Marios Piste, Cheep-Cheep-Strand, Shy Guys Wasserfälle, Warios Goldmine, Wario-Abfahrt
Players: Mariofan, Bowserlover, Teampeach, Toadboy
Results: 0, 0, 0, 0

- The first line shows the GameID - the assigned number to that game - and the matchstate (octal/quarter/semi/finals).
- The second line includes the courses that will be played in that game.
- The third line depicts the Players participating in that game. If theres a name listed in every slot, that means the game is ready to be played and will show up in "games up next". in some cases, instead of a player the slots will show something like "game 13:1st". That means that the first place of the game with ID 13 will participate in this slot. It updates once game 13 results have been entered.
- The fourth line shows the resulting placements (1,2,3,4) of the players in the line above after finishing the game. If the game has not been entered yet, it shows 0,0,0,0.

## Main menu

The menu shows three options:
- Show the games that are up next
	- this opens a seperate list of matches, which filters all the ones that can not be played or already have been played.
	- It is used to quickly be able to call out who's next
- Show the whole Bracket
	- this shows every game
	- it can be used to get an overview of matches left or which participants are already assigned to which future slots
- Update the score on a game
	- this is used to enter the score of a finished game.
	- when asked "Which game do you want to update?", input the corresponding number
	- when "Placement (number '1 - 4') for Mariofan" is displayed, type in a number between 1 and 4 corresponding to the position that Mariofan resulted in for that Game (only relative positions to other participants matter. There is no difference for a Player to be 3rd or 1st in a race if he came in before the other participants). Repeat for every participant. Once all are entered you will be led back to the main menu with the updated results displayed in the bracket


