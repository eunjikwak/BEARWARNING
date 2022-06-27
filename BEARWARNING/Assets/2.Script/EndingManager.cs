using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    //���� 
    public Animator bear_anim;
    public Text end_title;
    public Image end_img;
    public Sprite die_img;
    public Text end_text;
    public Transform bear_qt;
    public GameObject car;
    public static bool isDie;
    public Text HiddenMission_txt;




    //������ �������� ȣ��Ǵ� �Լ� 
    public void GameDie()
    {

        //�׾��ٸ� 
        if(isDie)
        {
            //�������� ī Ȱ��ȭ
            car.SetActive(true);
            //�� ��ġ ����
            bear_qt.eulerAngles = new Vector3(0, 270, 0);
            
            //�ؽ�Ʈ ���� 
            end_title.text = "DIE";
            end_img.sprite = die_img;
            end_img.GetComponentInChildren<Text>().text = "���� ������ ���� �ð� " + GameManager.instance.lastTime;
            end_text.text = "�����϶�� �ߴµ��� \n��Ÿ��� �����̱���";
            bear_anim.SetTrigger("Die");
           
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.CameraClick==3)
        {
            HiddenMission_txt.text = "���� �̼� ����";
        }
        GameDie();
        //���� �ʾҴٸ� �� �ִϸ��̼� Win
        bear_anim.SetTrigger("Win");
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
    //�̼� �����ߴٸ� 


}
