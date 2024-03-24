using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour, IStateMachineOwner
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private const string VerticalDirection = "Vertical";
    private const string HorizontalDirection = "Horizontal";

    private Rigidbody _rigidbody;
    private Vector3 _movement;

    public IStateMachine StateMachine { get; private set; } = new StateMachine();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        //StateMachine.SwitcState<TestStateA, PlayerMovement>(this);
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Update()
    {
        StateMachine.UpdateState();
    }

    private void Move()
    {
        float xDirection = _joystick.Horizontal;
        float zDirection = _joystick.Vertical;

        if (Input.GetAxisRaw(HorizontalDirection) != 0 | Input.GetAxisRaw(VerticalDirection) != 0)
        {
            xDirection = Input.GetAxisRaw(HorizontalDirection);
            zDirection = Input.GetAxisRaw(VerticalDirection);
        }

        _movement = new Vector3(xDirection, 0, zDirection);
        _agent.speed = _speed;
        _agent.velocity = _movement.normalized * _agent.speed;
    }

    private void Rotate()
    {
        if (_movement != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(_movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed);
        }
    }
}
