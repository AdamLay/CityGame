using Godot;

public partial class BuildPreview : Node3D
{
	[Export] public Camera3D Camera;
	[Export] public Building Building;
	public override void _Process(double delta)
	{
		Vector2 mousePos = GetViewport().GetMousePosition();

		// Ray origin and direction
		Vector3 rayOrigin = Camera.ProjectRayOrigin(mousePos);
		Vector3 rayDirection = Camera.ProjectRayNormal(mousePos);

		// Define a horizontal plane (e.g., y = 0)
		Plane floorPlane = new Plane(Vector3.Up, 0);

		// Calculate intersection point
		var didHit = floorPlane.IntersectsRay(rayOrigin, rayDirection);

		if (didHit.HasValue)
		{
			Vector3 snappedPosition = new Vector3(
				Mathf.Round(didHit.Value.X),
				Mathf.Round(didHit.Value.Y),
				Mathf.Round(didHit.Value.Z)
			);
			Position = snappedPosition;
		}
	}
}
