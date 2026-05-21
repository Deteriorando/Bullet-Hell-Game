using Godot;
using System;

public abstract partial class State : Node
{
    protected FiniteStateMachine FSM;
    protected Enemy enemy;
    protected CharacterBody2D Player;

    protected bool IsActive = false;

    public override void _Ready()
    {
        FSM = GetParent<FiniteStateMachine>();
        enemy = FSM.GetParent<Enemy>();
        
        Player = GetTree().GetFirstNodeInGroup("player") as CharacterBody2D;
    }

	public virtual void Enter()
    {
        IsActive = true;
    }
    public virtual void Exit()
    {
        IsActive = false;
    }
    public virtual void Update(double delta) {}
}
