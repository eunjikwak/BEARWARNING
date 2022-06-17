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

        //�̵��� ���� ���� 
        Vector3 dir = new Vector3(h, 0, v)*Time.deltaTime;

        //�÷��̾ �ٶ󺸴� �������� ������ 
        dir = transform.TransformDirection(dir);

        //�밢�� ������ ����ȭ �ؾ���.
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
