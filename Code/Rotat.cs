using Sandbox;

public sealed class Rotat : Component
{
    float a = 50;

    protected override void OnUpdate()
    {
        WorldRotation *= Rotation.FromYaw(a * Time.Delta);
        a += 1 * Time.Delta;
    }

    void OnCollisionStart( Collision other )
    {
        Log.Info("HIT SOMETHING!");
    }
}