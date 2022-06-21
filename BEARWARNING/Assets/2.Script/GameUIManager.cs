using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{

    public GameObject needle;
    float start_pos = 220f, end_pos = -42f;
    float desired_pos;

    float carSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        carSpeed =CarController.speed;
   
       
        print(carSpeed);
        UpdateNeedle();
    }

    public void UpdateNeedle()
    {
        desired_pos = start_pos - end_pos;
        float temp = carSpeed / 180f;
        needle.transform.eulerAngles = new Vector3(0, 0, (start_pos - temp * desired_pos)+4);
    }


}
