using Godot;

public abstract partial class AttackState : State
{
    [Export]
    protected Timer CooldownTimer;

    [Export]
    protected Timer DurationTimer;

    [Export]
    protected float AngleOffset = 0f;

    [Export]
    protected float AngleStep = 0.2f;

    protected float CurrentAngle = 0f;

    public override void _Ready()
    {
        base._Ready();

        // ✅ Correção:
        // Usa signal do timer.
        DurationTimer.Timeout += OnDurationTimeout;
    }

    public override void Enter()
    {
        CurrentAngle = AngleOffset;

        DurationTimer.Stop();
        DurationTimer.Start();

        CooldownTimer.Stop();
        CooldownTimer.Start();
    }

    public override void Exit()
    {
        CooldownTimer.Stop();
        DurationTimer.Stop();
    }

    public override void Update(double delta)
    {
        if (CooldownTimer.TimeLeft > 0) return;

        ExecuteAttack();

        CooldownTimer.Start();
    }

    private void OnDurationTimeout()
    {
        GD.Print($"{Name} terminou");

        EndAttack();
    }

    protected virtual void EndAttack()
    {
        FSM.ChangeState(FSM.GetState("IdleState"));
    }

    protected abstract void ExecuteAttack();
}