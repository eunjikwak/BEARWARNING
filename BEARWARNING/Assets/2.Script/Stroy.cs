using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stroy : MonoBehaviour
{
    //�����ι� ������Ʈ (�迭)
    GameObject [] people;

    //��ȭâ
    Text talk;

    //�������� ����Ÿ ������
    Dictionary<int,string[]> talkData;


    //Ŭ���޴�?
    bool isClick;


    //��ȭ ���� üũ
    int count1=0, count2=0;
    // Start is called before the first frame update
    void Start()
    {
        //�����ι��� �±׷� ��������
        people = GameObject.FindGameObjectsWithTag("person");
        //�̸����� �ؽ�Ʈâ ��������
        talk = GameObject.Find("talk").GetComponent<Text>();
        //����
        talkData = new Dictionary<int, string[]>();
        GenerateData();


    }


    //��ȭ ������ ����
    void GenerateData()
    {

        //����
        talkData.Add(1, new string[] { "���ĸ����忡 ���� ���� ȯ���մϴ�.\n ���� ���ĸ��� �پ��� �߻������� ���� â���� ���ؼ� ���� �� �ֽ��ϴ�. ", 
                                       "��! �Ѱ��� ���ǻ����� �ֽ��ϴ�.", 
                                       "��� ���� ������ ���� ���� �����ϴ� ���� ����ϰ� �Ͼ�� �ֽ��ϴ�. \n ���� ������ ���� �������ǡ� ǥ������ ���� ������ �� ���� ���� ������." ,""});


        //�մ�
        talkData.Add(2, new string[] { "�ȳ��ϼ���. ���� �����ؼ� ������ ���ƴٳ൵ �ǳ���?",
                                       "� ������ ?", 
                                       "(��,,������ �°ǵ���;;) �� �˰ڽ��ϴ�.","" });
    }

    //��ȯ
    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }



    // Update is called once per frame
    void Update()
    {
        //��Ŭ���� �ϸ� 
        if(Input.GetMouseButtonDown(0))
        {
            //Ŭ������
            isClick = !isClick;
            if(isClick)
            {
                //���� ��ȭâ ī��Ʈ
                count1++;
            }
            else if(!isClick)
            {
                //�մ� ��ȭâ ī��Ʈ
                count2++;
            }

        }
        

        //�����ٸ� 
        if(!isClick)
        {
            //��ȭâ �ؽ�Ʈ �Ҵ�, ���� ����
            talk.text = GetTalk(1, count1);
            talk.color = Color.black;

            //���� Ȱ��ȭ �մ� ��Ȱ��ȭ
            people[0].SetActive(false);
            people[1].SetActive(true);
           
        }
        else
        {   //��ȭâ �ؽ�Ʈ �Ҵ�,���󺯰�
            talk.text = GetTalk(2, count2);
            talk.color=Color.white;

            //�մ� Ȱ��ȭ ������Ȱ��ȭ
            people[1].SetActive(false);
            people[0].SetActive(true);
           
        }


        //��� ��ȭ�� ������
           if(count2==3)
        {

            //���ӿ�����Ʈ ���� 
            Destroy(gameObject);

        }
 
        
    }


}
