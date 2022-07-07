using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarManager : MonoBehaviour
{
    //게임시작 UI
    public GameObject playOn;

    //카메라개수, 코인개수
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
                
                  print( "리스폰 해야함");
            }
           print(hit.collider.tag);
            playOn.GetComponent<GameUIManager>().hit = hit;
        }


    }



  
    //플레이어가 콜라이어에 닿았다면 (트리거)
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //시작위치면
            case "StartLine":
                //플레이 UI활성화
                playOn.SetActive(true);
                break;

            //도착라인에 도착했다면 
            case "FinishLine":
                FindObjectOfType<SettingManager>().WinClick();
                break;

            //코인이면
            case "Coin":
                //print(other.gameObject.name);
                //증가한 코인을 UI 적용
                playOn.GetComponent<GameUIManager>().CoinEat();

                //먹은 코인 삭제
                Destroy(other.gameObject);

                break;

            //카메라라면
            case "Camera":
                playOn.GetComponent<GameUIManager>().CameraEat();
                //먹은 카메라 삭제
                Destroy(other.gameObject);
                break;


            //꿀이라면
            case "Honey":
                //꿀 먹은 아이템 UI적용 
                playOn.GetComponent<GameUIManager>().HoneyEat();
                //먹은 꿀 삭제
                Destroy(other.gameObject);
                break;

            //양을 지나갔다면 
            case "Sheap":

                sheap.GetComponent<AnimalManager>().isSheapMove = true;

                break;
        }
    }

    }
