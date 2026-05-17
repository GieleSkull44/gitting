using Sandbox;

public sealed class CameraLookTargetComponent : Component
{
	protected override void OnUpdate()
	{
		GameObject.LocalRotation = GameObject.LocalRotation * new Angles(Input.AnalogLook.pitch,0,0);
	}
}
