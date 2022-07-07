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

    public GameObject sheap;

    public Transform respwanPoint;

  

    private void Update()
    {
       RaycastHit hit;
    Debug.DrawRay(transform.position+new Vector3(0,1f,0), Vector3.down * 1, Color.red);

        if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), Vector3.down, out hit))
        {
                
            if(hit.collider.tag=="test")
            {
                
                  print( "������ �ؾ���");
            }
           print(hit.collider.tag);
            playOn.GetComponent<GameUIManager>().hit = hit;
        }


    }



  
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

            //���� �������ٸ� 
            case "Sheap":

                sheap.GetComponent<AnimalManager>().isSheapMove = true;

                break;
        }
    }

    }
