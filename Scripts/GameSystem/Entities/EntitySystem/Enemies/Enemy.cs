using Godot;
using System;

public abstract partial class Enemy : CharacterBody2D
{
    [Export]
    public int HP = 100;

    [Export]
    public float Speed = 100;
    protected FiniteStateMachine FSM;

    public override void _Ready()
    {
        FSM = GetNode<FiniteStateMachine>("FSM");
    }

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0) Die();
    }

    protected virtual void Die()
    {
        QueueFree();
    }

    protected bool IsWindowMinimized()
    {
        return DisplayServer.WindowGetMode() ==
               DisplayServer.WindowMode.Minimized;
    }

    public virtual void Shoot(float angle)
    {
       
    }
}
