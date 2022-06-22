using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    //UIȰ��ȭ��ư
    
    public Text speedTxt;

    public static float speed = 0.0f;

   
    public float rpm;
    //���� (��/��)
    public enum Axel
    {
        Front,
        Rear
    }


    //����ȭ
    [Serializable]

    //�� ����
    public struct Wheel
    {
        //�� (�Ž�)
        public GameObject wheelModel;
        //�� ��Ʈ�ѷ�
        public WheelCollider wheelCollider;
        //���� ����(�յ�)
        public Axel axel;
    }


    //����
    public float minAcceleration;

    //�ִ� ���� 
    public float maxAcceleration;


    //�극��ũ ����
    public float brakeAcceleration = 100.0f;

    //ȸ�� ����
    public float turnSensitivity = 1.0f;
    //���� �ٲܶ� ���� �����̵����� 
    public float maxSteerAngle = 30.0f;


    //���� ���� 
    public Vector3 _centerOfMass;

    //�� ����Ʈ
    public List<Wheel> wheels;

    //�����̴� ��
    float moveInput;

    //������ġ(�ڵ鰪)
    float steerInput;

    //�ڵ��� ������ٵ�
    private Rigidbody rig;

    //private CarLights carLights;

    void Start()
    {
        //������ٵ� �� ��������
        rig = GetComponent<Rigidbody>();

        //������ �ٵ� ���������� �������� ������ 
        rig.centerOfMass = _centerOfMass;
    }



        void Update()
        {

            //�� �޾ƿ���
            GetInputs();
            //���� �����̴� �Լ�
            AnimateWheels();

            minAcceleration = GameManager.instance.min;
            maxAcceleration = GameManager.instance.max;


            speedTxt.text = speed.ToString("00");

        }

        void LateUpdate()
        {

            //�������Լ�
            Move();
            //�ڵ鰢�� �Լ�
            Steer();
            //�극��ũ �Լ�
            Brake();
        }



        //Ű�� �޾ƿ��� �Լ�
        void GetInputs()
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }

    //�����̴� �Լ� 
    void Move()
    {
        foreach (var wheel in wheels)
        {
            //������ ȸ������ �־��༭ �����̰� �� 
            wheel.wheelCollider.motorTorque = moveInput * minAcceleration * maxAcceleration * Time.deltaTime;
            rpm = wheel.wheelCollider.rpm*Time.deltaTime;
        }

 
          //speed = rig.velocity.magnitude*10f;
           speed = Mathf.Clamp(rig.velocity.magnitude * 3.78f*5f, 0, maxAcceleration);


      
    }

    

        void Steer()
        {
            foreach (var wheel in wheels)
            {
                //�� ������ �� �����̸� 
                if (wheel.axel == Axel.Front)
                {
                    //�ڵ� ���� = �ڵ�޾ƿ� �� * ȸ�� ���� * �ִ� �ڵ鰢��
                    var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                    //������ ���� �ڵ� �������� 0.6�ӵ���  _�ڵ鰢���� ��ȭ�ȴ�. 
                    wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
                }
            }
        }

        void Brake()
        {

            //�����̽��� �����ų� �޾ƿ��� ���� ���ٸ� 
            if (Input.GetKey(KeyCode.Space) || moveInput == 0)
            {
                foreach (var wheel in wheels)
                {
                    //�� �ݶ��̴� �극��ũ ȸ������ ���߱�
                    wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
                }

            

            }
            else
            {

                foreach (var wheel in wheels)
                {
                    //�극��ũȸ���¿� 0�� �־��� 
                    wheel.wheelCollider.brakeTorque = 0;
                }

            }
        }


        //���� �ִϸ��̼� 
        void AnimateWheels()
        {
            foreach (var wheel in wheels)
            {
                //ȸ��
                Quaternion rot;
                //������ ����
                Vector3 pos;
                wheel.wheelCollider.GetWorldPose(out pos, out rot);
                wheel.wheelModel.transform.position = pos;
                wheel.wheelModel.transform.rotation = rot;
            }
        }
   
}



