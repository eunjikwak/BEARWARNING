using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{

    public Animator bear_anim;

    // Start is called before the first frame update
    void Start()
    {
        bear_anim.SetTrigger("End");
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
