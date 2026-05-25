using Sandbox;



public sealed class CustomPlayerController : Component
{
	//--------------------------------- Movement
	[Property, Title("huh")]
	public bool onGround { get; set; } = true;
	[Property, Title("canRun")]
	public bool canRun { get; set; } = true;
	[Property, Title("running")]
	private bool running { get; set; } = true;
	[Property, Title("onGround")]
	public bool huh { get; set; } = true;
	[Property, Title("addedRunningMultiplier")]
	public float addedRunningMultiplier;
	[Property, Title("defaultRunningMultiplier")]
	private float defaultRunningMultiplier;
   	[Property, Title("movementFriction")]
	private float activeFriction;
	[Property, Title("activeFriction")]
	private float movingFriction;
	[Property, Title("movingFriction")]
	private float unmovingFriction;
	[Property, Title("unmovingFriction")]
	public float moveSpeedMultiplier;
	[Property, Title("defaultMoveSpeed")]
	public float defaultMoveSpeed;
	[Property, Title("defaultMaxHealth")]
	//----------------------------------- Health
	public float defaultMaxHealth;
	[Property, Title("currentHealth")]
	public float currentHealth;
	[Property, Title("damageResistance")]
	
	//----------------------------------- Camera
	public float damageResistance;
	[Property, Title("defaultFOV")]
	public float defaultFOV;
	[Property, Title("localPlayerCamera")]
	public GameObject localPlayerCamera;
	
	
	//-----------
	public Rigidbody rB;
	public Component localPlayerCameraComponent;

	public float forwBackwMove;
	public float leftRightMove;
	public Vector3 localMoveInputVector3;
	public Vector3 localMoveVector;

   protected override void OnAwake()
	{
		//localPlayerCameraComponent = localPlayerCamera.GetComponent<Camera>(); //doesnt work for now, used for FOV modding
		//Rigidbody rB = GetComponent<Rigidbody>(); //cannot globally set for multiple functions for some reason
		Log.Info("yup started");
	}

	public void Hello()
	{
		Log.Info("hello executed");
	}

	protected override void OnUpdate()
	{
		
	GameObject.Parent.LocalRotation = GameObject.Parent.LocalRotation * new Angles(0,Input.AnalogLook.yaw,0); 
	
//----------------------- forward backword move
	if (Input.Keyboard.Down("W"))
		{
			forwBackwMove = 1;
		}

	if (Input.Keyboard.Down("S"))
		{
			forwBackwMove = -1;
		}

	if (Input.Keyboard.Released("S") ||Input.Keyboard.Released("W"))
		{
			forwBackwMove = 0;
		}
	
	if (Input.Keyboard.Down("Shift"))
		{
			running = true;
		}
		else
		{
			running = false;
		}

//----------------------- left right move
	if (Input.Keyboard.Down("A"))
		{
			leftRightMove = 1;
		}

	if (Input.Keyboard.Down("D"))
		{
			leftRightMove = -1;
		}

	if (Input.Keyboard.Released("A") ||Input.Keyboard.Released("D"))
		{
			leftRightMove = 0;
		}
//------------------------ Friction management
		if (!Input.Keyboard.Down("W") && !Input.Keyboard.Down("A") && !Input.Keyboard.Down("S") && !Input.Keyboard.Down("D"))
		{
			activeFriction = unmovingFriction;
		}
		else
		{
			activeFriction = movingFriction;
		}
	}
	protected override void OnFixedUpdate()
	{
	rB = GetComponent<Rigidbody>(); //gets the Rigidbody component from the object this component is applied to



//------------------------ defining movement

localMoveInputVector3 = new Vector3(forwBackwMove, leftRightMove, 0);

localMoveVector = new Vector3((localMoveInputVector3.x * defaultMoveSpeed) + GameObject.Parent.GetComponent<Rigidbody>().Velocity.x, GameObject.Parent.GetComponent<Rigidbody>().Velocity.y + (localMoveInputVector3.y * defaultMoveSpeed), GameObject.Parent.GetComponent<Rigidbody>().Velocity.z) * moveSpeedMultiplier;
GameObject.Parent.GetComponent<Rigidbody>().Velocity = localMoveVector;
Log.Info(GameObject.Parent.WorldRotation);


	
	
	
	
	
	
	//if (Input.Pressed("Jump")) //test function for jumping
	//{
	//rB.ApplyImpulse(new Vector3(0,0,32000f)); //adds vertical velocity as an impulse
	//Hello(); //test function to be called
	//}
	//GameObject.LocalRotation += //unfinished part of rotation

	}
}
