# FMScoutFramework Reborn

FMScoutFramework Reborn is a C#.NET/Mono Framework that enables you to create your own assistant tools / editors for Football Manager. It supports FM 26.

## Current Status

This is a complete rewrite based on [FMScoutFramework](https://github.com/ThanosSiopoudis/FMScoutFramework), which was only publicly released until FM16. Since the game has gone through a switch to 64 bit architecture and an engine change since then, there is a lot to go through to make everything work again.

The non-exhaustive list of things done and still to do is as follows:
- [x] get all the memory-reading code to 64-bit support
- [x] find basic offsets to access all the central lists (Players, Clubs, etc.)
- [ ] get the offsets for the basic objects up to date -> partially finished for Persons/Players, Continents, Nations, Contracts
- [ ] set up some basic automated testing (load a known save file, find specific objects, make sure the values are interpreted correctly; low priority at the moment)
- [ ] support for OSes besides Windows (low priority at the moment)

As of right now, the library can successfully load game data from FM 26 on Windows, but you will only receive a list of players, continents and nations in the opened savegame, with some data still missing in those objects.

## Project Setup

Clone the project in your favourite github client
You will need [MonoDevelop](http://monodevelop.com) or [Xamarin](https://www.xamarin.com/download-it) if you develop your application for all platforms (Windows, OS X, Linux) or Microsoft Visual Studio if you develop just for windows. The client requirements will be the Mono framework for apps developed in Xamarin / MonoDevelop, or the .NET Framework for Visual Studio apps.

### Xamarin / Monodevelop Settings
1. Create your new Xamarin / MonoDevelop Solution
2. You can clone this repository and add it as a submodule in your own git tree, or just checkout the latest.
3. Add the FMScoutFramework project to your solution.
4. Expand your own project, and right click on `References`
5. Select `Edit References`
6. Click the `Projects` tab and tick the checkbox next to `FMScoutFramework`
7. Click `OK`
8. Right click on the `FMScoutFramework` Project
9. Click on `Options`
10. Select `Compiler` from the Menu
11. In the `Define Symbols` entry, enter `MAC` for OS X, `LINUX` for Linux or `WINDOWS` for windows.
12. You are now ready to start developing your app. Look further down for code

### Microsoft Visual Studio Settings
1. Create your new Visual Studio Solution
2. You can clone this repository and add it as a submodule in your own git tree, or just checkout the latest.
3. Add the FMScoutFramework project to your solution.
4. Expand your own project and right click on `References`
5. Click `Add Reference`
6. Click the `Projects` tab, under `Solution` and tick the checkbox next to `FMScoutFramework`
7. Click `OK`
8. Right click on the `FMScoutFramework` Project
9. Click on `Properties`
10. Select `Build` from the menu on the left
11. In the `Conditional Compilation Symbols` textbox, enter `WINDOWS;`
12. You are now ready to start developing your app. Look further down for code

##### Example Code

The following code is an example for a simple Windows Forms application and another for Mono
First, include the necessary framework headers:
```csharp
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FMScoutFramework.Core;
using FMScoutFramework.Core.Entities.InGame;
```

In your class, create a new public variable:
```csharp
public FMCore fmCore = new FMCore (FMScoutFramework.Core.Entities.DatabaseModeEnum.Realtime);
```

First, create a new method that will be asynchronously called by the framework when loading is finished:
```csharp
public void GameLoaded() {
  Debug.WriteLine("Loading Finished");
}
```

Then, in your action callback method (from a button, or a menu for example) use the following code:
```csharp
fmcore.GameLoaded += new Action(GameLoaded);
new Action(() => fmCore.LoadData()).BeginInvoke((s) => { }, null);
```

That's it! You can now query the data, with simple Linq queries! Amazing, eh? Here's an example, to look for "Bar":
```csharp
var clubs = (from c in fmCore.Clubs
				     where c.Name.Contains ("Bar")
			       select c).Take (100).ToList ();
```

## Contributing changes
Since this is currently my personal attempt to establish a solid baseline that makes this library usable and useful for other tools to be built on top of it, I'm currently not looking for contributions until I have at least a clean state that successfully loads Players, Staff and Clubs with a sensible amount of implemented attributes. Once this is achieved, I'm happy about any contributions.

## License

FMScoutFramework Reborn is released under the GNU General Public License v2.0
Please read the LICENSE file for a full version of the License