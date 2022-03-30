using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject Ball;
    private void OnCollisionEnter(Collision collision)
    {  
        if(collision.gameObject.tag == "Floor") // ���� ������������� ������ ����� ��� ���
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true; // ������ ��� ����������
        }
    }
    public void ActivateBall()
    {
        Ball.GetComponent<Rigidbody>().isKinematic = false; // ��� ������ ���� � ���� ���������� ����������
    }
}
