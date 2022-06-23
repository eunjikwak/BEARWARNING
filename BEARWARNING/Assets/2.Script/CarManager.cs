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
               // print("���� �÷��̾� ����");
                GameManager.instance.hp--;
                playOn.GetComponent<GameUIManager>().hpUpdate();
                if(GameManager.instance.hp==0)
                {
                   //print("�÷��̾� �Ҳ���");

                    FindObjectOfType<SettingManager>().DieClick();

                }
                break;

            
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
       switch(other.gameObject.tag)
        {
            case "Coin":

                print("���θ���");
                Destroy(other.gameObject);

                break;


            case "Camera":

                print("ī�޶����");
                Destroy(other.gameObject);

                break;


            case "Honey":

                print("�ܸ���");
                Destroy(other.gameObject);

                break;
        }
    }
}
