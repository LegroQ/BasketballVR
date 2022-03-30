using UnityEngine;

public class ReloadBtn : MonoBehaviour
{
    public ScoreCounter ReloadScore;
    public GameObject TutorialCanvas;
    private bool ChangeValue = false;
    public GameObject WinnerCanvas;
    public GameObject LoseCanvas;
    public GameObject Ball;
    public void PlayAgain()
    {
        WinnerCanvas.SetActive(false);
        LoseCanvas.SetActive(false);
        ReloadScore.PlayerScore -= ReloadScore.PlayerScore;
        ReloadScore.EnemyScore -= ReloadScore.EnemyScore;
        ReloadScore.PlayerScoreText.text = "Игрок: " + ReloadScore.PlayerScore.ToString();
        ReloadScore.EnemyScoreText.text = "Робот: " + ReloadScore.EnemyScore.ToString();
        Ball.transform.position = new Vector3(0.004f, 1.046f, 2.853f);
    }
}
