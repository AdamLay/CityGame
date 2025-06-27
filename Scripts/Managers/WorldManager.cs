using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public partial class WorldManager : Node
{
  public static WorldManager Instance { get; private set; }
  public WorldManager()
  {
    Instance = this;
  }

  [Export]
  public Node3D BuildingsContainer;

  // Path to save file
  private string SaveFilePath => "user://savegame.json";

  // List of building nodes in the world
  public List<Building> Buildings { get; private set; } = new List<Building>();

  // Call this to save all buildings
  public void SaveGame()
  {
    var saveData = new List<object>();
    foreach (var building in Buildings)
    {
      saveData.Add(building.GetSerialisable());
    }

    var json = JsonSerializer.Serialize(saveData);
    using var file = Godot.FileAccess.Open(SaveFilePath, Godot.FileAccess.ModeFlags.Write);
    file.StoreString(json);
    file.Close();
    GD.Print("Game saved to " + SaveFilePath);
  }

  // Call this to load all buildings
  public void LoadGame(Func<string, Building> buildingFactory)
  {
    if (!Godot.FileAccess.FileExists(SaveFilePath))
    {
      GD.Print("No save file found.");
      return;
    }
    using var file = Godot.FileAccess.Open(SaveFilePath, Godot.FileAccess.ModeFlags.Read);
    var json = file.GetAsText();
    file.Close();
    List<object> saveData = JsonSerializer.Deserialize<List<object>>(json);
    if (saveData == null) return;

    // Remove existing buildings
    foreach (var building in Buildings)
    {
      building.QueueFree();
    }
    Buildings.Clear();

    // Instantiate buildings from save data
    foreach (var data in saveData)
    {
      // if (!data.ContainsKey("type")) continue;
      // string type = data["type"] as string;
      // var building = buildingFactory(type);
      // if (building != null)
      // {
      //   building.Deserialize(data);
      //   AddChild(building);
      //   Buildings.Add(building);
      // }
    }
    GD.Print("Game loaded from " + SaveFilePath);
  }
}
