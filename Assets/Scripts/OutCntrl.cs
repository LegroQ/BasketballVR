using UnityEngine;

public class OutCntrl : MonoBehaviour
{
    public EnemyThrow enemyThrow; // Взаимодействие с другим скриптом
    private void OnCollisionEnter(Collision collision)
    {
        if(enemyThrow.PlayerThrow == false && collision.gameObject.tag == "Ball") // Если бросал бот
        {
            enemyThrow.PlayerThrow = true; // Контроль, чей бросок
            collision.gameObject.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // Возвращаем мяч в стандартную позицию
        }
        else if(enemyThrow.PlayerThrow == true && collision.gameObject.tag == "Ball") // Если бросал игрок
        {
            enemyThrow.PlayerThrow = false; // Контроль, чей бросок
            collision.gameObject.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // Возвращаем мяч в стандартную позицию
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false; // Физичный мяч
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // Бросок
        }
    }
}