using UnityEngine;
using UnityEngine.AI;

public class Chasing : State
{
    public Chasing(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.CHASING;
    }
    
    public override void Enter()
    {
        Debug.Log("Chasing");
        Agent.SetDestination(EnemyClass.target.position);
        base.Enter();
    }
    
    public override void Update()
    {
        Agent.SetDestination(EnemyClass.target.position); // constantly update path

        if (Agent.remainingDistance <= EnemyClass.atkRange)
        {
            NextState = new Battle(EnemyClass, Agent);
            Stage = EVENT.EXIT;
        }
    }
    
}
