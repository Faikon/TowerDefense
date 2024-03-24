using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementState : BaseState<Enemy>
{
    public Transform _transformPoint;

    public override void Update()
    {
        Owner.Agent.SetDestination(_transformPoint.position);

        if(Owner.Agent.path.corners.Length > 1  & Owner.Agent.remainingDistance <= 0.5)
        {
            Owner.StateMachine.SwitchState<EnemyIdleState, Enemy>(Owner);
        }
    }
}
