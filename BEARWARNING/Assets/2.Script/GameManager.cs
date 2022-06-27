using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    //어디서든 사용할 수 있도록 스태틱화
    public static GameManager instance;


    //저장할 자동차스킨
    public Texture2D carSkin;
    //자동차 기능 값 랜덤
    public int hp, min, max;
    //시간 
    public string lastTime;

    //아이템 사용 유무 
    public bool isOil,isHoney;
    public int CameraClick;

    
   
    private void Awake()
    { //인스턴스가 존재하지 않는 다면 나를 할당
        if (instance==null)
        {
            instance = this;
        }
        //인스턴스가 존재한다면 + 내가 그 인스턴스가 아니라면 나 삭제 
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
