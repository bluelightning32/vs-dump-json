# Dump Json - Vintage Story Mod

This mod is only used to add extra debug output for debugging other mods. It serializes the assets received by the server back into json in the Logs directory.

Inside the Logs directory, a 'dump' subdirectory is created. All of the blocks, items, and entities are saved as separate files in that directory. Note that each block/item/entity variant gets its own file, because the variant substitutions have already been processed by the time this mod receivese the data.

This mod gets the data from the `Packet_ServerAssets`, which has a similar format as the original json, but not exactly the same. For instance, the mod also tries to dump the recipes, but they end up being long random looking strings, because the recipes are additionally protobuf encoded.

## Building

The `VINTAGE_STORY` environment variable must be set before loading the
project. It should be set to the install location of Vintage Story (the
directory that contains VintagestoryLib.dll).

A Visual Studio Code workspace is included. The mod can be built through it or
from the command line.

### Release build from command line

This will produce a zip file in a subfolder of `bin/Release`.
```
dotnet build -c Release
```

### Debug build from command line

This will produce a zip file in a subfolder of `bin/Debug`.
```
dotnet build -c Debug
```

### Run unit tests

```
dotnet test -c Debug --logger:"console;verbosity=detailed"
```
