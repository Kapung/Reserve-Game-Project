# Reserve-Game-Project
_________________________

Just in case

School project: 2D Labyrinth game

Executable can be found in  ...\Reserve-Game-Project-master\Reserve-Game-Project-master\Labyrintho\bin\Release Labyrintho.exe


Controls: WASD to move, ESC to open pause menu
_________________________

Story

You're trapped in a labyrinth having no idea who you were before or what you are doing there. Your objective is to escape through traps and hostiles you encounter in the labyrinth. Collect the keys for the corresponding door to open them. You need to find ladder up to proceed to the next floor.

_________________________

Buglist

Not Fixed:

1. Ducks like to run out of borders of the map, prevent this by putting ducks either always run to walls and not to the map borders
2. DeathScreen may pop up twice after dying to abnormal ducks or more
3. If you delete a map between the first ID and last ID the Map Editor changes your ID to last ID even if it already exists
4. Everything except Next Level works
5. Ducks may have 1 additional turn when turning around sometimes
6. Ducks can instakill

Fixed:

1. For some unknown reason setting door/key after putting some things doesnt let you put doors/keys after it on MapEditor
2. Next Level only works for 9 first levels.
3. Build doesnt work because unknown IO error with XML but debug build works on Visual Studio 17
