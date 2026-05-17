using Sandbox;



public sealed class CustomPlayerController : Component
{

	[Property, Title("huh")]
	public bool IsEnabled { get; set; } = true;
   	[Property, Title("moveSpeedMultiplier")]
	public float moveSpeedMultiplier;
	[Property, Title("defaultMoveSpeed")]
	public float defaultMoveSpeed;
	[Property, Title("defaultMaxHealth")]
	public float defaultMaxHealth;
	[Property, Title("currentHealth")]
	public float currentHealth;
	[Property, Title("damageResistance")]
	public float damageResistance;
	[Property, Title("defaultFOV")]
	public float defaultFOV;
	
	
	//-----------
	public Rigidbody rB;



   protected override void OnAwake()
	{
		//Rigidbody rB = GetComponent<Rigidbody>(); //cannot globally set for multiple functions for some reason
		Log.Info("yup started");
	}

	public void Hello()
	{
		Log.Info("hello executed");
	}
	protected override void OnUpdate()
	{
	rB = GetComponent<Rigidbody>(); //gets the Rigidbody component from the object this component is applied to

	GameObject.LocalRotation = GameObject.LocalRotation * new Angles(0,Input.AnalogLook.yaw,0); 
	
	
	
	
	
	
	
	
	
	
	//if (Input.Pressed("Jump")) //test function for jumping
	//{
	//rB.ApplyImpulse(new Vector3(0,0,32000f)); //adds vertical velocity as an impulse
	//Hello(); //test function to be called
	//}
	//GameObject.LocalRotation += //unfinished part of rotation

	Log.Info("updated");

	}
}
