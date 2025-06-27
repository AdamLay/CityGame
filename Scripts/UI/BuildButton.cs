using Godot;
using System;

public partial class BuildButton : Button
{
	public override void _Ready()
	{
		Pressed += ButtonPressed;
	}

	private void ButtonPressed()
	{
		BuildManager.Instance.ShowPreview();
	}
}
