using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    //변수 
    public Animator bear_anim;
    public Text end_title;
    public Image end_img;
    public Sprite die_img;
    public Text end_text;
    public Transform bear_qt;
    public GameObject car;
    public static bool isDie;
    public Text HiddenMission_txt;




    //게임이 끝났을때 호출되는 함수 
    public void GameDie()
    {

        //죽었다면 
        if(isDie)
        {
            //뒤집어진 카 활성화
            car.SetActive(true);
            //곰 위치 변경
            bear_qt.eulerAngles = new Vector3(0, 270, 0);
            
            //텍스트 변경 
            end_title.text = "DIE";
            end_img.sprite = die_img;
            end_img.GetComponentInChildren<Text>().text = "곰을 만나고 죽은 시간 " + GameManager.instance.lastTime;
            end_text.text = "조심하라고 했는데… \n안타까운 죽음이군요";
            bear_anim.SetTrigger("Die");
           
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.CameraClick==3)
        {
            HiddenMission_txt.text = "히든 미션 성공";
        }
        GameDie();
        //죽지 않았다면 곰 애니메이션 Win
        bear_anim.SetTrigger("Win");
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
    //미션 성공했다면 


}
