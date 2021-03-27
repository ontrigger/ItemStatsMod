# ItemStats 2.2.0
Provides current stack bonuses for an item in the tooltip

![demo](https://i.nyah.moe/VvsO.png)

# Installation
First thing you'll need is the BepInExPack. If you don't have it, get it [here](https://thunderstore.io/package/bbepis/BepInExPack/) and follow the installation instructions.

Afterwards, get the zip file from releases and extract the ItemStats folder in BepInEx/plugins. That's it!

# Custom Item API
In order to use API, add a Bepin SoftDependency to your BaseUnityPlugin annotations. 
Make sure to check if ItemStats is loaded before trying to use it

Then, create an ItemStatDef for your item (see ItemStatDefinitions.cs for examples).

Use the R2API ItemApi Submodule to add your item and get its ItemIndex.

After that, simply call `ItemStatsMod.AddCustomItemStatDef(myItemIndex, myItemStatDef)`

To create an item stat modifier, extend from `AbstractStatModifier`. Check ItemStats.StatModification.Modifiers for examples
Add an instance of the class with `ItemStatsMod.AddStatModifier(new MyStatModifier())`

# Building

You will first need the following libraries:

* Assembly-CSharp (duh)
* UnityEngine
* UnityEngine.CoreModule
* BepInEx
* MMHOOK_Assembly-CSharp
* R2API

Open the solution, link the libraries in the Lib folder, DL the required NuGet package and compile.

# Contributors

* kylewill0725
* orare
* XuaTheGrate
