
# Program Organization
Architecture Diagrams
<br>System Context Diagram:
<br/><img src = "/artifacts/C1.jpg">
<br/>This game is designed to be played by two people.
<br/>The game will be designed using Unity. 



<br/>Container Diagram:
<br/><img src = "/artifacts/C2.jpg">
<br/>Game: Two-dimensional grid with different strategic paths and environmental obstacles.
<br/>Player input: Each player takes turns in repositioning the monkeys during the game loop.
<br/>The Statistics of the characters are calculated in during each turn.
<br/>Scores can be calculated based on how many enemies monkeys are captured in the time it takes to capture a bandana.

<br/>The game ends when the captured ‘bandana’ is brought to the base or all the team members are eliminated.

<br/>Component Diagram:
<br/><img src = "/artifacts/C3.jpg">

<br/>The game is split into two major components, the Menu and the Game.
<br/>The Menu will provide options that allow access to the Game.
<br/>The Game will provide the option to continue to another game level or to end the game altogether. 

<br/>Features 2-5 involve the creation of the Main Menu. The rest of the user stories involve the creation of the Game.<br/>

# Major Classes
Class Diagrams
<br/>Main Menu Classes:
<br/><img src = "/artifacts/c4_classDiagram_MainM.png">

MainMenu()- (Feature 2)
* This class stores the functions of the Main Menu Screen.
<br/>OptionsScreen() - (Feature 3)
* This class stores the functions of the Options Screen.
<br/>CharacterSelect() - (Feature 5)
* This class stores the functions of the Character Select Screen.
<br/>LevelSelect() - (Feature 4) 
* This class stores the functions of the Level Select Screen.

<br/>Game Classes:
<br/><img src = "/artifacts/c4_classDiagram_Game.png">

Environment() - (Feature 16)
* This class stores classes and functions of objects in the environment.
<br/>Treebase() - (Feature 38)
* This class stores the functions of the Treehouse base
<br/>Barrel() - (Feature 36)
* This class stores the functions of the Monkey Barrel.
<br/>Mud() - (Feature 40c)
* This class stores the functions of the Mud environmental hazard.
<br/>River() - (Feature 40h)
* This class stores the functions of the River environmental hazard.
<br/>Vine() - (Feature 40g)
* This class stores the functions of the Vine object.
<br/>Bandana() - (Feature 37)
* This class stores the functions of the Bandana object.
<br/>CoconutCursor - (Feature 23)
* This class stores the functions of the Coconut Cursor
<br/>Grid() - (Feature 25)
* This class stores the functions of the Movement Grid.
<br/>Cover() - (Feature 40b)
* This class stores the cover function of Cover obstacles
<br/>Character()
* This class stores the functions of the characters
<br/>(Feature 29)
<br/>Weapon()
* This class stores the functions of Weapons.
<br/>Range()
* This class stores the long range functions of Attack Mode.
<br/>Melee()
* This class stores the short range functions of Attack Mode.
<br/>Pause Menu() - (Feature 6)
* This class stores the functions of the Pause Menu.
<br/>InGameOptions() - (Feature 7)
* This class stores the functions of the In-Game Options Menu.
<br/>InGameLevel() - (Feature 8)
* This class stores the functions of the In-Game Level Select Menu.
<br/>GameOver() - (Feature 9)
* This class stores the functions of the Game Over Menu.
<br/>Victory() - (Feature 10)
* This class stores the functions of the Victory Screen Menu.


# Data Design
We do not need databases for this project, so this does not apply to this project.

# Business Rules
Since this is a game, it is expected to be playable. Also, players of this game are expected to read English. Other than that, there are no particular expectations for users of this game.

# User Interface Design

<img src = "/artifacts/UI_1.jpg">
<img src = "/artifacts/UI_2.jpg">

### Main Menu
The UI for Banana Bandana Savanna will greet the user with a Main Menu screen when the game is launched. Below are a series of options for the user to click, including ‘Play’, ‘Level Select’, ‘Options’, and ‘Quit’.
When the user clicks ‘Play’ on the Main Menu screen they will be taken to the “Character Select” screen. A picture of each of the monkey character models are displayed for users to click on to add them to their respective teams. The size of each team is displayed below the character models for the users’ convenience. At the bottom of this screen a large hexagonal ‘Play’ button becomes clickable and changes color from gray to yellow when the users’ teams are both full.
When the user clicks ‘Level Select’ on the Main Menu screen they will be taken to the “Level Select” screen. This screen contains clickable, numbered circles that represent the different levels or maps the game can be played on. The background of this screen will depict the selected level and will change as new options are selected. A large ‘Ready’ Button will become clickable and change colors from gray to yellow once a level is selected. This ‘Ready’ button will bring the user to the “Character Select” screen. In the bottom left corner of the “Level Select” is a yellow ‘Back’ button, when clicked, brings the user back to the Main Menu screen.
When the user clicks ‘Options’ on the Main Menu screen they will be taken to the “Options” screen. ‘Music’ and ‘SFX’ are displayed in yellow text, followed by respective volume meters for each item. The volume meters consist of 5 banana shaped bars. The number of yellow colored bananas indicated the volume on a scale of 0 to 5. At the bottom of this screen are two clickable buttons: ‘Back’ and ‘Credits’. When the user clicks ‘Credits’ they will be taken to a screen that displays the creators of Banana Bandana Savana. When the user clicks ‘Back’ from the “Options” screen they will be taken to the Main Menu screen.
When the user clicks ‘Quit’ on the Main Menu screen the game will close.

### Gameplay
During gameplay the users will control monkey characters on a grid battle ield. Users will select attacks and special moves using buttons appearing in the game window. During gameplay a user may pause the game prompting the UI to display the “Pause” screen. The “Pause” screen will have clickable options to direct the user to the Main Menu or Options screen, and a ‘Quit’ option that will close the game.
At the end of the game, one of two “Victory Screens” will be displayed. A blue “Victory Screen” with the text “Team 1 Victory” in the event Team 1 wins, or a red victory screen with the text “Team 2 Victory” for when Team 2 wins. Both of the “Victory Screens” will contain clickable options to direct the player to the Main Menu or Option screen, and a ‘Quit’ option that will close the game.


# Resource Management
Unity manages memory automatically, so this item does not apply to the project.

# Security
Our Unity project does not have security level concerns, so this does not apply to the project. 

# Performance
Although this is a 3D game, it is set up like a 2D game and is not expected to be particularly performance heavy. This does not mean that performance isn’t a concern: if there are any assets that considerably slow down the game, they will be removed.

# Scalability
After being built, a unity game can no longer have anything added to it. It also cannot have anything taken away. Therefore, it has no scalability.

# Interoperability
This does not apply, as Unity games only work with Unity games.

# Internationalization/Localization
This game is not  to be important to another nation. It is not intended to be translated into another language.
Therefore, Internationalization/Localization does not apply.

# Input/Output
This game will run with a keyboard and a mouse.
It will also run using an X-Box 360 controller using the Unity Input Manager.

# Error Processing
In Unity, any errors that develop during gameplay will show up on the console. If the error is large, the program won't run.

# Fault Tolerance
Aside from closing the program when it can no longer run the game, Unity doesn’t do anything to corrects errors in code. 

# Architectural Feasibility
The architecture of our project is feasible. Unity is capable of all the functions that we would need.

# Overengineering
Unity games will not terminate over every single error. Unity will continue run the game unless as long as the error doesn't affect the game's functions. But since small errors can lead to bigger ones, we will be correcting them as well.

# Build-vs-Buy Decisions
Many assets on this game will be external assets taken for free from the unity store.
However, if they are completed, original Character models may be used for this project.

# Reuse
The software that will be used to develop this game is Unity.

# Change Strategy
Large gameplay changes will be discussed and approved of in the regular team meetings. Minor changes that do not involve gameplay can be implemented by any member freely. All changes will kept within the scope of the project.
