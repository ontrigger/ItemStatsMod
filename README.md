# ItemStats BepInEx Version
Provides current stack bonuses for an item in the tooltip

![demo](https://i.nyah.moe/VvsO.png)

# Installation
First thing you'll need is the BepInExPack. If you don't have it, get it [here](https://thunderstore.io/package/bbepis/BepInExPack/) and follow the installation instructions.

Afterwards, get the zip file from releases and extract the ItemStats folder in BepInEx/plugins. That's it!

# Building

You will first need the following libraries:

* Assembly-CSharp (duh)
* UnityEngine
* UnityEngine.CoreModule
* BepInEx
* MMHOOK_Assembly-CSharp
* R2API

Open the solution, link the libraries in the Lib folder, DL the required NuGet package and compile.