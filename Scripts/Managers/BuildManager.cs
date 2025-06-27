using Godot;
using System;

public partial class BuildManager : Node
{
	[Export]
	public PackedScene BuildPreviewScene;
	[Export]
	public PackedScene ToBuild;
	[Export]
	public BuildPreview BuildPreview;
	[Export]
	public Node3D BuildingsContainer;

	public static BuildManager Instance { get; private set; }
	public BuildManager()
	{
		Instance = this;
	}

	public void ShowPreview()
	{
		Node instance = BuildPreviewScene.Instantiate();
		BuildPreview = instance as BuildPreview;
		BuildPreview.Building = ToBuild.Instantiate() as Building;
		BuildPreview.Camera = CameraController.Instance;
		BuildPreview.AddChild(BuildPreview.Building);
		GetTree().Root.AddChild(BuildPreview);
	}

	public override void _Process(double delta)
	{
		if (Input.IsMouseButtonPressed(MouseButton.Left))
		{
			Building newBuilding = ToBuild.Instantiate() as Building;

			newBuilding.Position = BuildPreview.Position;

			// Is valid?
			BuildingsContainer.AddChild(newBuilding);

			// Remove preview
			BuildPreview.QueueFree();
			BuildPreview = null;
		}
	}
}
