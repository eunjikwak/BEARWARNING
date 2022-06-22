using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{

    public GameObject needle;
    float start_pos = 220f, end_pos = -42f;
    float desired_pos;

    float carSpeed;
    float time;
    int sec, min;

    public Text playTime;

    public Image [] hp_img;
    public Sprite ramdom_hp_F;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<BearManager>().isON = true;

        
        
    }

    private void FixedUpdate()
    {
        carSpeed =CarController.speed;
   
       
       
        UpdateNeedle();
        TimeStart();
    }

    public void UpdateNeedle()
    {
        desired_pos = start_pos - end_pos;
        float temp = carSpeed / 180f;
        needle.transform.eulerAngles = new Vector3(0, 0, start_pos - temp * desired_pos);
    }


    public void TimeStart()
    {
        time += Time.deltaTime;

        sec = (int)time;

        if(sec==60)
        {
            min++;
            time = 0;
        }

        playTime.text = min.ToString("00:") + sec.ToString("00");
        GameManager.instance.lastTime = playTime.text;

    }

    public void hpUpdate()
    {
        print("hp업데이트함수 호출");


        //랜덤 hp이미지 구현
        for (int i =4; i >= GameManager.instance.hp; i--)
        {
            //이미지 스프라이트 변경
            hp_img[i].sprite = ramdom_hp_F;
        }
    }

}
