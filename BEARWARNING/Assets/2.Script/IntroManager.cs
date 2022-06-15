using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    public GameObject dontDestory;

    private void Awake()
    {
        //씬이 전환 되어도 삭제되지 않게 
        DontDestroyOnLoad(dontDestory);


    }
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
            //시작 화면으로 씬전환
            SceneManager.LoadScene(1);
        }
        
    }
}
