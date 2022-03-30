using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject Ball;
    private void OnCollisionEnter(Collision collision)
    {  
        if(collision.gameObject.tag == "Floor") // Если соприкасаемый объект имеет тег пол
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true; // делаем мяч нефизичным
        }
    }
    public void ActivateBall()
    {
        Ball.GetComponent<Rigidbody>().isKinematic = false; // При взятии мяча в руки возвращаем физичность
    }
}
