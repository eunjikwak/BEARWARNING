using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //�뽬���� �ٴ�
    public GameObject needle;

    //������,����
    float start_pos = 220f, end_pos = -42f;
    //���ϴ� ��ġ
    float desired_pos;
    //�����ǵ�
    float carSpeed;

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
        //ī�޶��ǵ� = ����Ʈ�ѷ��� ���ǵ�־��ֱ� 
        carSpeed =CarController.speed;
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
        needle.transform.eulerAngles = new Vector3(0, 0, start_pos - temp * desired_pos);
    }


    //�ð� ���� �Լ�
    public void TimeStart()
    {

        //�ð��� ����
        time += Time.deltaTime;

        sec = (int)time;

        if(sec==60)
        {
            min++;
            time = 0;
        }

        playTime.text = min.ToString("00:") + sec.ToString("00");

        //���� ������Ʈ�� �ð� �־��ֱ� 
        GameManager.instance.lastTime = playTime.text;

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
    public void CoinEat(int coin)
    {
        //������ 3�� �Ծ��ٸ� 
        if (coin == 10)
        {
            //���� �ʱ�ȭ
            coin = 0;
            //���Կ� �⸧ ������ ����
            item_img.sprite = items[0];

        }
        
        
       
        //���� ���� ������Ʈ 
        texts[0].text = "X" + coin;
    }



    //ī�޶� �Ծ����� ȣ�� 
    public void CameraEat(int camera)
    { 
       
        //ī�޶� ���� ������Ʈ 
        texts[1].text = "X"+camera;
        //���Կ� ī�޶� ������ ���� 
        item_img.sprite = items[1];



    }

    //�ܾ����� �Ծ����� ȣ�� 
    public void HoneyEat()
    {
        //���Կ� �� ������ ���� 
        item_img.sprite = items[2];
    }
}
