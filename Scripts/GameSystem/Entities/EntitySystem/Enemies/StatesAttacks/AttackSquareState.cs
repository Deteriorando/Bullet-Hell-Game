using Godot;

public partial class AttackSquareState : AttackStateManager
{
    [Export]
    private int BulletCount = 4;

    protected override void ExecuteAttack()
    {
        for (int i = 0; i < BulletCount; i++)
        {
            float angle = (Mathf.Tau / BulletCount) * i + CurrentAngle;

            enemy.Shoot(angle);
        }

        CurrentAngle += AngleStep;
    }
}