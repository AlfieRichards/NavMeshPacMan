using UnityEngine;

public class AIFlee : AIBaseState
{
    public override void EnterState(AIStateManager enemy)
    {
        enemy.agent.isStopped = false;
        enemy.index= Random.Range(0, enemy.positions.Length);
        enemy.currentPosition = enemy.positions[enemy.index];
        enemy.agent.SetDestination(enemy.currentPosition.transform.position);
    }
    
    public override void UpdateState(AIStateManager enemy)
    {

    }   

    public override void OnCollisionEnter(AIStateManager enemy, Collision collsion)
    {

    }
}