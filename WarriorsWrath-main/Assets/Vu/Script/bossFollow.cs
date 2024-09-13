using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float moveSpeed;
    private NavMeshAgent agent;
    private float distanceToPlayer;
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        agent.speed = moveSpeed;
        agent.SetDestination(player.position);

        if (player.transform.position.x >= transform.position.x)
        {
            isRight = true;
            GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            isRight = false;
            GetComponent<Transform>().localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void startChasing()
    {
        agent.isStopped = false;
    }

    public void stopChasing()
    {
        agent.isStopped = true;
    }

    public float getDistance()
    {
        return distanceToPlayer;
    }
    public bool Right()
    {
        return isRight;
    }
    public void setSPD(float spd)
    {
        moveSpeed = spd;
    }
}
