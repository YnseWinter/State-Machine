using UnityEngine;

public class ChaseState : State
{
    public ChaseState(EnemyController enemy) : base(enemy) { }

    public override void Enter()
    {
        Debug.Log("Enemy starts chasing the player!");
    }

    public override void Update()
    {
        enemy.MoveTowardsPlayer();

        if (!enemy.SeesPlayer())  // Lost sight of the player
        {
            enemy.StopMovement();
            enemy.ChangeState(new IdleState(enemy));
        }

        if (enemy.CanAttackPlayer())
        {
            enemy.StopMovement();
            enemy.ChangeState(new AttackState(enemy));
        }
    }

    public override void Exit()
    {
        Debug.Log("Stopping chase.");
    }
}
