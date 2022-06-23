using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //대쉬보드 바늘
    public GameObject needle;

    //시작점,끝점
    float start_pos = 220f, end_pos = -42f;
    //원하는 위치
    float desired_pos;
    //차스피드
    float carSpeed;

    //시간 초,분
    float time;
    int sec, min;
    //플레이시간
    public Text playTime;
    //hp 이미지/스프라이트
    public Image [] hp_img;
    public Sprite ramdom_hp_F;
    
    //코인텍스트, 카메라텍스트 배열
    Text[] texts;
    public Image item_img;
    public Sprite[] items;

    


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<BearManager>().isON = true;
        texts = GetComponentsInChildren<Text>();
      

    }

    private void FixedUpdate()
    {
        //카메라스피드 = 차컨트롤러에 스피드넣어주기 
        carSpeed =CarController.speed;
        //대시보드 함수 호출
        UpdateNeedle();
        //시간 시작
        TimeStart();
       
    }


    //대쉬보드
    public void UpdateNeedle()
    {

        //원하는 위치 구하기
        desired_pos = start_pos - end_pos;
        //차 스피드를 temp 180으로 나누기
        float temp = carSpeed / 180f;
        //바늘 각도 구하기
        needle.transform.eulerAngles = new Vector3(0, 0, start_pos - temp * desired_pos);
    }


    //시간 시작 함수
    public void TimeStart()
    {

        //시간초 시작
        time += Time.deltaTime;

        sec = (int)time;

        if(sec==60)
        {
            min++;
            time = 0;
        }

        playTime.text = min.ToString("00:") + sec.ToString("00");

        //게임 오브젝트에 시간 넣어주기 
        GameManager.instance.lastTime = playTime.text;

    }


    //HP 업데이트 함수
    public void hpUpdate()
    {

        //랜덤 hp이미지 구현
        for (int i =4; i >= GameManager.instance.hp; i--)
        {
            //이미지 스프라이트 변경
            hp_img[i].sprite = ramdom_hp_F;
        }
    }


    //코인을 먹었을때 호출 
    public void CoinEat(int coin)
    {
        //코인을 3개 먹었다면 
        if (coin == 10)
        {
            //코인 초기화
            coin = 0;
            //슬롯에 기름 아이템 생성
            item_img.sprite = items[0];

        }
        
        
       
        //코인 개수 업데이트 
        texts[0].text = "X" + coin;
    }



    //카메라 먹었을때 호출 
    public void CameraEat(int camera)
    { 
       
        //카메라 개수 업데이트 
        texts[1].text = "X"+camera;
        //슬롯에 카메라 아이템 생성 
        item_img.sprite = items[1];



    }

    //꿀아이템 먹었을때 호출 
    public void HoneyEat()
    {
        //슬롯에 꿀 아이템 생성 
        item_img.sprite = items[2];
    }
}
