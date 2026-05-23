using Godot;

public partial class IdleState : State
{
    [Export]
    private Timer IdleTimer;

    public override void _Ready()
    {
        base._Ready();

        IdleTimer.Timeout += OnIdleTimeout;
    }

    public override void Enter()
    {
        IdleTimer.Stop();
        IdleTimer.Start();
    }

    private void OnIdleTimeout()
    {
        FSM.ChangeState(FSM.GetState("AttackBurstState"));
    }
}