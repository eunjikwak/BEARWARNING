using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stroy : MonoBehaviour
{
    //등장인물 오브젝트 (배열)
    GameObject [] people;

    //대화창
    Text talk;

    //사전으로 데이타 가져옴
    Dictionary<int,string[]> talkData;


    //클릭햇니?
    bool isClick;


    //대화 순서 체크
    int count1=0, count2=0;
    // Start is called before the first frame update
    void Start()
    {
        //등장인물을 태그로 가져오기
        people = GameObject.FindGameObjectsWithTag("person");
        //이름으로 텍스트창 가져오기
        talk = GameObject.Find("talk").GetComponent<Text>();
        //선언
        talkData = new Dictionary<int, string[]>();
        GenerateData();


    }


    //대화 데이터 저장
    void GenerateData()
    {

        //직원
        talkData.Add(1, new string[] { "사파리월드에 오신 것을 환영합니다.\n 저희 사파리는 다양한 야생동물을 차의 창문을 통해서 보실 수 있습니다. ", 
                                       "아! 한가지 주의사항이 있습니다.", 
                                       "요새 곰이 난폭해 져서 차를 공격하는 일이 빈번하게 일어나고 있습니다. \n 저희 직원이 “곰 출현주의” 표지판을 세워 놨으니 그 곳을 들어가지 마세요." ,""});


        //손님
        talkData.Add(2, new string[] { "안녕하세요. 제가 운전해서 마음껏 돌아다녀도 되나요?",
                                       "어떤 것이죠 ?", 
                                       "(아,,곰보러 온건데…;;) 네 알겠습니다.","" });
    }

    //반환
    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }



    // Update is called once per frame
    void Update()
    {
        //좌클릭을 하면 
        if(Input.GetMouseButtonDown(0))
        {
            //클릭했음
            isClick = !isClick;
            if(isClick)
            {
                //직원 대화창 카운트
                count1++;
            }
            else if(!isClick)
            {
                //손님 대화창 카운트
                count2++;
            }

        }
        

        //눌렀다면 
        if(!isClick)
        {
            //대화창 텍스트 할당, 색상 변경
            talk.text = GetTalk(1, count1);
            talk.color = Color.black;

            //직원 활성화 손님 비활성화
            people[0].SetActive(false);
            people[1].SetActive(true);
           
        }
        else
        {   //대화창 텍스트 할당,색상변경
            talk.text = GetTalk(2, count2);
            talk.color=Color.white;

            //손님 활성화 직원비활성화
            people[1].SetActive(false);
            people[0].SetActive(true);
           
        }


        //모든 대화가 끝나면
           if(count2==3)
        {

            //게임오브젝트 삭제 
            Destroy(gameObject);

        }
 
        
    }


}
