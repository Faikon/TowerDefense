using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine 
{
    IState CurrentState {  get; }
    void SwitcState<T, Owner>(Owner owner)
         where T : BaseState<Owner>, new()
        where Owner : class, IStateMachineOwner;
    void UpdateState();

}
