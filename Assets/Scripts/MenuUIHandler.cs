using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;

    public void StartButton()
    {
        if (nameInputField.text.Length > 0)
        {
            DataManager.Instance.playerName = nameInputField.text;
        }
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
