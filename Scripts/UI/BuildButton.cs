using Godot;
using System;

public partial class BuildButton : Button
{
	[Export] public PackedScene Building;

	public override void _Ready()
	{
		Pressed += ButtonPressed;
	}

	private void ButtonPressed()
	{
		BuildManager.Instance.ToBuild = Building;

		BuildManager.Instance.ShowPreview();
	}
}
