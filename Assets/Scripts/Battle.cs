using UnityEngine;
using UnityEngine.AI;

public class Battle : State
{
    private float attackCooldown = 1.5f; // seconds between attacks
    private float attackTimer;

    public Battle(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.BATTLE;
    }

    public override void Enter()
    {
        Debug.Log("In Battle");

        Agent.isStopped = true; // Stop movement during battle
        attackTimer = attackCooldown;

        base.Enter();
    }

    public override void Update()
    {
        if (EnemyClass.target == null)
        {
            Debug.Log("Lost target going Idle");
            NextState = new Idle(EnemyClass, Agent);
            Stage = EVENT.EXIT;
            return;
        }

        float distanceToTarget = Vector3.Distance(EnemyClass.transform.position, EnemyClass.target.position);

        if (distanceToTarget > EnemyClass.atkRange)
        {
            Debug.Log("Target out of range");
            NextState = new Chasing(EnemyClass, Agent);
            Stage = EVENT.EXIT;
            return;
        }

        // Handle attack cooldown
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            Character targetCharacter = EnemyClass.target.GetComponent<Character>();
            if (targetCharacter != null)
            {
                EnemyClass.Attack(targetCharacter);
                attackTimer = 0f;
            }
        }
    }

    public override void Exit()
    {
        Agent.isStopped = false;
        base.Exit();
    }
}
