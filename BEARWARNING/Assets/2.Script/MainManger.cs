using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManger : MonoBehaviour
{


    //설정창 변수
    public GameObject SetView;
    //차 버튼 배열
    public Button [] CarsBtn;
    //차 스킨 종류
    public Texture2D [] skins;
    //스킨을 바꿀 오브젝트 변수
    public MeshRenderer carskin;





    // Start is called before the first frame update
    void Start()
    {
       //초기화 (플레이씬에서 다시 돌아갈때 기본 값 할당)
        GameManager.instance.carSkin = skins[0];
    }

    // Update is called once per frame
    void Update()
    {
    }
   

    //시작버튼을 누르면
    public void StartClick()
    {
       
        //플레이 씬으로 전환
        SceneManager.LoadScene(1);
      
    }



    
    //세팅버튼을 클릭하면
    public void SetClick()
    {
        //셋팅팝업창을 활성화
        SetView.SetActive(true);
       
    }

    //뒤로가기 버튼을 클릭하면
    public void BackClick()
    {
        //셋팅팝업창 비활성화
        SetView.SetActive(false);
        
     
    }
    //ver1선택 하면
    public void CarCheck1()
    {
        //버전 2 비활성화
        CarsBtn[1].interactable = true;
        //버전 1 활성화
        CarsBtn[0].interactable = false;
        //스킨의 색상을 0번째 스킨으로 변경
       carskin.material.mainTexture = skins[0];
        //저장
        GameManager.instance.carSkin = skins[0];
    
    }

    //ver2선택 하면
    public void CarCheck2()
    {
        //버전 1 비활성화 
        CarsBtn[0].interactable = true;
        //버전 2 활성화
        CarsBtn[1].interactable = false;
        //스킨의 색상을 1번째 스킨으로 변경
        carskin.material.mainTexture = skins[1];
        //저장
        GameManager.instance.carSkin = skins[1];

    }


}
