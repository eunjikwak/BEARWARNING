using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{

    public GameObject playOn;

    Rigidbody rig;
    public float speed;

    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //이동할 방향 정함 
        Vector3 dir = new Vector3(h, 0, v)*Time.deltaTime;

        //플레이어가 바라보는 방향으로 움직임 
        dir = transform.TransformDirection(dir);

        //대각선 때문에 정규화 해야함.
        dir.Normalize();
        rig.AddForce(dir*speed, ForceMode.Impulse);
     
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.name);

    
      
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        playOn.SetActive(true);
    }


}
