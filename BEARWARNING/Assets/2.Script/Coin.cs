using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int coin;

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.coin++;

            print("코인개수:" + GameManager.instance.coin);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
