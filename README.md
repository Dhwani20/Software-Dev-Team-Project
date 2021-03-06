# LAWKI: "Life as We Know It"
## by Dhwani Khatter - Dhwani20, Mario Ramirez - MiRamirezJr, Richard Li - rich4rdli, Josephina Hendrix - jrhendrix, Zachary Haney - zaha0077

### Description: 
LAWKI is a computer game meant to teach users about the natural sciences and encourage outdoor exploration. The game currently offers 5 characters to select from with information on biological organisms. Inside play mode, the user can move through the environment while their character's statistics change over time, distance, and based on the weather.
The game was created in Unity and is currently compatible with Mac. Later versions will be compatible with PC and Android.

### Organization of repo:
The project source code, assests, dependencies, and test cases are located on our GitHub page under LAWKI. This directory also contains compiled versions of the game for Mac and Windows located in folders LAWKI_Mac.app and LAWKI_PC.app, respectively. See directions below on how to run the executables. Documentation on how to initiate automatic testing of LAWKI in Unity is located in the TESTING.md file. 

### Build, Run, and Test code:
Building: Clone this repo and import LAWKI into Unity. Click File --> Build Setting. Select the intended platform and click Switch Platform if necessary. Then select Build. On the right hand side, specify the Target Platform. Select Build and Unity will compile a run file for the intended platform.

Running on Windows: After cloning this reqo, go to LAWKI/LAWKI_PC.app/ and run the Windows_LAWKI.exe application.

Running on Mac: After cloning this repo, open LAWKI/ in Finder and run the LAWKI_Mac.app application. Alter the graphics settings in Menu Configuration, as needed, and click play.

Testing: Refer to TESTING.md for instructions on how to test the LAWKI code in Unity.

### Auto Documentation:
The Auto Documentation PDF can be found in the repository in the folder AutoDocumentation.
1. Open the LAWKI folder in the repository in unity.
2. Through unity open the three scripts ManageChar, ShowPanels, and timer2 in Visual Studios.
2. Under the projects tab in visual studios ensure that in the build section the XML file documentation option is enabled.
3. build the project now in Visual Studios.
4. In the LAWKI folder go to the Temp/bin/Debug where you will find an XML file called Assembly-CSharp.
5. Open that XML file with Visual Studios and print it to a pdf file.

### CI System:
We did not use a CI system.
 
### Vision statement: 
In this project, we will be making an app that allows users to connect with not only other users, but also engage students to go outside and interact with their surroundings, as well as have fun while learning about the natural sciences.
To make learning about the natural sciences more effective and fun.

### Motivation: 
This app would be useful to educate students about the natural sciences and bring more students into STEM based studies.

### Usage Instructions
Option 1: After cloning this repository, load LAWKI project into Unity.
Option 2: Pull compilation files and run on appropriate system. Use LAWKI_Mac.exe for Mac and Windows_LAWKI.exe for Windows.

### Testing:
See TESTING.md for instructions on how to enable automated testing of system.

### Risks:
* It would take a lot of time to make and we potentially might not finish.
* Using new programming languages.
* No prior experience working with the people on the team.

### Dealing with the risk: 
This can be dealt with by creating a timeline and updating it at each milestone as well as working together in order to gain experience with working in a team and with different programming languages.

### List of requirements:
1. **(Estimate: 2hr)** As a teacher, I want helpful context so that my students can access information explaining the science used in the game.
2. **(Estimate: 6hr)** As a student, I want to be notified when in the vacinity of another player so that I can have the option to engage that player in competition. 
3. **(Estimate: 4hr)** As a student, I want a point system and character statistics so that I can track my progress and be more competative. 
4. **(Estimate: 5hr)** As a developer, I want to develop the wireframe of the components so that I can build the foundation of the graphic design. 
5. **(Estimate: 3hr)** As a developer, I want to establish mutation criteria so that I can establish when and how characters develop.  
6. **(Estimate: 4hr)** As a developer, I want to obtain and incorporate geographic data so that I can define the application's local environment. 

### Methodology: 
Agile

### Project Tracking software: 
[Trello](https://trello.com/b/oPpdoATT/software-dev-team-project)

### Project plan:
![project plan image](https://github.com/MiRamirezJr/Software-Dev-Team-Project/blob/master/Graphics/team%20project%20pictures/Project%20Plan.PNG)
