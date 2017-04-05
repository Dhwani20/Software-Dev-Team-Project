Who: Dhwani Khatter, Josephina Hendrix, Mario Ramirez, Richard Li, Zachary Haney

Title: Life as We Know It

Vision: To make learning about the natural scienes more effective and fun

Automated Tests:

User Acceptance Tests:
1. The script, when attached to an object, (The provided scene contains such an object) will function as follows:

When the game is running, press any of the numbers 1-6* as inputs and the script will have the object switches to the corresponding sprite. Pressing an invalid key or an out of range number will display an error sprite.

It's simple, but it allows us to see that the sprites are indeed being loaded correctly.

---------------------
*Note that 1-6 refers to the alphanumeric 1-6 keys (the ones at the top of the keyboard), not the numpad

2. The game will display the longitudinal and latitudinal location of the player.

Using arrow keys, a player can move around the character and verify the success of the operation by observing the coordinates change. Each move should increment or decrement the coordinates by 10 to 20 degrees.  
