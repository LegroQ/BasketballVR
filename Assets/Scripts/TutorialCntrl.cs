using UnityEngine;

public class TutorialCntrl : MonoBehaviour
{
    public GameObject TutorialCanvas; // ����� � ���������
    private bool ChangeValue = false; // ��������� ������
    public void ShowTutorialText()
    {
        TutorialCanvas.SetActive(!ChangeValue); // �������� �����
        ChangeValue = !ChangeValue;
    }
}