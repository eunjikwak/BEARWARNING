using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    public GameObject dontDestory;

    private void Awake()
    {
        //���� ��ȯ �Ǿ �������� �ʰ� 
        DontDestroyOnLoad(dontDestory);


    }
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
            //���� ȭ������ ����ȯ
            SceneManager.LoadScene(1);
        }
        
    }
}
