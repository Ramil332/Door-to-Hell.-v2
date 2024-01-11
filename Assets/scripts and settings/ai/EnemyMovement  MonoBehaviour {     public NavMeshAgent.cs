// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Player mainPlayer;
    private NavMeshAgent agent;
    public Transform[] waypoints;
    public Transform targetToFollow;
    public float followRadius = 10f;
    public Animator animator;
    public GameObject player;
    bool isAttacking;
    bool IsMovingToRandomPoint;
    public float AttackRange = 3f;
    int randomIndex;
    public float TimeSetRandomPoint = 1.0f;
    void Start()
    {
        randomIndex = 0;
        IsMovingToRandomPoint = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void SetRandomDestination()
    {
        if (waypoints.Length > 0)
        {
            if (Vector3.Distance(transform.position, waypoints[randomIndex].position) > 0.1f)
            {
                animator.SetBool("Walk", true);
                agent.SetDestination(waypoints[randomIndex].position);
                IsMovingToRandomPoint = true;
            }
            else
            {
                IsMovingToRandomPoint = false;
                randomIndex = Random.Range(0, waypoints.Length);
            }
        }
    }
    void StartAttackAnimation()
    {
        isAttacking = true;
        Debug.Log("Atack");
        animator.SetTrigger("Attack");
    }
    void IsAttacked()
    {
        isAttacking = false;
    }
    void Update()
    {
        if (targetToFollow != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, targetToFollow.position);
            if (distanceToPlayer <= followRadius)
            {

                if (distanceToPlayer > AttackRange && !isAttacking)
                {
                    IsMovingToRandomPoint = false;
                    agent.SetDestination(targetToFollow.position);
                    animator.SetBool("Walk", true);
                }
                else
                {
                    animator.SetBool("Walk", false);
                    StartAttackAnimation();
                }

            }
            else
            {
                if (agent.remainingDistance < agent.stoppingDistance)
                {
                    animator.SetBool("Walk", true);
                    agent.SetDestination(waypoints[randomIndex].position);

                }
                else
                {
                    randomIndex = Random.Range(0, waypoints.Length);
                }
            }

        }

    }
}
