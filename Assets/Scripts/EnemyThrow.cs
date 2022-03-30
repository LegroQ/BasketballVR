using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    public bool PlayerThrow = true; // ������� ������ �����
    private GameObject ball;
    public float BallVelocity = 20f; // �������� ����� ����
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball") // ���� ���� �������� ���
        {
            ball = collision.collider.gameObject;
            PlayerThrow = !PlayerThrow; // ��������� ������� ������ ���
            if(PlayerThrow == false) // ��������, ��� ������
            {
                ball.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // ���������� ��� � ����������� �������
                ball.GetComponent<Rigidbody>().isKinematic = false; // ������ ��� ��������
                ball.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // ������ ���� ���� � ������ ������������
            }
        }
    }
}