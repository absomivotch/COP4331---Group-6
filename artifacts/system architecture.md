
# Program Organization

<img src = "/artifacts/0.jpg">

# Major Classes

<img src = "/artifacts/c4_classDiagram_MainM.png">

MainMenu()<br/>* This class stores the functions of the Main Menu Screen.
<br/>OptionsScreen()<br/>* This class stores the functions of the Options Screen.
<br/>CharacterSelect()<br/>* This class stores the functions of the Character Select Screen.
<br/>LevelSelect()<br/>* This class stores the functions of the Level Select Screen.

<img src = "/artifacts/c4_classDiagram_Game.png">

Environment()<br/>* This class stores classes and functions of objects in the environment.
<br/>Treebase()<br/>* This class stores the functions of the Treehouse base
<br/>Barrel()<br/>* This class stores the functions of the Monkey Barrel.
<br/>Mud()<br/>* This class stores the functions of the Mud environmental hazard.
<br/>River()<br/>* This class stores the functions of the River environmental hazard.
<br/>Vine()<br/>* This class stores the functions of the Vine object.

<br/>Bandana()<br/>* This class stores the functions of the Bandana object.
<br/>CoconutCursor()<br/>* This class stores the functions of the Coconut Cursor
<br/>Grid()<br/>* This class stores the functions of the Movement Grid.
<br/>Cover()<br/>* This class stores the cover function of Cover obstacles

<br/>Character()<br/>* This class stores the functions of the characters
<br/>Weapon()<br/>* This class stores the functions of Weapons.
<br/>Range()<br/>* This class stores the long range functions of Attack Mode.
<br/>Melee()<br/>* This class stores the short range functions of Attack Mode.

<br/>Pause Menu()<br/>* This class stores the functions of the Pause Menu.
<br/>InGameOptions()<br/>* This class stores the functions of the In-Game Options Menu.
<br/>InGameLevel()<br/>* This class stores the functions of the In-Game Level Select Menu.
<br/>GameOver()<br/>* This class stores the functions of the Game Over Menu.
<br/>Victory()<br/>* This class stores the functions of the Victory Screen Menu.


# Data Design
We do not need databases for this project, so this does not apply.

# Business Rules
Since this is a game, it is expected to be playable. Also, players of this game are expected to read English.
...Perhaps I should say instead that players of this game are expected to be able to read.
This is all that is generally expected of this game and its players.

# User Interface Design

<img src = "/artifacts/1.jpg">

# Resource Management
Resources for this project will consist of the Game Assets, Scripts, and Scenes.
Since most Assets will be borrowed, we will not be using any that will disrupt the frame rate of the game.
Scripts that run for too long and disrupt down gameplay will be either modified or discarded.
There is no limit to the size of Scenes. They will be as large or as small as they need to be.

# Security
The Unity Project will be stored on github for anyone to download.
It will also be stored on each team member's computer(s).
Therefore, the security the game has is minimal.


# Performance
Although this is a 3D game, it is set up like a 2D game and is not expected to be particularly performance heavy.

# Scalability
After being built, a unity game can no longer have anything added to it. It also cannot have anything taken away. Therefore, I would not consider it scalable.

# Interoperability
This does not apply, as Unity games only work with Unity games.

# Internationalization/Localization
We do not intend to import this game to a different nation. We also do not intend to translate into another language.
Therefore, Internationalization/Localization is not necessary.

# Input/Output
This game will run with a keyboard and a mouse.
It will also run using an X-Box 360 controller using the Unity Input Manager.
This can also run using a Playstation controller through the use of external software that reads a Playstation controller input as an X-Box 360 controller.

# Error Processing
In Unity, any errors that develop during gameplay will show up on the console.

# Fault Tolerance
When files go missing in a Unity project, the project does not shut itself down. As long as files are properly named, (or outright deleted) it isn't difficult to use the Unity Editor to find them again.
If a file happens to be irrecoverable, we can still use back-ups to receover it.

# Architectural Feasibility
If the architecture of our project is unfeasible, it will likely become apparent during our game playtesting. At that point, we can simply simply modify it until we have an architecture that works.

# Overengineering
To avoid overengineering, the game will be first developed starting from the core features and expanding onto side features. The team's weak points, character model creation and animation baking, will be kept at low priority.

# Build-vs-Buy Decisions
Many assets on this game will be external assets.
Most modeling resources will be bought for free on the Unity store.
Character models may be used if they are completed, but if not they will be substituted with external assets as well.

# Reuse
Assets for the game can be freely redistributed, although most of them are borrowed assets themselves.

# Change Strategy
Large gameplay changes will be discussed and approved of in the regular team meetings. Minor changes that do not involve gameplay can be implemented by any member freely.
