using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movementSpeed;
    public float sightDistance;
    public float attackDistance;
    public float attackDuration;

    private State currentState;

    private Rigidbody2D rb;

    void Start()
    {
        currentState = new IdleState(this);
        currentState.Enter();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        currentState.Update();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public bool SeesPlayer()
    {
        // Placeholder: Implement actual visibility logic
        return Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < sightDistance;
    }

    public void MoveTowardsPlayer()
    {
        Vector2 movement = (PlayerController.instance.rb.position - rb.position).normalized;
        rb.linearVelocity = movement * movementSpeed;
    }

    public void StopMovement()
    {
        rb.linearVelocity = Vector2.zero;
    }

    public bool CanAttackPlayer()
    {
        return Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) < attackDistance;
    }
}
