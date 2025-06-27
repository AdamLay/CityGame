using Godot;
using System;

public partial class BuildManager : Node
{
	[Export]
	public PackedScene BuildPreviewScene;
	[Export]
	public BuildPreview BuildPreview;

	public static BuildManager Instance { get; private set; }
	public BuildManager()
	{
		Instance = this;
	}

	public void ShowPreview()
	{
		Node instance = BuildPreviewScene.Instantiate();
		BuildPreview = instance as BuildPreview;
		BuildPreview.Camera = CameraController.Instance;
		GetTree().Root.AddChild(BuildPreview);
	}

	public override void _Process(double delta)
	{
		if (Input.IsMouseButtonPressed(MouseButton.Left))
		{
			// Is valid?
		}
	}
}
