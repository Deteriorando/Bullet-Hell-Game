using Godot;

public partial class AttackBurstState : AttackState
{
    [Export]
    private int BulletCount = 12;

    protected override void ExecuteAttack()
    {
        for (int i = 0; i < BulletCount; i++)
        {
            float angle = i * Mathf.Tau / BulletCount;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            
            enemy.Shoot(angle);
        }

        CurrentAngle += AngleStep;
    }
}