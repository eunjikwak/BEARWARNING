using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManger : MonoBehaviour
{

    public GameObject SetView;
    public Toggle [] CarsBtn;
    public GameObject CarSkin;
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
        GameObject.Find("Object").gameObject.SetActive(false);

      
    }

    public void SetClick()
    {
        SetView.SetActive(true);
    }

    public void BackClick()
    {
        SetView.SetActive(false);
    }

    public void CarCheck2()
    {
       
        CarsBtn[0].isOn = false;
       // CarsBtn[1].isOn = true;

        


    }
    public void CarCheck1()
    {
        
        CarsBtn[1].isOn = false;
       // CarsBtn[0].isOn = true;

    }

}
