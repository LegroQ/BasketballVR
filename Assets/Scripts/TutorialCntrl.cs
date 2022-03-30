using UnityEngine;

public class TutorialCntrl : MonoBehaviour
{
    public GameObject TutorialCanvas; // Текст с обучалкой
    private bool ChangeValue = false; // Видимость текста
    public void ShowTutorialText()
    {
        TutorialCanvas.SetActive(!ChangeValue); // Показать текст
        ChangeValue = !ChangeValue;
    }
}