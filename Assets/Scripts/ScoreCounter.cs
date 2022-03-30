using UnityEngine;
using UnityEngine.UI; // Библиотека для взаимодействия с интерфейсом

public class ScoreCounter : MonoBehaviour
{
    public EnemyThrow CheckThrow; // Получаем переменные из скрипта EnemyThrow
    public Text PlayerScoreText; // Текст счёта игрока
    public Text EnemyScoreText; // Текст счёта соперника
    public int PlayerScore = 0; // Счёт игрока
    public int EnemyScore = 0; // Счёт соперника
    public GameObject WinCanvas; // Экран победы
    public GameObject LoseCanvas; // Экран поражения
    public AudioClip[] Goals; // Массив звуков
    private AudioSource audioSource; // Источник воспроизведения звука
    private GameObject ball; // Переменная для получения соприкосаемого объекта

    public void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Получаем компонент для воспроизведения звука
    }
    private void OnCollisionEnter(Collision collision) // Функция срабатывает при соприкосновении двух объектов
    {
        if(collision.collider.tag == "Ball") // Если касающийся объект имеет тэг Ball
        {
            ball = collision.collider.gameObject; // Сохраняем информацию об объекте
            if (CheckThrow.PlayerThrow == true) // Если бросал игрок
            {
                if (PlayerScore < 30) // Счёт меньше 30
                {
                    PlayerScore += 3; // Увеличиваем на три и воспроизводим звук забрасывания мяча в кольцо
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                }
                else if (PlayerScore >= 30 && PlayerScore < 33) // Счёт больше 30, но меньше 33
                {
                    PlayerScore++; // Увеличиваем на один и воспроизводим звук забрасывания мяча в кольцо
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                }
                if (PlayerScore > 32) // Счёт больше 32
                {
                    WinCanvas.SetActive(true); // Показываем экран победы и воспроизводим звук победы
                    audioSource.PlayOneShot(Goals[2]);
                }
                PlayerScoreText.text = "Игрок: " + PlayerScore.ToString(); // Увеличиваем счёт, чтобы игрок это видел
                ball.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // После заброса мяча перемещаем в исходную позицию
                collision.rigidbody.isKinematic = true; // Отключаем физичность мяча
            }
            else // Если бросал соперник(бот)
            {
                if (EnemyScore < 30) // Счёт меньше 30
                {
                    EnemyScore += 3; // Увеличиваем на три и воспроизводим звук забрасывания мяча в кольцо
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                    ball.GetComponent<Rigidbody>().isKinematic = false; // Повторный бросок бота, если он забил
                    ball.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // Прикладываем силу к мячу (бросок бота)
                }
                else if (EnemyScore >= 30 && EnemyScore < 33) // Счёт больше 30, но меньше 33
                {
                    EnemyScore++; // Увеличиваем на один и воспроизводим звук забрасывания мяча в кольцо
                    audioSource.PlayOneShot(Goals[Random.Range(0, Goals.Length - 2)]);
                    ball.GetComponent<Rigidbody>().isKinematic = false; // Повторный бросок бота, если он забил
                    ball.GetComponent<Rigidbody>().AddForce(Random.Range(-20f, 20f), Random.Range(570f, 600f), Random.Range(770f, 800f)); // Прикладываем силу к мячу (бросок бота)
                }
                if (EnemyScore > 32) // Счёт больше 32
                {
                    LoseCanvas.SetActive(true); // Показываем экран поражения
                    collision.rigidbody.isKinematic = true; 
                    audioSource.PlayOneShot(Goals[3]); // Воспроизводим звук поражения
                }
                EnemyScoreText.text = "Робот: " + EnemyScore.ToString(); // Показываем пользователю счёт
                ball.transform.position = new Vector3(0.004f, 1.046f, 2.853f); // Возвращаем мяч на исходную позицию
            }
        }
    }
}