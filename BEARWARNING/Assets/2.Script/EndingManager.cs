using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{

    public Animator bear_anim;

    public Text end_title;
    public Image end_img;
    public Sprite die_img;
    public Text end_text;
    public Transform bear_qt;
    public GameObject car;
    public static bool isDie;



    public void GameDie()
    {
        if(isDie)
        {
            car.SetActive(true);
            bear_qt.eulerAngles = new Vector3(0, 270, 0);
            end_title.text = "DIE";
            end_img.sprite = die_img;
            end_img.GetComponentInChildren<Text>().text = "곰을 만나고 죽은 시간 00:00";
            end_text.text = "조심하라고 했는데… \n안타까운 죽음이군요";
            bear_anim.SetTrigger("Die");
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        GameDie();
        bear_anim.SetTrigger("Win");
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
