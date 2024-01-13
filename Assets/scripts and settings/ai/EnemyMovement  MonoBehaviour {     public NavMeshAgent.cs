// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] waypoints;
    public float followRadius = 10f;
    public Animator animator;
    private GameObject player;
    bool isAttacking;
    public float AttackRange = 3f;
    int randomIndex;
    void Start()
    {
        randomIndex = 0;
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
            }
            else
            {
                randomIndex = Random.Range(0, waypoints.Length);
            }
        }
    }
    void StartAttackAnimation()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
    }
    void IsAttacked()
    {
        isAttacking = false;
    }
    void Update()
    {
        if (!isAttacking)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= AttackRange)
            {
                animator.SetBool("Walk", false);
                StartAttackAnimation();
            }
            else
                MoveToTarget();

        }
    }

    private void MoveToTarget()
    {
        animator.SetBool("Walk", true);

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= followRadius)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                agent.SetDestination(waypoints[randomIndex].position);
            }
            else
            {
                randomIndex = Random.Range(0, waypoints.Length);
            }
        }

    }
}
