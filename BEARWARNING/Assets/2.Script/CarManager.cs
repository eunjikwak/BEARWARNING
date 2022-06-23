using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarManager : MonoBehaviour
{
    //���ӽ��� UI
    public GameObject playOn;

    //ī�޶󰳼�, ���ΰ���
    int camera_eat,coin_eat;

    Color color;

    private void Update()
    {
      
    }

    //�÷��̾ �ݶ��̴��� ��Ҵٸ�
    private void OnCollisionEnter(Collision collision)
    {
        //�±װ� ��Ҵٸ� 
        switch(collision.gameObject.tag)
        {

            //���̶� �ε����ٸ� 
            case "Bear":    

                //hp ����
                GameManager.instance.hp--;
                //������ hp UI����
                playOn.GetComponent<GameUIManager>().hpUpdate();
                //���� hp�� ���ٸ� 
                if(GameManager.instance.hp==0)
                {
                    //���忣������ ��ȯ
                    FindObjectOfType<SettingManager>().DieClick();

                }
                break;

            
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            ////�����̸�
            //case "Coin":

            //    coin_eat++;

            //    //������ ������ UI ����
            //    playOn.GetComponent<GameUIManager>().CoinEat(coin_eat);

            //    //���� ���� ����
            //    Destroy(other.gameObject);

            //    break;
            
            //ī�޶���
            case "Camera":
                ////ī�޶� ���� ����
                camera_eat++;
                //������ ī�޶� ��Ʈ UI����
                playOn.GetComponent<GameUIManager>().CameraEat(camera_eat);
                //���� ���� ����
                Destroy(other.gameObject);
                break;
        }

    }


    //�÷��̾ �ݶ��̾ ��Ҵٸ� (Ʈ����)
    void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            //������ġ��
            case "StartLine":

                //�÷��� UIȰ��ȭ
                playOn.SetActive(true);
                break;

            ////�����̸�
            //case "Coin":

            //  SpriteRenderer coinColor= other.GetComponent<SpriteRenderer>();
            //    color.a = 0;
            //    coinColor.color = color;
            //    break;

            //ī�޶���
            case "Camera":
                SpriteRenderer cameraColor = other.GetComponent<SpriteRenderer>();
                color.a = 0;
                cameraColor.color = color;
                break;

            //���̶��
            case "Honey":
                //�� ���� ������ UI���� 
                playOn.GetComponent<GameUIManager>().HoneyEat();
                //���� �� ����
                Destroy(other.gameObject);
                break;
        }


    }

}
