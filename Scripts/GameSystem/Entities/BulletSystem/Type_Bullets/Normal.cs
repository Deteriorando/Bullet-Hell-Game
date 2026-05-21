using Godot;
using System;

public partial class Normal : Area2D
{
	[Export]
	private Sprite2D sprite;
	
	[Export]
	private int velocity = 500;

	[Export]
	private int damage = 1;

	[Export]
	private string state = "normal";
}
