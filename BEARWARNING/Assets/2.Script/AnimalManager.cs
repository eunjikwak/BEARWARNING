using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    Animator[] anims;

    public bool isSheapMove;

    

    

    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponentsInChildren<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {

        if(isSheapMove)
        {

            SheapMove();
        }

      





    }

    public void SheapMove()
    {
        Vector3 point = new Vector3(-37f, -8f, 22f);
        transform.position = Vector3.Lerp(transform.position, point, 0.01f);

        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].SetBool("Walk", true);
        }

        

        if(transform.position.z>=21f)
        { 


            for (int i = 0; i < anims.Length; i++)
            {
                anims[i].SetBool("Walk", false);
            }
       
        }
        

    }

   
}
