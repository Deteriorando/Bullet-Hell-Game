using Godot;

public partial class Boss : Enemy
{
    [Export]
    private PackedScene BulletScene;

    [Export]
    private Marker2D ShootPoint;

    public override void Shoot(float angle)
    {
        GD.Print("Shoot chamado");

        if (BulletScene == null)
        {
            GD.PushError("BulletScene está NULL");
            return;
        }


        if (IsWindowMinimized()) return;

        Bullet bullet = BulletScene.Instantiate<Bullet>();

        bullet.GlobalPosition = ShootPoint.GlobalPosition;
        bullet.direction = GetAngle(angle);
        GetTree().CurrentScene.CallDeferred(Node.MethodName.AddChild, bullet);
    }

    private Vector2 GetAngle(float angle)
    {
        return new Vector2(
			Mathf.Cos(angle),
			Mathf.Sin(angle))
			.Normalized();
    }
}
