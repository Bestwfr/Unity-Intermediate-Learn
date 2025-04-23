using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public Transform[] ObserveLocation => _observeLocation;
    
    [SerializeField]private Transform[] _observeLocation;
    [SerializeField]private NavMeshAgent _agent;
    public float detectionRadius = 5f;
    public float atkRange = 1f;
    public Transform target;
    
    private State _currentState;

    private void Start()
    {
        _currentState = new Roaming(this, _agent);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Attack(Character target)
    {
        Debug.Log("I attack player");
        base.Attack(target);
    }

    private void Update()
    {
        _currentState = _currentState.Process();
    }
}
