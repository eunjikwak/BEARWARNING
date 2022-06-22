using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    //UI활성화버튼
    
    public Text speedTxt;

    public static float speed = 0.0f;

   
    public float rpm;
    //엑셀 (앞/뒤)
    public enum Axel
    {
        Front,
        Rear
    }


    //직렬화
    [Serializable]

    //휠 구조
    public struct Wheel
    {
        //휠 (매쉬)
        public GameObject wheelModel;
        //휠 컨트롤러
        public WheelCollider wheelCollider;
        //엑셀 선택(앞뒤)
        public Axel axel;
    }


    //최저
    public float minAcceleration;

    //최대 가속 
    public float maxAcceleration;


    //브레이크 가속
    public float brakeAcceleration = 100.0f;

    //회전 감도
    public float turnSensitivity = 1.0f;
    //방향 바꿀때 바퀴 스핀이동각도 
    public float maxSteerAngle = 30.0f;


    //센터 질량 
    public Vector3 _centerOfMass;

    //휠 리스트
    public List<Wheel> wheels;

    //움직이는 값
    float moveInput;

    //조향장치(핸들값)
    float steerInput;

    //자동차 리지드바디
    private Rigidbody rig;

    //private CarLights carLights;

    void Start()
    {
        //리지드바디 값 가져오기
        rig = GetComponent<Rigidbody>();

        //리지드 바디 센터질링을 센터질량 변수로 
        rig.centerOfMass = _centerOfMass;
    }



        void Update()
        {

            //값 받아오기
            GetInputs();
            //바퀴 움직이는 함수
            AnimateWheels();

            minAcceleration = GameManager.instance.min;
            maxAcceleration = GameManager.instance.max;


            speedTxt.text = speed.ToString("00");

        }

        void LateUpdate()
        {

            //움직임함수
            Move();
            //핸들각도 함수
            Steer();
            //브레이크 함수
            Brake();
        }



        //키값 받아오는 함수
        void GetInputs()
        {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }

    //움직이는 함수 
    void Move()
    {
        foreach (var wheel in wheels)
        {
            //바퀴에 회전력을 넣어줘서 움직이게 함 
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
                //휠 엑셀이 앞 엑셀이면 
                if (wheel.axel == Axel.Front)
                {
                    //핸들 각도 = 핸들받아온 값 * 회전 감도 * 최대 핸들각도
                    var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                    //바퀴가 기존 핸들 각도에서 0.6속도로  _핸들각도로 변화된다. 
                    wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
                }
            }
        }

        void Brake()
        {

            //스페이스를 누르거나 받아오는 값이 없다면 
            if (Input.GetKey(KeyCode.Space) || moveInput == 0)
            {
                foreach (var wheel in wheels)
                {
                    //휠 콜라이더 브레이크 회전력을 멈추기
                    wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
                }

            

            }
            else
            {

                foreach (var wheel in wheels)
                {
                    //브레이크회전력에 0을 넣어줌 
                    wheel.wheelCollider.brakeTorque = 0;
                }

            }
        }


        //휠의 애니메이션 
        void AnimateWheels()
        {
            foreach (var wheel in wheels)
            {
                //회전
                Quaternion rot;
                //포지션 변수
                Vector3 pos;
                wheel.wheelCollider.GetWorldPose(out pos, out rot);
                wheel.wheelModel.transform.position = pos;
                wheel.wheelModel.transform.rotation = rot;
            }
        }
   
}



