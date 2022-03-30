using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    public bool PlayerThrow = true; // Бросает первым игрок
    private GameObject ball;
    public float BallVelocity = 20f; // Скорость полёта мяча
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball") // Если пола коснулся мяч
        {
            ball = collision.collider.gameObject;
            PlayerThrow = !PlayerThrow; // Следующим бросать должен бот
            if(PlayerThrow == false) // Проверка, чей бросок
            {
                ball.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // Возвращаем мяч в стандартную позицию
                ball.GetComponent<Rigidbody>().isKinematic = false; // Делаем мяч физичным
                ball.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // Придаём мячу силу в нужных направлениях
            }
        }
    }
}