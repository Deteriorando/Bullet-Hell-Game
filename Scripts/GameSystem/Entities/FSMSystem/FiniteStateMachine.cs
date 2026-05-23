using Godot;
using System.Collections.Generic;

public partial class FiniteStateMachine : Node
{
    private State CurrentState;

    private Dictionary<string, State> States = new();

    [Export]
    public NodePath InitialState;

    public override void _Ready()
    {
        CacheStates();
        InitializeState();
    }

    public override void _Process(double delta)
    {
        CurrentState?.Update(delta);
    }

    private void CacheStates()
    {
        foreach (Node child in GetChildren())
            if (child is State state)
            {
                States[state.Name] = state;
                GD.Print("State guardado: ", state.Name);
            }
    }

    public State GetState(string stateName)
    {
        if (States.TryGetValue(stateName, out State state))
            return state;

        GD.PushError($"Estado '{stateName}' não encontrado.");
        return null;
    }

    private void InitializeState()
    {
        if (InitialState.IsEmpty)
        {
            GD.PushError("InitialState não configurado.");
            return;
        }

        CurrentState = GetNode<State>(InitialState);

        if (CurrentState == null)
        {
            GD.PushError("Estado inicial não encontrado.");
            return;
        }

        CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
        if (newState == null)
        {
            GD.PushError("Tentando trocar para estado null.");
            return;
        }

        if (newState == CurrentState) return;

        GD.Print($"Saindo: {CurrentState?.Name}");

        CurrentState?.Exit();

        CurrentState = newState;

        GD.Print($"Entrando: {CurrentState.Name}");

        CurrentState.Enter();
    }
}
