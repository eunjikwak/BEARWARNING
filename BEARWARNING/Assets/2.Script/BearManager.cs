using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearManager : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<CarController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.Move(player.position);
    }
}
