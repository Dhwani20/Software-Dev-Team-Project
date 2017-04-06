**Who**: Dhwani Khatter, Josephina Hendrix, Mario Ramirez, Richard Li, Zachary Haney

**Title**: Life as We Know It

**Vision**: To make learning about the natural sciences more effective and fun

**Automated Tests**:

How To Replicate Testing:
1. Open unity and open project "LAWKI" (\Software-Dev-team-project\LAWKI).
2. Click on playerCanvas in the Hierarchy tab.
3. In the Inspector tab look for the "Show Panels", "Testing Sprites", and "Testing Timer" Scripts and make sure the Testing button in checked.
4. Click on Plane in the Hierarchy tab.
5. In the INspector tab look for the "Move Map" Script and make sure the Testing button in checked.
6. Open the "Console" window by going to Window>Console, this is where the success or fail messages will be displayed.
7. Clear the Console and press the play button in Unity.
8. As the game plays it you will see different features occur in the "Game" window and success/fail messages appear in the Console.
9. When the test are completed the game with exit and the console will still have the success/fail messages.

![Testing Outcome](https://github.com/MiRamirezJr/Software-Dev-team-project/blob/master/team%20project%20pics/testingOutput.PNG)

**User Acceptance Tests**:

Use case name

	Testing map movement
Description

	Moving the map around with arrow keys

Pre-conditions

	User has started the game

Test steps
  1. On start screen, begin game
  2. Use arrow keys to scroll map in respective directions


Expected result

	User should be able to traverse the map 
Actual result

	User is able to traverse map
Status (Pass/Fail)

	Pass
Notes

	N/A
Post-conditions

	User has successfully called Google Maps API to load new map elements into the game
	
___

Use case name
  
	Testing character selection
Description
	
	Testing if character selection works
Pre-conditions

	User has started game and is on the Player menu
Test steps
  1. User can use the number keys 1 through 6 to select a character
  2. Observe that each character should oscillate on the screen
  3. Observe that every character should have different stats, and that they should fluctuate in size 
  4. Observe that incorrect number key usage will result in an error icon
  
  
Expected result

	User is able to switch characters freely and observe fluctuating stat lines
Actual result

	User can select different characters, stats do fluctuate with time
Status (Pass/Fail)

	Pass
Notes

	N/A
Post-conditions
	
	
	Arrow keys are working
___
Use case name

	Testing changing weather
Description
	
	Change weather condition on main map
	
Pre-conditions

	User has started the game
Test steps
  1. Use the Q,W,E,R keys to change the weather observed on the map
  2. Test that Q is bound with the sun icon
  3. Test that W is bound with the clouds icon
  4. Test that E is bound with the raindrops icon
  5. Test that R is bound with the snowflake icon
  6. Observe that incorrect keyboard inputs will result in an error

Expected result

	Keyboard inputs change weather, incorrect input will result in error
Actual result

	Keyboard inputs correctly change weather icon on map, incorrect inputs result in an error message
Status (Pass/Fail)

	Pass
Notes

	N/A
Post-conditions
	
	Q, W, E, R keys are working


