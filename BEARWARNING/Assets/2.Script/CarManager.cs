using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarManager : MonoBehaviour
{
    //���ӽ��� UI
    public GameObject playOn;

    //ī�޶󰳼�, ���ΰ���
    int camera_eat;


  

    private void Update()
    {
       RaycastHit hit;
    Debug.DrawRay(transform.position+new Vector3(0,1f,0), Vector3.down * 1, Color.red);

        if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), Vector3.down, out hit))
        {
           // print(hit.collider.name);
            playOn.GetComponent<GameUIManager>().hit = hit;
        }
    }



    ////�÷��̾ �ݶ��̴��� ��Ҵٸ�
    //private void OnCollisionEnter(Collision collision)
    //{
    //    //�±װ� ��Ҵٸ� 
    //    switch(collision.gameObject.tag)
    //    {

    //        //���̶� �ε����ٸ� 
    //        case "Bear":    

    //            //hp ����
    //            GameManager.instance.hp--;
    //            //������ hp UI����
    //            playOn.GetComponent<GameUIManager>().hpUpdate();
    //            //���� hp�� ���ٸ� 
    //            if(GameManager.instance.hp==0)
    //            {
    //                //���忣������ ��ȯ
    //                FindObjectOfType<SettingManager>().DieClick();

    //            }
    //            break;

            
    //    }    
    //}

    //�÷��̾ �ݶ��̾ ��Ҵٸ� (Ʈ����)
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //������ġ��
            case "StartLine":
                //�÷��� UIȰ��ȭ
                playOn.SetActive(true);
                break;

            //�������ο� �����ߴٸ� 
            case "FinishLine":
                FindObjectOfType<SettingManager>().WinClick();
                break;

            //�����̸�
            case "Coin":
                //print(other.gameObject.name);
                //������ ������ UI ����
                playOn.GetComponent<GameUIManager>().CoinEat();

                //���� ���� ����
                Destroy(other.gameObject);

                break;

            //ī�޶���
            case "Camera":
                playOn.GetComponent<GameUIManager>().CameraEat();
                //���� ī�޶� ����
                Destroy(other.gameObject);
                break;


            //���̶��
            case "Honey":
                //�� ���� ������ UI���� 
                playOn.GetComponent<GameUIManager>().HoneyEat();
                //���� �� ����
                Destroy(other.gameObject);
                break;
        }
    }

    }
