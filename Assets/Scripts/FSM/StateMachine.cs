using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StateMachine : IStateMachine
{
    public IState CurrentState { get; private set; }

    public void UpdateState()
    {
        CurrentState?.Update();
    }

    public void SwitcState<T, Owner>(Owner owner)
        where T : BaseState<Owner>, new()
        where Owner : class, IStateMachineOwner
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
            CurrentState.Dispose();
        }

        T state = new T();
        state.Owner = owner;

        CurrentState = state;
        CurrentState.Enter();
    }
}
