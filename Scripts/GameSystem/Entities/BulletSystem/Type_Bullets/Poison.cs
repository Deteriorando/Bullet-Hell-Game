using Godot;
using System;
using System.Diagnostics;

public partial class Poison : Area2D
{
	//Montar um modulo para cado estado de bala.

   [Export]
	private Sprite2D sprite;
	
	[Export]
	private int velocity = 500;

	[Export]
	private int damage = 1;

	[Export]
	private string state = "poison";
}
