using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BearManager : MonoBehaviour
{

    //AI����
    NavMeshAgent agent;
    //Ÿ�� ��ġ
    Transform player;

    //�÷��� ����
    public bool isON;
    //�� ������ ����
    bool isMove;
    //���� �̹���
    public Image number_Img;
    //���� ���� �̹��� �迭
    public Sprite[] number_sprite;
    //�ð� ����
    float time;
    //����ġ��� �ؽ�Ʈ 
    public GameObject runText;


    public enum EnmeyState
    {
        Idle,
        Walk,
        Run,
        Attak,
        Damaged
    }

    public EnmeyState eState;



    // Start is called before the first frame update
    void Start()
    {
        //�ֳʹ� AI
        agent = GetComponent<NavMeshAgent>();
        //�÷��̾� ��ġ ��������
        player = FindObjectOfType<CarController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //������ ���۵ƴٸ�
        if (isON)
        {
            //�����̱��� UIȰ��ȭ
            BeforeMove();
            //����ġ��� ��Ʈ Ȱ��ȭ
            runText.SetActive(true);


        }
        //�����̰� �ִٸ� 
        if (isMove)
        {
            //����ġ��� ��Ʈ ��Ȱ��ȭ
            runText.SetActive(false);
            //�� ������ ����
            BearMove();
        }


        switch (eState)
        {
            case EnmeyState.Idle: Idle(); break;
            case EnmeyState.Walk: Walk(); break;
            case EnmeyState.Run: Run(); break;
            case EnmeyState.Attak: Attack(); break;
            case EnmeyState.Damaged: Damged(); break;

        }


    }

    void Idle()
    {
        //�⺻�ִϸ��̼� 

        //�÷��̾ 3�ʰ� ������ Walk�Լ� ��ȯ

        //�÷��̾�� �־����ٸ� 

        //Walk������ȯ
    }

    void Walk()
    {
        //�ȴ� �ִϸ��̼�

        //�÷��̾�� ��������� 

        //���� ��ȯ 

        //�÷��̾�� �־����� 

        //�� ��ȯ


    }

    void Run()
    {
        //�ȴ� �ִϸ��̼�*2

        //�÷��̾�� ��������� 

        //walk ȭ�� ��ȯ 




    }

    void Attack()
    {
        //���� �ִϸ��̼�

        //�����ؼ� �ڵ����� �¾Ҵٸ� 

        //Hp���� 

        //�÷��̾�� �־����ٸ� 

        //Walk ȭ�� ��ȯ
    }

    void Damged()
    {


        //�� �����ۿ� ��Ҵٸ� 
        //�´� �ִϸ��̼�
        //���̵� ���� ��ȯ 

    }

    //���̿����̴� �Լ�
    void BearMove()
    {

        //���� �����̴� �Ÿ��� �÷��̾��� ��ġ��
      
        agent.destination = player.position;
        //print("���� ������°� ����");

       
    }

    //�����̱� �� ���� ǥ�� �Լ�
    void BeforeMove()
    {

        //�ð� (�� �������ؼ�)
        time += Time.deltaTime;

        //�÷� �ð��� ��Ʈ�� ��ȯ���� 
        int sec = (int)time;
        //1�ʰ� �����ٸ�
        if (sec == 1)
        {
            //2��� ��������Ʈ�� �̹����� ����
            number_Img.sprite = number_sprite[0];
        }
        //2�ʰ� �����ٸ�
        else if (sec == 2)
        {
            //1�̶�� ��������Ʈ�� �̹����� ����
            number_Img.sprite = number_sprite[1];
        }
        //3�ʰ� �����ٸ� 
        else if (sec == 3)
        {
            //�̹��� UI��Ȱ��ȭ
            number_Img.gameObject.SetActive(false);
            //�����̱� ����
            isMove = true;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="HoneyAttck")
        {
           
            print("�ƾ�! �� �Ѿ��� ");
            agent.isStopped = true;

            //Destroy(other.gameObject, 5);

           
        }
    }

}
