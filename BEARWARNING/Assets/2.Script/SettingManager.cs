using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{

    public GameObject powerview;
    public MeshRenderer car;
    public Texture2D skins;
    public GameObject story;

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
        powerview.SetActive(false);
        GameObject.Find("Car").SetActive(false);
        story.SetActive(true);
    }

    public void SettingClick()
    {
        SetView.SetActive(true);

    }

    public void ReplayClick()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("Car").SetActive(true);
    }

    public void HomeClick()
    {
        SceneManager.LoadScene(0);

    }
    public void EscClick()
    {
        SetView.SetActive(false);
      
    }

}
