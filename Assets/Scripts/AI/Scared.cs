using UnityEngine;
using UnityEngine.AI;

public class Scared : State
{
    public Scared(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.SCARED;
    }
    
    public override void Enter()
    {
        Debug.Log("Scared");
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (EnemyClass.target == null) return;

        if (EnemyClass.isScared)
        {
            Vector3 bestFleePos = Vector3.zero;
            float maxDistance = 0f;

            // Try directions in a circle (every 45 degrees)
            for (int i = 0; i < 360; i += 45)
            {
                Vector3 dir = Quaternion.Euler(0, i, 0) *
                              (EnemyClass.transform.position - EnemyClass.target.position).normalized;
                Vector3 candidate = EnemyClass.transform.position + dir * 10f;

                if (NavMesh.SamplePosition(candidate, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
                {
                    float distanceToTarget = Vector3.Distance(hit.position, EnemyClass.target.position);
                    if (distanceToTarget > maxDistance)
                    {
                        maxDistance = distanceToTarget;
                        bestFleePos = hit.position;
                    }
                }
            }

            if (maxDistance > 0f)
            {
                Agent.SetDestination(bestFleePos);
            }
        }
        else
        {
            NextState = new Chasing(EnemyClass, Agent);
            Stage = EVENT.EXIT;
        }
    }


}
