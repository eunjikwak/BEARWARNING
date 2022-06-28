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
   

    private void Update()
    {

    }



    //플레이어가 콜라이더에 닿았다면
    private void OnCollisionEnter(Collision collision)
    {
        //태그가 닿았다면 
        switch(collision.gameObject.tag)
        {

            //곰이랑 부딪혔다면 
            case "Bear":    

                //hp 감소
                GameManager.instance.hp--;
                //감소한 hp UI적용
                playOn.GetComponent<GameUIManager>().hpUpdate();
                //만약 hp가 없다면 
                if(GameManager.instance.hp==0)
                {
                    //새드엔딩으로 전환
                    FindObjectOfType<SettingManager>().DieClick();

                }
                break;

            
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
        }
    }

    }
