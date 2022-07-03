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

    //�ִϸ����� ����
    Animator anim;

    //���ݽ� ��Ÿ��
    float coolTime;


    //�ֳʹ� ���� 
    public enum EnmeyState
    {
        Idle,
        Walk,
        Run,
        Attak,
        Damaged,
        Die
    }

    //���� ����
    public EnmeyState eState;



    // Start is called before the first frame update
    void Start()
    {
        eState = EnmeyState.Idle;
        //�ֳʹ� AI
        agent = GetComponent<NavMeshAgent>();
        //�÷��̾� ��ġ ��������
        player = FindObjectOfType<CarController>().transform;
       //�ִϸ��̼�
        anim = GetComponent<Animator>();
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

    //���̿����̴� �Լ�
    void BearMove()
    {
        //���� �����̴� �Ÿ��� �÷��̾��� ��ġ��
        //agent.SetDestination(player.position);
        agent.destination = player.position;

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

        if (isMove)
        {
            //����ġ��� ��Ʈ ��Ȱ��ȭ
            runText.SetActive(false);
            //�� ������ ����
            BearMove();
        }

        //�ֳʹ� ���¿� ���� �ٸ� �Լ� ȣ��
            switch (eState)
        {
            case EnmeyState.Idle: Idle(); break;
            case EnmeyState.Walk: Walk(); break;
            case EnmeyState.Run: Run(); break;
            case EnmeyState.Attak: Attack(); break;
            case EnmeyState.Damaged: break;
            case EnmeyState.Die: Die(); break;

        }


    }

    void Idle()
    {
      if(isMove)
        {
            //�÷��̾�� ��������ٸ�
            if(Vector3.Distance(transform.position,player.position)<10f)
            {
                //���� ���� ��ȯ 
                eState = EnmeyState.Attak;
                //���� �ִϸ��̼� 
                anim.SetTrigger("Attack");
                agent.isStopped = true;
            }
            
            //�÷��̾�� �־����ٸ�
            else if (Vector3.Distance(transform.position, player.position) >= 15f)
            {
                //Walk������ȯ
                eState = EnmeyState.Walk;
                //��ũ �ִϸ��̼�
                anim.SetBool("IsWalk", true);
                agent.isStopped = false;

            }
        }

       
    }

    void Walk()
    {
        //�÷��̾�� ��������ٸ� 
        if (Vector3.Distance(transform.position,player.position)<15f)
        {
            //�⺻ ���� ��ȯ
            eState = EnmeyState.Idle;
            anim.SetBool("IsWalk", false) ;
            agent.isStopped = true;
        }
        //�÷��̾�� �־����� 
        else if(Vector3.Distance(transform.position, player.position) >= 30f)
        {
            //�ٴ� ���� ��ȯ
            eState = EnmeyState.Run;
            anim.SetBool("IsRun", true);
            agent.speed = 50f;

        }

    }

    void Run()
    {
        //�÷��̾�� ��������� 
        if (Vector3.Distance(transform.position,player.position)<30f)
        {  //walk ȭ�� ��ȯ 
            eState = EnmeyState.Walk;
            anim.SetBool("IsRun", false);
            agent.speed = 25f;

        }

    }



    void Attack()
    {

        coolTime += Time.deltaTime;

        if(coolTime>=1)
        {
            //hp ����
            GameManager.instance.hp--;
            //������ hp UI����
            FindObjectOfType<GameUIManager>().hpUpdate();
            coolTime = 0;
            eState = EnmeyState.Idle;
        }

        //���� hp�� ���ٸ� 
        if (GameManager.instance.hp == 0)
        {
            //���忣������ ��ȯ
            FindObjectOfType<SettingManager>().DieClick();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HoneyAttck")
        {
            agent.isStopped = true;
            Damged();

             Destroy(other.gameObject, 3);

        }
    }

    void Damged()
    {
        
        print("�ƾ�! �� �Ѿ��� ");

        anim.SetTrigger("Hit");

        eState = EnmeyState.Idle;
    }



    void Die()
    {
        //�÷��̾ ��������Ʈ�� �����ߴٸ� 

        agent.isStopped = true;
        anim.SetTrigger("Die");
        // �ֳʹ� ���߱� 

    }


}
