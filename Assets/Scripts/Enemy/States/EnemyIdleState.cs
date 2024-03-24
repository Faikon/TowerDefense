using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : BaseState<Enemy>
{
    private Transform _transformPoint;

    public override void Enter()
    {
        _transformPoint = GameObject.Find("Point").transform;
    }

    public override void Update()
    {
        Owner.Agent.SetDestination(Owner.transform.position);

        if(Vector3.Distance(Owner.Agent.transform.position, _transformPoint.position) > 5)
        {
            Owner.StateMachine.SwitchState<EnemyMovementState, Enemy>(Owner, state =>
            {
                state._transformPoint = _transformPoint;
            });
        }
    }
}
