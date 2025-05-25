using UnityEngine;

public abstract class State
{
    protected EnemyController enemy;

    public State(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
