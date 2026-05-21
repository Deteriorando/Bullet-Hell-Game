using Godot;
using System;
using System.Runtime.CompilerServices;

[GlobalClass]
public partial class PlayerStats : Resource
{
	[Export]
	public int Life = 10;
	[Export]
	public int Speed = 500;
	[Export]
	public int Stamina = 100;

	private static PlayerStats instance;

	private PlayerStats()
	{
		
	}

	public static PlayerStats getInstace()
	{
		if(instance == null) instance = new PlayerStats();
		return instance;
	}

	public void damagePlayer(int damage)
	{
		Life = Life - damage;
		GD.Print("Dano levado ", damage);
		GD.Print("Vida: ", Life);
	}

	
}
