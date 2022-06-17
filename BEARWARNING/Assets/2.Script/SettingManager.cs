using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{


    //능력치 팝업창
    public GameObject powerview;
    //스토리창
    public GameObject story;
    //설정창(게임중)
    public GameObject SetView;
    //자동차 스킨 저장할 공간
    public MeshRenderer carskin;
    //픽토그램 설정버튼
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

        //플레이의 차 스킨을 계속해서 넣어줌 (게임 매니저 차스킨으로)
        carskin.material.mainTexture = GameManager.instance.carSkin;


        //만약 스토리 오브젝트가 없다면
       if(story==null)
        {

            //픽토그램 설정창 활성화
            setting_play.SetActive(true);
        }

    }


    //스타트 버튼을 클릭했다면 
    public void StartClick()
    {

        //능력치창 비활성화
        powerview.SetActive(false);
       

        //스토리창 활성화
        story.SetActive(true);
    }


    //셋팅버튼을 클릭했다면
    public void SettingClick()
    {

        //셋팅창(플레이중)활성화
        SetView.SetActive(true);

    }


    //다시시작 버튼을 눌렀다면
    public void ReplayClick()
    {

        //플레이씬 전환
        SceneManager.LoadScene(1);
      
    }


    //홈버튼을 눌렀다면
    public void HomeClick()
    {

        //메인씬으로 전환
        SceneManager.LoadScene(0);

    }

    //ESC 버튼을 눌렀다면
    public void EscClick()
    {

        //셋팅창(플레이중) 비활성화
        SetView.SetActive(false);
      
    }

}
