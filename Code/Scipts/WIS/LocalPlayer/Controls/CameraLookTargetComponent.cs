using Sandbox;

public sealed class CameraLookTargetComponent : Component
{
	[Property, Title("localPlayerCamera")]
	public GameObject localPlayerCamera;
	protected override void OnUpdate()
	{
		GameObject playerEmpty = GameObject.Parent.Parent;

		GameObject.LocalRotation = new Angles(Input.AnalogLook.pitch,0, 0) * GameObject.LocalRotation;
		Log.Info(GameObject.Parent.LocalRotation.z);
		
		localPlayerCamera.LocalPosition = GameObject.LocalPosition;
		localPlayerCamera.LocalRotation = GameObject.LocalRotation;
	}
}
