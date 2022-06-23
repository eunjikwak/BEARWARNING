using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarManager : MonoBehaviour
{
    //게임시작 UI
    public GameObject playOn;

    //카메라개수, 코인개수
    int camera_eat,coin_eat;

    Color color;

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

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            ////코인이면
            //case "Coin":

            //    coin_eat++;

            //    //증가한 코인을 UI 적용
            //    playOn.GetComponent<GameUIManager>().CoinEat(coin_eat);

            //    //먹은 코인 삭제
            //    Destroy(other.gameObject);

            //    break;
            
            //카메라라면
            case "Camera":
                ////카메라 개수 증가
                camera_eat++;
                //증가한 카메라 멘트 UI적용
                playOn.GetComponent<GameUIManager>().CameraEat(camera_eat);
                //먹은 코인 삭제
                Destroy(other.gameObject);
                break;
        }

    }


    //플레이어가 콜라이어에 닿았다면 (트리거)
    void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //시작위치면
            case "StartLine":

                //플레이 UI활성화
                playOn.SetActive(true);
                break;

            ////코인이면
            //case "Coin":

            //  SpriteRenderer coinColor= other.GetComponent<SpriteRenderer>();
            //    color.a = 0;
            //    coinColor.color = color;
            //    break;

            //카메라라면
            case "Camera":
                SpriteRenderer cameraColor = other.GetComponent<SpriteRenderer>();
                color.a = 0;
                cameraColor.color = color;
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
