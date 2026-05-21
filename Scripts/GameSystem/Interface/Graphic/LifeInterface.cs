using Godot;
using System;

public partial class LifeInterface : Label
{
	PlayerStats playerStats = PlayerStats.getInstace();

    public override void _Ready()
    {
        HorizontalAlignment = HorizontalAlignment.Center;
    }

    public override void _Process(double delta)
    {
        UpdateLife(playerStats.Life);
    }

	public void UpdateLife(int life)
	{
		Text = "Vida: " + life.ToString();

		PivotOffset = Size / 2;
		Position = new Vector2(-40, -60);
	}
}
