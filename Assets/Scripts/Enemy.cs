using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    float distance;
    public float health = 100;
    public float minDistance;

    public Transform player;

    public NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.SetDestination(transform.position);

        
    }

    // Update is called once per frame
    void Update()
    {

        ChasePlayer();
        
        if(health < 0)
        {
            Death();
        }

        distance = Vector3.Distance(transform.position, player.transform.position);

        //print(distance);
    }

    private void ChasePlayer()
    {
        //transform.LookAt(player);
      
        agent.SetDestination(player.position);
        //print("kek");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        print("aua");
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
