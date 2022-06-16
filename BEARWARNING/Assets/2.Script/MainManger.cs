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
        //플레이 씬으로 전환
        SceneManager.LoadScene(1);
      
    }


    //세팅버튼을 클릭하면
    public void SetClick()
    {
        //셋팅팝업창을 활성화
        SetView.SetActive(true);
        carsave.SetActive(true);
    }

    //뒤로가기 버튼을 클릭하면
    public void BackClick()
    {
        //셋팅팝업창 비활성화
        SetView.SetActive(false);
        carsave.SetActive(false);
    }
    //ver1선택 하면
    public void CarCheck1()
    {
        //버전 2 비활성화
        CarsBtn[1].interactable = true;
        //버전 1 활성화
        CarsBtn[0].interactable = false;
        //스킨의 색상을 0번째 스킨으로 변경
        CarSkin.material.mainTexture = skins[0];
    
    }

    //ver2선택 하면
    public void CarCheck2()
    {
        //버전 1 비활성화 
        CarsBtn[0].interactable = true;
        //버전 2 활성화
        CarsBtn[1].interactable = false;
        //스킨의 색상을 1번째 스킨으로 변경
        CarSkin.material.mainTexture=skins[1];

       
      

    }


}
