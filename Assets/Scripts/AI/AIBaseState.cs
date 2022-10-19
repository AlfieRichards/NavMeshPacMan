using UnityEngine;

public abstract class AIBaseState
{
    public abstract void EnterState(AIStateManager enemy);

    public abstract void UpdateState(AIStateManager enemy);

    public abstract void OnCollisionEnter(AIStateManager enemy, Collision collsion); 
}

