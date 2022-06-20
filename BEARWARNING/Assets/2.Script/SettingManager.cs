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

    //랜덤버튼 사용 끝 
    public GameObject ramdom_end;
    //랜덤버튼 사용 버튼
    public GameObject ramdom_start;
    //랜덤 hp이미지(능력치)
    public Image[] random_hp_img;
    //랜덤 hp이미지 (게임중)
    public Image[] hp_img;
    //랜덤 hp이미지_활성화
    public Sprite ramdom_hp_T;
    //슬라이더 변수
    public Slider[] speed_bar;
    //능력창_스타트버튼
    public Button start_btn;
    

    // Start is called before the first frame update
    void Start()
    {

        

    }


    //랜덤 버튼을 클릭하면
    public void RandomClick()
    {
        //랜덤 텍스트 배열로 받아오기 
        Text[] randomtxt = powerview.GetComponentsInChildren<Text>();

        //랜덤값 설정
        GameManager.instance.hp= Random.Range(3, 6);
        GameManager.instance.min = Random.Range(30,61);
        GameManager.instance.max = Random.Range(80, 131);
  
        //랜덤 텍스트 적용
        randomtxt[1].text = "Hp : " + GameManager.instance.hp;
        randomtxt[2].text = "기본속도 : " + GameManager.instance.min+"km";
        randomtxt[3].text = "최대속도 : " + GameManager.instance.max + "km";

        //랜덤 hp이미지 구현
        for (int i = 0; i < GameManager.instance.hp; i++)
        {
            //이미지 스프라이트 변경
            random_hp_img[i].sprite = ramdom_hp_T;
            hp_img[i].sprite = ramdom_hp_T;
        }
        //랜덤 기본속도 슬라이더 구현(기본속도는 최대60km랜덤이라 최대속도를 1로 맞춤)
        speed_bar[0].value = GameManager.instance.min / 100f/0.6f;
        //랜덤 최대속도 슬라이더 구현 (기본속도는 최대 130이라 최대속도를 1로 맞춤)
        speed_bar[1].value = GameManager.instance.max / 100f/1.3f;

        //랜덤 버튼 1번 사용하도록 구현
        ramdom_start.SetActive(false);
        ramdom_end.SetActive(true);

        start_btn.interactable = true;

    }

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
