using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManger : MonoBehaviour
{

    public GameObject SetView;
    public Button [] CarsBtn;
    public MeshRenderer CarSkin;
    public Texture2D [] skins;
    public GameObject dontdestroy;
    public GameObject carsave;


    private void Awake()
    {
        DontDestroyOnLoad(dontdestroy);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
   
    public void StartClick()
    {
        dontdestroy.SetActive(true);
        //�÷��� ������ ��ȯ
        SceneManager.LoadScene(1);
      
    }


    //���ù�ư�� Ŭ���ϸ�
    public void SetClick()
    {
        //�����˾�â�� Ȱ��ȭ
        SetView.SetActive(true);
        carsave.SetActive(true);
    }

    //�ڷΰ��� ��ư�� Ŭ���ϸ�
    public void BackClick()
    {
        //�����˾�â ��Ȱ��ȭ
        SetView.SetActive(false);
        carsave.SetActive(false);
    }
    //ver1���� �ϸ�
    public void CarCheck1()
    {
        //���� 2 ��Ȱ��ȭ
        CarsBtn[1].interactable = true;
        //���� 1 Ȱ��ȭ
        CarsBtn[0].interactable = false;
        //��Ų�� ������ 0��° ��Ų���� ����
        CarSkin.material.mainTexture = skins[0];
    
    }

    //ver2���� �ϸ�
    public void CarCheck2()
    {
        //���� 1 ��Ȱ��ȭ 
        CarsBtn[0].interactable = true;
        //���� 2 Ȱ��ȭ
        CarsBtn[1].interactable = false;
        //��Ų�� ������ 1��° ��Ų���� ����
        CarSkin.material.mainTexture=skins[1];

       
      

    }


}
