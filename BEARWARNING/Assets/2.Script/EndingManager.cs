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
}
