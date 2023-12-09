using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    float distance;
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
        
        

        distance = Vector3.Distance(transform.position, player.transform.position);

        //print(distance);
    }

    private void ChasePlayer()
    {
        //transform.LookAt(player);
      
        agent.SetDestination(player.position);
        print("kek");
    }
}
