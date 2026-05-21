using Godot;

public partial class AttackSpiralState : AttackState
{

    protected override void ExecuteAttack()
    {
        CurrentAngle += AngleStep;
        enemy.Shoot(CurrentAngle);
        GD.Print($"Spiral Shot: {CurrentAngle}");
    }
}