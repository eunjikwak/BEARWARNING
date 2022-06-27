using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BearManager : MonoBehaviour
{

    //AI변수
    NavMeshAgent agent;
    //타겟 위치
    Transform player;

    //플레이 유무
    public bool isON;
    //곰 움직임 유무
    bool isMove;
    //숫자 이미지
    public Image number_Img;
    //숫자 변경 이미지 배열
    public Sprite[] number_sprite;
    //시간 변수
    float time;
    //도망치라는 텍스트 
    public GameObject runText;

    // Start is called before the first frame update
    void Start()
    {
        //애너미 AI
        agent = GetComponent<NavMeshAgent>();
        //플레이어 위치 가져오기
        player = FindObjectOfType<CarController>().transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        //게임이 시작됐다면
        if (isON)
        {
            //움직이기전 UI활성화
            BeforeMove();
            //도망치라는 멘트 활성화
            runText.SetActive(true);
        }
       //움직이고 있다면 
        if(isMove)
        {
            //도망치라는 멘트 비활성화
            runText.SetActive(false);
            //곰 움직임 시작
            BearMove();
        }


    }


    //곰이움직이는 함수
    void BearMove()
    {
        //곰의 움직이는 거리를 플레이어의 위치로
        agent.destination = player.position;
        //print("곰이 따라오는거 시작");
    }


    //움직이기 전 숫자 표시 함수
    void BeforeMove()
    {

        //시간 (초 세기위해서)
        time +=Time.deltaTime;
        
        

        //플롯 시간을 인트로 변환해줌 
        int sec = (int)time;
        //1초가 지났다면
        if(sec==1)
        {
            //2라는 스프라이트를 이미지에 저장
            number_Img.sprite = number_sprite[0];
        }
        //2초가 지났다면
        else if(sec ==2)
        {
            //1이라는 스프라이트를 이미지에 저장
            number_Img.sprite = number_sprite[1];
        }
        //3초가 지났다면 
        else if(sec ==3)
        {
            //이미지 UI비활성화
            number_Img.gameObject.SetActive(false);
            //움직이기 시작
            isMove = true;
           
        }
   
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="HoneyAttck")
        {
           
            print("아악! 곰 넘어짐 ");
            agent.isStopped = true;

            Destroy(other.gameObject, 5);

           
        }
    }

}
