using UnityEngine;

public class AIChase : AIBaseState
{
    public bool delayed = true;
    Vector3 velocity;

    public override void EnterState(AIStateManager enemy)
    {
        enemy.agent.isStopped = false;
    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        if(enemy.agent.pathPending)
        {
            enemy.agent.velocity = velocity;
        }
        if(delayed)
        {
            delayed = false;
            velocity = enemy.agent.velocity;
            enemy.agent.SetDestination(enemy.player.transform.position);
            enemy.Invoke("resetDelay", .1f);
        }
    }

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}