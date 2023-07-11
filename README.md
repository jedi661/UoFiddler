# UOFiddler

## About

UOFiddler based on Ultima SDK it's a tool to view and alter almost every UO 2D client file. Source code is released under the Beerware license.

## Changelog

Version : 4.10.16 
- LandTiles has received another function, which allows importing using the keyboard shortcut Ctrl+V and to copy using Ctrl+X.
- The  items have gained the function to import using the keyboard shortcut Ctrl+V and to copy using Ctrl+X.
- The  textures have also gained the function to import graphics using the keyboard shortcut Ctrl+V and to copy graphics using Ctrl+X.
- Gumps has also received the keyboard shortcut Ctrl+V for importing and Ctrl+X for copying.
- TileData has received a button that saves the settings on the selected ID repeatedly with each click. This function is only active when there are settings loaded from memory.
- MainForm has received a new function that opens the selected directory, specified in the options path, in Explorer.

Version : 4.10.15 
- Added Multis contextMenuStrip1 Copy Image to clipboard.
- Admin tool form set up to be opened only once.
- ChangeLog extended to display colors when I define them with abbreviations in the colors. Here you now set the colors with the text.
- Graphics added and replaced, function added for selection
- Gumps: I have added a button "Show all Free Slots" that displays all empty IDs in the Gump.mul. I have also modified the method "PopulateListBox" accordingly.
- ToolTip Text added

Version : 4.10.14 
- Added a mirror function to items.
- Added tooltips to items.
- GraficCutter: toolStrip ComboBox Added green, water clear.
- GraficCutter: Added the "changeBorder" function that makes the graphics transparent.
- GraficCutter: Added graphics.
- GraficCutter: Added Color selection added for grid
- MultiControl:  tabPage6 add contextMenuStrip3 and Copy Text

Version : 4.10.13 
- A new link has been added to uodev.uo-freeshards.de.
- A new tool has been added: a graphic cutter for arts.

Version : 4.10.12 
- Documentation now available.
- Added logo selection in the main menu under the context menu, with multiple graphics to choose from.
- The logo selection is now being saved, and it will be displayed again upon restarting with the selected logo.
- Two links to the German community focusing on development, graphics, and design have been added.

Version : 4.10.11 
- Changelog added.
- Changelog.txt added.
- Changelog Search feature added.
- System.NullReferenceException: Sound Button Add\Replace is fixed (If no file is selected).
- AdminTool Added a ping and tracert button.
- Help link removed, a documentation form created with Help Doku so that the application description is local, the whole thing is made possible with WebView, the cache is stored in %LOCALAPPDATA%, and when UOFiddler is closed, the UoFiddler.exe.WebView2 folder is deleted.

Version : 4.10.10 
- LandTile added: a 90-degree rotation to the left.

Version : 4.10.9 
- For the MainForm, a TabPanel_DrawItem event was added. The tabs are being reloaded and sorted differently. Additionally, the tabs have been assigned their own colors for identification purposes.
- Texture - Another function added: a 90-degree rotation to the left. It works with all sizes, such as 64x64, 128x128, or larger.

Version : 4.10.8 
- The Light has received another extension. It now includes two forms, each containing LandTiles and StaticItems, allowing for browsing and previewing them in advance. The forms can be positioned flexibly and function across tabs, enabling scrolling up and down.

Version : 4.10.7 
- Enable multiple selection for saving in Items and LandTiles by pressing the Ctrl key, then selecting the desired items, and finally clicking on the Save button with the respective format.
- Light has received the functions of copying and importing from the clipboard, as well as copying from the clipboard to the ID slot.

Version : 4.10.6 
- Multiple functions have been added to Radarcolor, expanding the graphical representation. Loading of data now utilizes ColorTreeView for graphical display. When saving the Color Palette, it is also displayed with colors. 
By activating the checkbox, the Color Palette's hex code is copied to the clipboard. Another textbox lists the hex codes, and there is a textbox for the 15-bit color depth per channel. In this case, the color code represents the intensities of the red, 
green, and blue color channels, each with 5 bits, making it compatible with Photoshop's color code. Additionally, the Photoshop textbox has a clipboard function that stores the color code when clicked.

Version : 4.10.5 
- A copy function has been added to the Controls, Items, LandTiles, Textures, and Gumps, allowing the graphics to be copied to the clipboard for direct use with copy and paste.
- Import function revised again, direct import through buffer added, existing SelectImageFormatForm class retained for outsourcing to Temp to store the graphics there and addressed this with new importByTempToolStripMenuItem.
- Import clipboard - Import graphics from clipboard (Items, LandTile, Gumps, Texture)

Version : 4.10.4 
- Added a new ConverterMultiText to convert Decimal to Hex. This allows for converting old Sphere Multitexts, enabling their import into the Multi.mul file in UoFiddler. Additionally, for the sake of preserving the old scripts, they are automatically placed in a folder named "Oldscript".
- The Tiledata has received a copy button that copies the selected settings from the selected location. You can now place them at any location by pressing again, save and you’re done.
- An XML editor has been added to the multis that edits, saves and recreates the Multilist.xml. A reload button has been added that reads in the Multilist.xml again without having to restart the program. A save button that copies the Multilist.xml and stores it in the OLDScript directory.

Version : 4.10.3 
- CompareItems expanded.
- Multi-selection added for saving images (Bmp, Tiff).
- Graphics can now be placed at any hexadecimal address.
- Display of the placed graphic.
- Hexadecimal address search added.
- The selected directory is now exported to its own directory called 'DirectoryisSettings' and saved as 'CompareiItemsDirectoryisSettings.txt'. It will be loaded on the next startup until a new directory is set."
- Added combo box for multiple selection of directories to quickly switch between them.
- Tiledata now has a ToolStripComboBox that sets predefined patterns for selecting settings.
- Tiledata now has a sound button that disables and enables the message box and plays a sound located in the main directory. This feature works for both items and land tiles, so no more messages and the Windows sound.

Version : 4.10.2 
- Fixed preview coloring in hue editor.

Version : 4.10.1 
- Fixed invalid value for tiledata flag `Unused8`. As tiledata csv export is positional this fix may affect files exported before this version. You'll have to compare files on your own. To fix older files just reorder columns later in file so this part `artused,noshadow,pixelbleed,playanimonce,unused8` should be `artused,unused8,noshadow,pixelbleed,playanimonce`.

Version : 4.10.0 
- Migrate to .net 7.

Version : 4.9.28 
- Fixed applying hues to items and animations.
- Updated map replace tiles form to better indicate progress and possible issues with XML file.

Version : 4.9.27 
- Added "Remove tile border" option that makes tile borders invisible (tabs: items, land tiles, textures, fonts).
- Added "Set background color same as tile background". When you select custom tile background color it will be applied to whole control too when this option is checked (currently limited to Items tab only).

Version : 4.9.26 
- Added "Export all sounds" option to Sounds tab.

Version : 4.9.25 
- Fixed multi editor plugin import range (maximum multi id was lower than in multi tab). 
- Minor cleanup.

Version : 4.9.24 
- Added UOX3 multi export. It's very basic Version : so expect some features to be missing.

Version : 4.9.23 
- Import multi dialog will now run as modal.
- Added import/export for multi as csv. To be used with punt's multi utilities.
- Added import multi to "Mass import" plug-in
- Fixed hue format saving to match original format better.

Version : 4.9.22 
- Fixed focusing of an item after search on Items, Land tiles and Textures tabs.

Version : 4.9.21 
- Added export to JPG and PNG on item detail form.
- Added export to JPG and PNG on animation edit form.

Version : 4.9.20 
- Removed source file locking when importing or replacing assets.

Version : 4.9.19 
- Fixed update checker exception handling.

Version : 4.9.18 
- Fixed crash when exporting animation frames where action has missing frame.

Version : 4.9.17 
- Updated client window enumeration logic to look for alternative clients first to fix Client.SendText() on OrionUO client.

Version : 4.9.16 
- Gump list will now select last inserted index when using "Insert at..." and "Insert starting from..." while "Show free slots" is enabled.

Version : 4.9.15 
- Fixed problems with "Replace starting from.." in Items, Land tiles and Textures tabs. It now replaces tiles as it should. Stops when index reaches max index value.
- Fixed "Show free slots" menu item not clearing its state after reloading files.

Version : 4.9.14 
- Fixed crash when browsing Textures with "show free slots" enabled.
- Fixed crash when browsing SkillGrp that uses nonexistent skill id.

Version : 4.9.13 
- Fix for multi (multi tab) region export/import. MultiRegion should now have same coordinates after import.
- Added "Replace starting from.." to Items tab. Allows replacing multiple items starting from selected index.
- Renamed "Insert Starting From.." to "Replace starting from.." as it reflects actual function better.
- Extended Ultima.Client with method to enumerate multiple ultima windows. Author: NaphalAXT. Source: https://github.com/NaphalAXT/ultimasVos/commit/5f2847739e8c690f8caa5e41c26075f64b930c0b
- Minor code fixes and cleanups.

Version : 4.9.12 
- Added search items on Dress tab.

Version : 4.9.11 
- Added "Show Free Slots" option to Land Tiles tab.
- Added "Show Free Slots" option to Textures tab.

Version : 4.9.10 
- Send item plug-in should now register itself only once and not twice.
- Send item to client plug-in should work with ClassicUO (thanks to Xuri)

Version : 4.9.9 
- Fixed Items tab - some larger statics items were not visible by default.
- Updated Sounds tab to use 0-based indexes by default. There is new option "Offset Sound Id by 1 (POL emulator)" for POL users. POL starts sound ids from 1.
- Added search by text to Hues control.

Version : 4.9.8 
- Updated animationlist.xml (you need to copy updated file from UOFiddler directory to your profile folder and override existing animationlist.xml)
- Fixed speech.mul Id value reading - no longer limited to 256.

Version : 4.9.7 
"Select in Gump" tab option added to context menus in Items and Tiledata tabs.
Minor updates in projects to fix building using `dotnet build` command.
Fixed wrong map size pre-selection when using .uop format.
"Insert starting from" option added to Gumps, Land Tiles and Textures tabs - allows to insert range of items in sequence (author Maybacco). 
Added "Set textures" option for Tiledata tab - sets texture id for all land tiles without it but having corresponding texture. Assumption is that land tile index value is equal to texture index. Option will only update tiles where TexID is 0. You can also enable option to set individual landtile TexID to land tile index via double click in TexID text box (default is off). (author Maybacco).
Default controls for items, land tiles and textures were removed. Alternative controls were renamed and are now main and only controls available.
Removed obsolete hash file usage.
"Replace" button on animation edit form has been hidden until its implementation is finished.
Fixed inability to map animation body id values over 1696. It works now up to body id 2048 which is UO client limit. #58 
New button "Average All" in RadarColor tab which checks all items and land tiles and sets all black non empty ones to average color. It's batch update command (author DiPaolaMarco).
Fixed invalid marking of AnimData as modified when user only browse contents of the tab.
Fixed 'Show Free Slots' on Items tab when using UOP file format.
Fixed 'Show Free Slots' on Gumps tab.
New options. You can now select selection color and focus color for tile view controls (items, land tiles, textures and fonts).
Fixed crash when providing invalid regular expression pattern string in items, land tiles, tiledata and cliloc tabs. 
Cliloc tab. "Goto text" uses case insensitive string comparison by default. You can switch to regular expressions if needed.
Renamed Hue tab to Hues. Hues control - added quick Search option. You can now jump to hue by it's index. Displayed hue index values are now 0-based same as stored in hues.mul.
Updated animation editor layout.
Added action names to animation list in animation editor.
Updated Serilog.Sinks.File package to latest versi

Version : 4.8 

    AsYlum added multiple selection in items tab using <ctrl> left-click used to with the test plug-in for exporting multiple items to an itemdesc.cfg file.
    AsYlum added graphic size & offset information to Item details box.
    AsYlum added export all item's graphic offsets to offset.cfg. This is useful for properly positioning art tiles displayed in a gump using the TilePic gump command.




## Requirements

Starting from version 4.10.0:

- Requires .NET Desktop Runtime 7.0.x (or SDK) installed to run the application.
- You can download .NET 7.0 at: <https://dotnet.microsoft.com/en-us/download/dotnet/7.0>
- Minimum supported Windows version is Windows 10.

Older versions, 4.9.28 and lower use .Net Framework 4.8

## Building

You'll need Visual Studio 2022 v17.4, .NET 7.0 and .NET desktop development workload.

## Reporting bugs and issues

Please report any bugs or issues here: [issues](https://github.com/polserver/UOFiddler/issues).
Or here :[issues](https://github.com/jedi661/UoFiddler).
