using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarManager : MonoBehaviour
{
    public GameObject playOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartLine")
        {
            playOn.SetActive(true);
            // playOn.SendMessage("TimeStart");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Bear":
               // print("°õÀÌ ÇÃ·¹ÀÌ¾î °ø°Ý");
                GameManager.instance.hp--;
                playOn.GetComponent<GameUIManager>().hpUpdate();
                if(GameManager.instance.hp==0)
                {
                   //print("ÇÃ·¹ÀÌ¾î ²Ò²¿´Ú");

                    FindObjectOfType<SettingManager>().DieClick();

                }
                break;

            case "Coin":

                print("ÄÚÀÎ¸ÔÀ½");
                Destroy(collision.collider.gameObject);

                break;


            case "Camera":

                print("Ä«¸Þ¶ó¸ÔÀ½");
                Destroy(collision.collider.gameObject);

                break;


            case "Honey":

                print("²Ü¸ÔÀ½");
                Destroy(collision.collider.gameObject);

                break;
        }
        
    }
}
