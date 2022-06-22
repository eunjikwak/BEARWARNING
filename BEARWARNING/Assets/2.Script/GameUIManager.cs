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
    

    // Start is called before the first frame update
    void Start()
    {
        
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


    }

}
