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
        //�ƹ�Ű�� ������
        if(Input.anyKeyDown)
        {
            //�ؽ�Ʈ ��Ȱ��ȭ 

            anyKeyTxt.SetActive(false);

            //��ư Ȱ��ȭ 
            button.SetActive(true);
        }
        
    }
}
