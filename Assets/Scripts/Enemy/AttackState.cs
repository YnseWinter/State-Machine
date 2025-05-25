using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public class AttackState : State
{
    private bool isAttacking = false;
    public AttackState(EnemyController enemy) : base(enemy) { }

    public override void Enter()
    {
        Debug.Log("Enemy is attacking!");
        isAttacking = true;
        enemy.StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(enemy.attackDuration);
        isAttacking = false;
    }

    public override void Update()
    {
        if (!isAttacking)
        {
            enemy.ChangeState(new ChaseState(enemy));
        }
    }

    public override void Exit()
    {
        Debug.Log("Enemy stopped attacking");
    }
}
