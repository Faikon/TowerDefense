using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Enemy : MonoBehaviour, IStateMachineOwner
{
    [SerializeField] private int _health;
    [SerializeField] private NavMeshAgent _agent;

    public NavMeshAgent Agent => _agent;

    public IStateMachine StateMachine {  get; private set; }  
    //public IStateMachine StateMachine { get; private set; } = new StateMachine();

    public event Action<Enemy> Died;

    private void Start()
    {
        StateMachine = new StateMachine();
        StateMachine.SwitchState<EnemyIdleState, Enemy>(this);
    }

    private void Update()
    {
        StateMachine.UpdateState();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       Destroy(gameObject);
        Died?.Invoke(this);
    }
}
