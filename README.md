# Launcher for Mafia: Oakwood (Mafia: The City of Lost Heaven multi-player modification) 

This program is some kind of launcher for Oakwood ver. RC2 (Mafia: TCOLH multi-player modification)

What can this program:
1) Write and read `launcher.json` and `client.json` files from `"config"` folder.
2) Configure parameters from above listed files and rewrite files with specified changes.
3) Run the multiplayer after confirmed settings.
4) Save the recently saved Oakwood directory and read it after next launcher run.
5) Create the `"config"` folder (if it doesn't exist) with configured `JSON`-files.

It's necessary to specify the Mafia and Oakwood paths for the changes to be made correctly and avoid of unexpected errors and issues.

Link to download: https://github.com/legion2809/LauncherForOakwood/releases

# Change Log

v 1.0.1:
- Now, the launcher can read recently chosen Mafia and Oakwood directories from file (`MafiaPath.txt` and `OakPath.txt`) that will be created after choosing path from FolderBrowser dialog window.

v 1.0.2:
- Now, the launcher can read both of JaSON-files at the same time (`client.json` and `launcher.json`), there's no need in use openFileDialog. :) 

v 1.0.3:
- Now, the launcher can create the `"config"` folder (if it isn't exists) with configured JaSON-files.
- (Hotfix) Now, the launcher will try to read recently chosen Mafia and Oakwood directories from files (`MafiaPath.txt` and `OakPath.txt`) and JaSON-files at the same time when launcher is running.
- (Hotfix) Mafia and Oakwood will be stored in single file (`Pathes.txt`)

v.1.0.4:
- Added Discord Rich Presence by Smelson (Vanya Shatilov)
- (Hotfix) FolderBrowserDialog has been changed to CommonOpenFileDialog

v 1.0.5:
- Aurora BdCn BT font injected into the executable file
- Rounded borders and additional resolution check
- (Hotfix) There was no need in to store the Mafia directory (cuz it will have been stored in `launcher.json`), now only the Oakwood directory will be stored in `OakPath.txt` file

v 1.0.6
- Fixed gamepath formatting due to new Oakwood RC2 client update
- Fixed an issue with Mafia path reading from JaSON-file

# Credits and Additional Info

Special thanks to: 
- **Smelson (Vanya Shatilov)** - for providing an idea to create this thing and helping me.
- **AsaSK** - for background image to the program. :)
- **Mafia Bar** - for improving some minor stuff in code.
- And, finally, **MafiaHub dev team** - for the multiplayer.

If you found any bugs, don't be hesitate to tell about this. ;)

You can find my contacts in my personal webpage: https://legion2809.github.io
