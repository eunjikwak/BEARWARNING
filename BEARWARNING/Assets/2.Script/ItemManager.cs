using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

    public Sprite[] items;

   public  Image itemSlot;
   
    // Start is called before the first frame update
    void Start()
    {
       
      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            print("��Ʈ�� ����!");

        }
    }



  
}
