using UnityEngine;

public class IdleState : State
{
    public IdleState(EnemyController enemy) : base(enemy) { }

    public override void Enter()
    {
        Debug.Log("Enemy is now idle.");
    }

    public override void Update()
    {
        if (enemy.SeesPlayer())  // Check if the player is spotted
        {
            enemy.ChangeState(new ChaseState(enemy));
        }
    }

    public override void Exit()
    {
        Debug.Log("Leaving Idle state.");
    }
}
