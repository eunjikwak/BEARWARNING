using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    Animator[] anims;
    string[] names = { "eat", "jump", "walk" };
    // Start is called before the first frame update
    void Start()
    {
        anims = GetComponentsInChildren<Animator>();
        HorseMove();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void HorseMove()
    {

        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].SetTrigger(names[Random.Range(0, names.Length)]);
           
        }

        Invoke("HorseMove", 2f);

    }
}
