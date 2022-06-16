using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject anyKeyTxt;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //아무키나 누르면
        if(Input.anyKeyDown)
        {
            //텍스트 비활성화 

            anyKeyTxt.SetActive(false);

            //버튼 활성화 
            button.SetActive(true);
        }
        
    }
}
