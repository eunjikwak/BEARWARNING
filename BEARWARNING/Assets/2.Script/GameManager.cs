using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    //��𼭵� ����� �� �ֵ��� ����ƽȭ
    public static GameManager instance;


    //������ �ڵ�����Ų
    public Texture2D carSkin;

    public int hp, min, max;


   
    private void Awake()
    { //�ν��Ͻ��� �������� �ʴ� �ٸ� ���� �Ҵ�
        if (instance==null)
        {
            instance = this;
        }
        //�ν��Ͻ��� �����Ѵٸ� + ���� �� �ν��Ͻ��� �ƴ϶�� �� ���� 
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
       
        DontDestroyOnLoad(gameObject);
    }

    private void update()
    {
        
    }


}
