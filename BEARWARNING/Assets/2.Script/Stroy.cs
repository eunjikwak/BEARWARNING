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
        talkData.Add(1, new string[] { "���ĸ����忡 ���� ���� ȯ���մϴ�.\n ���� ���ĸ��� �پ��� �߻������� ���� â���� ���ؼ� ���� �� �ֽ��ϴ�. ", 
            "��! �Ѱ��� ���ǻ����� �ֽ��ϴ�.", 
            "��� ���� ������ ���� ���� �����ϴ� ���� ����ϰ� �Ͼ�� �ֽ��ϴ�. \n ���� ������ ���� �������ǡ� ǥ������ ���� ������ �� ���� ���� ������." ,""});
        talkData.Add(2, new string[] { "�ȳ��ϼ���. ���� �����ؼ� ������ ���ƴٳ൵ �ǳ���?", "� ������ ?", "(��,,������ �°ǵ���;;) �� �˰ڽ��ϴ�.","" });
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
