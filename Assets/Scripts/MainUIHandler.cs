using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{

    [SerializeField] private Text bestScoreText;

    private void Awake()
    {
        UpdateBestScoreText();
    }

    public void UpdateBestScoreText()
    {
        DataManager.Instance.LoadHighScore();
        bestScoreText.text = "Best score -> " + DataManager.Instance.highScore.playerName + ": " + DataManager.Instance.highScore.playerScore;
    }

}
