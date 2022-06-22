using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearManager : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;

   public bool isON=false;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<CarController>().transform;

    }

    // Update is called once per frame
    void Update()
    {

          if(isON)
        {
            BearMove();
        }

    }


    void BearMove()
    {
        //agent.destination = player.position;
    }


}
