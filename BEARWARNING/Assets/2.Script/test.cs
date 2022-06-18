using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    CharacterController cc;

    public float speed;
    float _y;
    public float gravityScale;

    public GameObject playOn;

   

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();



    }

    // Update is called once per frame
    void Update()
    {

        if (!cc.isGrounded)
        {
            //중력
            _y -= gravityScale * Time.deltaTime;
        }


        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //이동할 방향 정함 
        Vector3 dir = new Vector3(h, 0, v);

        //플레이어가 바라보는 방향으로 움직임 
        //dir = transform.TransformDirection(dir);

        //대각선 때문에 정규화 해야함.
        //dir.Normalize();

        dir.y = _y;

        cc.Move(dir * Time.deltaTime * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="StartLine")
        {
            playOn.SetActive(true);
        }
    }
}

