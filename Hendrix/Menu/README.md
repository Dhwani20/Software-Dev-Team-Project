Menu

DESCRIPTION:
Full Unity project for Game.apk. Application demonstrates the framework of our application with a working menu and play scene. The scene contains a timer, weather changing simulator, and a virtual joystick that are all described in the game README.
In addition, Menu contains the scripts needed to transition between scens (DontDestroy.cs so assets are preserved between scenes, LoadOnClick.cs to load a scene, QuitApplication to exit the game, ShowPanels.cs to orchestrate when various screens should be viewed, etc.) along with scripts needed for our map feature. GoogleMap.cs obtains a map based on the latitude and longitude. MoveMap.cs moves the map under the player so the map can be continuously updated and the player object does not fall off the edge of the play area or require walls to contain movement.

KNOWN ISSUES:
The map updates are very slow and not continuous (the map jumps a large distance with every key press).
At this time, we are unable to obtain latitude and longitude data from a mobile devise and movement is dependent on the vertical and horizontal instructions provided by keyboard arrow keys. 
The quit buttons are unreliable and redundant

FUTURE DIRECTIONS:
Allow the user to choose a character before entering game mode.
Add stats to our characters.
Find a faster method of updating the map.
Use buttons or joystick to move character in order to test functionality on a mobile phone.

Developed with Unity
Intended for Android; Currently requires a keyboard
REFERENCES:
	Unity tutorials
	Game Jam Template for menu
	Stack Overflow
	Free open source images
