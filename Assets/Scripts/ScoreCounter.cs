using UnityEngine;
using UnityEngine.UI; // ���������� ��� �������������� � �����������

public class ScoreCounter : MonoBehaviour
{
    public EnemyThrow CheckThrow; // �������� ���������� �� ������� EnemyThrow
    public Text PlayerScoreText; // ����� ����� ������
    public Text EnemyScoreText; // ����� ����� ���������
    public int PlayerScore = 0; // ���� ������
    public int EnemyScore = 0; // ���� ���������
    public GameObject WinCanvas; // ����� ������
    public GameObject LoseCanvas; // ����� ���������
    public AudioClip[] Goals; // ������ ������
    private AudioSource audioSource; // �������� ��������������� �����
    private GameObject ball; // ���������� ��� ��������� �������������� �������

    public void Start()
    {
        audioSource = GetComponent<AudioSource>(); // �������� ��������� ��� ��������������� �����
    }
    private void OnCollisionEnter(Collision collision) // ������� ����������� ��� ��������������� ���� ��������
    {
        if(collision.collider.tag == "Ball") // ���� ���������� ������ ����� ��� Ball
        {
            ball = collision.collider.gameObject; // ��������� ���������� �� �������
            if (CheckThrow.PlayerThrow == true) // ���� ������ �����
            {
                if (PlayerScore < 30) // ���� ������ 30
                {
                    PlayerScore += 3; // ����������� �� ��� � ������������� ���� ������������ ���� � ������
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                }
                else if (PlayerScore >= 30 && PlayerScore < 33) // ���� ������ 30, �� ������ 33
                {
                    PlayerScore++; // ����������� �� ���� � ������������� ���� ������������ ���� � ������
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                }
                if (PlayerScore > 32) // ���� ������ 32
                {
                    WinCanvas.SetActive(true); // ���������� ����� ������ � ������������� ���� ������
                    audioSource.PlayOneShot(Goals[2]);
                }
                PlayerScoreText.text = "�����: " + PlayerScore.ToString(); // ����������� ����, ����� ����� ��� �����
                ball.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // ����� ������� ���� ���������� � �������� �������
                collision.rigidbody.isKinematic = true; // ��������� ���������� ����
            }
            else // ���� ������ ��������(���)
            {
                if (EnemyScore < 30) // ���� ������ 30
                {
                    EnemyScore += 3; // ����������� �� ��� � ������������� ���� ������������ ���� � ������
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                    ball.GetComponent<Rigidbody>().isKinematic = false; // ��������� ������ ����, ���� �� �����
                    ball.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // ������������ ���� � ���� (������ ����)
                }
                else if (EnemyScore >= 30 && EnemyScore < 33) // ���� ������ 30, �� ������ 33
                {
                    EnemyScore++; // ����������� �� ���� � ������������� ���� ������������ ���� � ������
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                    ball.GetComponent<Rigidbody>().isKinematic = false; // ��������� ������ ����, ���� �� �����
                    ball.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // ������������ ���� � ���� (������ ����)
                }
                if (EnemyScore > 32) // ���� ������ 32
                {
                    LoseCanvas.SetActive(true); // ���������� ����� ���������
                    collision.rigidbody.isKinematic = true; 
                    audioSource.PlayOneShot(Goals[3]); // ������������� ���� ���������
                }
                EnemyScoreText.text = "�����: " + EnemyScore.ToString(); // ���������� ������������ ����
                ball.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // ���������� ��� �� �������� �������
            }
        }
    }
}