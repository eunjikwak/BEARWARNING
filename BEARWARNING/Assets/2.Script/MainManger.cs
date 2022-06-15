using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManger : MonoBehaviour
{

    public GameObject SetView;
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
        //플레이 씬으로 전환
        SceneManager.LoadScene(2);
        //곰 삭제 
        Destroy(GameObject.Find("Object").gameObject);
    }

    public void SetClick()
    {
        SetView.SetActive(true);
    }

    public void BackClick()
    {
        SetView.SetActive(false);
    }
}
