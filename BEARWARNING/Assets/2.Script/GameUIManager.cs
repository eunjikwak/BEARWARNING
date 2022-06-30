using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //�뽬���� �ٴ�
    public GameObject needle;

    //������,����
    float start_pos = 220f, end_pos = -45f;
    //���ϴ� ��ġ
    float desired_pos;
    //�����ǵ�
    int carSpeed;

    //�ð� ��,��
    float time;
    int sec, min;
    //�÷��̽ð�
    public Text playTime;
    //hp �̹���/��������Ʈ
    public Image [] hp_img;
    public Sprite ramdom_hp_F;
    
    //�����ؽ�Ʈ, ī�޶��ؽ�Ʈ �迭
    Text[] texts;
    public Image itemSlot;
    public Sprite[] items;

    int coin;


    float oil_sec;
    public Slider oil_slider;

    Transform car;

    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<BearManager>().isON = true;
        texts = GetComponentsInChildren<Text>();
        car = FindObjectOfType<CarManager>().transform;

    }
    void Update()
    {


      
        //�⸧,ī�޶�,��
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            if (itemSlot.sprite == items[0])
            {
                print("������ �ȵ�");

            }
            else if (itemSlot.sprite == items[1])
            {
                //print("���ϻ��");

                Oil_Use();
                itemSlot.sprite = items[0];

            }
            else if (itemSlot.sprite == items[2])
            {
                //print("ī�޶� ���");
                Camera_Use();
                itemSlot.sprite = items[0];
            }
            else if (itemSlot.sprite == items[3])
            {
                //print("�ܻ��");
                Honey_Use();
                itemSlot.sprite = items[0];
            }



        }
    }

    private void FixedUpdate()
    {
        //ī�޶��ǵ� = ����Ʈ�ѷ��� ���ǵ�־��ֱ� 
        carSpeed =(int)CarController.speed;
        //��ú��� �Լ� ȣ��
        UpdateNeedle();
        //�ð� ����
        TimeStart();
       
    }


    //�뽬����
    public void UpdateNeedle()
    {
        //���ϴ� ��ġ ���ϱ�
        desired_pos = start_pos - end_pos;
        //�� ���ǵ带 temp 180���� ������
        float temp = carSpeed / 180f;
        //�ٴ� ���� ���ϱ�
        needle.transform.eulerAngles = new Vector3(0, 0, start_pos - temp * desired_pos) ;
    }


    //�ð� ���� �Լ�
    public void TimeStart()
    {

        //�ð��� ����
        time += Time.deltaTime;
        oil_sec += Time.deltaTime;
        sec = (int)time;

        if(sec==60)
        {
            min++;
            time = 0;
        }

        playTime.text = min.ToString("00:") + sec.ToString("00");

        //���� ������Ʈ�� �ð� �־��ֱ� 
        GameManager.instance.lastTime = playTime.text;

        //���������̴� ���� 
        OilUpate();
    }

    //���� ������Ʈ �Լ�
    public void OilUpate()
    {
        //������ ���۵ǰ� 10�ʵڿ� 
        if(oil_sec>10f)
        {
            //�ٽ� 10�� �� �� �ֵ��� �ʱ�ȭ
            oil_sec = 0;
            //�����̴��� ���� 10�� ����
            oil_slider.value -= 0.1f;
        }

        if(GameManager.instance.isOil)
        {
            oil_slider.value = 1;
            GameManager.instance.isOil = false;
            oil_sec = 0;
        }
        
        ////���� ���� ���� 0�̶�� 
        //if(oil_slider.value<=0f)
        //{
        //    //�÷��̾� �������̰� 
        //    GameManager.instance.min = 0;
        //    GameManager.instance.max = 0;
        //}


    }


    //HP ������Ʈ �Լ�
    public void hpUpdate()
    {

        //���� hp�̹��� ����
        for (int i =4; i >= GameManager.instance.hp; i--)
        {
            //�̹��� ��������Ʈ ����
            hp_img[i].sprite = ramdom_hp_F;
        }
    }


    //������ �Ծ����� ȣ�� 
    public void CoinEat()
    {
        coin++;
        //������ 3�� �Ծ��ٸ� 
        if (coin == 10)
        {
            //���� �ʱ�ȭ
            coin = 0;
            //���Կ� �⸧ ������ ����
            itemSlot.sprite = items[1];
        }
        //���� ���� ������Ʈ 
        texts[0].text = "X" + coin;
    }

    //ī�޶� �Ծ����� ȣ�� 
    public void CameraEat()
    {
        //���Կ� ī�޶� ������ ���� 
        itemSlot.sprite = items[2];

    }

    //�ܾ����� �Ծ����� ȣ�� 
    public void HoneyEat()
    {
        //���Կ� �� ������ ���� 
        itemSlot.sprite = items[3];
    }


    void Oil_Use()
    {
        print("���� �ʱ�ȭ!");
        GameManager.instance.isOil = true;
    }

    void Camera_Use()
    {

        //ī�޶� Ŭ��
        GameManager.instance.CameraClick++;
        print("��Ĭ");
        ////ī�޶� ���� ������Ʈ 
        //texts[1].text = "X" + GameManager.instance.CameraClick;
       

        
    }

    void Honey_Use()
    {
        print("�ܰ���");

        GameObject honey = Instantiate(Resources.Load("Splash1"), hit.point, Quaternion.LookRotation(hit.point)) as GameObject;
        //GameObject honey = Instantiate(Resources.Load("Splash"), hit.point, Quaternion.LookRotation(hit.normal)) as GameObject;
        //honey.transform.position = car.position;
        //honey.transform.position += new Vector3(0, 0.1f, 0);
        honey.transform.position += honey.transform.forward * 0.1f;
        

        GameManager.instance.isHoney = true;
    }
    
}
