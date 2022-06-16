using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stroy : MonoBehaviour
{

    GameObject [] people;

    Text talk;

    Dictionary<int,string[]> talkData;

    bool isPull;

    int count1=0, count2=0;
    // Start is called before the first frame update
    void Start()
    {
        people = GameObject.FindGameObjectsWithTag("person");
        talk = GameObject.Find("talk").GetComponent<Text>();

        talkData = new Dictionary<int, string[]>();
        GenerateData();


    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "사파리월드에 오신 것을 환영합니다.\n 저희 사파리는 다양한 야생동물을 차의 창문을 통해서 보실 수 있습니다. ", 
            "아! 한가지 주의사항이 있습니다.", 
            "요새 곰이 난폭해 져서 차를 공격하는 일이 빈번하게 일어나고 있습니다. \n 저희 직원이 “곰 출현주의” 표지판을 세워 놨으니 그 곳을 들어가지 마세요." ,""});
        talkData.Add(2, new string[] { "안녕하세요. 제가 운전해서 마음껏 돌아다녀도 되나요?", "어떤 것이죠 ?", "(아,,곰보러 온건데…;;) 네 알겠습니다.","" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }



    // Update is called once per frame
    void Update()
    {

        if(Input.anyKeyDown)
        {
            isPull =!isPull;
            if(isPull)
            {
                count1++;
            }
            else
            {
                count2++;
            }

        }
        
        if(!isPull)
        {
            talk.text = GetTalk(1, count1);
            talk.color = Color.black;
            people[0].SetActive(false);
            people[1].SetActive(true);
           
        }
        else
        {
            talk.text = GetTalk(2, count2);
            talk.color=Color.white;
            people[1].SetActive(false);
            people[0].SetActive(true);
           
        }


           if(count2==3)
        {
            Destroy(gameObject);
        }
 
        
    }


}
