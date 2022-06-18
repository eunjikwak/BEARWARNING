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
            //�߷�
            _y -= gravityScale * Time.deltaTime;
        }


        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //�̵��� ���� ���� 
        Vector3 dir = new Vector3(h, 0, v);

        //�÷��̾ �ٶ󺸴� �������� ������ 
        //dir = transform.TransformDirection(dir);

        //�밢�� ������ ����ȭ �ؾ���.
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

