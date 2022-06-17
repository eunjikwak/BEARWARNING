using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManger : MonoBehaviour
{


    //����â ����
    public GameObject SetView;
    //�� ��ư �迭
    public Button [] CarsBtn;
    //�� ��Ų ����
    public Texture2D [] skins;
    //��Ų�� �ٲ� ������Ʈ ����
    public MeshRenderer carskin;





    // Start is called before the first frame update
    void Start()
    {
       //�ʱ�ȭ (�÷��̾����� �ٽ� ���ư��� �⺻ �� �Ҵ�)
        GameManager.instance.carSkin = skins[0];
    }

    // Update is called once per frame
    void Update()
    {
    }
   

    //���۹�ư�� ������
    public void StartClick()
    {
       
        //�÷��� ������ ��ȯ
        SceneManager.LoadScene(1);
      
    }



    
    //���ù�ư�� Ŭ���ϸ�
    public void SetClick()
    {
        //�����˾�â�� Ȱ��ȭ
        SetView.SetActive(true);
       
    }

    //�ڷΰ��� ��ư�� Ŭ���ϸ�
    public void BackClick()
    {
        //�����˾�â ��Ȱ��ȭ
        SetView.SetActive(false);
        
     
    }
    //ver1���� �ϸ�
    public void CarCheck1()
    {
        //���� 2 ��Ȱ��ȭ
        CarsBtn[1].interactable = true;
        //���� 1 Ȱ��ȭ
        CarsBtn[0].interactable = false;
        //��Ų�� ������ 0��° ��Ų���� ����
       carskin.material.mainTexture = skins[0];
        //����
        GameManager.instance.carSkin = skins[0];
    
    }

    //ver2���� �ϸ�
    public void CarCheck2()
    {
        //���� 1 ��Ȱ��ȭ 
        CarsBtn[0].interactable = true;
        //���� 2 Ȱ��ȭ
        CarsBtn[1].interactable = false;
        //��Ų�� ������ 1��° ��Ų���� ����
        carskin.material.mainTexture = skins[1];
        //����
        GameManager.instance.carSkin = skins[1];

    }


}
