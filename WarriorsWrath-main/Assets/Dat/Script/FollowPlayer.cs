using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 3.0f;

    [SerializeField] private float distanceToPlayer;
    [SerializeField] private float distanceToAttack;
    NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private bool isAttacking;

    private bool isRight;
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;   
        agent.updateUpAxis = false;
        animator = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > distanceToAttack && isAttacking == false)
        {
            agent.isStopped = false;
            agent.speed = moveSpeed;
            agent.SetDestination(player.position);
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            isAttacking = true;
            agent.isStopped = true;
            agent.speed = 0;
            animator.SetFloat("Speed", 0.0f);
            agent.ResetPath();
        }



        if (isAttacking)
        {
            return;
        }
        if(player.transform.position.x >= transform.position.x)
        {
            isRight = true;
            gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            isRight = false;
            gameObject.transform.GetChild(0).GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
        }

        //Di chuyen
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            if (direction != Vector3.zero)
            {

            }
            else
            {

            }
        }
    }

    public bool getIsAttacking()
    {
        return isAttacking;
    }

    public void SetAttacking()
    {
        isAttacking= false;
    }
}
