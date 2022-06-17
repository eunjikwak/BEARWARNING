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


    // Start is called before the first frame update
    void Start()
    {
      



    }

    //void RandomClick()
    //{
    //    Text[] randomtxt = powerview.GetComponentsInChildren<Text>();


    //    //for (int i = 0; i <randomtxt.Length; i++)
    //    //{
    //    //    print(randomtxt[i].text);
    //    //}
    //}

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

}
