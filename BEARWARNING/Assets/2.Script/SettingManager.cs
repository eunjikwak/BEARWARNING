using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{


    //�ɷ�ġ �˾�â
    public GameObject powerview;
    //���丮â
    public GameObject story;
    //����â(������)
    public GameObject SetView;
    //�ڵ��� ��Ų ������ ����
    public MeshRenderer carskin;
    //����׷� ������ư
    public GameObject setting_play;

    //������ư ��� �� 
    public GameObject ramdom_end;
    //������ư ��� ��ư
    public GameObject ramdom_start;
    //���� hp�̹���(�ɷ�ġ)
    public Image[] random_hp_img;
    //���� hp�̹��� (������)
    public Image[] hp_img;
    //���� hp�̹���_Ȱ��ȭ
    public Sprite ramdom_hp_T;
    //�����̴� ����
    public Slider[] speed_bar;
    //�ɷ�â_��ŸƮ��ư
    public Button start_btn;
    

    // Start is called before the first frame update
    void Start()
    {

        

    }


    //���� ��ư�� Ŭ���ϸ�
    public void RandomClick()
    {
        //���� �ؽ�Ʈ �迭�� �޾ƿ��� 
        Text[] randomtxt = powerview.GetComponentsInChildren<Text>();

        //������ ����
        GameManager.instance.hp= Random.Range(3, 6);
        GameManager.instance.min = Random.Range(30,61);
        GameManager.instance.max = Random.Range(80, 131);
  
        //���� �ؽ�Ʈ ����
        randomtxt[1].text = "Hp : " + GameManager.instance.hp;
        randomtxt[2].text = "�⺻�ӵ� : " + GameManager.instance.min+"km";
        randomtxt[3].text = "�ִ�ӵ� : " + GameManager.instance.max + "km";

        //���� hp�̹��� ����
        for (int i = 0; i < GameManager.instance.hp; i++)
        {
            //�̹��� ��������Ʈ ����
            random_hp_img[i].sprite = ramdom_hp_T;
            hp_img[i].sprite = ramdom_hp_T;
        }
        //���� �⺻�ӵ� �����̴� ����(�⺻�ӵ��� �ִ�60km�����̶� �ִ�ӵ��� 1�� ����)
        speed_bar[0].value = GameManager.instance.min / 100f/0.6f;
        //���� �ִ�ӵ� �����̴� ���� (�⺻�ӵ��� �ִ� 130�̶� �ִ�ӵ��� 1�� ����)
        speed_bar[1].value = GameManager.instance.max / 100f/1.3f;

        //���� ��ư 1�� ����ϵ��� ����
        ramdom_start.SetActive(false);
        ramdom_end.SetActive(true);

        start_btn.interactable = true;

    }

    // Update is called once per frame
    void Update()
    {

        //�÷����� �� ��Ų�� ����ؼ� �־��� (���� �Ŵ��� ����Ų����)
        carskin.material.mainTexture = GameManager.instance.carSkin;


        //���� ���丮 ������Ʈ�� ���ٸ�
       if(story==null)
        {

            //����׷� ����â Ȱ��ȭ
            setting_play.SetActive(true);
        }

    }


    //��ŸƮ ��ư�� Ŭ���ߴٸ� 
    public void StartClick()
    {
  

        //�ɷ�ġâ ��Ȱ��ȭ
        powerview.SetActive(false);
       

        //���丮â Ȱ��ȭ
        story.SetActive(true);
    }


    //���ù�ư�� Ŭ���ߴٸ�
    public void SettingClick()
    {

        //����â(�÷�����)Ȱ��ȭ
        SetView.SetActive(true);

    }


    //�ٽý��� ��ư�� �����ٸ�
    public void ReplayClick()
    {

        //�÷��̾� ��ȯ
        SceneManager.LoadScene(1);

      
    }


    //Ȩ��ư�� �����ٸ�
    public void HomeClick()
    {

        //���ξ����� ��ȯ
        SceneManager.LoadScene(0);

    }

    //ESC ��ư�� �����ٸ�
    public void EscClick()
    {

        //����â(�÷�����) ��Ȱ��ȭ
        SetView.SetActive(false);
      
    }

    public void WinClick()
    {
        SceneManager.LoadScene(2);
        EndingManager.isDie = false;
    }
    public void DieClick()
    {
        SceneManager.LoadScene(2);
        EndingManager.isDie = true;
    }
}
