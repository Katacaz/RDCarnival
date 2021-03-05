using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    Enemy enemy;

    public float moveSpeed = 3.5f;
    private AggroDetection aggroDetection;
    private Transform target;

    GameStateCheck gameState;
    private void Awake()
    {
        gameState = FindObjectOfType<GameStateCheck>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        //aggroDetection.OnAgrro += AggroDetection_OnAgrro;
        enemy = GetComponent<Enemy>();
    }

    /*private void AggroDetection_OnAgrro(CharacterInfo target)
    {
        this.target = target.transform;
        
    }*/

    private void Update()
    {
        if (!gameState.gamePaused)
        {
            if (enemy.currentTarget != null)
            {
                target = enemy.currentTarget.transform;
            }
            if (target != null)
            {
                //Debug.Log("Moving towards target: " + target.name);
                navMeshAgent.speed = moveSpeed * Time.timeScale;
                navMeshAgent.SetDestination(target.position);
                float speed = navMeshAgent.velocity.magnitude;
                animator.SetFloat("Speed", speed);
            }
        } else
        {
            navMeshAgent.speed = 0;
        }
        
    }
}
