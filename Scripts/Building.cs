using Godot;

public partial class Building : Node3D, ISerialisable<BuildingData>
{
	// The type or scene name of the building (should match the resource path or identifier)
	public string BuildingType { get; set; }

	// Deserialize building data from a dictionary
	public void Deserialize(BuildingData data)
	{
		Position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);
		Rotation = new Vector3(0, data.RotationY, 0);
		BuildingType = data.Type;
	}

	public BuildingData GetSerialisable()
	{
		return new BuildingData
		{
			Type = BuildingType,
			Position = [Position.X, Position.Y, Position.Z],
			RotationY = Rotation.Y
		};
	}
}

public class BuildingData
{
	public string Type;
	public float[] Position;
	public float RotationY;
}