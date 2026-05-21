using Godot;
using System;

public partial class Bullet : Area2D
{
	[Export]
	private int Speed = 100;
	[Export]
	private int damage = 1;
	public Vector2 direction;
	private PlayerStats playerStats = PlayerStats.getInstace();

    public override void _PhysicsProcess(double delta)
    {
        Position += direction * Speed * (float)delta;
    }

	public void player_damage(Node2D body)
	{
		playerStats.damagePlayer(damage);
		QueueFree();
	}

	public void on_bullet_exited()
	{
		QueueFree();
	}

}
