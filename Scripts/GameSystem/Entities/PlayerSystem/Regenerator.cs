using Godot;
using System;

public partial class Regenerator : Area2D
{
	private PlayerStats playerStats = PlayerStats.getInstace();

	public void restore_life(Node2D body)
	{
		regenerator_life();
	}

	private void regenerator_life()
	{
		if(playerStats.Life >= 10) return;

		playerStats.Life += 1;
		QueueFree();
		GD.Print("Vida restaurada! \nVidas: ", playerStats.Life);
	}
}
