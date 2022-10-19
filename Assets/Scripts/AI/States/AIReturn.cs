using UnityEngine;

public class AIReturn : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {

    }
    
    public override void UpdateState(AIStateManager enemy)
    {
        enemy.agent.SetDestination(enemy.home.transform.position);
    }   

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}