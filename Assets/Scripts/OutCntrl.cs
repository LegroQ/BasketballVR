using UnityEngine;

public class OutCntrl : MonoBehaviour
{
    public EnemyThrow enemyThrow; // �������������� � ������ ��������
    private void OnCollisionEnter(Collision collision)
    {
        if(enemyThrow.PlayerThrow == false && collision.gameObject.tag == "Ball") // ���� ������ ���
        {
            enemyThrow.PlayerThrow = true; // ��������, ��� ������
            collision.gameObject.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // ���������� ��� � ����������� �������
        }
        else if(enemyThrow.PlayerThrow == true && collision.gameObject.tag == "Ball") // ���� ������ �����
        {
            enemyThrow.PlayerThrow = false; // ��������, ��� ������
            collision.gameObject.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // ���������� ��� � ����������� �������
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false; // �������� ���
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // ������
        }
    }
}