using Godot;

public partial class AttackSpiralState : AttackStateManager
{

    protected override void ExecuteAttack()
    {
        CurrentAngle += AngleStep;
        enemy.Shoot(CurrentAngle);
        GD.Print($"Spiral Shot: {CurrentAngle}");
    }
}