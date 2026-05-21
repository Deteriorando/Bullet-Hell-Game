using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	protected PlayerStats playerStats;
	private static Player instance;

	public static Player getInstace()
	{
		if(instance == null) instance = new Player();
		return instance;
	}

	public override void _PhysicsProcess(double delta)
	{
		playerMoviment();
	}

	public void playerMoviment()
	{
		Vector2 velocity = Vector2.Zero;
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		if(direction != Vector2.Zero)
		{
			velocity = direction * playerStats.Speed;
		} else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, playerStats.Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, playerStats.Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

}
