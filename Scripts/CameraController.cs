using Godot;
using System;

public partial class CameraController : Camera3D
{
	[Export] public float Speed = 5.0f;

	public static CameraController Instance { get; private set; }
	public CameraController()
	{
		Instance = this;
	}

	public override void _Process(double delta)
	{
		Vector3 direction = Vector3.Zero;

		if (Input.IsActionPressed("move_left"))
			direction.X += 1;
		if (Input.IsActionPressed("move_right"))
			direction.X += -1;
		if (Input.IsActionPressed("move_up"))
			direction.Z += 1;
		if (Input.IsActionPressed("move_down"))
			direction.Z += -1;

		// Convert direction to local space
		//direction = GlobalTransform.Basis * direction;
		//direction.y = 0; // Lock vertical movement (optional)

		Position += direction.Normalized() * Speed * (float)delta;
	}
}
